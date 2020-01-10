using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<UnsafeRecord> _unsafeRecords;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteRecord();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            if(new UnsafeRecordWindow().ShowDialog() == true)
            {
                LoadData();
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditRcord();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pdf file (*.pdf)|*.pdf";
            saveFileDialog.FileName =  "UnsafeBehaviour-" + DateTime.Now.ToString("dd-MM-yyyy");

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    
                    new PdfGenerator(saveFileDialog.FileName, _unsafeRecords).Generate();
                    Process.Start(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        void EditRcord()
        {
            if (dgRecords.SelectedItem != null)
            {
                if (new UnsafeRecordWindow((UnsafeRecord)dgRecords.SelectedItem).ShowDialog() == true)
                {
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Please select a Record");
            }
        }

        void DeleteRecord()
        {
            if (dgRecords.SelectedItem != null)
            {
                using(var db = new UnsafeRecordDAL())
                {

                    if (db.Delete(((UnsafeRecord)dgRecords.SelectedItem).Id)>0)
                    {
                        LoadData();
                    }
                }
               
            }
            else
            {
                MessageBox.Show("Please select a Record");
            }
        }

        void LoadData()
        {
            try
            {
                using (var db = new UnsafeRecordDAL())
                {
                    _unsafeRecords = db.RetrieveAll();
                }

                dgRecords.ItemsSource = _unsafeRecords;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
          
            
        }

        private void dgRecords_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditRcord();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
