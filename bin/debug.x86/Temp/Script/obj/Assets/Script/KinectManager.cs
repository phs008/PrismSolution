public class KinectManager : EActor
{

    Container KinectContainer;

    Container CharacterContainer;
    Container ObjectContainer;



    World world;

    KinectSkeletonComponent kinect;

    TransformGroup Character_trans;
    TransformGroup Object_trans;


    bool isAwake = false;

    bool isPrevPosSaved = false;

    bool isDebug;

    Vector3 prevPos;
    Vector3 PlayerPos;
    Vector3 distPos;

    Vector3 destPos;

    public override int OnMessage(string msg, int arg0, Vector4 arg1, Vector4 arg2)
    {

    }

    public void Awake()
    {
        isDebug = false;

        kinect = (KinectSkeletonComponent)KinectContainer.FindComponentByType("KinectSkeletonComponent");

        Character_trans = (TransformGroup)CharacterContainer.FindComponentByType("TransformGroup");
        Object_trans = (TransformGroup)ObjectContainer.FindComponentByType("TransformGroup");
        world = (World)KinectContainer.GetRootContainer();
        prevPos = new Vector3(0, 0, 0);
        PlayerPos = new Vector3(0, 0, 0);
        distPos = new Vector3(0, 0, 0);

        destPos = new Vector3(0, 0, 0);

        isPrevPosSaved = false;
    }

    public override int Update()
    {
        if(isAwake == false)
        {
            Awake();
            isAwake = true;
            DegugLog("Awake OK", 0, 0);
        }
        else
        {
            this.Move();
        }
    }

    public void Move()
    {
        DegugLog("Move Start", 0, 0);

        if (kinect != null)
        {
            DegugLog("kinect != null", 0, 0);
            int found = -1;
            for (int i = 0; i < 6; i++)
            {
                kinect.PropKinectSkeleton.GroupIndex = i;
                if (kinect.PropKinectSkeleton.GetTracked() > 0)
                {
                    found = i;
                    break;
                }
            }

            if (found >= 0)
            {
                PlayerPos = kinect.PropKinectSkeleton.GetSpineBase();
                DegugLog("GetSpineBase OK", 0, 0);
                if (isPrevPosSaved == false)
                {
                    prevPos = PlayerPos;
                    DegugLog("prevPos Save OK", 0, 0);
                    isPrevPosSaved = true;
                    return;
                }

                distPos = PlayerPos - prevPos;
                DegugLog("distPos.x = ", 0, distPos.x);
                DegugLog("distPos.y = ", 0, distPos.y);
                DegugLog("distPos.z = ", 0, distPos.z);
                prevPos = PlayerPos;

                destPos = Character_trans.PropTransform.GetPosition() + distPos;
                Character_trans.PropTransform.SetPosition(destPos);
                DegugLog("SetPosition OK", 0, 0);
            }
        }
    }

    public void DegugLog(string text, int n, float f)
    {
        if(isDebug)
            Log(text, n, f);
    }
}
