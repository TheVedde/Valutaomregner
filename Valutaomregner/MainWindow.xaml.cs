using System;
using System.Collections.Generic;
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
using System.Xml.Linq;
using System.Globalization;


namespace Valutaomregner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            XDocument currencies = XDocument.Load("https://www.nationalbanken.dk/_vti_bin/DN/DataService.svc/CurrencyRatesXML?lang=da");

            foreach(var currency in currencies.Descendants("currency"))
            {
                var comboItem1 = new ComboBoxItem();
                comboItem1.Content = currency.Attribute("code").Value;
                comboItem1.Tag = currency.Attribute("rate").Value;

                var comboItem2 = new ComboBoxItem();
                comboItem2.Content = currency.Attribute("code").Value;
                comboItem2.Tag = currency.Attribute("rate").Value;

                From.Items.Add(comboItem1);
                To.Items.Add(comboItem2);

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           float first = float.Parse(((ComboBoxItem)From.SelectedItem).Tag.ToString(), CultureInfo.InvariantCulture);
           float second = float.Parse(((ComboBoxItem)To.SelectedItem).Tag.ToString(), CultureInfo.InvariantCulture);

            //todo convert "from" && "To" into int to do math equation
            // 


             

            if (float.TryParse(Input.Text, NumberStyles.Any, CultureInfo.CreateSpecificCulture("en-GB"), out float y))
            {
              var x = Math.Round((first / second) * y, 2);
                Output1.Content = x.ToString("N");  

            }
            
            else
            {
                Input.Text = "NaN";
                Output1.Content = " ";
            }


        }
    }
}
