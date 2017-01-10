using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.DataModel
{
    [Serializable]
    public class EtcMeta : MetaBase, ISerializable
    {
        public EtcMeta(string FilePath)
            :base(FilePath)
        {
            base.MetaType = MetaTypeEnum.Etc;
        }
        public EtcMeta(SerializationInfo info,StreamingContext context)
            :base(info,context)
        {

        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
