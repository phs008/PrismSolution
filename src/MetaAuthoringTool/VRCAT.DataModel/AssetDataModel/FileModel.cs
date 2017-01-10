using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using VRCAT.DataModel;
using VRCAT.Infrastructure;

namespace VRCAT.DataModel
{
    /// <summary>
    /// FileModel Class
    /// </summary>
    public class FileModel : BindableBase
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public FileModel(string Name, string FullPath, string FileName, string FileExtension, string ParentFolderPath)
        {
            this.Name = Name;
            this.FullPath = FullPath;
            this.FileName = FileName;
            this.FileExtension = FileExtension;
            this.ParentFolderPath = ParentFolderPath;
            /// MetaData 정보가 존재할경우
            /// /// 없는경우 Meta 데이터를 생성 및 정보 저장
            /// MetaGUID 기반 MetaMap 도 구성
            /// TODO : MetaData 만들어 지는곳
            //if (!VRWorld.Instance.GuidAssetMap.ContainsKey(this.FullPath))
            //{
            //    this.MetaData = SetMetaData();
            //    VRWorld.Instance.GuidAssetMap.Add(this.FullPath, this.MetaData.uuid);
            //}
            //else
            //{
            //    Guid guid = VRWorld.Instance.GuidAssetMap[this.FullPath];
            //    string folderPath = guid.ToString().Substring(0, 2);
            //    string metaFullPath = Path.Combine(VRWorld.Instance.WorkingRootDir, "Library", folderPath, guid.ToString() + ".meta");
            //    this.MetaData = MetaDeSerialize(metaFullPath);
            //}
        }
        
        private MetaBase SetMetaData()
        {
            MetaBase meta = null;
            if (this.FileExtension.Equals("fbx"))
            {
                //meta = new FbxMeta(this.FullPath);
                /// FBX 를 분석하여 Material 을 만들고
                /// 그에 따른 Material Meta Data를 생성한다.
                meta = new FbxMeta(this.FullPath);
                meta.uuid = Guid.NewGuid();
                MetaSerialize(meta.uuid, meta);
            }
            else if (this.FileExtension.Equals("jpg") | this.FileExtension.Equals("jpeg") | this.FileExtension.Equals("png") | this.FileExtension.Equals("bmp"))
            {
                meta = new TextureMeta(this.FullPath);
                meta.uuid = Guid.NewGuid();
                ///Meta Binarary File Generation
                MetaSerialize(meta.uuid, meta);
                ///Add Retun value
            }
            else
            {
                meta = new EtcMeta(this.FullPath);
                meta.uuid = Guid.NewGuid();
                MetaSerialize(meta.uuid, meta);
            }
            return meta;
        }
        /// <summary>
        /// Meta 파일에 대한 Binarary Serializaion 수행
        /// </summary>
        /// <param name="uuid">해당 Meta 파일에 대한 UUID</param>
        /// <param name="baseData">Binarary Serialization 수행할 Data</param>
        private void MetaSerialize(Guid uuid, MetaBase baseData)
        {
            char[] metaFolder = uuid.ToString().ToCharArray(0, 2);
            string folderPath = metaFolder[0].ToString() + metaFolder[1].ToString();
            //string metaFileFullPath = Path.Combine(VRWorld.Instance.WorkingRootDir, "Library", folderPath, uuid + ".meta");
            string metaFileFullPath = "";
            ///META 파일 생성
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(metaFileFullPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, baseData);
            stream.Close();
        }
        private MetaBase MetaDeSerialize(string metaFullPath)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(metaFullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var instanceMeta = (MetaBase)formatter.Deserialize(stream);
            if (instanceMeta != null)
            {
                if (instanceMeta.MetaType == MetaTypeEnum.Texture)
                    return (TextureMeta)instanceMeta;
                //VRWorld.Instance.MetaMap.Add(instanceMeta.uuid, (TextureMeta)instanceMeta);
                else if (instanceMeta.MetaType == MetaTypeEnum.Model3D)
                    return (FbxMeta)instanceMeta;
                //VRWorld.Instance.MetaMap.Add(instanceMeta.uuid, (FbxMeta)instanceMeta);
                else if (instanceMeta.MetaType == MetaTypeEnum.Etc)
                    return (EtcMeta)instanceMeta;
                else
                    return null;
                //VRWorld.Instance.MetaMap.Add(instanceMeta.uuid, (EtcMeta)instanceMeta);
            }
            else
                return null;
        }
        
