using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.DataModel
{
    public class PreferenceModel
    {
        internal PreferenceModel()
        {
            _general = new _General();
            _external = new _External();
            _hotkeys = new _Hotkeys();
            _isprbmode = new _IsPBRMode();
        }
        public _General _general;
        public _External _external;
        public _Hotkeys _hotkeys;
        public _IsPBRMode _isprbmode;
    }
    public class _General
    {
        public bool AutoSavePlaying = false;
    }
    public class _External
    {
        internal _External()
        {
            __externalscripttool = new __ExternalScriptTool();
            __externalimagetool = new __ExternalImageTool();
        }
        public __ExternalScriptTool __externalscripttool;
        public __ExternalImageTool __externalimagetool;
    }
    public class _Hotkeys
    { }
    public class __ExternalScriptTool
    {
        public string ProgramPath = "";
        public bool AutomaticGenerateSln = false;
    }
    public class __ExternalImageTool
    {
        public string ProgramPath = "";
    }
    public class _IsPBRMode
    {
        public bool IsPRBMode = false;
    }
}
