using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using VRCAT.Infrastructure;
using System.Threading;
using Microsoft.Practices.Prism.PubSubEvents;
using VRCAT.DataModel.Event;

namespace VRCAT.DataModel
{
    /// <summary>
    /// DirectoryModel Class
    /// </summary>
	public class DirectoryModel : BindableBase
    {
        AssetDirecotryWatcher DirWatcher;
        AssetDirecotryWatcher FileWatcher;
        /// <summary>
        /// 생성자
        /// </summary>
        /// <remarks>최상위 이름은 Assets 으로 상시 설정</remarks>
		public DirectoryModel()
        {
            Name = "Assets";
        }
        /// <summary>
        /// Directory Model 재귀 생성자
        /// </summary>
        /// <param name="DirPath">상위 DirectoryPath</param>
        /// <param name="ParentDm">Parent Directory Model , Default = null</param>
        /// <param name="AutoGenSubDir">하위 폴더 자동 탐색 여부, Default = true</param>
		public DirectoryModel(string DirPath, DirectoryModel ParentDm = null, bool AutoGenSubDir = true)
        {
            this.DirectoryFullPath = DirPath;
            string pathName = DirPath.Split(new string[] { @"/" }, StringSplitOptions.RemoveEmptyEntries).Last();
            pathName = pathName.Split(new string[] { @"\" }, StringSplitOptions.RemoveEmptyEntries).Last();
            this.Name = pathName;
            if (AutoGenSubDir)
            {
                foreach (string d in Directory.GetDirectories(DirPath))
                {
                    DirectoryModel subDirModel = new DirectoryModel(d, this);
                    this.SubDirectorys.Add(subDirModel);
                }
                foreach (string f in Directory.GetFiles(this.DirectoryFullPath))
                {
                    if (File.Exists(f))
                    {
                        FileAttributes fileAttr = File.GetAttributes(f);
                        if (!fileAttr.HasFlag(FileAttributes.Hidden))
                        {
                            string name = Path.GetFileNameWithoutExtension(f);
                            string filename = Path.GetFileName(f);
                            string fileExtension = Path.GetExtension(f);
                            string fullPath = f.Replace("\\", "/");
                            if (fileExtension.Length > 0)
                                fileExtension = fileExtension.Remove(0, 1);

                            /// TODO : FBX 파일이 복사된경우 FBX 파일을 Code3 엔진 ffbx,ffmt,등에 맞게 변환시키고 파일은 삭제한다.
                            /// 따라서 fbx 파일의 경우는 FildeModel 을 제작하지 않는것을 원칙으로 한다.
                            /// AssetView 의 경우는 엔진 과는 무관한 모듈로서 모듈독립성을 위해 단순히 fbx 폴더 위치를 Message 로 보내고 
                            /// 실제 엔진 인스턴스에 접근하는 부분은 WrapperBridge 모듈에서 수행토록 한다.
                            if (fileExtension.ToLower().Equals("fbx"))
                            {
                                ///Loger.SetLog.Info("[DirectoryModel] FBX 파싱 이벤트 전달 : " + fullPath);
                                //Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectFBX>>().Publish(new SelectFBX() { FBXPath = fullPath });
                                if (!VRWorld.Instance.ParshingFBXList.Contains(fullPath))
                                    VRWorld.Instance.ParshingFBXList.Add(fullPath);
                            }
                            else
                            {
                                if (!this.IsAlreadyContainFile(fullPath))
                                {
                                    FileModel fileModel = new FileModel(name, fullPath, filename, fileExtension, fullPath.Replace(filename, ""));
                                    this.SubFiles.Add(fileModel);
                                    if (fileExtension.ToLower() == "jpg" || fileExtension.ToLower() == "jpeg" || fileExtension.ToLower() == "bmp" || fileExtension.ToLower() == "tga")
                                        VRWorld.Instance.ImageFileCollection.Add(fileModel);
                                }

                                /// TODO : AssetDirectoryModel 에서 차후 이미지 별도 관리를 위해 ImageFileCollection 에 추가하는 부분
                                //if (fileExtension.ToLower().Equals("jpeg") || fileExtension.ToLower().Equals("jpg") ||
                                //    fileExtension.ToLower().Equals("png") || fileExtension.ToLower().Equals("bmp"))
                                //{
                                //    VRWorld.Instance.ImageFileCollection.Add(fileModel);
                                //}
                            }
                        }
                    }
                }
            }
        }
        string _Name;
        /// <summary>
        /// Directory 이름
        /// </summary>
        /// <remarks>DirectoryFullPath 의 최하위 이름과 다른경우는 파일탐색기에서 이름변경됨으로 인지하고 자기 이름을 변경 및 Move 를 호출</remarks>
		public string Name
        {
            get { return _Name; }
            set
            {
                string[] FinalNames = DirectoryFullPath.Split(new string[] { @"/" }, StringSplitOptions.RemoveEmptyEntries);
                if (FinalNames.Last() != value)
                {
                    FinalNames[FinalNames.Count() - 1] = value;
                    string MovingPath = "";
                    foreach (var cString in FinalNames)
                    {
                        MovingPath += cString + "/";
                    }
                    MovingPath = MovingPath.Remove(MovingPath.Length - 1, 1);
                    //MovingPath = MovingPath.Trim();
                    try
                    {
                        ///Loger.SetLog.Info(DirectoryFullPath);
                        ///Loger.SetLog.Info(MovingPath);
                        DirectoryInfo di = new DirectoryInfo(DirectoryFullPath);
                        di.MoveTo(MovingPath);
                    }
                    catch (Exception ex)
                    {
                        ///Loger.SetLog.Error("DirectoryModel Direcotry Name 변경에 의한 Move시 에러 발생 Message :" + ex.Message);
                    }
                    DirectoryFullPath = MovingPath;
                }
                SetProperty(ref _Name, value);
            }
        }

        string _directoryFullPath;
        /// <summary>
        /// Direcotry FullPath
        /// </summary>
        /// <remarks>\\ 를 / 로 변경처리</remarks>
		public string DirectoryFullPath
        {
            get { return _directoryFullPath; }
            set
            {
                value = value.Replace("\\", "/");
                if (value.Last().Equals('/'))
                {
                    value = value.Remove(value.Count() - 1, 1);
                }
                SetProperty(ref _directoryFullPath, value);
            }
        }

        bool _IsEditMode = false;
        /// <summary>
        /// AssetModule 에서 디렉토리 이름변경시 사용하는 Property
        /// </summary>
        /// <remarks>True 일 경우 EditTextBox 에서 해당 Property 에 따라 EditTextBox Adorner 를 변경함</remarks>
        public bool IsEditMode
        {
            get { return _IsEditMode; }
            set { SetProperty(ref _IsEditMode, value); }
        }

        MTObservableCollection<DirectoryModel> _subDirectorys;
        /// <summary>
        /// Sub DirectoryModel List
        /// </summary>
		public MTObservableCollection<DirectoryModel> SubDirectorys
        {
            get
            {
                if (_subDirectorys == null)
                    _subDirectorys = new MTObservableCollection<DirectoryModel>();
                return _subDirectorys;
            }
            set { SetProperty(ref _subDirectorys, value); }
        }

        MTObservableCollection<FileModel> _subFiles;
        /// <summary>
        /// Sub FileModel List
        /// </summary>
		public MTObservableCollection<FileModel> SubFiles
        {
            get
            {
                if (_subFiles == null)
                    _subFiles = new MTObservableCollection<FileModel>();
                return _subFiles;
            }
            set { SetProperty(ref _subFiles, value); }
        }

        MTObservableCollection<MetaBase> _subMetas;

        public MTObservableCollection<MetaBase> SubMetas
        {
            get
            {
                if (_subMetas == null)
                    _subMetas = new MTObservableCollection<MetaBase>();
                return _subMetas;
            }
            set { _subMetas = value; }
        }

        bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set { SetProperty(ref _IsSelected, value); }
        }
        bool _IsExpanded;
        public bool IsExpanded
        {
            get { return _IsExpanded; }
            set { SetProperty(ref _IsExpanded, value); }
        }

        public bool IsAlreadyContainFile(string compareFileFullpath)
        {
            bool retunVal = false;
            foreach (FileModel f in SubFiles)
            {
                if (f.FullPath.Equals(compareFileFullpath))
                {
                    retunVal = true;
                    break;
                }
            }
            return retunVal;
        }
    }
}
