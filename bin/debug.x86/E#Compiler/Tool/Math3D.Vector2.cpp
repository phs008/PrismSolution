#include "ESharp.h"
#include "ESDllInterface.h"
#include "Engine.h"
#include "Math3D.Vector2.h"


namespace Math3D
{


void Vector2::Zero(Vector2* $ReturnValueParam$)
{
{
$ReturnValueParam$->$CopyForStructureType$(new Vector2(0, 0));
return;
}
;
}


Vector2::Vector2()
{
}


Vector2::Vector2(float fx, float fy)
{
x = fx;
y = fy;
}


Vector2::Vector2(Vector2* $StructParam0$)
{
Vector2* v = new Vector2();
v->$CopyForStructureType$(v, $StructParam0$);

x = v::x;
y = v::y;
}


void Vector2::$Operator_PLUS$(Vector2* $StructParamLeftOperand$)
{
Vector2* v = new Vector2();
v->$CopyForStructureType$($StructParamLeftOperand$);

{
$ReturnValueParam$->$CopyForStructureType$(v);
return;
}
;
}


void Vector2::$Operator_MINUS$(Vector2* $StructParamLeftOperand$)
{
Vector2* v = new Vector2();
v->$CopyForStructureType$($StructParamLeftOperand$);

{
$ReturnValueParam$->$CopyForStructureType$(new Vector2((-v->x), (-v->y)));
return;
}
;
}


void Vector2::$Operator_PLUS$(Vector2* $StructParamLeftOperand$, Vector2* $StructParamRightOperand$)
{
Vector2* v0 = new Vector2();
v0->$CopyForStructureType$($StructParamLeftOperand$);
Vector2* v = new Vector2();
v->$CopyForStructureType$($StructParamRightOperand$);

{
$ReturnValueParam$->$CopyForStructureType$(new Vector2((v0->x+v->x), (v0->y+v->y)));
return;
}
;
}


void Vector2::$Operator_MINUS$(Vector2* $StructParamLeftOperand$, Vector2* $StructParamRightOperand$)
{
Vector2* v0 = new Vector2();
v0->$CopyForStructureType$($StructParamLeftOperand$);
Vector2* v = new Vector2();
v->$CopyForStructureType$($StructParamRightOperand$);

{
$ReturnValueParam$->$CopyForStructureType$(new Vector2((v0->x-v->x), (v0->y-v->y)));
return;
}
;
}


void Vector2::$Operator_TIMES$(Vector2* $StructParamLeftOperand$, float f)
{
Vector2* v = new Vector2();
v->$CopyForStructureType$($StructParamLeftOperand$);

{
$ReturnValueParam$->$CopyForStructureType$(new Vector2((v->x*f), (v->y*f)));
return;
}
;
}


void Vector2::$Operator_DIVIDE$(Vector2* $StructParamLeftOperand$, float f)
{
Vector2* v = new Vector2();
v->$CopyForStructureType$($StructParamLeftOperand$);

{
$ReturnValueParam$->$CopyForStructureType$(new Vector2((v->x/f), (v->y/f)));
return;
}
;
}


void Vector2::$Operator_TIMES$(float f, Vector2* $StructParamRightOperand$)
{
Vector2* v = new Vector2();
v->$CopyForStructureType$($StructParamRightOperand$);

{
$ReturnValueParam$->$CopyForStructureType$(new Vector2((f*v->x), (f*v->y)));
return;
}
;
}


void Vector2::$Operator_TIMES$(Vector2* $StructParamLeftOperand$, Vector2* $StructParamRightOperand$)
{
Vector2* v = new Vector2();
v->$CopyForStructureType$($StructParamLeftOperand$);
Vector2* v2 = new Vector2();
v2->$CopyForStructureType$($StructParamRightOperand$);

{
$ReturnValueParam$->$CopyForStructureType$(new Vector2((v->x*v2->x), (v->y*v2->y)));
return;
}
;
}


void Vector2::$Operator_DIVIDE$(Vector2* $StructParamLeftOperand$, Vector2* $StructParamRightOperand$)
{
Vector2* v = new Vector2();
v->$CopyForStructureType$($StructParamLeftOperand$);
Vector2* v2 = new Vector2();
v2->$CopyForStructureType$($StructParamRightOperand$);

{
$ReturnValueParam$->$CopyForStructureType$(new Vector2((v->x/v2->x), (v->y/v2->y)));
return;
}
;
}


bool Vector2::$Operator_EQUAL$(Vector2* $StructParamLeftOperand$, Vector2* $StructParamRightOperand$)
{
Vector2* v = new Vector2();
v->$CopyForStructureType$($StructParamLeftOperand$);
Vector2* v1 = new Vector2();
v1->$CopyForStructureType$($StructParamRightOperand$);

return ((v1->x==v->x)&&(v1->y==v->y));
}


bool Vector2::$Operator_NOTEQUAL$(Vector2* $StructParamLeftOperand$, Vector2* $StructParamRightOperand$)
{
Vector2* v = new Vector2();
v->$CopyForStructureType$($StructParamLeftOperand$);
Vector2* v1 = new Vector2();
v1->$CopyForStructureType$($StructParamRightOperand$);

return ((v1->x!=v->x)||(v1->y!=v->y));
}


void Vector2::Normalize()
{
float norm = ;
norm = Length();
if ((norm==0.0f))
{
x = 0.0f;
y = 0.0f;
}
else
{
x = (x/norm);
y = (y/norm);
}
}


float Vector2::Length()
{
return 0;
}


float Vector2::LengthSq()
{
return ((x*x)+(y*y));
}


Vector2::Vector2()
{
}


void Vector2::$CopyForStructureType$(Vector2* rhs)
{
this->x = rhs->x;
this->y = rhs->y;
}

}
