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

        private void SerializeFolderButton(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog() == true)
            {
                string folderPath = dialog.SelectedPath;
                DirectoryInfo info = new DirectoryInfo(folderPath);
                SerializationHelper.SerializeFolder(DirectoryTreeHelper.CreateTree(info), fileName);
            }
        }
        private void DeserializeFolderButton(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog() == true)
            {
                SerializationHelper.DeserializeFolder(fileName, dialog.SelectedPath);
            }
        }
    }
}
