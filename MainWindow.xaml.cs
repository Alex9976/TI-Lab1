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

namespace TILab1
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();  
        }

        static string CaesarEncrypt(string SourceText, int key)
        {
            string Result = "";
            int i, StrLen = SourceText.Length;

            for (i = 0; i < StrLen; i++)
            {
                if ((SourceText[i] >= 'A' && SourceText[i] <= 'Z'))
                    Result += (char)((SourceText[i] + key - 'A') % 26 + 'A');
                else if ((SourceText[i] >= 'a' && SourceText[i] <= 'z'))
                    Result += (char)((SourceText[i] + key - 'a') % 26 + 'a');
                else if ((SourceText[i] >= 'А' && SourceText[i] <= 'Я'))
                    Result += (char)((SourceText[i] + key - 'А') % 33 + 'А');
                else if ((SourceText[i] >= 'а' && SourceText[i] <= 'я'))
                    Result += (char)((SourceText[i] + key - 'а') % 33 + 'а');
                else
                    Result += SourceText[i];
            }
            return Result;
        }

        static string CaesarDecrypt(string SourceText, int key)
        {
            string Result = "";
            int i, StrLen = SourceText.Length;

            for (i = 0; i < StrLen; i++)
            {
                if ((SourceText[i] >= 'A' && SourceText[i] <= 'Z'))
                    Result += (char)((26 + ((SourceText[i] - 'A') - (key % 26))) % 26 + 'A');
                else if ((SourceText[i] >= 'a' && SourceText[i] <= 'z'))
                    Result += (char)((26 + ((SourceText[i] - 'a') - (key % 26))) % 26 + 'a');
                else if ((SourceText[i] >= 'А' && SourceText[i] <= 'Я'))
                    Result += (char)((33 + ((SourceText[i] - 'а') - (key % 33))) % 33 + 'а');
                else if ((SourceText[i] >= 'а' && SourceText[i] <= 'я'))
                    Result += (char)((26 + ((SourceText[i] - 'А') - (key % 26))) % 26 + 'А');
                else
                    Result += SourceText[i];
            }
            return Result;
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = CaesarEncrypt(SourceText.Text, Int32.Parse(Key.Text));
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = CaesarDecrypt(SourceText.Text, Int32.Parse(Key.Text));
        }
    }
}
