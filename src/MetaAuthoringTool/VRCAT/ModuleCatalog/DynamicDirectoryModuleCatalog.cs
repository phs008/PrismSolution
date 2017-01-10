using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using VRCAT.Infrastructure;

namespace VRCAT
{
    /// <summary>
    /// Dynamic Direcotry 모듈 로딩 Class
    /// </summary>
    public class DynamicDirectoryModuleCatalog : ModuleCatalog
    {
        private LoadingAnimation animationWindow = null;
        private Thread StatusThread = null;
        SynchronizationContext _context;

        public string ModulePath { get; set; }
        /// <summary>
        /// 생성자
        /// </summary>
        /// <remarks>Dynamic 모듈 로딩 대해 동기화 모델 처리</remarks>
        /// <param name="modulePath"></param>
        public DynamicDirectoryModuleCatalog(string modulePath)
        {
            _context = SynchronizationContext.Current;
            ModulePath = modulePath;


            /// TODO : Dynamic Module Load 에 대한 FilesystemWatcher 임시 사용 중지
            //FileSystemWatcher fileWatcher = new FileSystemWatcher(ModulePath, "*.dll");
            //fileWatcher.Created += fileWatcher_Created;
            //fileWatcher.EnableRaisingEvents = true;
        }

        void fileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                LoadModuleCatalog(e.FullPath, true);
            }
        }
        /// <summary>
        /// Drives the main logic of building the child domain and searching for the assemblies.
        /// </summary>
        protected override void InnerLoad()
        {
            //LoadModuleCatalog(ModulePath);
            this.StatusThread = new Thread(() =>
            {
                try
                {
                    this.animationWindow = new LoadingAnimation();
                    this.animationWindow.Show();
                    this.animationWindow.Closed += (sender, le) =>
                    {
                        this.animationWindow.Dispatcher.InvokeShutdown();
                        this.animationWindow = null;
                        this.StatusThread = null;
                    };
                    System.Windows.Threading.Dispatcher.Run();
                }
                catch (Exception ex) { }
            });
            this.StatusThread.SetApartmentState(ApartmentState.STA);
            this.StatusThread.Priority = ThreadPriority.Normal;
            this.StatusThread.Start();
            BaseModuleCatalog();
            PlugInModuleCatalog();
            if (this.animationWindow != null)
                this.animationWindow.Dispatcher.BeginInvoke(new Action(() =>
                {
                    this.animationWindow.Close();
                }));
        }

        /// <summary>
        /// 처음 생성할때 기본 모듈 및 BaseModule 있는 모든 Dll 을 불러온다.
        /// </summary>
        void BaseModuleCatalog()
        {
            AppDomain childDomain = this.BuildChildDomain(AppDomain.CurrentDomain);
            try
            {
                List<string> loadedAssemblies = new List<string>();
                var assemblies = (
                                     from Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     where !(assembly is System.Reflection.Emit.AssemblyBuilder)
                                        && assembly.GetType().FullName != "System.Reflection.Emit.InternalAssemblyBuilder"
                                        && !String.IsNullOrEmpty(assembly.Location)
                                     select assembly.Location
                                 );

                loadedAssemblies.AddRange(assemblies);
                Type loaderType = typeof(InnerModuleInfoLoader);
                if (loaderType.Assembly != null)
                {
                    var loader = (InnerModuleInfoLoader)childDomain.CreateInstanceFrom(loaderType.Assembly.Location, loaderType.FullName).Unwrap();
                    loader.LoadAssemblies(loadedAssemblies);
                    string BaseModulePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "BaseModule/");
                    ModuleInfo[] modules = loader.GetModuleInfos(BaseModulePath, false);
                    this.Items.AddRange(modules);
                    LoadModules(modules);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                AppDomain.Unload(childDomain);
            }
        }

        /// <summary>
        /// 프로젝트 폴더 마다 존재하는 ProjectSettings 폴더 하위에 있는 VRCAT.Module.xa 파일에 있는 해당 SW 에서 사용할 PlugInModule 종류를 확인하고 로딩한다.
        /// </summary>
        void PlugInModuleCatalog()
        {
            string ProgramInstallDir = Directory.GetCurrentDirectory();
            List<string> loadPlugInPathList = new List<string>();
            using (StreamReader sr = new StreamReader(DataModel.VRWorld.Instance.ProjectSettingsDir + "VRCAT.Module.xa"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    loadPlugInPathList.Add(ProgramInstallDir + "/Plugins/" + line);
                }
            }
            foreach (var LoadpluginFile in loadPlugInPathList)
            {
                if (File.Exists(LoadpluginFile))
                {
                    LoadModuleCatalog(LoadpluginFile, true);
                }
            }
        }

        void LoadModuleCatalog(string path, bool isFile = false)
        {
            if (string.IsNullOrEmpty(path))
                throw new InvalidOperationException("Path cannot be null.");

            if (isFile)
            {
                if (!File.Exists(path))
                    throw new InvalidOperationException(string.Format("File {0} could not be found.", path));
            }
            else
            {
                if (!Directory.Exists(path))
                    throw new InvalidOperationException(string.Format("Directory {0} could not be found.", path));
            }

            AppDomain childDomain = this.BuildChildDomain(AppDomain.CurrentDomain);

            try
            {
                List<string> loadedAssemblies = new List<string>();

                var assemblies = (
                                     from Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()
                                     where !(assembly is System.Reflection.Emit.AssemblyBuilder)
                                        && assembly.GetType().FullName != "System.Reflection.Emit.InternalAssemblyBuilder"
                                        && !String.IsNullOrEmpty(assembly.Location)
                                     select assembly.Location
                                 );

                loadedAssemblies.AddRange(assemblies);

                Type loaderType = typeof(InnerModuleInfoLoader);
                if (loaderType.Assembly != null)
                {
                    var loader = (InnerModuleInfoLoader)childDomain.CreateInstanceFrom(loaderType.Assembly.Location, loaderType.FullName).Unwrap();
                    loader.LoadAssemblies(loadedAssemblies);

                    //get all the ModuleInfos
                    ModuleInfo[] modules = loader.GetModuleInfos(path, isFile);

                    //add modules to catalog
                    this.Items.AddRange(modules);

                    //we are dealing with a file from our file watcher, so let's notify that it needs to be loaded
                    if (isFile)
                    {
                        LoadModules(modules);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                AppDomain.Unload(childDomain);
            }
        }

        /// <summary>
        /// Uses the IModuleManager to load the modules into memory
        /// </summary>
        /// <param name="modules"></param>
        private void LoadModules(ModuleInfo[] modules)
        {
            IModuleManager manager = ServiceLocator.Current.GetInstance<IModuleManager>();
            //if (_context == null)
            //    return;

            //_context.Send(new SendOrPostCallback(delegate (object state)
            //{
            //    foreach (var module in modules)
            //    {
            //        ///Loger.SetLog.Info(module.ModuleName + " is now Loaded");
            //        manager.LoadModule(module.ModuleName);
            //    }
            //}), null);
            foreach (var module in modules)
            {
                ///Loger.SetLog.Info(module.ModuleName + " is now Loaded");
                manager.LoadModule(module.ModuleName);
            }
        }

        /// <summary>
        /// Creates a new child domain and copies the evidence from a parent domain.
        /// </summary>
        /// <param name="parentDomain">The parent domain.</param>
        /// <returns>The new child domain.</returns>
        /// <remarks>
        /// Grabs the <paramref name="parentDomain"/> evidence and uses it to construct the new
        /// <see cref="AppDomain"/> because in a ClickOnce execution environment, creating an
        /// <see cref="AppDomain"/> will by default pick up the partial trust environment of 
        /// the AppLaunch.exe, which was the root executable. The AppLaunch.exe does a 
        /// create domain and applies the evidence from the ClickOnce manifests to 
        /// create the domain that the application is actually executing in. This will 
        /// need to be Full Trust for Composite Application Library applications.
        /// </remarks>
        /// <exception cref="ArgumentNullException">An <see cref="ArgumentNullException"/> is thrown if <paramref name="parentDomain"/> is null.</exception>
        protected virtual AppDomain BuildChildDomain(AppDomain parentDomain)
        {
            if (parentDomain == null) throw new System.ArgumentNullException("parentDomain");

            Evidence evidence = new Evidence(parentDomain.Evidence);
            AppDomainSetup setup = parentDomain.SetupInformation;
            return AppDomain.CreateDomain("DiscoveryRegion", evidence, setup);
        }


        private class InnerModuleInfoLoader : MarshalByRefObject
        {

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
            internal ModuleInfo[] GetModuleInfos(string path, bool isFile = false)
            {
                Assembly moduleReflectionOnlyAssembly =
                    AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies().First(
                        asm => asm.FullName == typeof(IModule).Assembly.FullName);

                Type IModuleType = moduleReflectionOnlyAssembly.GetType(typeof(IModule).FullName);

                FileSystemInfo info = null;
                if (isFile)
                    info = new FileInfo(path);
                else
                    info = new DirectoryInfo(path);


                ResolveEventHandler resolveEventHandler = delegate(object sender, ResolveEventArgs args) { return OnReflectionOnlyResolve(args, info); };
                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += resolveEventHandler;
                IEnumerable<ModuleInfo> modules = GetNotAllreadyLoadedModuleInfos(info, IModuleType);
                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve -= resolveEventHandler;

                return modules.ToArray();
            }

            private static IEnumerable<ModuleInfo> GetNotAllreadyLoadedModuleInfos(FileSystemInfo info, Type IModuleType)
            {
                List<FileInfo> validAssemblies = new List<FileInfo>();
                Assembly[] alreadyLoadedAssemblies = AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies();

                FileInfo fileInfo = info as FileInfo;
                if (fileInfo != null)
                {
                    if (alreadyLoadedAssemblies.FirstOrDefault(assembly => String.Compare(Path.GetFileName(assembly.Location), fileInfo.Name, StringComparison.OrdinalIgnoreCase) == 0) == null)
                    {
                        var moduleInfos = Assembly.ReflectionOnlyLoadFrom(fileInfo.FullName).GetExportedTypes()
                        .Where(IModuleType.IsAssignableFrom)
                        .Where(t => t != IModuleType)
                        .Where(t => !t.IsAbstract).Select(t => CreateModuleInfo(t));

                        return moduleInfos;
                    }
                }

                DirectoryInfo directory = info as DirectoryInfo;

                var files = directory.GetFiles("*.dll").Where(file => alreadyLoadedAssemblies.
                    FirstOrDefault(assembly => String.Compare(Path.GetFileName(assembly.Location), file.Name, StringComparison.OrdinalIgnoreCase) == 0) == null);

                foreach (FileInfo file in files)
                {
                    try
                    {
                        Assembly asem = Assembly.ReflectionOnlyLoadFrom(file.FullName);
                        asem.GetExportedTypes();
                        validAssemblies.Add(file);
                    }
                    catch (BadImageFormatException)
                    {
                        // skip non-.NET Dlls
                    }
                }

                return validAssemblies.SelectMany(file => Assembly.ReflectionOnlyLoadFrom(file.FullName)
                                            .GetExportedTypes()
                                            .Where(IModuleType.IsAssignableFrom)
                                            .Where(t => t != IModuleType)
                                            .Where(t => !t.IsAbstract)
                                            .Select(type => CreateModuleInfo(type)));
            }


            private static Assembly OnReflectionOnlyResolve(ResolveEventArgs args, FileSystemInfo info)
            {
                Assembly loadedAssembly = AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies().FirstOrDefault(
                    asm => string.Equals(asm.FullName, args.Name, StringComparison.OrdinalIgnoreCase));
                if (loadedAssembly != null)
                {
                    return loadedAssembly;
                }

                DirectoryInfo directory = info as DirectoryInfo;
                if (directory != null)
                {
                    AssemblyName assemblyName = new AssemblyName(args.Name);
                    string dependentAssemblyFilename = Path.Combine(directory.FullName, assemblyName.Name + ".dll");
                    if (File.Exists(dependentAssemblyFilename))
                    {
                        return Assembly.ReflectionOnlyLoadFrom(dependentAssemblyFilename);
                    }
                }
                return Assembly.ReflectionOnlyLoad(args.Name);
            }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
            internal void LoadAssemblies(IEnumerable<string> assemblies)
            {
                foreach (string assemblyPath in assemblies)
                {
                    try
                    {
                        Assembly.ReflectionOnlyLoadFrom(assemblyPath);
                    }
                    catch (FileNotFoundException)
                    {
                        // Continue loading assemblies even if an assembly can not be loaded in the new AppDomain
                    }
                }
            }

            private static ModuleInfo CreateModuleInfo(Type type)
            {
                string moduleName = type.Name;
                List<string> dependsOn = new List<string>();
                bool onDemand = false;
                var moduleAttribute = CustomAttributeData.GetCustomAttributes(type).FirstOrDefault(cad => cad.Constructor.DeclaringType.FullName == typeof(ModuleAttribute).FullName);

                if (moduleAttribute != null)
                {
                    foreach (CustomAttributeNamedArgument argument in moduleAttribute.NamedArguments)
                    {
                        string argumentName = argument.MemberInfo.Name;
                        switch (argumentName)
                        {
                            case "ModuleName":
                                moduleName = (string)argument.TypedValue.Value;
                                break;

                            case "OnDemand":
                                onDemand = (bool)argument.TypedValue.Value;
                                break;

                            case "StartupLoaded":
                                onDemand = !((bool)argument.TypedValue.Value);
                                break;
                        }
                    }
                }

                var moduleDependencyAttributes = CustomAttributeData.GetCustomAttributes(type).Where(cad => cad.Constructor.DeclaringType.FullName == typeof(ModuleDependencyAttribute).FullName);
                foreach (CustomAttributeData cad in moduleDependencyAttributes)
                {
                    dependsOn.Add((string)cad.ConstructorArguments[0].Value);
                }

                ModuleInfo moduleInfo = new ModuleInfo(moduleName, type.AssemblyQualifiedName)
                {
                    InitializationMode =
                        onDemand
                            ? InitializationMode.OnDemand
                            : InitializationMode.WhenAvailable,
                    Ref = type.Assembly.CodeBase,
                };
                moduleInfo.DependsOn.AddRange(dependsOn);
                return moduleInfo;
            }
        }

    }

    /// <summary>
    /// Class that provides extension methods to Collection
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Add a range of items to a collection.
        /// </summary>
        /// <typeparam name="T">Type of objects within the collection.</typeparam>
        /// <param name="collection">The collection to add items to.</param>
        /// <param name="items">The items to add to the collection.</param>
        /// <returns>The collection.</returns>
        /// <exception cref="System.ArgumentNullException">An <see cref="System.ArgumentNullException"/> is thrown if <paramref name="collection"/> or <paramref name="items"/> is <see langword="null"/>.</exception>
        public static Collection<T> AddRange<T>(this Collection<T> collection, IEnumerable<T> items)
        {
            if (collection == null) throw new System.ArgumentNullException("collection");
            if (items == null) throw new System.ArgumentNullException("items");

            foreach (var each in items)
            {
                collection.Add(each);
            }

            return collection;
        }
    }
}
