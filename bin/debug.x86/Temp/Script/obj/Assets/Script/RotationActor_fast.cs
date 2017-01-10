public class RotationActor_fast : EActor
{
	Container T;
	public override int Update()
	{
		TransformGroup trans = (TransformGroup)T.FindComponentByType("TransformGroup");
		if(trans != null)
		{
			Vector3 Pos;
			trans.Rotate(20,0,trans.GetPosition());
			return 1;
		}
		else 
			return 0;
	}
}
