using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace BeerBuzzBackend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        // File Store
        public const string RootDir = @"C:/BeerBuzz/";
        public string BuzzFileStoreDir = Path.Combine(RootDir, "BuzzFiles");
        public string BuzzInfoStoreFilename = Path.Combine(RootDir, "BuzzFileInfoStore.txt");

        public ObservableCollection<string> BuzzList = new ObservableCollection<string>();

        public Dictionary<string, BuzzInfo> BuzzInfos;

        // Web Server
        WebServer webServer = new WebServer();
        CancellationToken cancelToken = new CancellationToken();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.webServer.Listen(this.cancelToken);
        }

        //TODO: OnPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
