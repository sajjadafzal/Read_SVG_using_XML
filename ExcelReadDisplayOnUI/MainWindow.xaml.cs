using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ExcelReadDisplayOnUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable table = new DataTable();
        
        public MainWindow()
        {
            InitializeComponent();
            //dataGrid.DataContextChanged += contextChanged;

        }

        private void btn_DisplayExcel_Click(object sender, RoutedEventArgs e)
        {
            
            FileInfo fileInfo = new FileInfo("D:\\Testing Files\\WpfExcelRead.xlsx");
            using (ExcelPackage pck = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets[0];
                int i = 1;
                while (ws.Cells[1,i].Value != null)
                {
                    //DataColumn Col = new DataColumn();
                    //Col.ColumnName = ws.Cells[1, i].Value.ToString();
                    table.Columns.Add(ws.Cells[1, i].Value.ToString(),typeof(string));
                    i++;
                }

                i = 2;
                while (ws.Cells[i, 1].Value != null)
                {
                    //DataColumn Col = new DataColumn();
                    //Col.ColumnName = ws.Cells[1, i].Value.ToString();
                    DataRow row = table.NewRow();
                    row[ws.Cells[1, 1].Value.ToString()] = ws.Cells[i, 1].Value.ToString();
                    row[ws.Cells[1, 2].Value.ToString()] = ws.Cells[i, 2].Value.ToString();
                    row[ws.Cells[1, 3].Value.ToString()] = ws.Cells[i, 3].Value.ToString();
                    table.Rows.Add(row);
                    
                    i++;
                }


            }

            //dataGrid.ItemsSource = table.DefaultView;
            dataGrid.DataContext = table;
            
           
        }

        private void btn_ChangeItem_Click(object sender, RoutedEventArgs e)
        {

            table.Columns[1].ColumnName = "Changed";
            //dataGrid
            
        }

        private void contextChanged()
        {

        }
    }
}
