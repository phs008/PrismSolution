using System;
using System.Windows.Controls;

namespace VRCAT.InspectorModule
{
    /// <summary>
    /// PreviewSoundControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PreviewSoundControl : UserControl
    {
        public PreviewSoundControl(string soundFilePath)
        {
            InitializeComponent();
            NAudioEngine soundEngine = NAudioEngine.Instance;
            //SpectrumAnalyzer.RegisterSoundPlayer(soundEngine);
            WaveformatTimeLine.RegisterSoundPlayer(soundEngine);
            if (System.IO.Path.GetExtension(soundFilePath) == ".mp3")
            {
                NAudioEngine.Instance.OpenFile(soundFilePath);
            }
            Unloaded += PreviewSoundControl_Unloaded;
        }

        private void PreviewSoundControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            NAudioEngine.Instance.Stop();
            NAudioEngine.Instance.Dispose();
        }

        private void PlayClick(object sender, System.Windows.RoutedEventArgs e)
        {
            NAudioEngine.Instance.Play();
        }

        private void StopClick(object sender, System.Windows.RoutedEventArgs e)
        {
            NAudioEngine.Instance.Stop();
        }
    }
}
