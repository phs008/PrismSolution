using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VRCAT.DataModel
{
    [Serializable]
    public class TextureMeta : MetaBase , ISerializable
    {
        public double WidthPixel { get; set; }
        public double HeightPixel { get; set; }
        public BitmapPalette Palette { get; set; }
        public BitmapMetadata ImageMetaData { get; set; }
        public TextureMeta(string FilePath)
            :base(FilePath)
        {
            base.MetaType = MetaTypeEnum.Texture;
            SetTextureInfomation();
        }
        private void SetTextureInfomation()
        {
            BitmapFrame frame = BitmapFrame.Create(new Uri(this.OriginDataPath));
            this.WidthPixel = frame.Width;
            this.HeightPixel = frame.Height;
            this.Palette = frame.Palette;
            ReadOnlyCollection<ColorContext> c = frame.ColorContexts;
        }
        public TextureMeta(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.WidthPixel = info.GetDouble("WidthPixel");
            this.HeightPixel = info.GetDouble("HeightPixel");
            this.Palette = (BitmapPalette)info.GetValue("Palette", typeof(BitmapPalette));
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("WidthPixel", this.WidthPixel);
            info.AddValue("HeightPixel", this.HeightPixel);
            info.AddValue("Palette", this.Palette);
            base.GetObjectData(info, context);
        }
    }
}
