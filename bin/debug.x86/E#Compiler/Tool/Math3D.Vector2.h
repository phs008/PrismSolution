#pragma once


namespace Math3D
{


struct Vector2 : public $__Object__$
{
public: float x;
public: float y;
public: static void Zero(Vector2* $ReturnValueParam$);
public: Vector2();
public: Vector2(float fx, float fy);
public: Vector2(Vector2* $StructParam0$);
public: static void $Operator_PLUS$(Vector2* $StructParamLeftOperand$);
public: static void $Operator_MINUS$(Vector2* $StructParamLeftOperand$);
public: static void $Operator_PLUS$(Vector2* $StructParamLeftOperand$, Vector2* $StructParamRightOperand$);
public: static void $Operator_MINUS$(Vector2* $StructParamLeftOperand$, Vector2* $StructParamRightOperand$);
public: static void $Operator_TIMES$(Vector2* $StructParamLeftOperand$, float f);
public: static void $Operator_DIVIDE$(Vector2* $StructParamLeftOperand$, float f);
public: static void $Operator_TIMES$(float f, Vector2* $StructParamRightOperand$);
public: static void $Operator_TIMES$(Vector2* $StructParamLeftOperand$, Vector2* $StructParamRightOperand$);
public: static void $Operator_DIVIDE$(Vector2* $StructParamLeftOperand$, Vector2* $StructParamRightOperand$);
public: static bool $Operator_EQUAL$(Vector2* $StructParamLeftOperand$, Vector2* $StructParamRightOperand$);
public: static bool $Operator_NOTEQUAL$(Vector2* $StructParamLeftOperand$, Vector2* $StructParamRightOperand$);
public: void Normalize();
public: float Length();
public: float LengthSq();
public: Vector2();
public:void $CopyForStructureType$(Vector2* rhs);
};

}
