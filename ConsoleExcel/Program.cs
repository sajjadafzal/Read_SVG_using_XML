using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
namespace ConsoleExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            Excel Exl = new Excel();
            //Console.WriteLine("Hello World!");
            //Exl.CreateNewExcelFile();
            Exl.ReadExcelFileUsingStream();
            Console.Read();


        }

        
    }

    class Excel
    {
        public void CreateNewExcelFile()
        {
            ExcelPackage pck = new ExcelPackage();
            //var ws = pck.Workbook
            var ws = pck.Workbook.Worksheets.Add("Sample1");
            ws.Cells[1, 1].Value = "Sajjad Afzal Khattaka";
            pck.SaveAs(new FileInfo("D:\\EPPlus.xlsx"));
        }

        public void ReadExcelFile()
        {
            FileInfo fileInfo = new FileInfo("D:\\EPPlus.xlsx");
            ExcelPackage pck = new ExcelPackage(fileInfo);
            ExcelWorksheet ws = pck.Workbook.Worksheets[0];
            Console.WriteLine(ws.Cells[1, 1].Value);

        }
        public void ReadExcelFileUsingStream()
        {
            //FileInfo fileInfo = new FileInfo("D:\\EPPlus.xlsx");
            string path = "D:\\EPPlus.xlsx";

            var lst = new List<DataTableDTO>();

            using (FileStream fs = new FileStream(path, FileMode.Open))
            using (ExcelPackage pck = new ExcelPackage())
            {
                pck.Load(fs);
                ExcelWorksheet ws = pck.Workbook.Worksheets[0];
                Console.WriteLine(ws.Cells[1, 1].Value);
            }

        }

    }

    public class DataTableDTO
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
    }
}
