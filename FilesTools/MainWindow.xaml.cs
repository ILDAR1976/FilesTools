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
using System.IO;
using WinForms = System.Windows.Forms;

namespace FilesTools
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_src_one_Click(object sender, RoutedEventArgs e)
        {
            WinForms.FolderBrowserDialog folderDialog = new WinForms.FolderBrowserDialog();

            folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            WinForms.DialogResult result = folderDialog.ShowDialog();

            if (result == WinForms.DialogResult.OK)
            {
                sourceOne.Text = folderDialog.SelectedPath;
            }
        }

        private void btn_src_two_Click(object sender, RoutedEventArgs e)
        {
            WinForms.FolderBrowserDialog folderDialog = new WinForms.FolderBrowserDialog();

            folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            WinForms.DialogResult result = folderDialog.ShowDialog();

            if (result == WinForms.DialogResult.OK)
            {
                sourceTwo.Text = folderDialog.SelectedPath;
            }

        }

        private void btn_diff_Click(object sender, RoutedEventArgs e)
        {
            WinForms.FolderBrowserDialog folderDialog = new WinForms.FolderBrowserDialog();

            folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
            WinForms.DialogResult result = folderDialog.ShowDialog();

            if (result == WinForms.DialogResult.OK)
            {
                diffrents.Text = folderDialog.SelectedPath;
            }

        }

        private bool fileEquals(string file1, string file2)
        {
            using (FileStream s1 = new FileStream(file1, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (FileStream s2 = new FileStream(file2, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BinaryReader b1 = new BinaryReader(s1))
            using (BinaryReader b2 = new BinaryReader(s2))
            {
                while (true)
                {
                    byte[] data1 = b1.ReadBytes(64 * 1024);
                    byte[] data2 = b2.ReadBytes(64 * 1024);
                    if (data1.Length != data2.Length)
                        return false;
                    if (data1.Length == 0)
                        return true;
                    if (!data1.SequenceEqual(data2))
                        return false;
                }
            }
        }
    }
}
