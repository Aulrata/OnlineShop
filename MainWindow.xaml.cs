using OnlineShop.Service;
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

namespace OnlineShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private DBService _service;
        public MainWindow()
        {
            InitializeComponent();
            _service = new();
            _service.RegisterHandler(PrintMessage);
            _service.CheckConnection();
        }
        private void PrintMessage(string message) => MessageBox.Show(message);
    }
}
