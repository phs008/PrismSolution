using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VRCAT.Infrastructure;
using VRCAT.DataModel;
using VRCAT.DataModel.Event;
using System.Windows.Input;
using WPFXCommand;

namespace VRCAT.ToolBarModule
{
    /// <summary>
    /// ToolBarViewModel Class
    /// </summary>
    public class ToolBarViewModel : BindableBase
    {
        private IRegionManager _RegionManager;
        public IRegionManager RegionManager
        {
            get { return _RegionManager; }
            set { _RegionManager = value; }
        }
        /// <summary>
        /// FileMenu Click Binding Command
        /// </summary>
        public DelegateCommand<RoutedEventArgs> FileMenuClick { get; private set; }
        public DelegateCommand<RoutedEventArgs> EditMenuClick { get; private set; }
        public DelegateCommand<RoutedEventArgs> AssetMenuClick { get; private set; }
        /// <summary>
        /// GameObject Click Binding Command
        /// </summary>
        public DelegateCommand<RoutedEventArgs> GameObjectMenuClick { get; private set; }
        /// <summary>
        /// ViewMenu Click Binding Command
        /// </summary>
        public DelegateCommand<RoutedEventArgs> ViewMenuClick { get; private set; }
        /// <summary>
        /// ToolMenu Click Binding Command
        /// </summary>
        public DelegateCommand<RoutedEventArgs> ToolMenuClick { get; private set; }
        /// <summary>
        /// [작업용]
        /// TestMenu Click Binding Command
        /// </summary>
        public DelegateCommand<RoutedEventArgs> TestMenuClick { get; private set; }
        /// <summary>
        /// 기즈모 종류 선택 버튼 Command
        /// </summary>
        public DelegateCommand<string> GizmoBtnClickCommand { get; private set; }

        #region MenuItem ShortCut Command
        /// <summary>
        /// MenuItem 단축키 Command
        /// </summary>
        ICommand _KeyBindingCommand;
        public ICommand KeyBindingCommand
        {
            get
            {
                if (_KeyBindingCommand == null)
                    _KeyBindingCommand = new RelayCommand(KeyBindingFunction);
                return _KeyBindingCommand;
            }
        }

        ICommand _UndoCommand;
        public ICommand UndoCommand
        {
            get
            {
                if (_UndoCommand == null)
                    _UndoCommand = new RelayCommand(UndoCommandFunction);
                return _UndoCommand;
            }
        }
        private void UndoCommandFunction(object obj)
        {
            StateManager.Instance.UndoState();
        }
        ICommand _RedoCommand;
        public ICommand RedoCommand
        {
            get
            {
                if (_RedoCommand == null)
                    _RedoCommand = new RelayCommand(RedoCommandFunction);
                return _RedoCommand;
            }
        }
        private void RedoCommandFunction(object obj)
        {
            StateManager.Instance.RedoState();
        }
        /// <summary>
        /// MenuItem 에 대한 단축키 이벤트 바인딩
        /// </summary>
        /// <param name="obj"></param>
        private void KeyBindingFunction(object obj)
        {
            OnMenuCommand(obj.ToString());
        }
        #endregion

        #region Gizmo 버튼 Check 표시 변경을 위한 Binding 객체
        bool _PositionBtnISChecked = true;
        bool _ScaleBtnIsChecked = false;
        bool _RotationBtnIsChecked = false;
        public bool PositionBtnISChecked
        {
            get { return _PositionBtnISChecked; }
            set { SetProperty(ref _PositionBtnISChecked, value); }
        }

        public bool ScaleBtnIsChecked
        {
            get { return _ScaleBtnIsChecked; }
            set { SetProperty(ref _ScaleBtnIsChecked, value); }
        }

        public bool RotationBtnIsChecked
        {
            get { return _RotationBtnIsChecked; }
            set { SetProperty(ref _RotationBtnIsChecked, value); }
        }
        #endregion

