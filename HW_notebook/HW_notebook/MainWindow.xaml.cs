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

namespace HW_notebook
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        string filename = "";
        string newFileName = "";
        string text = "";
        string savetext = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        // 存檔(路徑.文字)
        void Save()
        {
            Microsoft.Win32.SaveFileDialog dig = new Microsoft.Win32.SaveFileDialog();

            Nullable<bool> result = dig.ShowDialog();

            if (result == true)
            {
                System.IO.File.WriteAllText(dig.FileName, Textarea.Text);
                filename = dig.FileName;
                savetext = text; ;
                Title = dig.SafeFileName;
            }
        }

        // 讀檔(路徑)
        void Open()
        {
            Microsoft.Win32.OpenFileDialog dig = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = dig.ShowDialog();

            if (result == true)
            {
                Textarea.Text = System.IO.File.ReadAllText(dig.FileName);
                filename = dig.FileName;
                savetext = Textarea.Text;
                Title = dig.SafeFileName;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Open();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (filename == newFileName)
            {
                Save();
            }
            else
            {
                System.IO.File.WriteAllText(filename, Textarea.Text);
                savetext = text;
            }
        }

        private void SaveasBtn_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            Textarea.Clear();
        }

        private void BlackBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Textarea.Foreground = Brushes.White;
            Textarea.Background = Brushes.Gray;
        }

        private void WhiteBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Textarea.Foreground = Brushes.Black;
            Textarea.Background = Brushes.White;
        }

        private void Size1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Textarea.FontSize++;
        }

        private void Size2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Textarea.FontSize = 20;
        }

        private void Size3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Textarea.FontSize--;
        }
    }
}