        string _Name;
        /// <summary>
        /// File 자체 이름(확장자 제외)
        /// </summary>
        /// <remarks>FileFullPath 의 최하위 이름과 다른경우는 파일탐색기에서 이름변경됨으로 인지하고 자기 이름을 변경 및 Move 를 호출</remarks>
        public string Name
        {
            get { return _Name; }
            set 
            {
                /// F2key 를 이용하여 파일 이름을 변경할 경우 처리
                if (!string.IsNullOrEmpty(FullPath))
                {
                    string[] FinalNames = FullPath.Split(new string[] { @"/" }, StringSplitOptions.RemoveEmptyEntries);
                    string changeFileName = value;
                    if (!string.IsNullOrEmpty(FileExtension))
                        changeFileName += "." + FileExtension;
                    if (FinalNames.Last() != changeFileName)
                    {
                        string originName = _Name;
                        if (!string.IsNullOrEmpty(FileExtension))
                            originName += "." + FileExtension;
                        string changeFullPath = FullPath.Replace(originName, changeFileName);
                        /// TODO : Meta 처리 관련 된 부분
                        //Guid g = VRWorld.Instance.GuidAssetMap[this.FullPath];
                        //this.MetaData.OriginDataPath = changeFullPath;
                        //this.MetaData.Serialize();
                        try
                        {
                            File.Move(FullPath, changeFullPath);
                            //FullPath = changeFullPath;
                            //FileName = changeFileName;

                        }
                        catch (Exception ex)
                        {
                            ///Loger.SetLog.Error("FileModel [Name] Message : " + ex.Message);
                        }
                    }
                    else
                        SetProperty(ref _Name, value);
                }
                else
                    SetProperty(ref _Name, value);
            }
        }
        string _fileName;
        /// <summary>
        /// File Extension 을 포함한 이름
        /// </summary>
        /// <remarks>CyberDemon.fbx</remarks>
        public string FileName
        {
            get { return _fileName; }
            set { SetProperty(ref _fileName, value); }
        }

        string _fullPath;
        /// <summary>
        /// File 전체 경로
        /// </summary>
        /// <remarks>\\ 를 / 로 변경처리</remarks>
        public string FullPath
        {
            get { return _fullPath; }
            set 
            {
                value = value.Replace("\\", "/");
                SetProperty(ref _fullPath, value);
            }
        }
        string _fileExtension;
        /// <summary>
        /// File 확장자
        /// 확장자 명 자체가 표현된다. (ex : exe , jpg, png)
        /// </summary>
        public string FileExtension
        {
            get { return _fileExtension; }
            set 
            {
                value = value.ToLower();
                SetProperty(ref _fileExtension, value); 
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
        string _ParentFolderPath;
        /// <summary>
        /// 상위폴더 경로
        /// </summary>
        public string ParentFolderPath
        {
            get { return _ParentFolderPath; }
            set { SetProperty(ref _ParentFolderPath, value); }
        }
        MetaBase _MetaData;
        public MetaBase MetaData
        {
            get { return _MetaData; }
            set { SetProperty(ref _MetaData, value); }
        }

        public bool IsImageSource
        {
            get
            {
                string lowerFileExtension = this.FileExtension.ToLower();
                if (lowerFileExtension == "jpeg" || lowerFileExtension == "jpg" || lowerFileExtension == "bmp" || lowerFileExtension == "tga" || lowerFileExtension == "psd" || lowerFileExtension == "png")
                    return true;
                else
                    return false;
            }
        }
        public bool IsScriptSource
        {
            get
            {
                string lowerFileExtension = this.FileExtension.ToLower();
                if (lowerFileExtension == "cs")
                    return true;
                else
                    return false;
            }
        }

        public bool IsSceneSource
        {
            get
            {
                string lowerFileExtension = this.FileExtension.ToLower();
                if (lowerFileExtension == "fsf")
                    return true;
                else
                    return false;
            }
        }

        
    }
}
