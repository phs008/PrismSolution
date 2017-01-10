using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.DataModel
{
    [Serializable]
    public class FbxMeta : MetaBase , ISerializable
    {
        public FbxMeta(string FilePath)
            :base(FilePath)
        {
            base.MetaType = MetaTypeEnum.Model3D;
        }
        public FbxMeta(SerializationInfo info,StreamingContext context)
            :base(info,context)
        {

        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
