public class RotationActor : EActor
{
	Container T;
    int a;
private int j;
	public override int Update()
	{
		TransformGroup trans = (TransformGroup)T.FindComponentByType("TransformGroup");
		if(trans != null)
		{
			Vector3 Pos;
			trans.Rotate(5,0,trans.GetPosition());
			return 1;			
		}

		else 
			return 0;
	}
}
