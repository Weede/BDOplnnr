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
//using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Bson;

namespace BDOplnnr
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMongoClient mongo;
        private IMongoDatabase db;

        public MainWindow()
        {
            InitializeComponent();
            string connectionFile = Environment.GetEnvironmentVariable("USERPROFILE");
            connectionFile = connectionFile + @"\documents\mongo_connection_string.txt";
            string connectionString = System.IO.File.ReadAllText(connectionFile);
            mongo = new MongoClient(connectionString);
            var dbs = mongo.ListDatabases();
            foreach (var db in dbs.ToEnumerable())
            {
                listBox0.Items.Add(db["name"]);
            }
        }

        private void listBox0_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            listBox1.Items.Remove(0);
            ListBox lb = sender as ListBox;
            db = mongo.GetDatabase(lb.SelectedItem.ToString());
            var cols = db.ListCollections();
            foreach (var col in cols.ToEnumerable())
            {
                listBox1.Items.Add(col["name"]);
            }
        }
    }

    class DatabaseDescription
    {
        public string name { get; set; }
        public BsonDecimal128 sizeOnDisk { get; set; }
        public BsonBoolean empty { get; set; }
    }
}
