public class ScaleActor : EActor
{
	Container T;

	public override int Update()
	{
		TransformGroup trans = (TransformGroup)T.FindComponentByType("TransformGroup");
		if(trans != null)
		{
			Vector3 scaleV; 
			scaleV = trans.GetScale();
			if(scaleV.x < 10)
			{
				scaleV.x = 0;
				scaleV.y = 0;
				scaleV.z = 0;
			}
			scaleV.x += 0.05;
			scaleV.y += 0.05;
			scaleV.z += 0.05;
			trans.SetScale(scaleV);
			return 1;
		}
		else 
			return 0;
	}
}
