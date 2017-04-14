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
using MongoDB.Bson.Serialization.Attributes;

namespace BDOplnnr
{
    public class Node
    {
        [BsonId]
        public string territory { get; set; }
        [BsonElement("city")]
        public string city { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DbConnection();

        }

        private void DbConnection()
        {
            var DbServer = new MongoDB.Driver.MongoClient();
            var mongo = new MongoDB.Driver.MongoClient();
            var db = mongo.GetDatabase("test1");
            try
            {
                db.CreateCollection("bdo_test1");
            }
            catch (MongoDB.Driver.MongoCommandException)
            {
                ;
            }

            var collection = db.GetCollection<Node>("bdo1");

            var set = new Properties.Settings();
            
        }
    }
}