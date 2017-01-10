using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using VRCAT.DataModel;
using VRCAT.DataModel.Event;
using VRCAT.Infrastructure;
using VRCAT.Infrastructure.DragDrop;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using WPFXCommand;
using VRCAT.WrapperBridge;
using System.Threading;
using System.Windows.Threading;

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
    public class AssetViewModel : BindableBase , IDropTarget
    {
        public bool IsFocused = false;
        string SelectDirecotryPath = string.Empty;
        string AssetRootPath = string.Empty;
        int FolderCnt = 0;
        int FileClickCnt = -1;
        //AssetDirecotryWatcher DirWatcher;
        //AssetDirecotryWatcher FileWatcher;
        VRWorld World;
        ICommand _SelectedAssetLBUp;
        ICommand _SelectedAssetLBDown;
        public ICommand SelectedAssetLBDown
        {
            get
            {
                if (_SelectedAssetLBDown == null)
                    _SelectedAssetLBDown = new RelayCommand(new Action<object>(delegate (object p)
                    {
                        if (SelectedFile != null)
                        {
                            if (SelectedFile.IsSceneSource)
                                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<TriggerEngineEvent>>().Publish(new TriggerEngineEvent(TriggerEngineEvent.TriggerEvent.LoadScene, SelectedFile.FullPath));
                            else if (SelectedFile.IsImageSource)
                                System.Diagnostics.Process.Start(SelectedFile.FullPath);
                            else if (SelectedFile.IsScriptSource)
                                System.Diagnostics.Process.Start(SelectedFile.FullPath);
                        }
                    }),
                    new Predicate<object>(delegate (object g)
                    {
                        FileClickCnt = ((System.Windows.Input.MouseButtonEventArgs)g).ClickCount;
                        if (FileClickCnt == 2)
                            return true;
                        else
                            return false;

                    }));
                return _SelectedAssetLBDown;

            }
        }
        public ICommand SelectedAssetLBUp
        {
            get
            {
                if (_SelectedAssetLBUp == null)
                    _SelectedAssetLBUp = new RelayCommand(FileItemSelectEvent);
                return _SelectedAssetLBUp;
            }
        }
        ICommand _CreateFolderCommand;
        public ICommand CreateFolderCommand
        {
            get
            {
                if (_CreateFolderCommand == null)
                    _CreateFolderCommand = new RelayCommand(CreateFolderBehavior);
                return _CreateFolderCommand;
            }
        }

        private void CreateFolderBehavior(object obj)
        {
            if(!string.IsNullOrEmpty(SelectDirecotryPath))
            {
                string CreateFolderPath = SelectDirecotryPath + "/";
                string OriginComparePath = CreateFolderPath;
                while (Directory.Exists(CreateFolderPath))
                {
                    CreateFolderPath = OriginComparePath+ "[" + FolderCnt.ToString() + "]";
                    FolderCnt++;
                }
                Directory.CreateDirectory(CreateFolderPath);
                FolderCnt = 0;
            }
        }

        ICommand _TestCommand;
        public ICommand TestCommand
        {
            get
            {
                if (_TestCommand == null)
                    _TestCommand = new RelayCommand(TestBehavior);
                return _TestCommand;
            }
        }

        private void TestBehavior(object obj)
        {
            FileItem = DirectoryItem[0].SubFiles;
        }

        private void FileItemSelectEvent(object obj)
        {
            if (obj != null)
            {
                FileModel fm = (FileModel)obj;
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish(fm.FileName);
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = fm });
                SelectedFile = fm;
            }
            else
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = null });
        }

        FileModel _SelectedFile;
        public FileModel SelectedFile
        {
            get { return _SelectedFile; }
            set { SetProperty(ref _SelectedFile, value); }
        }

        ICommand _RefreshFolderCommand;
        public ICommand RefreshFolderCommand
        {
            get
            {
                if (_RefreshFolderCommand == null)
                    _RefreshFolderCommand = new RelayCommand(RefreshFolder);
                return _RefreshFolderCommand;
            }
        }

        private void RefreshFolder(object param)
        {
            InitializeDirectory(AssetRootPath);
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ImportFBX>>().Publish(null);
        }


        #region Directory F2 Key 에 대한 이벤트 처리
        ICommand _DirectoryKeyDown;
        /// <summary>
        /// AssetView KeyDown BindingCommand
        /// </summary>
        public ICommand DirectoryKeyDown
        {
            get
            {
                if (_DirectoryKeyDown == null)
                    _DirectoryKeyDown = new RelayCommand(DirectoryAssetKeyDownExecute, DirectoryAssetKeyDownCanExecute);
                return _DirectoryKeyDown;
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
            if (obj is DirectoryModel)
            {
                DirectoryModel dm = (DirectoryModel)obj;
                if (!dm.DirectoryFullPath.Equals(VRWorld.Instance.AssetsDir))
                {
                    dm.IsEditMode = true;
                }
            }
        }
        #endregion

        #region File F2 Key 에 대한 이벤트 처리
        ICommand _FileKeyDown;
        public ICommand FileKeyDown
        {
            get
            {
                if (_FileKeyDown == null)
                    _FileKeyDown = new RelayCommand(FileAssetKeyDownExecute, FileAssetKeyDownCanExecute);
                return _FileKeyDown;
            }
        }

        private bool FileAssetKeyDownCanExecute(object obj)
        {
            if (((KeyEventArgs)obj).Key == Key.F2)
            {
                return true;
            }
            else
                return false;
        }

        private void FileAssetKeyDownExecute(object obj)
        {
            if(obj is FileModel)
            {
                FileModel fm = (FileModel)obj;
                fm.IsEditMode = true;
            }
        }
        #endregion

        /// <summary>
        /// Direcotry 선택변경시 발생 이벤트 Handler
        /// </summary>
        public DelegateCommand<RoutedPropertyChangedEventArgs<object>> DirectorySelect { get; private set; }
        /// <summary>
        /// File 선택 변경시 발생 이벤트 Handler
        /// </summary>

        #region Direcotry Delete Event
        ICommand _DeleteItemCommand;
        /// <summary>
        /// AssetView Delete Binding Command
        /// </summary>
        public ICommand DeleteItemCommand
        {
            get 
            {
                if (_DeleteItemCommand == null)
                    _DeleteItemCommand = new RelayCommand(DeleteItemCommandExecute);
                return _DeleteItemCommand; 
            }
        }
        /// <summary>
        /// AssetView Delete Execute Handler 
        /// </summary>
        /// <param name="obj"></param>
        private void DeleteItemCommandExecute(object obj)
        {
            if (IsFocused)
            {
                if (SelectedFile != null)
                {
                    MessageBoxResult mResult = MessageBox.Show("파일을 삭제하시겠습니까? 한번 삭제하시면 되돌릴수없습니다.", "알림", MessageBoxButton.OKCancel);
                    if (mResult == MessageBoxResult.OK)
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = null });
                        File.Delete(SelectedFile.FullPath);
                    }
                }
            }
        }
        #endregion

        #region Explorer 실행 이벤트
        ICommand _OpenExplorerCommand;
        /// <summary>
        /// AssetView 탐색기 열기 Binding Command
        /// </summary>
        public ICommand OpenExplorerCommand
        {
            get
            {
                if (_OpenExplorerCommand == null)
                    _OpenExplorerCommand = new RelayCommand(OpenExplorerCommandExecute);
                return _OpenExplorerCommand;
            }
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
        #endregion

        ObservableCollection<DirectoryModel> _DirectoryItem;
        /// <summary>
        /// DirectoryModel Collection
        /// </summary>
        public ObservableCollection<DirectoryModel> DirectoryItem
        {
            get
            {
                if (_DirectoryItem == null)
                    _DirectoryItem = new ObservableCollection<DirectoryModel>();
                return _DirectoryItem;
            }
            set { SetProperty(ref _DirectoryItem, value); }
        }
        ObservableCollection<FileModel> _FileItem;

        public ObservableCollection<FileModel> FileItem
        {
            get
            {
                if (_FileItem == null)
                    _FileItem = new ObservableCollection<FileModel>();
                return _FileItem;
            }
            set { SetProperty(ref _FileItem, value); }
        }

        

        /// <summary>
        /// 생성자
        /// </summary>
        public AssetViewModel()
        {
            World = VRWorld.Instance;
            if (!EngineInit.GetInstance.IsEngineInit)
                EngineInit.GetInstance.EngineInitStart();

            /// Directory Select Command
            DirectorySelect = new DelegateCommand<RoutedPropertyChangedEventArgs<object>>(delegate(RoutedPropertyChangedEventArgs<object> obj)
                {
                    if (obj.OldValue != obj.NewValue && obj.NewValue != null)
                    {
                        //FilesInSelectDirectoryItem = (obj.NewValue as DirectoryModel).SubFiles;
                        ///FileInfoItem = new FileInfoVM() { FolderPath = (obj.NewValue as DirectoryModel).DirectoryFullPath, FilesInSelectDirectoryItem = (obj.NewValue as DirectoryModel).SubFiles };

                        FileItem = ((DirectoryModel)obj.NewValue).SubFiles;
                        SelectDirecotryPath = (obj.NewValue as DirectoryModel).DirectoryFullPath;
                        SelectedFile = null;
                    }
                });
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Subscribe(param =>
            {
                if (param.Equals("AssetViewRefresh"))
                    InitializeDirectory(AssetRootPath);
            });

            AssetViewRefresh();

            KeyBinderMultiCommand.Instance.AddKeyBinderMultiCommand(new KeyGesture(Key.Delete), DeleteItemCommand);

        }

        void AssetViewRefresh()
        {
            ///이벤트 에 대한 Subscribe 처리
            AssetRootPath = VRCAT.DataModel.VRWorld.Instance.AssetsDir + @"\";

            if (Directory.Exists(AssetRootPath))
            {
                AssetDirecotryWatcher DirWatcher = new AssetDirecotryWatcher(AssetRootPath);
                DirWatcher.EnableRaisingEvents = true;
                DirWatcher.IncludeSubdirectories = true;
                DirWatcher.NotifyFilter = NotifyFilters.DirectoryName;
                DirWatcher.InternalBufferSize = 2048000;
                DirWatcher.Created += DirWatcher_Created;
                DirWatcher.Deleted += DirWatcher_Deleted;
                DirWatcher.Renamed += DirWatcher_Renamed;
                
                AssetDirecotryWatcher FileWatcher = new AssetDirecotryWatcher(AssetRootPath);
                FileWatcher.EnableRaisingEvents = true;
                FileWatcher.IncludeSubdirectories = true;
                FileWatcher.NotifyFilter = NotifyFilters.FileName;
                FileWatcher.InternalBufferSize = 2048000;
                FileWatcher.Created += FileWatcher_Created;
                FileWatcher.Deleted += FileWatcher_Deleted;
                FileWatcher.Renamed += FileWatcher_Renamed;

                /// Project Root 폴더 기반 기본 Asset 구성 
                //ThreadGetAssetFolder.Start(AssetRootPath);

                InitializeDirectory(AssetRootPath);
                FileItem = DirectoryItem[0].SubFiles;

                ///// DirectoryVM 를 만드는 과정에서 FBX 가 있어 이를 파싱한 경우 다시 Directory VM구조를 만든다.
                //if (VRWorld.Instance.FbxParserLoading)
                //{
                //    InitializeDirectory(AssetRootPath);
                //}
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
            if (DirectoryItem.Count == 0)
                return;
            if (File.Exists(e.FullPath))
            {
                string GenerateFullPath = VRWorld.Instance.AssetsDir + "/" + e.Name;
                GenerateFullPath = GenerateFullPath.Replace("\\", "/");
                string name = Path.GetFileNameWithoutExtension(GenerateFullPath);
                string fileName = Path.GetFileName(GenerateFullPath);
                string extensionName = Path.GetExtension(GenerateFullPath);
                //FileAttributes fileAttr = File.GetAttributes(GenerateFullPath);
                /// TODO : FBX 파일이 복사된경우 FBX 파일을 Code3 엔진 ffbx,ffmt,등에 맞게 변환시키고 파일은 삭제한다.
                /// 따라서 fbx 파일의 경우는 FildeModel 을 제작하지 않는것을 원칙으로 한다.
                /// AssetView 의 경우는 엔진 과는 무관한 모듈로서 모듈독립성을 위해 단순히 fbx 폴더 위치를 Message 로 보내고 
                /// 실제 엔진 인스턴스에 접근하는 부분은 WrapperBridge 모듈에서 수행토록 한다.
                if (extensionName.ToLower().Equals(".fbx"))
                {
                    if (VRWorld.Instance.ParshingFBXList.Count == 0)
                    {
                        if (!VRWorld.Instance.ParshingFBXListFromFileWatcher.Contains(GenerateFullPath))
                        {
                            VRWorld.Instance.ParshingFBXListFromFileWatcher.Enqueue(GenerateFullPath);
                            Application.Current.Dispatcher.Invoke(new Action(delegate ()
                            {
                                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ImportFBX>>().Publish(null);
                            }));
                        }
                    }
                }
                string GeneratePathFolder = GenerateFullPath.Replace(fileName, "");
                string FindParentPath = GeneratePathFolder.Remove(GeneratePathFolder.Count() - 1, 1);
                ///Loger.SetLog.Debug("FileWatcher parent Path" + FindParentPath);
                var ParentDirModel = FindParentDM(DirectoryItem[0], FindParentPath);
                if (ParentDirModel != null)
                {
                    if (extensionName.Length > 0)
                        extensionName = extensionName.Remove(0, 1);
                    GenerateFullPath = GenerateFullPath.Replace("\\", "/");
                    if (!ParentDirModel.IsAlreadyContainFile(GenerateFullPath))
                    {
                        FileModel fileModel = new FileModel(name, GenerateFullPath, fileName, extensionName, GeneratePathFolder);
                        ParentDirModel.SubFiles.Add(fileModel);
                        //FileItem = ParentDirModel.SubFiles;
                        if (extensionName.ToLower() == "jpg" || extensionName.ToLower() == "jpeg" || extensionName.ToLower() == "bmp" || extensionName.ToLower() == "tga")
                            VRWorld.Instance.ImageFileCollection.Add(fileModel);
                    }
                }
                //}
            }
        }
        /// <summary>
        /// 윈도우 탐색기 내에서 File 이름변경 Watcher
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">RenamedEventArgs</param>
        void FileWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (DirectoryItem.Count == 0)
                return;
            string FolderPath = Path.GetDirectoryName(e.OldFullPath);
            string FileName = e.OldFullPath.Replace("\\", "/");
            FolderPath = FolderPath.Replace("\\", "/");
            var ParentDirModel = FindParentDM(DirectoryItem[0], FolderPath);
            if (ParentDirModel != null)
            {
                FileModel renameFM = ParentDirModel.SubFiles.Where(a => a.FullPath.Equals(FileName)).FirstOrDefault();
                if (renameFM != null)
                {
                    /// 기존 GuidAssetMap 을 삭제한후
                    //VRWorld.Instance.GuidAssetMap.Remove(renameFM.FullPath);
                    string ReplaceFullPath = e.FullPath.Replace("\\", "/");
                    string ReplaceFilePath = Path.GetFileName(ReplaceFullPath);
                    string ReplaceFileName = Path.GetFileNameWithoutExtension(ReplaceFullPath);
                    string ReplaceFileExtension = Path.GetExtension(ReplaceFullPath);
                    if (!string.IsNullOrEmpty(ReplaceFileExtension))
                        ReplaceFileExtension = ReplaceFileExtension.Remove(0, 1);

                    renameFM.FullPath = ReplaceFullPath;
                    renameFM.FileName = ReplaceFilePath;
                    renameFM.FileExtension = ReplaceFileExtension;
                    renameFM.Name = ReplaceFileName;
                    /// 새로운 GUID 로 세팅
                    //VRWorld.Instance.GuidAssetMap.Add(renameFM.FullPath, renameFM.MetaData.uuid);
                }
            }
        }
        void FileWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (DirectoryItem.Count == 0)
                return;
            string FolderPath = Path.GetDirectoryName(e.FullPath);
            FolderPath = FolderPath.Replace("\\", "/");
            var ParentDirModel = FindParentDM(DirectoryItem[0], FolderPath);
            if(ParentDirModel != null)
            {
                string comparePath = e.FullPath.Replace("\\", "/");
                FileModel removeModel = ParentDirModel.SubFiles.Where(a => a.FullPath.Equals(comparePath)).FirstOrDefault();
                /// TODO : 기존 GuidAssetMap 에서 삭제 처리 수행
                //VRWorld.Instance.GuidAssetMap.Remove(removeModel.FullPath);
                ParentDirModel.SubFiles.Remove(removeModel);
                FileItem = ParentDirModel.SubFiles;
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
            if (DirectoryItem.Count == 0)
                return;
            string createPath = e.FullPath.Replace("\\", "/");
            DirectoryModel subDir = new DirectoryModel(createPath, null, false);
            int lastRemovePointIDX = createPath.LastIndexOf("/");
            string parentPath = createPath.Remove(lastRemovePointIDX);
            ///Loger.SetLog.Debug("Create Dir : " + createPath);
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
            if (DirectoryItem.Count == 0)
                return;
            string oldPath = Path.GetDirectoryName(e.OldFullPath);
            oldPath = oldPath.Replace("\\", "/");
            var ParentDirModel = FindParentDM(DirectoryItem[0], oldPath);
            if(ParentDirModel != null)
            {
                string comparePath = e.OldFullPath.Replace("\\", "/");
                var renameDM = ParentDirModel.SubDirectorys.Where(a => a.DirectoryFullPath.Equals(comparePath)).FirstOrDefault();
                if(renameDM != null)
                {
                    string newPath = e.FullPath.Replace("\\", "/");
                    /// DirectoryFullPath 를 먼저 변경해야 한다. 
                    renameDM.DirectoryFullPath = newPath;
                    /// DirectoryName 은 내부적으로 이름 변경시 Path 에 따라 이동처리되는 코드가 존재함.
                    renameDM.Name = newPath.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries).Last();
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
            if (DirectoryItem.Count == 0)
                return;
            string ParentPath = Path.GetDirectoryName(e.FullPath);
            ParentPath = ParentPath.Replace("\\", "/");
            var ParentDirModel = FindParentDM(DirectoryItem[0], ParentPath);
            if(ParentDirModel != null)
            {
                string comparePath = e.FullPath.Replace("\\", "/");
                var removeDM = ParentDirModel.SubDirectorys.Where(a => a.DirectoryFullPath.Equals(comparePath)).FirstOrDefault();
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
        void InitializeDirectory(string AssetRootPath)
        {
            try
            {
                DirectoryModel subModel = new DirectoryModel(AssetRootPath, null);
                if (DirectoryItem.Count > 0)
                    DirectoryItem.Clear();
                DirectoryItem.Add(subModel);
                SelectDirecotryPath = subModel.DirectoryFullPath;
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ImportFBX>>().Publish(null);
            }
            catch(Exception ex)
            {

            }
        }

        public void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.Data is System.Windows.DataObject )
            {
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                dropInfo.Effects = DragDropEffects.Copy;
            }
            else if(dropInfo.Data is FileModel)
            {
                if(dropInfo.VisualTarget is TreeView)
                {
                    dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                    if (Keyboard.GetKeyStates(Key.LeftCtrl) == KeyStates.Down)
                        dropInfo.Effects = DragDropEffects.Copy;
                    else
                        dropInfo.Effects = DragDropEffects.Move;
                }
            }
            else if(dropInfo.Data is DirectoryModel)
            {
                if(dropInfo.TargetItem is DirectoryModel)
                {
                    //이동하려는 디렉터리가 자신의 하위디렉터리인지 체크
                    DirectoryModel parent = ((DirectoryModel)dropInfo.TargetItem);
                    string rootPath = AssetRootPath.Replace(@"\", "/");
                    rootPath = rootPath.TrimEnd("Assets/".ToCharArray());
                    while (rootPath != parent.DirectoryFullPath)
                    {
                        if (parent.DirectoryFullPath == ((DirectoryModel)dropInfo.Data).DirectoryFullPath)
                            return;
                        parent = new DirectoryModel(((DirectoryModel)parent).DirectoryFullPath.TrimEnd( ((DirectoryModel)parent).Name.ToCharArray() ));
                    }
                    //이동하려는 디렉터리에 source폴더와 같은 이름의 폴더가 존재하는지 확인
                    foreach(var folder in ((DirectoryModel)dropInfo.TargetItem).SubDirectorys)
                    {
                        if (folder.Name == ((DirectoryModel)dropInfo.Data).Name) return;
                    }

                    string sourcePath = ((DirectoryModel)dropInfo.Data).DirectoryFullPath;
                    string SourceParentPath = Path.GetDirectoryName(sourcePath);
                    SourceParentPath = SourceParentPath.Replace(@"\", "/");
                    string destPath = ((DirectoryModel)dropInfo.TargetItem).DirectoryFullPath;
                    if(sourcePath != destPath)
                    {
                        if (SourceParentPath == destPath)
                            return;
                        dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                        if (Keyboard.GetKeyStates(Key.LeftCtrl) == KeyStates.Down)
                            dropInfo.Effects = DragDropEffects.Copy;
                        else
                            dropInfo.Effects = DragDropEffects.Move;
                    }
                }
            }
        }

        public void Drop(IDropInfo dropInfo)
        {
            #region WindowDataObject 복사처리
            if (dropInfo.Data is DataObject)
            {
                DataObject data = (DataObject)dropInfo.Data;
                string[] DirORFileName = (string[])data.GetData(DataFormats.FileDrop, true);
                string copyFolder = "";
                if(dropInfo.TargetItem is DirectoryModel)
                {
                    copyFolder = ((DirectoryModel)dropInfo.TargetItem).DirectoryFullPath;
                }
                else if(dropInfo.VisualTarget is ListBox)
                {
                    AssetViewModel dc = (AssetViewModel)((ListBox)dropInfo.VisualTarget).DataContext;
                    copyFolder = dc.SelectDirecotryPath;
                }
                
                foreach (string Path in DirORFileName)
                {
                    if (Directory.Exists(Path))
                    {
                        FindChildDirCopy(copyFolder, Path);
                    }
                    else if (File.Exists(Path))
                    {
                        string FileName = System.IO.Path.GetFileName(Path);
                        string extension = System.IO.Path.GetExtension(Path);
                        //Console.WriteLine("Copy from [" + Path + "] to [" + copyFolder + "/" + FileName + "]");
                        if (extension.Equals(".fbx") || extension.Equals(".FBX"))
                            VRWorld.Instance.ParshingFBXList.Add(copyFolder + "/" + FileName);
                        File.Copy(Path, copyFolder + "/" + FileName, true);
                    }
                }
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ImportFBX>>().Publish(null);
            }
            #endregion
            else if (dropInfo.TargetItem is DirectoryModel)
            {
                #region Directory Copy / Move
                if(dropInfo.Data is DirectoryModel)
                {
                    string Name = ((DirectoryModel)dropInfo.Data).Name;
                    string sourcePath,destPath;
                    sourcePath = ((DirectoryModel)dropInfo.Data).DirectoryFullPath;
                    destPath = ((DirectoryModel)dropInfo.TargetItem).DirectoryFullPath + "/" + Name;
                    if (sourcePath != destPath)
                    {
                        if (dropInfo.Effects == DragDropEffects.Copy)
                        {
                            Copy(sourcePath, destPath);
                        }
                        else if (dropInfo.Effects == DragDropEffects.Move)
                        {
                            /// Directory Move 처리
                            Directory.Move(sourcePath, destPath);
                        }
                        InitializeDirectory(AssetRootPath);
                        DirectoryItem[0].SubDirectorys[0].IsExpanded = true;
                    }
                }
                #endregion
                #region File Copy / Move
                /// 무조건 FildeModel 일 경우
                else
                {
                    /// FileMove
                    string destFilePath = ((DirectoryModel)dropInfo.TargetItem).DirectoryFullPath + @"\" + ((FileModel)dropInfo.Data).FileName;
                    if (dropInfo.Effects == DragDropEffects.Move)
                        File.Move(((FileModel)dropInfo.Data).FullPath, destFilePath);
                    else if(dropInfo.Effects == DragDropEffects.Copy)
                    {

                    }
                }
                #endregion
            }
        }
        void Copy(string sourceDir, string targetDir)
        {
            //Console.WriteLine("DirCopy : {0}", new object[] { targetDir });
            Directory.CreateDirectory(targetDir);

            foreach (var file in Directory.GetFiles(sourceDir))
                File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)));
            //Console.WriteLine("FileCopy : {0} to {1}", new object[] { targetDir, Path.GetFileName(file) });

            foreach (var directory in Directory.GetDirectories(sourceDir))
                Copy(directory, Path.Combine(targetDir, Path.GetFileName(directory)));
        }
        /// <summary>
        /// DragDrop 에 의한 외부 Resource Directory 및 File 추가 처리
        /// </summary>
        /// <param name="CopyFolderRoot">Resource Target Path</param>
        /// <param name="OriginRootPath">Resource Source Path</param>
        void FindChildDirCopy(string CopyFolderRoot, string OriginRootPath)
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
                string extension = Path.GetExtension(copyFilePath);
                /// 파일들을 카피한다.
                copyFilePath = copyFilePath.Replace(OriginRootPath, GenerateFolderName);
                if (extension.Equals(".fbx") || extension.Equals(".FBX"))
                    VRWorld.Instance.ParshingFBXList.Add(copyFilePath);
                //Console.WriteLine("Copy from [" + file + "] to [" + copyFilePath + "]");

                File.Copy(file, copyFilePath, true);
            }
            foreach (string child in childDir)
            {
                FindChildDirCopy(GenerateFolderName, child);
            }
        }
    }
}
