using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace VRCATCompoeser
{
    public class MainViewModel : NotifichangeModel
    {
        bool _flag = true;
        /// <summary>
        /// 기본값은 true, true 일경우는 OpenProject DataTemplate , false 일 경우는 NewProject DataTemplate
        /// </summary>
        public bool Flag
        {
            get { return _flag; }
            set
            {
                _flag = value;
                OnPropertyChanged("Flag");
            } 
        }
        ObservableCollection<ProjectModel> _ProjectList;
        public ObservableCollection<ProjectModel> ProjectList
        {
            get 
            {
                if (_ProjectList == null)
                    _ProjectList = new ObservableCollection<ProjectModel>();
                return _ProjectList; 
            }
            set
            {
                _ProjectList = value;
                OnPropertyChanged("ProjectList");
            }
        }

        ObservableCollection<PackageModel> _PackagesList;
        public ObservableCollection<PackageModel> PackagesList
        {
            get 
            {
                if (_PackagesList == null)
                    _PackagesList = new ObservableCollection<PackageModel>();
                return _PackagesList; 
            }
            set
            {
                _PackagesList = value;
                OnPropertyChanged("PackagesList");
            }
        }

        private string _SelectPlatform;
        public string SelectPlatform
        {
            get
            {
                if (string.IsNullOrEmpty(_SelectPlatform))
                    _SelectPlatform = PlatformItems.First();
                return _SelectPlatform;
            }
            set
            {
                _SelectPlatform = value;
                OnPropertyChanged("SelectPlatform");
            }
        }
        private List<string> _PlatformItems;
        public List<string> PlatformItems
        {
            get
            {
                if (_PlatformItems == null)
                    _PlatformItems = new List<string>();
                return _PlatformItems;
            }
            set
            {
                _PlatformItems = value;
                OnPropertyChanged("PlatformItems");
            }
        }
        private string _SelectDisplay;
        public string SelectDisplay
        {
            get
            {
                if (string.IsNullOrEmpty(_SelectDisplay))
                    _SelectDisplay = DisplayItmes.First();
                return _SelectDisplay;
            }
            set
            {
                _SelectDisplay = value;
                OnPropertyChanged("SelectDisplay");
            }
        }
        private List<string> _DisplayItmes;

        public List<string> DisplayItmes
        {
            get
            {
                if (_DisplayItmes == null)
                    _DisplayItmes = new List<string>();
                return _DisplayItmes;
            }
            set
            {
                _DisplayItmes = value;
                OnPropertyChanged("DisplayItmes");
            }
        }

        private string _SelectDevice;
        public string SelectDevice
        {
            get
            {
                if (string.IsNullOrEmpty(_SelectDevice))
                    _SelectDevice = DeviceItems.First();
                return _SelectDevice;
            }
            set
            {
                _SelectDevice = value;
                OnPropertyChanged("SelectDevice");
            }
        }
        private List<string> _DeviceItems;
        public List<string> DeviceItems
        {
            get
            {
                if (_DeviceItems == null)
                    _DeviceItems = new List<string>();
                return _DeviceItems;
            }
            set
            {
                _DeviceItems = value;
                OnPropertyChanged("DeviceItems");
            }
        }
        private string _SelectPRBSetting;
        public string SelectPRBSetting
        {
            get
            {
                if (string.IsNullOrEmpty(_SelectPRBSetting))
                    _SelectPRBSetting = PBRSetting.First();
                return _SelectPRBSetting;
            }
            set
            {
                _SelectPRBSetting = value;
                OnPropertyChanged("SelectPRBSetting");
            }
        }
        private List<string> _PBRSetting;
        public List<string> PBRSetting
        {
            get
            {
                if (_PBRSetting == null)
                    _PBRSetting = new List<string>();
                return _PBRSetting;
            }
            set
            {
                _PBRSetting = value;
                OnPropertyChanged("PBRSetting");
            }
        }

        private string _SelectedPluginInfo;
        public string SelectedPluginInfo
        {
            get { return _SelectedPluginInfo; }
            set
            {
                _SelectedPluginInfo = value;
                OnPropertyChanged("SelectedPluginInfo");
            }
        }
        
        public MainViewModel()
        {
            string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/EVR";
            if (!Directory.Exists(AppDataFolder))
                Directory.CreateDirectory(AppDataFolder);
            /// TODO : Project 파일 Base 기반 ProjectModel 추가 처리
            string ProjectBHFilePath = AppDataFolder + "\\VRCAT.Project.list";
            if(File.Exists(ProjectBHFilePath))
            {
                using(StreamReader sr = new StreamReader(ProjectBHFilePath))
                {
                    string OneLine;
                    while ((OneLine = sr.ReadLine()) != null)
                    {
                        string[] OneLineDatas = OneLine.Split(new char[] { ',' });
                        ProjectModel pm = new ProjectModel() { FolderName = OneLineDatas[0], FolderPath = OneLineDatas[1] };
                        ProjectList.Add(pm);
                    }
                }
            }

            #region Plugin Information Set
            /// TODO : Plugin 쪽 폴더에 존재하는 dll 들에 대한 Assembly 정보 기반 PacakgeList 추가
            string PluginPath = Directory.GetCurrentDirectory() + "\\Plugins";
            string[] PluginFilePath = Directory.GetFiles(PluginPath, "*.dll", SearchOption.AllDirectories);
            foreach(string dll in PluginFilePath)
            {
                System.Reflection.Assembly asmInfo = GetAssemblyDLL(dll);
                string description = "";
                if(asmInfo != null)
                {
                    AssemblyConfigurationAttribute acAttr = (AssemblyConfigurationAttribute)Attribute.GetCustomAttribute(asmInfo, typeof(AssemblyConfigurationAttribute));
                    if (acAttr == null || !string.IsNullOrEmpty(acAttr.Configuration))
                        continue;
                    AssemblyDescriptionAttribute adAttr = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(asmInfo, typeof(AssemblyDescriptionAttribute));
                    description = adAttr.Description;
                }
                string name = Path.GetFileNameWithoutExtension(dll);
                //string name = dll.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries).Last();
                PackageModel pL = new PackageModel() { HeaderTitle = name, Description = description, PackagePath = dll };
                PackagesList.Add(pL);
            }
            #endregion

            #region NewProject 에 들어가는 Platform,Display,Deviece Items
            PlatformItems.Add("Desktop/Console");
            PlatformItems.Add("Mobile");
            DisplayItmes.Add("HMD");
            DisplayItmes.Add("Monitor/Screen");
            DeviceItems.Add("No Virtual Device");
            DeviceItems.Add("Virtual Device");
            PBRSetting.Add("None");
            PBRSetting.Add("High Quality Rendering");
            #endregion
        }

        public static System.Reflection.Assembly GetAssemblyDLL(string pAssemblyNameDLL)
        {
            System.Reflection.Assembly tMyAssembly = null;

            if (string.IsNullOrEmpty(pAssemblyNameDLL)) { return tMyAssembly; }
            try //try #a
            {
                if (!pAssemblyNameDLL.ToLower().EndsWith(".dll")) { pAssemblyNameDLL += ".dll"; }
                tMyAssembly = System.Reflection.Assembly.LoadFrom(pAssemblyNameDLL);
            }// try #a
            catch (Exception ex)
            {
                string m = ex.Message;
            }// try #a
            return tMyAssembly;
        }
    }


    public class ProjectModel 
    {
        public string FolderName { get; set; }
        public string FolderPath { get; set; }
        
    }
    /// <summary>
    /// Plugin 에 해당되는 DLL 의 정보가 담겨질 class
    /// </summary>
    public class PackageModel : NotifichangeModel
    {
        public string HeaderTitle { get; set; }
        public string Description { get; set; }
        public string PackagePath { get; set; }

        public bool _IsSelected = false;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
    }

    public class NotifichangeModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

}
