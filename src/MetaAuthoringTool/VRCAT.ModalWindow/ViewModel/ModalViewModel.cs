using Microsoft.Practices.Prism.PubSubEvents;
using System;
using VRCAT.Infrastructure;
using VRCAT.DataModel;
using System.Windows.Forms;
using Microsoft.Practices.Prism.Mvvm;
using System.Diagnostics;
using System.IO;
using VRCAT.DataModel.Event;
using System.Collections.Generic;
using System.Linq;

namespace VRCAT.CustomModalWindow
{
    /// <summary>
    /// 저작도구 내에서 ModalWindow 로 뛰워야할 기능들을 이벤트로 받아서 뛰어주는 모듈 class
    /// </summary>
	public class ModalViewModel : BindableBase
	{
        private readonly string AppDataFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/EVR/VRCAT.Project.list";
        List<ProjectModel> _ProjectList;
        internal List<ProjectModel> ProjectList
        {
            get
            {
                if (_ProjectList == null)
                    _ProjectList = new List<ProjectModel>();
                return _ProjectList;
            }
            set
            {
                _ProjectList = value;
            }
        }
        /// <summary>
        /// ToolbarEvent Subscribe
        /// </summary>
        public ModalViewModel()
        {
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Subscribe(new Action<ToolbarEvent>(ToolBarEventBehavior));
        }

