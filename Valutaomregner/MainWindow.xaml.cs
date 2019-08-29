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
    }
}
