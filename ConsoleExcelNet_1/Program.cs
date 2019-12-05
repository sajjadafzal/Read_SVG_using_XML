using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ConsoleExcelNet_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Excel.Application excel = new Excel.Application();

            excel.Visible = true;


            Excel._Workbook wb = excel.Workbooks.Add();

            Excel._Worksheet w = (Excel._Worksheet)excel.Worksheets.Add();
            w.Name = "MYSheet";
            w.Cells[1, 1] = "Hello";
            w.SaveAs("D:\\Test.xlsx");
            //wb.Save("D:\\Test.xlsx");
        }
    }
}