        bool _PlayBtnChecked = false;
        public bool PlayBtnChecked
        {
            get { return _PlayBtnChecked; }
            set
            {
                if (value)
                    Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("AnimationPlay"));
                else
                {
                    Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("AnimationStop"));
                    PauseBtnIsChecked = false;
                }
                SetProperty(ref _PlayBtnChecked, value);
            }
        }
        bool _PauseBtnIsChecked = false;
        public bool PauseBtnIsChecked
        {
            get { return _PauseBtnIsChecked; }
            set
            {
                if(value && PlayBtnChecked)
                    Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("AnimationPause"));
                else if(PlayBtnChecked)
                    Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("AnimationPauseRelease"));
                SetProperty(ref _PauseBtnIsChecked, value);
            }
        }
        public DelegateCommand<string> PlayModelBtnCommand { get; private set; }
        public DelegateCommand NextStepBtnCommand { get; private set; }


        /// <summary>
        /// 생성자
        /// </summary>
        public ToolBarViewModel()
        {
            FileMenuClick = new DelegateCommand<RoutedEventArgs>(delegate(RoutedEventArgs e)
                {
                    MenuItem mi = e.Source as MenuItem;
                    OnMenuCommand(mi.Header.ToString());
                });
            EditMenuClick = new DelegateCommand<RoutedEventArgs>(delegate (RoutedEventArgs e)
                {
                    MenuItem mi = e.Source as MenuItem;
                    OnMenuCommand(mi.Header.ToString());
                });
            AssetMenuClick = new DelegateCommand<RoutedEventArgs>(delegate (RoutedEventArgs e)
            {
                MenuItem mi = e.Source as MenuItem;
                OnMenuCommand(mi.Header.ToString());
            });
            ViewMenuClick = new DelegateCommand<RoutedEventArgs>(delegate(RoutedEventArgs e)
                {
                    MenuItem mi = e.Source as MenuItem;
                    OnMenuCommand(mi.Header.ToString());
                });
            ToolMenuClick = new DelegateCommand<RoutedEventArgs>(delegate(RoutedEventArgs e)
              {
                  MenuItem mi = e.Source as MenuItem;
                  OnMenuCommand(mi.Header.ToString());
              });
            GameObjectMenuClick = new DelegateCommand<RoutedEventArgs>(delegate(RoutedEventArgs e)
                {
                    MenuItem mi = e.Source as MenuItem;
                    OnMenuCommand(mi.Header.ToString());
                });
            TestMenuClick = new DelegateCommand<RoutedEventArgs>(delegate(RoutedEventArgs e)
                {
                    MenuItem mi = e.Source as MenuItem;
                    OnMenuCommand(mi.Header.ToString());
                });
            GizmoBtnClickCommand = new DelegateCommand<string>(delegate (string e)
            {
                switch (e)
                {
                    case "Position":
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<GizmoChangeEvent>>().Publish(new GizmoChangeEvent() { eventArg = GizmoEventArg.Position });
                        PositionBtnISChecked = true;
                        RotationBtnIsChecked = false;
                        ScaleBtnIsChecked = false;
                        break;
                    case "Rotation":
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<GizmoChangeEvent>>().Publish(new GizmoChangeEvent() { eventArg = GizmoEventArg.Rotation });
                        PositionBtnISChecked = false;
                        RotationBtnIsChecked = true;
                        ScaleBtnIsChecked = false;
                        break;
                    case "Scale":
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<GizmoChangeEvent>>().Publish(new GizmoChangeEvent() { eventArg = GizmoEventArg.Scale });
                        PositionBtnISChecked = false;
                        RotationBtnIsChecked = false;
                        ScaleBtnIsChecked = true;
                        break;
                }
            });
            PlayModelBtnCommand = new DelegateCommand<string>(delegate (string e)
            {
                switch (e)
                {
                    case "PlayBtn":
                        if (!PlayBtnChecked)
                        {
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("AnimationPlay"));
                            PlayBtnChecked = true;
                        }
                        else
                        {
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("AnimationStop"));
                            PauseBtnIsChecked = false;
                            PlayBtnChecked = false;
                        }
                        break;
                    case "PauseBtn":
                        if (!PauseBtnIsChecked && PlayBtnChecked)
                        {
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("AnimationPause"));
                            PauseBtnIsChecked = true;
                        }
                        else if (PlayBtnChecked)
                        {
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("AnimationPauseRelease"));
                            PauseBtnIsChecked = false;
                        }
                        break;
                    case "Play":
                        {
                            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("SaveScene"));
                            if (!string.IsNullOrEmpty(VRWorld.Instance.CurrentSceneFileName))
                            {
                                string PlayerExePath = Environment.CurrentDirectory + "/Player.exe";
                                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(PlayerExePath);

                                string ChangeProjectFolder = VRWorld.Instance.ProjectDir.Replace(@"\", "/");
                                string RemoveProjectDir = VRWorld.Instance.CurrentSceneFileName.Replace(ChangeProjectFolder, "");
                                //Console.WriteLine(ChangeProjectFolder);
                                //Console.WriteLine(RemoveProjectDir);

                                ChangeProjectFolder = "\"" + ChangeProjectFolder + "\"";
                                RemoveProjectDir = "\"" + RemoveProjectDir + "\"";
                                startInfo.Arguments = ChangeProjectFolder + " " + RemoveProjectDir;

                                //Console.WriteLine(startInfo.Arguments);
                                startInfo.UseShellExecute = false;
                                System.Diagnostics.Process.Start(startInfo);
                            }
                        }
                        break;
                }
            });
            NextStepBtnCommand = new DelegateCommand(() =>
            {
                Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("AnimationStep"));
            });
        }
        /// <summary>
        /// MenuItem 에 대한 이벤트 처리
        /// </summary>
        /// <param name="e">MenuItem Header 이름</param>
        internal void OnMenuCommand(object e)
        {
            switch (e.ToString())
            {
                case "New Scene":
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("NewScene"));
                        break;
                    }
                case "Open Scene":
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("OpenScene"));
                        break;
                    }
                case "Save Scene":
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("SaveScene"));
                        break;
                    }
                case "Save Scene as":
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("SaveSceneas"));
                        break;
                    }
                case "New Project":
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("NewProject"));
                        break;
                    }
                case "Open Project":
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("OpenProject"));
                        break;
                    }
                case "ProjectSetting":
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("ProjectSetting"));
                        break;
                    }
                case "Build":
                    {
                        /// TODO : Build 처리
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("Build"));
                        break;
                    }
                case "Exit":
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("Exit"));
                        break;
                    }



                case "Undo":
                    StateManager.Instance.UndoState();
                    break;
                case "Redo":
                    StateManager.Instance.RedoState();
                    break;

                case "ShowExplorer":
                    System.Diagnostics.Process.Start("explorer.exe", VRWorld.Instance.AssetsDir);
                    break;

                case "Copy":
                    break;

                case "Paste":
                    break;

                case "Build Play":
                    break;

                case "Hierarchy":
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("AddHierarchyView"));
                        break;
                    }
                case "Inspector":
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("AddInspectorView"));
                        break;
                    }
                case "Asset":
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("AddAssetView"));
                        break;
                    }
                case "Scene":
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("AddSceneView"));
                        break;
                    }
                case "Game":
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("Game"));
                        break;
                    }

                case "MotionDevice Plugin":
                    Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<string>>().Publish("ShowMDWindow");
                    break;
                case "VRDevice Manager":
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("VRDevice Manager"));
                    }
                    break;
                case "Virtual User":
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("ShowVirtualUser"));
                    }
                    break;
                case "Cube":
                    {
                        break;
                    }
                case "Sphere":
                    {
                        string fbxPath = "/Default/Default3DModel/";
                        fbxPath += "sphere.FBX";
                        //AddBase3DObject("sphere", fbxPath);
                        object o = new string[] { "sphere", fbxPath };
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<object>>().Publish(o);
                        break;
                    }
                case "3Dof emulation":
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("ThreeDOF"));
                        break;
                    }
                case "1Dof emulation":
                    {
                        Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<ToolbarEvent>>().Publish(new ToolbarEvent("OneDOF"));
                        break;
                    }

            }
        }
    }
}
