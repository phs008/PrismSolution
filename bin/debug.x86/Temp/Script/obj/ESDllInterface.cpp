#include "ESharp.h"
#include "ESDllInterface.h"
#include "Engine.h"
#include "Assets/Script/JSCscene1.h"
#include "Assets/Script/RotationActor.h"
#include "Assets/Script/RotationActor_fast.h"
#include "Assets/Script/ScaleActor.h"


const char* Fl2Es_GetCompilerVersion()
{
    return "20161214-001";
}


int Fl2Es_VRLangBegin()
{
    return 1;
}


void* Fl2Es_ActorCreate(char* classname, unsigned long UID)
{
    string classNameInString = classname;

    if (classNameInString == "JSCscene1")
    {
        JSCscene1* actor = new JSCscene1;
        return actor;
    }
    else if (classNameInString == "RotationActor")
    {
        RotationActor* actor = new RotationActor;
        return actor;
    }
    else if (classNameInString == "RotationActor_fast")
    {
        RotationActor_fast* actor = new RotationActor_fast;
        return actor;
    }
    else if (classNameInString == "ScaleActor")
    {
        ScaleActor* actor = new ScaleActor;
        return actor;
    }

    cout << "unknown class" << endl;
    return nullptr;
}
