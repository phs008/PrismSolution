public class EActor
{
	public virtual int Update()
	{
		return 0;
	}


	public virtual int OnMessage(string msg, int arg0, Vector4 arg1, Vector4 arg2)
	{
		return 0;
	}


	public void Log(string log, int v1, float v2);
	public int MsgBox(string log, int msgboxType);
}
