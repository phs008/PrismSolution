using System.ComponentModel.Composition;
using System.Windows;
using Microsoft.Practices.Prism.Regions;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout.Serialization;
using VRCAT.Infrastructure.PrismAvalonExtensions;
using System;
using Xceed.Wpf.AvalonDock.Layout;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Interop;
using System.Diagnostics;
using System.Windows.Media;
using VRCAT.DataModel;
using Microsoft.Practices.Prism.PubSubEvents;
using VRCAT.Infrastructure;
using System.Windows.Interop;
using VRCAT.View;
using System.Windows.Input;
using VRCAT.DataModel.Event;
using WPFXCommand;

namespace VRCAT
{
    /// <summary>
    /// Main UI
    /// </summary>
    [Export(typeof(ShellView))]
    public partial class ShellView : Window
    {
        ICommand _UndoCommand = new RelayCommand(delegate (object o)
        {
            StateManager.Instance.UndoState();
        });
        ICommand _RedoCommand = new RelayCommand(delegate (object o)
        {
            StateManager.Instance.RedoState();
        });

        /// <summary>
        /// 생성자
        /// </summary>
        public ShellView()
        {
            InitializeComponent();
            this.Loaded += ShellView_Loaded;
            this.SourceInitialized += ShellView_SourceInitialized;
            KeyBinding UndoKey = new KeyBinding(_UndoCommand, new KeyGesture(Key.Z, ModifierKeys.Control));
            KeyBinding RedoKey = new KeyBinding(_RedoCommand, new KeyGesture(Key.X, ModifierKeys.Control));
            if (!Application.Current.MainWindow.InputBindings.Contains(UndoKey))
                Application.Current.MainWindow.InputBindings.Add(UndoKey);
            if (!Application.Current.MainWindow.InputBindings.Contains(RedoKey))
                Application.Current.MainWindow.InputBindings.Add(RedoKey);
        }

        void ShellView_SourceInitialized(object sender, EventArgs e)
        {
            System.IntPtr handle = (new WindowInteropHelper(this)).Handle;
            HwndSource.FromHwnd(handle).AddHook(new HwndSourceHook(WindowMaximizeManager.WindowProc));
        }

        void ShellView_Loaded(object sender, RoutedEventArgs e)
        {
            this.SizeChanged += ShellView_SizeChanged;
            Eventer.Instance.EventAggregator.GetEvent<PubSubEvent<SceneChangeEvent>>().Subscribe(param =>
            {
                this.TextBox_SceneName.Text = "Title : " + param.SceneName;
            });
        }

        void ShellView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (File.Exists(VRWorld.Instance.LayoutPath))
                    SerializationHelper.Serialize(DockingManager, VRWorld.Instance.LayoutPath);
                else
                    SerializationHelper.Serialize(DockingManager, "layout.xl.xa");

                ///Preference 파일 저장
                PreferenceControl.GetInstance().SavePreference();
                //GuidAssetMapSerialize();
            }
            catch(Exception ex)
            {

            }
        }
        private void GuidAssetMapSerialize()
        {
            string filePath = Path.Combine(VRWorld.Instance.ProjectDir, "Library/GuidAssetBin.data");
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryWriter writer = new BinaryWriter(fs);
                writer.Write(VRWorld.Instance.GuidAssetMap.Count);
                foreach (var kvp in VRWorld.Instance.GuidAssetMap)
                {
                    writer.Write(kvp.Key);
                    writer.Write(kvp.Value.ToString());
                }
                writer.Flush();
            }
        }
        
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
                ChangeWindowState();
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
                this.DragMove();
        }

        private void close_program(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void minimize_program(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void maximize_program(object sender, RoutedEventArgs e)
        {
            ChangeWindowState();
        }
        void ChangeWindowState()
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
                this.WindowState = System.Windows.WindowState.Normal;
            else
                this.WindowState = System.Windows.WindowState.Maximized;
        }
    }
}
