using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using System.IO;
using System.Reflection;

namespace VRCAT.CustomModalWindow
{
    //public class ProjectSettingViewModel : BindableBase
    //{
    //    ObservableCollection<string> _ExistProjects;
    //    public ObservableCollection<string> ExistProjects
    //    {
    //        get
    //        {
    //            if (_ExistProjects == null)
    //                _ExistProjects = new ObservableCollection<string>();
    //            return _ExistProjects;
    //        }
    //        set { _ExistProjects = value; }
    //    }

    //    private string _DirectorySource;
    //    public string DirectorySource 
    //    {
    //        get { return _DirectorySource; }
    //        set { SetProperty(ref _DirectorySource, value); }
    //    }
    //    ObservableCollection<PackageModel> packagesList;
    //    public ObservableCollection<PackageModel> PackagesList
    //    {
    //        get 
    //        {
    //            if (packagesList == null)
    //                packagesList = new ObservableCollection<PackageModel>();
    //            return packagesList; 
    //        }
    //        set { packagesList = value; }
    //    }

    //    public ProjectSettingViewModel()
    //    {
    //        string RootDir = Directory.GetCurrentDirectory();
    //        string ProjectBHFilePath = RootDir + "\\VRCAT.Project.bh";
    //        if(File.Exists(ProjectBHFilePath))
    //        {
    //            using (StreamReader r = new StreamReader(ProjectBHFilePath))
    //            {
    //                string line;
    //                while ((line = r.ReadLine()) != null)
    //                {
    //                    string[] OneLineData = line.Split(new char[] { ',' });
    //                    ExistProjects.Add(OneLineData[0]);
    //                }
    //            }
    //        }

    //        string PluginPath = RootDir + "\\Plugins";
    //        string[] PluginFilePath = Directory.GetFiles(PluginPath, "*.dll", SearchOption.AllDirectories);
    //        foreach (string dll in PluginFilePath)
    //        {
    //            System.Reflection.Assembly asmInfo = GetAssemblyDLL(dll);
    //            string description = "";
    //            if (asmInfo != null)
    //            {
    //                AssemblyDescriptionAttribute adAttr = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(asmInfo, typeof(AssemblyDescriptionAttribute));
    //                description = adAttr.Description;
    //            }
    //            string name = dll.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries).Last();
    //            PackageModel pL = new PackageModel() { HeaderTitle = name, Description = description, PackagePath = dll };
    //            PackagesList.Add(pL);
    //        }
    //    }
    //    public static System.Reflection.Assembly GetAssemblyDLL(string pAssemblyNameDLL)
    //    {
    //        System.Reflection.Assembly tMyAssembly = null;

    //        if (string.IsNullOrEmpty(pAssemblyNameDLL)) { return tMyAssembly; }
    //        try //try #a
    //        {
    //            if (!pAssemblyNameDLL.ToLower().EndsWith(".dll")) { pAssemblyNameDLL += ".dll"; }
    //            tMyAssembly = System.Reflection.Assembly.LoadFrom(pAssemblyNameDLL);
    //        }// try #a
    //        catch (Exception ex)
    //        {
    //            string m = ex.Message;
    //        }// try #a
    //        return tMyAssembly;
    //    }
    //}
    //public class PackageModel
    //{
    //    public string HeaderTitle { get; set; }
    //    public string Description { get; set; }
    //    public string PackagePath { get; set; }
    //}
}
