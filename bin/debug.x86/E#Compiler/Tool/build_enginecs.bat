rem copy ..\ESLibrary\pch\EActor.cs .

copy ..\ESLibrary\pch\System.csi .
copy ..\ESLibrary\pch\Engine.cs .

esc -c Math3D.Vector2.cs System.csi Math3D.Vector3.csi
esc -c Math3D.Vector3.cs System.csi 
esc -c Math3D.Vector4.cs System.csi Math3D.Vector3.csi Math3D.Vector2.csi
esc -c Math3D.Matrix4x4.cs System.csi 
esc -c Math3D.Quaternion.cs System.csi 
esc -c Math3D.Color.cs System.csi 
esc -c Math3D.BoundingBox.cs System.csi 
esc -c Engine.cs System.csi Math3D.Vector2.csi Math3D.Vector3.csi Math3D.Vector4.csi Math3D.Quaternion.csi Math3D.Matrix4x4.csi Math3D.Color.csi Math3D.BoundingBox.csi 
esc -c EActor.cs System.csi Engine.csi Math3D.Vector2.csi Math3D.Vector3.csi Math3D.Vector4.csi  Math3D.Quaternion.csi Math3D.Matrix4x4.csi Math3D.Color.csi Math3D.BoundingBox.csi

copy *.ast ..\ESLibrary\pch
copy *.csi ..\ESLibrary\pch
copy *.cs ..\ESLibrary\pch


pause
