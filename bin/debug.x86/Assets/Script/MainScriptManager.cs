public class MainScriptManager : EActor
{
    #region Property
    Container MainContainer;
    Container SoundContainer;
    Container GestureContainer;
    Container FireContainer;
    Container CatchGameContainer;
    Container CameraContainer;

    #endregion

    #region Init
    ScriptComponent Mainscript;
    ScriptComponent Soundscript;
    ScriptComponent Gesturescript;
    ScriptComponent Firescript;
    ScriptComponent CatchGamescript;
    ScriptComponent Camerascript;
    #endregion

    bool isAwake = false;

    public override int OnMessage(string msg, int arg0, Vector4 arg1, Vector4 arg2)
    {
        if(msg == "LButtonDown")
        {
            CatchGamescript.SendMessage("", 0, new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0));
        }
    }

    public void Awake()
    {

    }

    public override int Update()
    {
        if (isAwake == false)
        {
            Awake();
            isAwake = true;
            Log("Awake Play", 0, 0);
        }
    }
}