
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BCA.Data.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Course { get; set; }
        public int Year { get; set; }
        public Image Picture { get; set; }

        public byte[] ConvertImageToByteArray()
        {
            if (Picture == null)
                return null;

            var ms = new MemoryStream();
            Picture.Save(ms, ImageFormat.Jpeg);
            byte[] photo_aray = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(photo_aray, 0, photo_aray.Length);

            return photo_aray;
        }

        public void ConvertByteArrayToImage(byte[] imgArr)
        {
            if(imgArr == null || imgArr.Length == 0)
            {
                Picture = null;
                return;
            }

            MemoryStream ms = new MemoryStream(imgArr);
            Picture = Image.FromStream(ms);
        }


    }
}
