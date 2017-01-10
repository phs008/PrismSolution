
public class JSCscene1 : EActor
{
    Container temp;

      public override int OnMessage(string msg, int arg0, Vector4 arg1, Vector4 arg2)
    {

        if (msg == "LButtonDown")
        {
            ScriptComponent cubeAscript = (ScriptComponent)temp.FindComponentByType("ScriptComponent");

            if (cubeAscript != null)
            {
                cubeAscript.TimedMessage("MoveCubeMan", 1.0f, 0, new Vector4(0.0, 0.0, 0.0, 0.0), new Vector4(0.0, 0.0, 0.0, 0.0));

            }

        }



        return 0;
    }

    public override int Update()
    {
        return 0;
    }
}
