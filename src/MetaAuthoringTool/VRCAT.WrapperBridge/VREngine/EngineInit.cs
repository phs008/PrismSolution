using Microsoft.Practices.Prism.PubSubEvents;
using MVRWrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using VRCAT.DataModel;
using VRCAT.DataModel.Event;
using VRCAT.Infrastructure;

namespace VRCAT.WrapperBridge
{
    public class EngineInit
    {
        static EngineInit _engineInstacne;
        public static EngineInit GetInstance
        {
            get
            {
                if (_engineInstacne == null)
                    _engineInstacne = new EngineInit();
                return _engineInstacne;
            }
        }
        bool _IsEngineInit = false;
        public bool IsEngineInit
        {
            get { return _IsEngineInit; }
        }
        delegate void TestDelegate(string param);
        public void EngineInitStart()
        { 
            MLog.GetInstance().SetLog("WrapperBridge Init");
            MWorld.SetProjectSetting(DataModel.VRWorld.Instance.ProjectDir);
            IntPtr windowHandle = new WindowInteropHelper(Application.Current.MainWindow).Handle;
            MContext.InitializeSound(windowHandle.ToInt32());

            if (VRCAT.DataModel.PreferenceControl.GetInstance().preferenceModel._isprbmode.IsPRBMode)
                MEngineConfig.GetInstance().SetRenderPBR(true);
            else
                MEngineConfig.GetInstance().SetRenderPBR(false);

            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Subscribe(param =>
            {
                if(param.ClickMenuHeader == "Build")
                {
                    Build();
                }
            });
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<TriggerEngineEvent>>().Subscribe(param =>
            {
                switch (param.Event)
                {
                    case TriggerEngineEvent.TriggerEvent.NewScene:
                        VRWorld.Instance.LasetedSelectedContainer = null;
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = null });
                        MWorld.GetInstance().NewWorld();
                        MGizmoHandler.GetInstance().DetachAllGizmo();
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish("SceneLoading");
                        break;
                    case TriggerEngineEvent.TriggerEvent.SaveScene:
                        MWorld.GetInstance().SaveScene(param.Value.ToString());
                        break;
                    case TriggerEngineEvent.TriggerEvent.LoadScene:
                        LoadingAnimation window = new LoadingAnimation();
                        window.Show();
                        string loadSceneFilePath = param.Value.ToString().Replace("\\", "/");
                        VRWorld.Instance.CurrentSceneFileName = loadSceneFilePath;
                        VRWorld.Instance.LasetedSelectedContainer = null;
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SelectedObjectEvent>>().Publish(new SelectedObjectEvent() { SelectedObject = null });
                        string sceneFileName = Path.GetFileNameWithoutExtension(loadSceneFilePath);
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SceneChangeEvent>>().Publish(new SceneChangeEvent() { SceneName = sceneFileName });
                        MWorld.GetInstance().LoadScene(param.Value.ToString());
                        window.Close();
                        MGizmoHandler.GetInstance().DetachAllGizmo();
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish("SceneLoading");
                        break;
                }
            });

            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<GizmoChangeEvent>>().Subscribe(param =>
            {
                switch (param.eventArg)
                {
                    case GizmoEventArg.Position:
                        MGizmoHandler.GetInstance().SetGizmoType(0);
                        VRWorld.Instance.GizmoType = 0;
                        break;
                    case GizmoEventArg.Rotation:
                        MGizmoHandler.GetInstance().SetGizmoType(2);
                        VRWorld.Instance.GizmoType = 2;
                        break;
                    case GizmoEventArg.Scale:
                        MGizmoHandler.GetInstance().SetGizmoType(1);
                        VRWorld.Instance.GizmoType = 1;
                        break;
                }
            });

            /// TODO : AssetView 에서 FBX 관련 파싱 메세지 처리
            
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ImportFBX>>().Subscribe(e =>
            {
                LoadingAnimation window = new LoadingAnimation();
                window.Show();
                if (VRWorld.Instance.ParshingFBXList.Count > 0)
                {
                    
                    foreach (string FBXPath in VRWorld.Instance.ParshingFBXList)
                    {
                        if (MFbx.ImportFBXSource(FBXPath))
                            File.Delete(FBXPath);
                    }
                    VRWorld.Instance.ParshingFBXList.Clear();
                    
                }
                if(VRWorld.Instance.ParshingFBXListFromFileWatcher.Count >0)
                {
                    string FBXPath;
                    while(VRWorld.Instance.ParshingFBXListFromFileWatcher.TryDequeue(out FBXPath))
                    {
                        if (MFbx.ImportFBXSource(FBXPath))
                            File.Delete(FBXPath);
                    }
                }
                window.Close();
            });
            _IsEngineInit = true;
        }

        public void Build()
        {
            /// eslist 를 추가합니다.
            string[] ScriptFiles = Directory.GetFiles(VRWorld.Instance.AssetsDir, "*.cs", SearchOption.AllDirectories);
            string eslistFilePath = VRWorld.Instance.ProjectDir + @"\Temp\Script\eslist";
            StreamWriter sf = new StreamWriter(eslistFilePath, false);
            //fs = File.OpenWrite(eslistFilePath);
            string removePath = VRWorld.Instance.ProjectDir + @"\";
            for (int i = 0; i < ScriptFiles.Length; i++)
            {
                string file = ScriptFiles[i];
                file = file.Replace(removePath, "");
                file = file.Replace(@"\", "/");
                sf.WriteLine(file);
            }
            sf.Close();
            /// eslist 추가 종료.


            string firstArg = Environment.CurrentDirectory + @"\E#Compiler";
            string SecondArg = VRWorld.Instance.ProjectDir;
            if (SecondArg.Last().Equals('\\'))
                SecondArg = SecondArg.Remove(SecondArg.Length - 1, 1);
            string compiler = Environment.CurrentDirectory + @"\E#Compiler\esc.bat";
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = compiler;
            p.StartInfo.Arguments = firstArg + " " + SecondArg;
            p.Start();
            p.WaitForExit();
            if (p.ExitCode != 0)
                MessageBox.Show("컴파일이 실패했습니다. 확인해주세요", "컴파일 실패", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
