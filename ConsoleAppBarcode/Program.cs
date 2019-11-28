using System;
using ZXing;
using System.Drawing;
using System.IO;

namespace ConsoleAppBarcode
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ZXing Barcode
            //IBarcodeReader reader = new BarcodeReader();
            //Image img = new Bitmap("D:\\svg\\BARCODE.tif");
            //byte[] imgData;
            //using(MemoryStream ms = new MemoryStream())
            //{
            //    img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            //    imgData =  ms.ToArray();
            //}

            //var result = reader.Decode(imgData,img.Width,img.Height,RGBLuminanceSource.BitmapFormat.RGB32);
            //if (result != null)
            //{
            //    Console.WriteLine(result.Text);
            //}
            //else
            //{
            //    Console.WriteLine("Null received");
            //}
            #endregion

            
            Console.Read();
        }
    }
}
