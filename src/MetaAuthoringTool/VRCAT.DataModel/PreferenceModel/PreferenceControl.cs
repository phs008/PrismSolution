using Newtonsoft.Json;
using System.IO;

namespace VRCAT.DataModel
{
    public class PreferenceControl
    {
        static PreferenceControl _Instance;
        public static PreferenceControl GetInstance()
        {
            if (_Instance == null)
                _Instance = new PreferenceControl();
            return _Instance;
        }

        string _PreferencePath = "";
        public PreferenceModel preferenceModel;
        PreferenceControl()
        {
            preferenceModel = new PreferenceModel();
        }
        public bool LoadPreference(string PreferencePath)
        {
            this._PreferencePath = PreferencePath;
            string jsonVal = File.ReadAllText(PreferencePath);
            preferenceModel = JsonConvert.DeserializeObject<PreferenceModel>(jsonVal);
            if (preferenceModel != null)
                return true;
            else
                return false;
        }
        public void SavePreference()
        {
            string jsonVal = JsonConvert.SerializeObject(preferenceModel);
            if (string.IsNullOrEmpty(_PreferencePath))
                _PreferencePath = Path.Combine(VRWorld.Instance.ProjectSettingsDir, "Preference.dat");
            File.WriteAllText(_PreferencePath, jsonVal);
        }
    }
}
