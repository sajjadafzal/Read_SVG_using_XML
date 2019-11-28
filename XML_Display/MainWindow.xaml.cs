using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;

namespace XML_Display
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string fileAddress;
        XDocument doc;
        XElement xDoc;
        XElement svg;
        string ns;
        public MainWindow()
        {
            InitializeComponent();
            //fileAddress = "D:\\svg\\CustomersAndSales.xml";
            //fileAddress = "D:\\svg\\SalesOrderDetails.xml";
            //fileAddress = "D:\\svg\\Customers.xml";
            //fileAddress = "D:\\svg\\Customers_Attributes.xml";
            fileAddress = "D:\\svg\\AnswerSheetSVG.svg";
            //fileAddress = "D:\\svg\\design.svg";
            ns = "{http://www.w3.org/2000/svg}";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            doc = XDocument.Load(fileAddress); //"D:\\svg\\AnswerSheetSVG.svg"
            myTextBlock.Text = doc.ToString();

            xDoc = XElement.Load(fileAddress);
            #region Display XElement in a TextBox
            //myTextBlock2.Text = xDoc.FirstNode.ToString();
            #endregion

            #region Enumeration through SVG Elements

            svg = doc.Root;

            StringBuilder sb = new StringBuilder();

            IEnumerable<XElement> shapes =
                from shps in svg.Descendants().Elements($"{ns}title")//
                where shps.ToString().Contains("Q") && (!shps.ToString().Contains("_"))  
                                                     && (shps.Value.ToString().Length <= 5)
                                                     && (  shps.ToString().Contains("A") 
                                                        || shps.ToString().Contains("B")
                                                        || shps.ToString().Contains("C")
                                                        || shps.ToString().Contains("D")
                                                        || shps.ToString().Contains("E"))
                select shps;

            if (shapes == null)
            {
                MessageBox.Show("Hard Luck");
            }

            foreach (XElement shp in shapes)
            {
               
                //if (shp.ToString().Length >= 0) { 
                double x = Convert.ToDouble(shp.Parent.Element($"{ns}rect").Attribute("x").Value);
                double y = Convert.ToDouble(shp.Parent.Element($"{ns}rect").Attribute("y").Value);
                double width = Convert.ToDouble(shp.Parent.Element($"{ns}rect").Attribute("width").Value);
                double height = Convert.ToDouble(shp.Parent.Element($"{ns}rect").Attribute("height").Value);
                string title = shp.Value[0..^1];
                string exportValue = shp.Value[^1].ToString(); //Convert the char to string
                //===Get the transform="translate(48.48,-355.68)" from parent node and apply it to the child for absolute positions
                String transformString = shp.Parent.Attribute("transform").Value;
                // Using Regex to get numbers from the text.
                //string[] numbers = Regex.Split(shp.Parent.Attribute("transform").Value, @"\-*[0-9]+(.[0-9]+)*");
                //foreach(string n in numbers)
                //{
                //sb.AppendLine(n);
                //}
                //sb.AppendLine("");

                transformString = transformString.Remove(0, 10);
                transformString = transformString.Remove(transformString.Length - 1);

                String[] numbers = transformString.Split(',', StringSplitOptions.RemoveEmptyEntries);

                double X1 = Math.Round(x + Convert.ToDouble(numbers[0]), 2);
                double Y1 = Math.Round(y + Convert.ToDouble(numbers[1]), 2);
                double X2 = Math.Round(X1 + width, 2);
                double Y2 = Math.Round(Y1 + height, 2);

                sb.AppendLine($"{shp.Value.ToString()}: Export[{title}] [{X1} , {Y1}] [{X2} , {Y2}] [{width},{height}]");
                //}



            }

            myTextBlock2.Text = sb.ToString();
            #endregion
            #region Enumeration through XElements Elements
            //StringBuilder sb = new StringBuilder();

            //IEnumerable<XElement> customers =
            //    from customer in xDoc.Elements("Customer")
            //    orderby customer.Element("CompanyName").Value
            //    select customer;

            //foreach (XElement cust in customers)
            //{
            //    sb.Append(cust.Element("CompanyName").Value);
            //    sb.Append(" [");
            //    sb.Append(cust.Element("FirstName").Value);
            //    sb.Append(" ");
            //    sb.Append(cust.Element("LastName").Value);
            //    sb.AppendLine("]");
            //}

            //myTextBlock2.Text = sb.ToString();
            #endregion
            #region Where Clause in XML using Element
            //XElement customer = (from cust in xDoc.Elements("Customer")
            //                     where cust.Element("CustomerID").Value == "1"
            //                     select cust).SingleOrDefault();
            //if (customer != null)
            //{
            //    myTextBlock2.Text = customer.Element("CompanyName").Value;
            //}
            //else
            //{
            //    myTextBlock2.Text = "Not found";
            //}
            #endregion

            #region Where Clause in XML using Attributes
            //XElement customer = (from cust in xDoc.Elements("Customer")
            //                     where cust.Attribute("CustomerID").Value == "1"
            //                     select cust).SingleOrDefault();
            //if (customer != null)
            //{
            //    myTextBlock2.Text = customer.Attribute("CompanyName").Value;
            //}
            //else
            //{
            //    myTextBlock2.Text = "Not found";
            //}
            #endregion


            //MessageBox.Show(doc2.FirstNode.ToString());

        }

        private void btn_ReadMarks_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder sb = new StringBuilder();

            IEnumerable<XElement> shapes =
                from shps in svg.Descendants().Elements($"{ns}title")//
                where shps.ToString().Contains("Mark") /*&& (!shps.ToString().Contains("_"))
                                                     && (shps.Value.ToString().Length <= 5)
                                                     && (shps.ToString().Contains("A")
                                                        || shps.ToString().Contains("B")
                                                        || shps.ToString().Contains("C")
                                                        || shps.ToString().Contains("D")
                                                        || shps.ToString().Contains("E"))*/
                select shps;

            if (shapes == null)
            {
                MessageBox.Show("Hard Luck");
            }

            foreach (XElement shp in shapes)
            {
                //if (shp.ToString().Length >= 0) { 
                double x = Convert.ToDouble(shp.Parent.Element($"{ns}rect").Attribute("x").Value);
                double y = Convert.ToDouble(shp.Parent.Element($"{ns}rect").Attribute("y").Value);
                double width = Convert.ToDouble(shp.Parent.Element($"{ns}rect").Attribute("width").Value);
                double height = Convert.ToDouble(shp.Parent.Element($"{ns}rect").Attribute("height").Value);

                //===Get the transform="translate(48.48,-355.68)" from parent node and apply it to the child for absolute positions
                String transformString = shp.Parent.Attribute("transform").Value;
                // Using Regex to get numbers from the text.
                //string[] numbers = Regex.Split(shp.Parent.Attribute("transform").Value, @"\-*[0-9]+(.[0-9]+)*");
                //foreach(string n in numbers)
                //{
                //sb.AppendLine(n);
                //}
                //sb.AppendLine("");

                transformString = transformString.Remove(0, 10);
                transformString = transformString.Remove(transformString.Length - 1);

                String[] numbers = transformString.Split(',', StringSplitOptions.RemoveEmptyEntries);

                double X1 = Math.Round(x + Convert.ToDouble(numbers[0]),2);
                double Y1 = Math.Round(y + Convert.ToDouble(numbers[1]), 2);
                double X2 = Math.Round(X1 + width, 2);
                double Y2 = Math.Round(Y1 + height, 2);

                sb.AppendLine($"{shp.Value.ToString()}: [{X1} , {Y1}] [{X2} , {Y2}] [{width},{height}]");
                //}



            }

            myTextBlock2.Text = sb.ToString();


        }

        private void btn_ReadDocProperties_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            //IEnumerable<XElement> shapes =
            //    from shps in svg.Elements($"{ns}svg")//
            //    /*where shps.ToString().Contains("Mark") /*&& (!shps.ToString().Contains("_"))
            //                                         && (shps.Value.ToString().Length <= 5)
            //                                         && (shps.ToString().Contains("A")
            //                                            || shps.ToString().Contains("B")
            //                                            || shps.ToString().Contains("C")
            //                                            || shps.ToString().Contains("D")
            //                                            || shps.ToString().Contains("E"))*/
            //    select shps;

            //foreach (XElement shp in shapes)
            //{
            //    sb.Append(shp.ToString());
            //}
            // using regular expressin we can do this like "\d+(\.\d+)?"
            //string[] numbers = svg.Attribute("viewBox").Value.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            MatchCollection numbers = Regex.Matches(svg.Attribute("viewBox").Value, @"\d+(\.\d+)?");
            foreach (Match n in numbers)
            {
               sb.Append($"{Convert.ToDouble(n.Value)}, ");
            }

            this.myTextBlock2.Text = sb.ToString();
        }

        private void btn_ReadBarcode_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<XElement> shapes =
                from shps in svg.Descendants().Elements($"{ns}title")//
                where shps.Value == "RollNoBarcode"
                select shps.Parent;
            
            foreach (XElement shp in shapes)
            {
                double x = Convert.ToDouble(shp.Element($"{ns}rect").Attribute("x").Value);
                double y = Convert.ToDouble(shp.Element($"{ns}rect").Attribute("y").Value);
                double width = Convert.ToDouble(shp.Element($"{ns}rect").Attribute("width").Value);
                double height = Convert.ToDouble(shp.Element($"{ns}rect").Attribute("height").Value);

                String transformString = shp.Attribute("transform").Value;
                transformString = transformString.Remove(0, 10);
                transformString = transformString.Remove(transformString.Length - 1);

                String[] numbers = transformString.Split(',', StringSplitOptions.RemoveEmptyEntries);
                double X1 = Math.Round(x + Convert.ToDouble(numbers[0]), 2);
                double Y1 = Math.Round(y + Convert.ToDouble(numbers[1]), 2);
                double X2 = Math.Round(X1 + width, 2);
                double Y2 = Math.Round(Y1 + height, 2);

                sb.AppendLine($"{shp.Value.ToString()}: [{X1} , {Y1}] [{X2} , {Y2}] [{width},{height}]");
               
            }
            
            this.myTextBlock2.Text = sb.ToString();

        }

        private void btn_ReadPostCenterTime_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<XElement> shapes =
                from shps in svg.Descendants().Elements($"{ns}title")//
                where ((shps.Value[0].ToString() == "C") || (shps.Value[0].ToString() == "T") || (shps.Value[0].ToString() == "P")) 
                && (shps.Value[^1].ToString() == "O") && (shps.Value.ToString().Length == 3)
                select shps;

            if (shapes == null)
            {
                MessageBox.Show("Hard Luck");
            }

            foreach (XElement shp in shapes)
            {

                //if (shp.ToString().Length >= 0) { 
                double x = Convert.ToDouble(shp.Parent.Element($"{ns}rect").Attribute("x").Value);
                double y = Convert.ToDouble(shp.Parent.Element($"{ns}rect").Attribute("y").Value);
                double width = Convert.ToDouble(shp.Parent.Element($"{ns}rect").Attribute("width").Value);
                double height = Convert.ToDouble(shp.Parent.Element($"{ns}rect").Attribute("height").Value);
                string title = shp.Value[0..^1];
                string exportValue = shp.Value[^1].ToString(); //Convert the char to string
                //===Get the transform="translate(48.48,-355.68)" from parent node and apply it to the child for absolute positions
                String transformString = shp.Parent.Attribute("transform").Value;
                // Using Regex to get numbers from the text.
                //string[] numbers = Regex.Split(shp.Parent.Attribute("transform").Value, @"\-*[0-9]+(.[0-9]+)*");
                //foreach(string n in numbers)
                //{
                //sb.AppendLine(n);
                //}
                //sb.AppendLine("");

                transformString = transformString.Remove(0, 10);
                transformString = transformString.Remove(transformString.Length - 1);

                String[] numbers = transformString.Split(',', StringSplitOptions.RemoveEmptyEntries);

                double X1 = Math.Round(x + Convert.ToDouble(numbers[0]), 2);
                double Y1 = Math.Round(y + Convert.ToDouble(numbers[1]), 2);
                double X2 = Math.Round(X1 + width, 2);
                double Y2 = Math.Round(Y1 + height, 2);

                sb.AppendLine($"{shp.Value.ToString()}: Export[{title}] [{X1} , {Y1}] [{X2} , {Y2}] [{width},{height}]");
                //}



            }

            myTextBlock2.Text = sb.ToString();
        }
    }
}
