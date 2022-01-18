using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using System.Windows;
using TestProj.Helpers;
using System.Windows.Navigation;

namespace TestProj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string fileName = "C:\\testProj\\testFile.dat";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_click(object sender, RoutedEventArgs e)
        {
            var op = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (op.ShowDialog() == true)
            {
                string folderPath = op.SelectedPath;
                DirectoryInfo info = new DirectoryInfo(folderPath);
                SerializationHelper.SerializeFolder(DirectoryTreeHelper.CreateTree(info), fileName);
            }
        }
        private void btn_click2(object sender, RoutedEventArgs e)
        {
            var op = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (op.ShowDialog() == true)
            {
                string folderPath = op.SelectedPath;
                DirectoryInfo info = new DirectoryInfo(folderPath);
                SerializationHelper.DeserializeFolder(fileName,folderPath);
            }
        }
    }
}
