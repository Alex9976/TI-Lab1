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
                    Result += (char)((33 + ((SourceText[i] - 'А') - (key % 33))) % 33 + 'А');
                else
                    Result += SourceText[i];
            }
            return Result;
        }

        static string ColumnEncrypt(string SourceText, string key)
        {
            string Result = "";
            int KeyLength = key.Length, NumOfRows = (int)Math.Ceiling((double)SourceText.Length / KeyLength) + 2, SourceLength = SourceText.Length;
            char[,] Matrix = new char[NumOfRows, KeyLength];
            int i, j;
            int MinInd, Ind = 0;
            for (i = 0; i < NumOfRows; i++)
            {
                for (j = 0; j < KeyLength; j++)
                {
                    Matrix[i, j] = (char)0;
                }
            }
            for (i = 0; i < KeyLength; i++)
            {
                Matrix[0, i] = key[i];
            }
            for (i = 0, Ind = 0; i < KeyLength; i++)
            {
                if (Matrix[0, i] > Matrix[0, Ind])
                    Ind = i;
            }
            for (i = 0; i < KeyLength; i++)
            {              
                for (j = 0, MinInd = Ind; j < KeyLength; j++)
                {
                    if (((Matrix[0, j] < Matrix[0, MinInd]) || ((Matrix[0, j] == Matrix[0, MinInd]) && (Matrix[1, MinInd] != (char)0))) && (Matrix[1, j] == (char)0))
                    {
                        MinInd = j;
                    }
                }
                if (Matrix[1, MinInd] == 0)
                    Matrix[1, MinInd] = (char)(i + 1);
            }
            Ind = 0;
            for (i = 2; i < NumOfRows; i++)
            {
                for (j = 0; j < KeyLength; j++)
                {
                    if (Ind < SourceLength)
                    {
                        Matrix[i, j] = SourceText[Ind++];
                    }
                }
            }

            for (Ind = 1; Ind <= KeyLength; Ind++)
            {
                for (j = 0; j < KeyLength; j++)
                {
                    if (Matrix[1, j] == Ind)
                    {
                        for (i = 2; i < NumOfRows; i++)
                        {
                            if (Matrix[i, j] != 0)
                            {
                                Result += Matrix[i, j];
                            }
                        }
                    }
                }
            }

            return Result;
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)RailFenceRadioButton.IsChecked)
            {

            }
            else if ((bool)СolumnRadioButton.IsChecked)
            {
                ResultText.Text = ColumnEncrypt(SourceText.Text, Key.Text);
            }
            else if ((bool)RotatingLatticeRadioButton.IsChecked)
            {
            }
            else if ((bool)CaesarRadioButton.IsChecked)
            {
                ResultText.Text = CaesarEncrypt(SourceText.Text, Int32.Parse(Key.Text));
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)RailFenceRadioButton.IsChecked)
            {

            }
            else if ((bool)СolumnRadioButton.IsChecked)
            {

            }
            else if ((bool)RotatingLatticeRadioButton.IsChecked)
            {

            }
            else if ((bool)CaesarRadioButton.IsChecked)
            {
                ResultText.Text = CaesarDecrypt(SourceText.Text, Int32.Parse(Key.Text));
            }         
        }
    }
}
