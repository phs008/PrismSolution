using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VRCAT.DataModel
{
    [Serializable]
    public abstract class MetaBase : ISerializable
    {
        public Guid uuid { get; set; }
        protected byte[] thumbNailImageData = null;
        public ImageSource ThumbNailImage { get; set; }
        public MetaTypeEnum MetaType { get; set; }
        public string OriginDataPath { get; set; }

        public MetaBase(string FilePath)
        {
            this.OriginDataPath = FilePath;
            ImageToThumbNail();
            SetThumbnailImage();
        }
        public MetaBase(SerializationInfo info,StreamingContext context)
        {
            this.uuid = (Guid)info.GetValue("uuid", typeof(Guid));
            this.OriginDataPath = (string)info.GetString("OriginDataPath");
            this.MetaType = (MetaTypeEnum)info.GetValue("MetaType", typeof(MetaTypeEnum));
            this.thumbNailImageData = (byte[])info.GetValue("thumbNailImageData", typeof(byte[]));
            if (this.thumbNailImageData.Count() >= 0)
                DataToThumbNail();
        }
        private void DataToThumbNail()
        {
            using(var mem = new MemoryStream(this.thumbNailImageData))
            {
                ThumbNailImage = new BitmapImage();
                ((BitmapImage)ThumbNailImage).BeginInit();
                ((BitmapImage)ThumbNailImage).CreateOptions = BitmapCreateOptions.None;
                ((BitmapImage)ThumbNailImage).CacheOption = BitmapCacheOption.OnLoad;
                ((BitmapImage)ThumbNailImage).StreamSource = mem;
                ((BitmapImage)ThumbNailImage).EndInit();
                //ThumbNailImage.Freeze();
            }
        }
        private void ImageToThumbNail()
        {
            string extension = Path.GetExtension(this.OriginDataPath).ToLower();
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.CacheOption = BitmapCacheOption.OnLoad;
            if (extension.Equals(".jpeg") || extension.Equals(".jpg") || extension.Equals(".bmp") || extension.Equals(".png"))
            {
                img.UriSource = new Uri(this.OriginDataPath);
                img.DecodePixelWidth = 256;
                img.DecodePixelHeight = 256;
            }
            else
            {
                if (GetRegistryImagePath.IconsInfo.Contains(extension))
                    img.UriSource = new Uri(GetRegistryImagePath.IconsInfo[extension].ToString());
                else
                    img.UriSource = new Uri(@"D:\test.png");
                if (!File.Exists(img.UriSource.LocalPath))
                    img.UriSource = new Uri(@"D:\test.png");
            }
            img.EndInit();

            ThumbNailImage = img;
        }
        private void SetThumbnailImage()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BitmapEncoder e = new PngBitmapEncoder();
                e.Frames.Add(BitmapFrame.Create((BitmapImage)ThumbNailImage));
                e.Save(stream);
                stream.Flush();
                thumbNailImageData = stream.ToArray();
            }
            string filePath = Environment.CurrentDirectory + "/imagetest/" + Path.GetFileName(this.OriginDataPath) + ".bmp";
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                BitmapEncoder e = new PngBitmapEncoder();
                e.Frames.Add(BitmapFrame.Create((BitmapImage)ThumbNailImage));
                e.Save(fs);
                fs.Flush();
            }
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("uuid", this.uuid);
            info.AddValue("OriginDataPath", this.OriginDataPath);
            info.AddValue("MetaType", this.MetaType);
            info.AddValue("thumbNailImageData", this.thumbNailImageData);
        } 
        /// <summary>
        /// Serialize 
        /// </summary>
        public void Serialize()
        {
            char[] metaFolder = uuid.ToString().ToCharArray(0, 2);
            string folderPath = metaFolder[0].ToString() + metaFolder[1].ToString();
            string metaFileFullPath ="";
            //string metaFileFullPath = Path.Combine(VRWorld.Instance.WorkingRootDir, "Library", folderPath, uuid + ".meta");
            ///META 파일 생성
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(metaFileFullPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }
    }
}
