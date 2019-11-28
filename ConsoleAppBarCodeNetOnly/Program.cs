using IronBarCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBarCodeNetOnly
{
    class Program
    {
        static void Main(string[] args)
        {
            /******     WRITE     *******/
            // Create A Barcode in 1 Line of Code
            //BarcodeWriter.CreateBarcode("https://ironsoftware.com/csharp/barcode", BarcodeWriterEncoding.QRCode).SaveAsJpeg("D:\\svg\\QuickStart.jpg");
            /******    READ    *******/
            // Read A Barcode in 1 Line of Code.  Gets Text, Numeric Codes, Binary Data and an Image of the barcode
            BarcodeResult Result = BarcodeReader.QuicklyReadOneBarcode("D:\\svg\\BARCODE.jpg");
            // Assert that IronBarCode Works :-)
            if (Result != null)
            {
                System.Console.WriteLine(Result.Text);
            }
            Console.Read();
        }
    }
}
