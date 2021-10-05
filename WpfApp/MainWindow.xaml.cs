using LiteDB;
using RestSharp;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                // Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<RealResource>("RealResource");

                foreach (RealResource item in col.FindAll())
                {
                    listBox.Items.Add(item.Name);
                }
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                // Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<RealResource>("RealResource");

                // Create your new customer instance
                var realResource = new RealResource
                {
                    Name = textBox.Text,
                    Interval = Int32.Parse(textBoxForInterval.Text)
                };

                col.Insert(realResource);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                var col = db.GetCollection<RealResource>("RealResource");

                RealResource rr = col.FindById(4);

                var client = new RestClient(rr.Name);

                var request = new RestRequest();
                var response = client.Get(request);

            }
        }
    }
}
