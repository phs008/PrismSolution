using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using VRCAT.DataModel;
using VRCAT.DataModel.Event;
using VRCAT.Infrastructure;
using VRCAT.Infrastructure.DragDrop;
using System.Linq;
using System.Windows.Input;
using WPFXCommand;
using System.Windows.Threading;
using System.Windows.Data;

namespace VRCAT.AssetModule
{
    /// <summary>
    /// [사용안함]
    /// </summary>
    public class StaticViewClass
    {
        static AddMaterialUI _Instance = new AddMaterialUI() { Owner = Application.Current.MainWindow, DataContext = new AddMaterialUIVM() };
        public static AddMaterialUI Instance
        {
            get { return _Instance; }
        }
    }
    /// <summary>
    /// AssetView - ViewModel class
    /// </summary>
    public class AssetViewModel : BindableBase
    {
        string SelectDirecotryPath = string.Empty;
        string AssetRootPath = string.Empty;
        AssetDirecotryWatcher DirWatcher;
        AssetDirecotryWatcher FileWatcher;
        VRWorld World;
        ICommand _KeyDownCommand;
        /// <summary>
        /// AssetView KeyDown BindingCommand
        /// </summary>
        public ICommand KeyDownCommand
        {
            get
            {
                if (_KeyDownCommand == null)
                    _KeyDownCommand = new RelayCommand(DirectoryAssetKeyDownExecute, DirectoryAssetKeyDownCanExecute);
                return _KeyDownCommand;
            }
        }
        /// <summary>
        /// AssetView KeyDown CanExecute Handler
        /// </summary>
        private bool DirectoryAssetKeyDownCanExecute(object obj)
        {
            if (((KeyEventArgs)obj).Key == Key.F2)
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// AssetView KeyDown Execute Handler
        /// </summary>
        private void DirectoryAssetKeyDownExecute(object obj)
        {
            DirectoryModel dm = (DirectoryModel)obj;
            if(!dm.DirectoryFullPath.Equals(VRWorld.Instance.WorkingDir))
            {
                dm.IsEditMode = true;
            }
        }
        /// <summary>
        /// Direcotry 선택변경시 발생 이벤트 Handler
        /// </summary>
        public DelegateCommand<RoutedPropertyChangedEventArgs<object>> DirectorySelect { get; private set; }

        ICommand _DeleteItemCommand;
        /// <summary>
        /// AssetView Delete Binding Command
        /// </summary>
        public ICommand DeleteItemCommand
        {
            get 
            {
                if (_DeleteItemCommand == null)
                    _DeleteItemCommand = new RelayCommand(DeleteItemCommandExecute, DeleteItemCommandCanExecute);
                return _DeleteItemCommand; 
            }
        }
        /// <summary>
        /// AssetView Delete CanExecute Handler
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool DeleteItemCommandCanExecute(object obj)
        {
            return true;
        }
        /// <summary>
        /// AssetView Delete Execute Handler 
        /// </summary>
        /// <param name="obj"></param>
        private void DeleteItemCommandExecute(object obj)
        {
            
        }
        
        ICommand _OpenExplorerCommand;
        /// <summary>
        /// AssetView 탐색기 열기 Binding Command
        /// </summary>
        public ICommand OpenExplorerCommand
        {
            get
            {
                if (_OpenExplorerCommand == null)
                    _OpenExplorerCommand = new RelayCommand(OpenExplorerCommandExecute, OpenExplorerCommandCanExecute);
                return _OpenExplorerCommand;
            }
        }
        private bool OpenExplorerCommandCanExecute(object obj)
        {
            return true;
        }
        private void OpenExplorerCommandExecute(object obj)
        {
            if(!String.IsNullOrEmpty(SelectDirecotryPath))
            {
                string DirPath = "/e,/root," + '"' + SelectDirecotryPath + '"';
                DirPath = DirPath.Replace("/", "\\");
                System.Diagnostics.Process.Start("explorer.exe", DirPath);
            }
        }

        MTObservableCollection<DirectoryModel> _DirectoryItem;
        /// <summary>
        /// DirectoryModel Collection
        /// </summary>
        public MTObservableCollection<DirectoryModel> DirectoryItem
        {
            get
            {
                if (_DirectoryItem == null)
                    _DirectoryItem = new MTObservableCollection<DirectoryModel>();
                return _DirectoryItem;
            }
            set { SetProperty(ref _DirectoryItem, value); }
        }

        FileInfoVM _FileInfoItem;
        /// <summary>
        /// Directory Tree 에서 선택된 파일들 용 ViewModel
        /// </summary>
        public FileInfoVM FileInfoItem
        {
            get { return _FileInfoItem; }
            set 
            {
                //GC.Collect();
                SetProperty(ref _FileInfoItem, value); 
            }
        }
        /// <summary>
        /// 생성자
        /// </summary>
        public AssetViewModel()
        {
            World = VRWorld.Instance;
            /// Directory Select Command
            DirectorySelect = new DelegateCommand<RoutedPropertyChangedEventArgs<object>>(delegate(RoutedPropertyChangedEventArgs<object> obj)
                {
                    if (obj.OldValue != obj.NewValue)
                    {
                        FileInfoItem = new FileInfoVM();
                        FileInfoItem.FolderPath = (obj.NewValue as DirectoryModel).DirectoryFullPath;
                        foreach(FileModel fM in (obj.NewValue as DirectoryModel).SubFiles)
                        {
                            Guid uuid = VRWorld.Instance.GuidAssetMap[fM.FullPath];
                            MetaBase meta = VRWorld.Instance.MetaMap[uuid];
                            FileInfoItem.FileVM.Add(new TemporaryFileVM() { FileModel = fM, MetaModel = meta });
                        }
                        SelectDirecotryPath = (obj.NewValue as DirectoryModel).DirectoryFullPath;
                    }
                });
            //Thread ThreadGetAssetFolder = new Thread(new ParameterizedThreadStart(InitializeDirectory));
            
            
            ///이벤트 에 대한 Subscribe 처리
            AssetRootPath = VRCAT.DataModel.VRWorld.Instance.WorkingDir + "/";

            if (Directory.Exists(AssetRootPath))
            {
                DirWatcher = new AssetDirecotryWatcher(AssetRootPath);
                DirWatcher.EnableRaisingEvents = true;
                DirWatcher.IncludeSubdirectories = true;
                DirWatcher.NotifyFilter = NotifyFilters.DirectoryName;
                DirWatcher.Created += DirWatcher_Created;
                DirWatcher.Deleted += DirWatcher_Deleted;
                DirWatcher.Renamed += DirWatcher_Renamed;

                FileWatcher = new AssetDirecotryWatcher(AssetRootPath);
                FileWatcher.EnableRaisingEvents = true;
                FileWatcher.IncludeSubdirectories = true;
                FileWatcher.NotifyFilter = NotifyFilters.FileName;
                FileWatcher.Created += FileWatcher_Created;
                FileWatcher.Deleted += FileWatcher_Deleted;
                FileWatcher.Renamed += FileWatcher_Renamed;
                /// Project Root 폴더 기반 기본 Asset 구성 
                //ThreadGetAssetFolder.Start(AssetRootPath);
                InitializeDirectory(AssetRootPath);
            }
            else
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish("Asset 폴더 경로가 존재하지 않습니다 확인후 다시 시작해주세요");
        }

        #region File Create , Rename , Delete 
        /// <summary>
        /// 윈도우 탐색기 내에서 File 생성,이동 Watcher
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">FileSystemEventArgs</param>
        void FileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (File.Exists(e.FullPath))
            {
                string GenerateFullPath = VRWorld.Instance.WorkingDir + "/" + e.Name;
                GenerateFullPath = GenerateFullPath.Replace("\\", "/");
                string name = Path.GetFileNameWithoutExtension(GenerateFullPath);
                string fileName = Path.GetFileName(GenerateFullPath);
                string extensionName = Path.GetExtension(GenerateFullPath);
                FileAttributes fileAttr = File.GetAttributes(GenerateFullPath);
                if (!fileAttr.HasFlag(FileAttributes.Hidden))
                {
                    string GeneratePathFolder = GenerateFullPath.Replace(fileName, "");
                    string FindParentPath = GeneratePathFolder.Remove(GeneratePathFolder.Count() - 1, 1);
                    var ParentDirModel = FindParentDM(DirectoryItem[0], FindParentPath);
                    if (ParentDirModel != null)
                    {
                        extensionName = extensionName.Remove(0, 1);
                        
                        //FileModel fileModel = new FileModel(name, GenerateFullPath, fileName, extensionName, GeneratePathFolder);
                        //ParentDirModel.SubFiles.Add(fileModel);
                        ///Thread Safe 하게 처리되어있음
                        FileInfoItem.AddNewItem(ParentDirModel, name, GenerateFullPath, fileName, extensionName, GeneratePathFolder);
                    }
                }
            }
        }
        /// <summary>
        /// 윈도우 탐색기 내에서 File 이름변경 Watcher
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">RenamedEventArgs</param>
        void FileWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            string FolderPath = Path.GetDirectoryName(e.OldFullPath);
            string FileName = Path.GetFileName(e.OldFullPath);
            FolderPath = FolderPath.Replace("\\", "/");
            var ParentDirModel = FindParentDM(DirectoryItem[0], FolderPath);
            if (ParentDirModel != null)
            {
                FileModel renameFM = ParentDirModel.SubFiles.Where(a => a.FileName.Equals(FileName)).FirstOrDefault();
                ///윈도우 탐색기에서 이름 변경시 renameFM is not null
                if (renameFM != null)
                {
                    ///Meta 파일 찾는 과정
                    Guid g = VRWorld.Instance.GuidAssetMap[FileName];
                    MetaBase meta = VRWorld.Instance.MetaMap[g];

                    string ReplaceName = e.Name.Replace("\\", "/");
                    string ReplaceFullPath = e.FullPath.Replace(e.Name, ReplaceName);
                    ReplaceFullPath = ReplaceFullPath.Replace("\\", "");
                    string reFileName = Path.GetFileName(ReplaceFullPath);
                    string reExtenstion = Path.GetExtension(reFileName).Remove(0, 1);
                    /// FileFullPath 를 먼저 변경해야 한다. 
                    renameFM.FullPath = ReplaceFullPath;
                    /// FileName 은 내부적으로 이름 변경시 Path 에 따라 이동처리되는 코드가 존재함.
                    renameFM.Name = Path.GetFileNameWithoutExtension(ReplaceFullPath);
                    renameFM.FileName = reFileName;
                    renameFM.FileExtension = reExtenstion;
                    ///Meta File 정보 변경후
                    meta.OriginDataPath = renameFM.FullPath;
                    ///Meta File 저장
                    meta.Serialize();
                }
            }
        }
        /// <summary>
        /// 윈도우 탐색기 내에서 File 삭제 Watcher
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">FileSystemEventArgs</param>
        void FileWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string FolderPath = Path.GetDirectoryName(e.FullPath);
            string FileName = Path.GetFileName(e.FullPath);
            FolderPath = FolderPath.Replace("\\", "/");
            var ParentDirModel = FindParentDM(DirectoryItem[0], FolderPath);
            if(ParentDirModel != null)
            {
                FileModel removeModel = ParentDirModel.SubFiles.Where(a => a.FileName.Equals(FileName)).FirstOrDefault();
                ParentDirModel.SubFiles.Remove(removeModel);
                ///Thread Safe 하게 처리되어있음
                FileInfoItem.RemoveExistItem(removeModel);
            }
        }
        #endregion

        #region Directory Create , Rename , Delete EventHandler
        /// <summary>
        /// 윈도우 탐색기 내에서 Directory 생성,이동 Watcher
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">FileSystemEventArgs</param>
        void DirWatcher_Created(object sender, FileSystemEventArgs e)
        {
            string createPath = e.Name.Replace("\\", "/");
            createPath = e.FullPath.Replace(e.Name, createPath);
            createPath = createPath.Replace("\\", "");
            DirectoryModel subDir = new DirectoryModel(createPath, null, false);
            int lastRemovePointIDX = createPath.LastIndexOf("/");
            string parentPath = createPath.Remove(lastRemovePointIDX);
            Loger.SetLog.Debug("Create Dir : " + createPath);
            var ParentDirModel = FindParentDM(DirectoryItem[0], parentPath);
            if (ParentDirModel != null)
            {
                ParentDirModel.SubDirectorys.Add(subDir);
            }
        }
        /// <summary>
        /// 윈도우 탐색기 내에서 Directory 이름변경 Watcher
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">RenamedEventArgs</param>
        void DirWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            string renamePath = e.OldName.Replace("\\", "/");
            renamePath = e.OldFullPath.Replace(e.OldName, renamePath);
            renamePath = renamePath.Replace("\\", "");
            int lastRemovePointIDX = renamePath.LastIndexOf("/");
            string parentPath = renamePath.Remove(lastRemovePointIDX);
            var ParentDirModel = FindParentDM(DirectoryItem[0], parentPath);
            if(ParentDirModel != null)
            {
                var renameDM = ParentDirModel.SubDirectorys.Where(a => a.DirectoryFullPath.Equals(renamePath)).FirstOrDefault();
                if(renameDM != null)
                {
                    renamePath = e.Name.Replace("\\", "/");
                    renamePath = e.FullPath.Replace(e.Name, renamePath);
                    renamePath = renamePath.Replace("\\", "");
                    /// DirectoryFullPath 를 먼저 변경해야 한다. 
                    renameDM.DirectoryFullPath = renamePath;
                    /// DirectoryName 은 내부적으로 이름 변경시 Path 에 따라 이동처리되는 코드가 존재함.
                    renameDM.Name = renamePath.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries).Last();
                }
            }
        }
        /// <summary>
        /// 윈도우 탐색기 내에서 Directory 삭제 Watcher
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">FileSystemEventArgs</param>
        void DirWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string removePath = e.Name.Replace("\\", "/");
            removePath =  e.FullPath.Replace(e.Name, removePath);
            removePath = removePath.Replace("\\", "");
            int lastRemovePointIDX = removePath.LastIndexOf("/");
            string parentPath = removePath.Remove(lastRemovePointIDX);
            var ParentDirModel = FindParentDM(DirectoryItem[0], parentPath);
            Loger.SetLog.Debug("Delete Dir : " + removePath);
            if(ParentDirModel != null)
            {
                var removeDM = ParentDirModel.SubDirectorys.Where(a => a.DirectoryFullPath.Equals(removePath)).FirstOrDefault();
                if (removeDM != null)
                {
                    ParentDirModel.SubDirectorys.Remove(removeDM);
                }
            }
        }
        #endregion

        #region DirectoryModel Helper Function
        DirectoryModel FindParentDM(DirectoryModel PastDM,string FindParentPath)
        {
            DirectoryModel returnVal = null;
            if (PastDM.DirectoryFullPath.Equals(FindParentPath))
                returnVal = PastDM;
            if (returnVal == null)
            {
                foreach (var compareDM in PastDM.SubDirectorys)
                {
                    if (compareDM.DirectoryFullPath.Equals(FindParentPath))
                    {
                        returnVal = compareDM;
                        break;
                    }
                    else
                    {
                        returnVal = FindParentDM(compareDM, FindParentPath);
                        if (returnVal != null)
                            break;
                    }
                }
            }
            return returnVal;
        }
        #endregion

        /// <summary>
        /// 처음시작시 프로젝트 Asset 폴더 기반 Tree 구성
        /// </summary>
        void InitializeDirectory(object AssetRootPath)
        {
            DirectoryModel subModel = new DirectoryModel(AssetRootPath.ToString(), null);
            DirectoryItem.Add(subModel);
            
            FileInfoItem = new FileInfoVM();
            FileInfoItem.FolderPath = subModel.DirectoryFullPath;
            foreach (FileModel fM in subModel.SubFiles)
            {
                Guid uuid = VRWorld.Instance.GuidAssetMap[fM.FullPath];
                MetaBase meta = VRWorld.Instance.MetaMap[uuid];
                FileInfoItem.FileVM.Add(new TemporaryFileVM() { FileModel = fM, MetaModel = meta });
            }
        }
    }

    /// <summary>
    /// 폴더 선택시 개별적 FielViewModel
    /// </summary>
    public class FileInfoVM : BindableBase, IDropTarget
    {
        object _lock = new object();
        public FileInfoVM()
        {
            ///Binding 에 대한 MultiThread 문제를 해결해주는 방법
            BindingOperations.EnableCollectionSynchronization(FileVM, _lock);
        }
        internal void AddNewItem(DirectoryModel ParentDM, string name, string GenerateFullPath, string fileName, string extensionName, string GeneratePathFolder)
        {
            lock (_lock)
            {
                ///내부에서 MetaFile 생성함.
                FileModel fileModel = new FileModel(name, GenerateFullPath, fileName, extensionName, GeneratePathFolder);
                ParentDM.SubFiles.Add(fileModel);
                FileVM.Add(new TemporaryFileVM() { FileModel = fileModel, MetaModel = VRWorld.Instance.MetaMap[fileModel.MappingUUID] });
            }
        }
        public void RemoveExistItem(FileModel fm)
        {
            lock(_lock)
            {
                ///Meta 파일 찾는 과정
                Guid g = VRWorld.Instance.GuidAssetMap[fm.FullPath];
                MetaBase meta = VRWorld.Instance.MetaMap[g];
                ///Meta 파일을 삭제처리
                char[] metaFolder = meta.uuid.ToString().ToCharArray(0, 2);
                string folderPath = metaFolder[0].ToString() + metaFolder[1].ToString();
                string metaFileFullPath = Path.Combine(VRWorld.Instance.WorkingRootDir, "Library", folderPath, meta.uuid + ".meta");
                File.Delete(metaFileFullPath);
                ///파일 삭제후 2개 매핑Structure 에서 제거처리
                bool successMetaRemove = VRWorld.Instance.MetaMap.Remove(g);
                bool successGuidAssetRemove = VRWorld.Instance.GuidAssetMap.Remove(fm.FullPath);
                TemporaryFileVM removeItem = new TemporaryFileVM() { FileModel = fm, MetaModel = meta };
                int a = FileVM.IndexOf(removeItem);
                bool ViewVMRemove = FileVM.Remove(removeItem);
            }
        }
        ICommand _AddMaterialClick;
        /// <summary>
        /// Material 추가 Binding Command
        /// </summary>
        public ICommand AddMaterialClick
        {
            get 
            {
                if (_AddMaterialClick == null)
                    _AddMaterialClick = new RelayCommand(AddMaterialClick_Execute);
                return _AddMaterialClick; 
            }
            
        }
        ICommand _KeyDownCommand;
        /// <summary>
        /// Key Down Binding Command
        /// </summary>
        public ICommand KeyDownCommand
        {
            get
            {
                if (_KeyDownCommand == null)
                    _KeyDownCommand = new RelayCommand(FileAssetKeyDownExecute, FileAssetKeyDownCanExecute);
                return _KeyDownCommand;
            }
        }
        ICommand _SelectionChanged;
        /// <summary>
        /// ListBox Selected Item Changed Command
        /// </summary>
        public ICommand SelectionChanged
        {
            get 
            {
                if (_SelectionChanged == null)
                    _SelectionChanged = new RelayCommand(selectionExecute, selectionCanExecute);
                return _SelectionChanged; 
            }
        }
        /// <summary>
        /// SelectionChanged CanExecute Handler
        /// </summary>
        private bool selectionCanExecute(object obj)
        {
            return true;
        }
        /// <summary>
        /// SelectionChanged Execute Handler
        /// </summary>
        /// <param name="obj"></param>
        private void selectionExecute(object obj)
        {
            IList l = (IList)obj;
            if(l.Count > 0)
            {
                TemporaryFileVM fm = (TemporaryFileVM)l[0];
                if (fm != null)
                {
                    Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish(fm.FileModel.FileName);
                    Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = fm.FileModel });
                }
            }
        }
        /// <summary>
        /// KeyDownCommand CanExecute Handler
        /// </summary>
        private bool FileAssetKeyDownCanExecute(object obj)
        {
            if (((KeyEventArgs)obj).Key == Key.F2)
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// KeyDownCommand Execute Handler
        /// </summary>
        private void FileAssetKeyDownExecute(object obj)
        {
            IList p = (IList)obj;
            if(p.Count>0)
            {
                TemporaryFileVM dm = (TemporaryFileVM)p[p.Count - 1];
                dm.FileModel.IsEditMode = true;
            }
        }

        /// <summary>
        /// AddMaterial Click
        /// </summary>
        private void AddMaterialClick_Execute(object obj)
        {
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<CustomMaterialEvent>>().Publish(new CustomMaterialEvent() { eventArg = MtlEventArg.Create, GenerateMtlPath = FolderPath + "/Material.mtl"  });
        }
        public string FolderPath { get; set; }

        ObservableCollection<TemporaryFileVM> _FileVM;
        public ObservableCollection<TemporaryFileVM> FileVM
        {
            get 
            {
                if (_FileVM == null)
                    _FileVM = new ObservableCollection<TemporaryFileVM>();
                return _FileVM; 
            }
            set { SetProperty(ref _FileVM, value); }
        }

        /// <summary>
        /// 타 모듈 UI 에서 내부 UI 쪽 DragOver 발생 이벤트 처리
        /// </summary>
        /// <param name="dropInfo">DropInfo Data</param>
        public void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.Data is System.Windows.DataObject)
            {
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                dropInfo.Effects = DragDropEffects.Copy;
            }
        }
        /// <summary>
        /// 타 모듈 UI 에서 내부 UI 쪽 Drop 발생 이벤트 처리
        /// </summary>
        /// <param name="dropInfo">DropInfo Data</param>
        public void Drop(IDropInfo dropInfo)
        {
            if (dropInfo.Data is DataObject)
            {
                DataObject data = (DataObject)dropInfo.Data;
                string[] DirORFileName = (string[])data.GetData(DataFormats.FileDrop, true);
                FileInfoVM dc = (FileInfoVM)((ListBox)dropInfo.VisualTarget).DataContext;
                foreach (string Path in DirORFileName)
                {
                    string copyFolder = dc.FolderPath;

                    if (Directory.Exists(Path))
                    {
                        FindChildDir(copyFolder, Path);
                    }
                    else if (File.Exists(Path))
                    {
                        string FileName = System.IO.Path.GetFileName(Path);
                        File.Copy(Path, copyFolder + "/" + FileName);
                    }
                }
            }
        }
        /// <summary>
        /// DragDrop 에 의한 외부 Resource Directory 및 File 추가 처리
        /// </summary>
        /// <param name="CopyFolderRoot">Resource Target Path</param>
        /// <param name="OriginRootPath">Resource Source Path</param>
        void FindChildDir(string CopyFolderRoot, string OriginRootPath)
        {
            OriginRootPath = OriginRootPath.Replace("\\", "/");

            string[] childDir = Directory.GetDirectories(OriginRootPath);
            string[] childDirFiles = Directory.GetFiles(OriginRootPath);

            string[] temporarySplitString = OriginRootPath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            string GenerateFolderName = CopyFolderRoot + "/" + temporarySplitString[temporarySplitString.Length - 1];
            /// 폴더를 만들고
            Directory.CreateDirectory(GenerateFolderName);
            foreach (string file in childDirFiles)
            {
                string copyFilePath = file.Replace("\\", "/");
                /// 파일들을 카피한다.
                copyFilePath = copyFilePath.Replace(OriginRootPath, GenerateFolderName);
                File.Copy(file, copyFilePath);
            }
            foreach (string child in childDir)
            {
                FindChildDir(GenerateFolderName, child);
            }
        }

        
    }
    public class TemporaryFileVM : BindableBase
    {
        FileModel _FileModel;

        public FileModel FileModel
        {
            get { return _FileModel; }
            set { SetProperty(ref _FileModel, value); }
        }
        MetaBase _MetaModel;

        public MetaBase MetaModel
        {
            get { return _MetaModel; }
            set { SetProperty(ref _MetaModel, value); }
        }
    }
}