        private void ToolBarEventBehavior(ToolbarEvent obj)
        {
            switch (obj.ClickMenuHeader)
            {
                case "NewScene":
                    {
                        DialogResult result = MessageBox.Show("작업하던 씬을 저장하시겠습니까?", "알림", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("SaveScene"));
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<TriggerEngineEvent>>().Publish(new TriggerEngineEvent(TriggerEngineEvent.TriggerEvent.NewScene, null));
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SceneChangeEvent>>().Publish(new SceneChangeEvent() { SceneName = "" });
                            VRWorld.Instance.CurrentSceneFileName = "";
                        }
                        else if (result == DialogResult.No)
                        {
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<TriggerEngineEvent>>().Publish(new TriggerEngineEvent(TriggerEngineEvent.TriggerEvent.NewScene, null));
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SceneChangeEvent>>().Publish(new SceneChangeEvent() { SceneName = "" });
                            VRWorld.Instance.CurrentSceneFileName = "";
                        }
                    }
                    break;
                case "SaveScene":
                    {
                        if (!string.IsNullOrEmpty(VRWorld.Instance.CurrentSceneFileName))
                        {
                            string sceneFileName = Path.GetFileNameWithoutExtension(VRWorld.Instance.CurrentSceneFileName);
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SceneChangeEvent>>().Publish(new SceneChangeEvent() { SceneName = sceneFileName });
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<TriggerEngineEvent>>().Publish(new TriggerEngineEvent(TriggerEngineEvent.TriggerEvent.SaveScene, VRWorld.Instance.CurrentSceneFileName));
                            MessageBox.Show("저장되었습니다.", "씬 저장완료", MessageBoxButtons.OK);
                            return;
                        }
                        SaveFileDialog saveFileDlg = new SaveFileDialog();
                        string InitDir = VRWorld.Instance.AssetsDir.Replace("/", "\\");
                        saveFileDlg.InitialDirectory = InitDir;
                        saveFileDlg.Filter = "Scene File {*.fsf}|*.fsf";
                        saveFileDlg.AutoUpgradeEnabled = true;
                        saveFileDlg.Title = "씬 저장";
                        DialogResult result = saveFileDlg.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string saveSceneFilePath = saveFileDlg.FileName.Replace("\\", "/");
                            string sceneFileName = Path.GetFileNameWithoutExtension(saveSceneFilePath);
                            VRWorld.Instance.CurrentSceneFileName = saveSceneFilePath;
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SceneChangeEvent>>().Publish(new SceneChangeEvent() { SceneName = sceneFileName });
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<TriggerEngineEvent>>().Publish(new TriggerEngineEvent(TriggerEngineEvent.TriggerEvent.SaveScene, saveSceneFilePath));
                        }
                    }
                    break;
                case "SaveSceneas":
                    {
                        SaveFileDialog saveFileDlg = new SaveFileDialog();
                        string InitDir = VRWorld.Instance.AssetsDir.Replace("/", "\\");
                        saveFileDlg.InitialDirectory = InitDir;
                        saveFileDlg.Filter = "Scene File {*.fsf}|*.fsf";
                        saveFileDlg.AutoUpgradeEnabled = true;
                        saveFileDlg.Title = "다른이름으로 씬 저장";
                        DialogResult result = saveFileDlg.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string saveSceneFilePath = saveFileDlg.FileName.Replace("\\", "/");
                            string sceneFileName = Path.GetFileNameWithoutExtension(saveSceneFilePath);
                            VRWorld.Instance.CurrentSceneFileName = saveSceneFilePath;
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SceneChangeEvent>>().Publish(new SceneChangeEvent() { SceneName = sceneFileName });
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<TriggerEngineEvent>>().Publish(new TriggerEngineEvent(TriggerEngineEvent.TriggerEvent.SaveScene, saveSceneFilePath));
                        }
                        break;
                    }
                case "OpenScene":
                    {
                        if (!string.IsNullOrEmpty(VRWorld.Instance.CurrentSceneFileName))
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<TriggerEngineEvent>>().Publish(new TriggerEngineEvent(TriggerEngineEvent.TriggerEvent.SaveScene, VRWorld.Instance.CurrentSceneFileName));
                        OpenFileDialog openFileDlg = new OpenFileDialog();
                        string InitDir = VRWorld.Instance.AssetsDir.Replace("/", "\\");
                        openFileDlg.InitialDirectory = InitDir;
                        openFileDlg.Filter = "Scene File {*.fsf}|*.fsf";
                        openFileDlg.Title = "씬 열기";
                        DialogResult result = openFileDlg.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string loadSceneFilePath = openFileDlg.FileName.Replace("\\", "/");
                            VRWorld.Instance.CurrentSceneFileName = loadSceneFilePath;
                            string sceneFileName = Path.GetFileNameWithoutExtension(loadSceneFilePath);
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<TriggerEngineEvent>>().Publish(new TriggerEngineEvent(TriggerEngineEvent.TriggerEvent.LoadScene, loadSceneFilePath));
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish("ReloadScene");
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = null });
                        }
                    }
                    break;
                case "OpenProject":
                    {
                        FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                        folderDlg.Description = "프로젝트 열기";
                        DialogResult result = folderDlg.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string ProjectDir = folderDlg.SelectedPath;
                            if (Directory.Exists(AppDataFile))
                            {
                                using (StreamReader sr = new StreamReader(AppDataFile))
                                {
                                    string OneLine;
                                    while ((OneLine = sr.ReadLine()) != null)
                                    {
                                        string[] OneLineDatas = OneLine.Split(new char[] { ',' });
                                        ProjectModel pm = new ProjectModel() { FolderName = OneLineDatas[0], FolderPath = OneLineDatas[1] };
                                        ProjectList.Add(pm);
                                    }
                                }
                                using (StreamWriter sw = new StreamWriter(AppDataFile))
                                {
                                    string newProjectpath = ProjectDir.Replace("\\", "/");
                                    foreach (var existProjectInfo in ProjectList)
                                    {
                                        if (!(existProjectInfo.FolderPath + existProjectInfo.FolderName).Equals(newProjectpath))
                                            sw.WriteLine(existProjectInfo.FolderName + "," + existProjectInfo.FolderPath);
                                    }
                                    string lastPath = newProjectpath.Split(new char[] { '/' }).Last();
                                    string pastpath = newProjectpath.Replace(lastPath, "");
                                    sw.WriteLine(lastPath + "," + pastpath);
                                }
                            }
                            Process.Start(System.AppDomain.CurrentDomain.BaseDirectory + @"\VRCAT.exe", ProjectDir);
                            Process.GetCurrentProcess().Kill();
                        }
                    }
                    break;
                case "NewProject":
                    {
                        FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                        folderDlg.ShowNewFolderButton = true;
                        folderDlg.Description = "신규 프로젝트 생성";
                        DialogResult result = folderDlg.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string ProjectDir = folderDlg.SelectedPath;
                            string NewWorkDir = ProjectDir + @"\ProjectSettings";

                            Directory.CreateDirectory(NewWorkDir);
                            string findProjectSettingFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ProjectSettings/");
                            string[] files = Directory.GetFiles(VRWorld.Instance.ProjectSettingsDir);
                            foreach (string file in files)
                            {
                                string fileName = Path.GetFileName(file);
                                File.Copy(file, NewWorkDir + @"\" + fileName);
                            }


                            string assetDir = ProjectDir + @"\Assets";
                            if (!Directory.Exists(assetDir))
                                Directory.CreateDirectory(assetDir);

                            string ScriptDir = ProjectDir + @"\Script";
                            if (!Directory.Exists(ScriptDir))
                                Directory.CreateDirectory(ScriptDir);

                            string TempDir = ProjectDir + @"\Temp";
                            if (!Directory.Exists(TempDir))
                                Directory.CreateDirectory(TempDir);
                            string TempScriptDir = TempDir + @"\Script";
                            string TempScriptObjDir = TempScriptDir + @"\Obj";
                            if (!Directory.Exists(TempScriptDir))
                                Directory.CreateDirectory(TempScriptDir);
                            if (!Directory.Exists(TempScriptObjDir))
                                Directory.CreateDirectory(TempScriptObjDir);

                            Process.Start(System.AppDomain.CurrentDomain.BaseDirectory + @"\VRCAT.exe", ProjectDir);
                            Process.GetCurrentProcess().Kill();
                        }
                    }
                    break;
                case "Exit":
                    {
                        DialogResult result = MessageBox.Show("작업 씬을 종료하시겠습니까?", "알림", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("SaveScene"));
                            Process.GetCurrentProcess().Kill();
                        }
                        else if (result == DialogResult.No)
                            Process.GetCurrentProcess().Kill();
                    }
                    break;
            }
        }
    }
    internal class ProjectModel
    {
        public string FolderName { get; set; }
        public string FolderPath { get; set; }

    }
}
