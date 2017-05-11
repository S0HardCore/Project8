using Microsoft.Win32;
using System;
using System.Windows;

namespace WpfApplication2
{
    public class DefaultDialogService
    {
        public string FilePath { get; set; }
        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "JSON [" + DateTime.Now.ToShortDateString() + "]";
            saveFileDialog.Filter = "Текстовый файл|*.txt|JSON|*.json";
            bool result = saveFileDialog.ShowDialog().Value;
            FilePath = saveFileDialog.FileName;
            return result;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}