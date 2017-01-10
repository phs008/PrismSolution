using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VRCATCompoeser
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string AppDataFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/EVR/VRCAT.Project.list";
        private SolidColorBrush BlueColorBrush = new SolidColorBrush(new Color() { R = 63, G = 81, B = 181, A = 255 });
        private Regex rx = new Regex(@"^[^ㄱ-힗]*$", RegexOptions.None);
        private MainViewModel vm;
        private FolderBrowserDialog folderDialog = new FolderBrowserDialog();
        private System.Windows.Controls.TextBox SelectedFolderTextbox;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MainViewModel();
            this.DataContext = vm;
            this.OpenButtonClickBorder.BorderBrush = Brushes.Blue;
            string[] argument = Environment.GetCommandLineArgs();
            if (argument.Count() == 2)
            {
                bool value = Convert.ToBoolean(argument.Last());
                ChangeFirstShow(value);
            }
            Uri iconUri = new Uri("pack://application:,,,/Resources/white_bg_icon_big.png",UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
        }

        private void BrowseClick(object sender, RoutedEventArgs e)
        {
            ContentPresenter myPresenter = FindVisualChild<ContentPresenter>(this.ContentView);
            DataTemplate NewProject = (DataTemplate)FindResource("NewProject");
            SelectedFolderTextbox = (System.Windows.Controls.TextBox)NewProject.FindName("SelectFolderTextBox", myPresenter);
            System.Windows.Controls.TextBox PrjTxtBox = (System.Windows.Controls.TextBox)NewProject.FindName("PrjTxtBox", myPresenter);


            DialogResult result = folderDialog.ShowDialog();
            if (rx.IsMatch(folderDialog.SelectedPath))
            {
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    SelectedFolderTextbox.Text = folderDialog.SelectedPath;
                    PrjTxtBox.Text = folderDialog.SelectedPath.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries).Last();
                }
            }
            else
                System.Windows.MessageBox.Show("한글폴더를 지원하지 않습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void GenerateNewProject(object sender, RoutedEventArgs e)
        {
            if (SelectedFolderTextbox == null)
                System.Windows.MessageBox.Show("프로젝트 폴더 위치를 선택해주세요");
            else
            {
                string ProjectRootFolder = SelectedFolderTextbox.Text;
                /// Asset 폴더 생성 및 ProjectSettings 폴더 생성 
                string AssetsFolderPath = ProjectRootFolder + "/Assets";
                ///string hiddenVerificationFile = ProjectRootFolder + "/VRCATProj.hidden";
                string ProjectSettingPath = ProjectRootFolder + "/ProjectSettings";
                string PluginFile = ProjectSettingPath + "/VRCAT.Module.xa";
                string layoutFile = ProjectSettingPath + "/layout.xl.xa";
                string ScriptPath = ProjectRootFolder + "/Script";
                string TempPath = ProjectRootFolder + "/Temp";
                string TempObjPath = TempPath + "/Obj";

                VRCAT.DataModel.VRWorld.Instance.ProjectDir = ProjectRootFolder;

                if (Directory.Exists(AssetsFolderPath) && Directory.Exists(ProjectSettingPath))
                {
                    System.Windows.MessageBox.Show("이미 존재하는 프로젝트입니다. 폴더를 다시 선택해주세요");
                    return;
                }
                Directory.CreateDirectory(AssetsFolderPath);
                Directory.CreateDirectory(ProjectSettingPath);
                Directory.CreateDirectory(ScriptPath);
                Directory.CreateDirectory(TempPath);
                Directory.CreateDirectory(TempObjPath);

                /// Hidden 파일을 만들어서 해당 폴더가 VRCAT 의 project 폴더임을 확인한다.
                ///System.IO.File.Create(hiddenVerificationFile);
                
                ///File.SetAttributes(hiddenVerificationFile, FileAttributes.Encrypted | FileAttributes.Hidden | FileAttributes.ReadOnly);

                /// TODO : 1월 25일 1차년도 데모를 위한 하드코딩
                string DisplayInfo = vm.SelectDisplay;
                //if (DisplayInfo.Equals("HMD"))
                //{
                //    vm.PackagesList.Insert(0, new PackageModel() { HeaderTitle = "VRCAT.StereoRenderingModule", IsSelected = true });
                //    vm.PackagesList.Add(new PackageModel() { HeaderTitle = "VRCAT.VirtualUserModule", IsSelected = true });
                //    System.IO.File.Copy(AppDomain.CurrentDomain.BaseDirectory + "/layout.xl_HMD.xa", layoutFile);
                //}
                //else
                //{
                //    vm.PackagesList.Insert(0,new PackageModel() { HeaderTitle = "VRCAT.RenderingModule", IsSelected = true });
                //    System.IO.File.Copy(AppDomain.CurrentDomain.BaseDirectory + "/layout.xl.xa", layoutFile);
                //}
                vm.PackagesList.Insert(0, new PackageModel() { HeaderTitle = "VRCAT.RenderingModule", IsSelected = true });
                System.IO.File.Copy(AppDomain.CurrentDomain.BaseDirectory + "/ProjectSettings/layout.xl.xa", layoutFile);

                //string VRDeviceInfo = vm.SelectDevice;
                //if (VRDeviceInfo.Equals("Virtual Device"))
                //    vm.PackagesList.Add(new PackageModel() { HeaderTitle = "VRCAT.VRDeviceManagerModule", IsSelected = true });

                string PBRSetting = vm.SelectPRBSetting;
                if (PBRSetting.Equals("High Quality Rendering"))
                    VRCAT.DataModel.PreferenceControl.GetInstance().preferenceModel._isprbmode.IsPRBMode = true;
                VRCAT.DataModel.PreferenceControl.GetInstance().SavePreference();
                ///// 사용할 PluginModule 정보에 대한 저장
                //using (StreamWriter sw = new StreamWriter(PluginFile))
                //{
                //    foreach (PackageModel pm in vm.PackagesList)
                //    {
                //        if (pm.IsSelected)
                //            sw.WriteLine(pm.HeaderTitle + ".dll");
                //    }
                //}

                /// PluginModule 강제 복사 처리
                File.Copy(AppDomain.CurrentDomain.BaseDirectory + "/ProjectSettings/VRCAT.Module.xa", PluginFile);



                ///// Default Shader Assets 복사
                //string DefaultCopyShader = AppDomain.CurrentDomain.BaseDirectory + "Default";
                //CopyToFindChildDir(AssetsFolderPath + "/", DefaultCopyShader);

                /// 폴더 카피 등의 모든 행위가 종료된 다음에 VRCAT.Project.bh 파일을 갱신한다.
                using (StreamWriter sw = new StreamWriter(AppDataFile))
                {
                    string newProjectpath = SelectedFolderTextbox.Text;
                    newProjectpath = newProjectpath.Replace("\\", "/");
                    foreach (var existProjectInfo in vm.ProjectList)
                    {
                        if (!(existProjectInfo.FolderPath + existProjectInfo.FolderName).Equals(newProjectpath))
                            sw.WriteLine(existProjectInfo.FolderName + "," + existProjectInfo.FolderPath);
                    }
                    string lastPath = newProjectpath.Split(new char[] { '/' }).Last();
                    string pastpath = newProjectpath.Replace(lastPath, "");
                    sw.WriteLine(lastPath + "," + pastpath);
                }

                /// VRCAT 프로세스가 열려져 있으면 죽인다.
                Process[] pList = Process.GetProcessesByName("VRCAT");
                foreach (var b in pList)
                {
                    b.CloseMainWindow();
                }

                /// 새로운 저작도구 실행
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + "VRCAT.exe", ProjectRootFolder);
                Environment.Exit(0);
                this.Close();
            }
        }

        private void NewProjectMenuClick(object sender, RoutedEventArgs e)
        {
            ChangeFirstShow(false);
        }

        private void ExistProjectMenuClick(object sender, RoutedEventArgs e)
        {
            ChangeFirstShow(true);
        }

        void ChangeFirstShow(bool value)
        {
            if (value)
            {
                vm.Flag = true;
                this.OpenButtonClickBorder.BorderBrush = BlueColorBrush;
                this.NewButtonClickBorder.BorderBrush = Brushes.Transparent;
            }
            else
            {
                vm.Flag = false;
                this.NewButtonClickBorder.BorderBrush = BlueColorBrush;
                this.OpenButtonClickBorder.BorderBrush = Brushes.Transparent;
            }

        }

        private void OpenExistPrjClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            ProjectModel selectedOpenPrjModel = (ProjectModel)button.DataContext;

            if (rx.IsMatch(selectedOpenPrjModel.FolderPath + selectedOpenPrjModel.FolderName))
            {
                if (Directory.Exists(selectedOpenPrjModel.FolderPath + selectedOpenPrjModel.FolderName))
                {
                    string VRCATArguementPath = selectedOpenPrjModel.FolderPath + selectedOpenPrjModel.FolderName;

                    /// TODO : VRCAT 프로세스가 열려져 있으면 죽인다.
                    Process[] pList = Process.GetProcessesByName("VRCAT");
                    foreach (var b in pList)
                    {
                        b.CloseMainWindow();
                    }

                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + "VRCAT.exe", VRCATArguementPath);
                    Environment.Exit(0);
                    this.Close();
                }
                else
                {
                    System.Windows.MessageBox.Show("프로젝트가 존재하지 않습니다.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ProjectModel deleteModel = vm.ProjectList.Where(a => a.FolderPath.Equals(selectedOpenPrjModel.FolderPath)).First();
                    vm.ProjectList.Remove(deleteModel);
                    using (StreamWriter sw = new StreamWriter(AppDataFile))
                    {
                        foreach (ProjectModel pm in vm.ProjectList)
                        {
                            sw.WriteLine(pm.FolderName + "," + pm.FolderPath);
                        }
                    }
                }
            }
            else
                System.Windows.MessageBox.Show("한글폴더를 지원하지 않습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// DataTemplate 정보획득을 위해 VisualTree 에서 하위 child 를 탐색하며 obj 와 일치한 dependencyObject 를 반환한다.
        /// </summary>
        private childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                    return (childItem)child;
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        /// <summary>
        /// 폴더 하위 에 위치하는 모든 폴더 및 파일을 CopyPathRoot 에 복사한다.
        /// </summary>
        /// <param name="CopyPathRoot">복사될 Root Path</param>
        /// <param name="rootDir">Source 가 되는 Rootpath</param>
        void CopyToFindChildDir(string CopyPathRoot, string rootDir)
        {
            string[] childDir = Directory.GetDirectories(rootDir);
            string[] childDirFiles = Directory.GetFiles(rootDir);
            string copyDir = rootDir.Replace(AppDomain.CurrentDomain.BaseDirectory, CopyPathRoot);
            /// 폴더를 만들고
            Directory.CreateDirectory(copyDir);
            foreach (string file in childDirFiles)
            {
                /// 파일들을 카피한다.
                string copyFilePath = file.Replace(rootDir, copyDir);
                File.Copy(file, copyFilePath);
            }
            foreach (string child in childDir)
            {
                CopyToFindChildDir(CopyPathRoot, child);
            }
        }

        private void AdvancedSettingClick(object sender, RoutedEventArgs e)
        {
            Point buttonPoint = (sender as System.Windows.Controls.Button).PointToScreen(new Point(0, 0));
            AdvanceSetting adSetting = new AdvanceSetting((MainViewModel)this.DataContext);
            adSetting.Left = buttonPoint.X;
            adSetting.Top = buttonPoint.Y - adSetting.Height + (sender as System.Windows.Controls.Button).Height;
            adSetting.Owner = this;
            adSetting.WindowStyle = WindowStyle.None;
            adSetting.ResizeMode = ResizeMode.NoResize;

            adSetting.Show();
        }

        private void OpenOtherPrjClick(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowNewFolderButton = false;
            f.RootFolder = Environment.SpecialFolder.MyComputer;
            f.Description = "Open Another Project";
            DialogResult r = f.ShowDialog();
            if(r == System.Windows.Forms.DialogResult.OK)
            {
                string OpenPrjFolder = f.SelectedPath;
                string OpenPrjAssetFolder = OpenPrjFolder + "/Assets";
                string OpenPrjProjectSettingFolder = OpenPrjFolder + "/ProjectSettings";
                string OpenPrjScriptFolder = OpenPrjFolder + "/Script";
                if(Directory.Exists(OpenPrjAssetFolder) && Directory.Exists(OpenPrjProjectSettingFolder) && Directory.Exists(OpenPrjScriptFolder))
                {
                    /// VRCAT.Project.bh 파일에 해당 폴더 path 를 갱신한다.
                    using (StreamWriter sw = new StreamWriter(AppDataFile))
                    {
                        OpenPrjFolder = OpenPrjFolder.Replace("\\", "/");
                        foreach (var existProjectInfo in vm.ProjectList)
                        {
                            if (!(existProjectInfo.FolderPath + existProjectInfo.FolderName).Equals(OpenPrjFolder))
                                sw.WriteLine(existProjectInfo.FolderName + "," + existProjectInfo.FolderPath);
                        }
                        string lastPath = OpenPrjFolder.Split(new char[] { '/' }).Last();
                        string pastpath = OpenPrjFolder.Replace(lastPath, "");
                        sw.WriteLine(lastPath + "," + pastpath);
                    }

                    /// TODO : VRCAT 프로세스가 열려져 있으면 죽인다.
                    Process[] pList = Process.GetProcessesByName("VRCAT");
                    foreach (var b in pList)
                    {
                        b.CloseMainWindow();
                    }

                    string VRCATArguementPath = OpenPrjFolder;
                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + "VRCAT.exe", VRCATArguementPath);
                    Environment.Exit(0);
                    this.Close();
                }
            }

        }
    }
}
