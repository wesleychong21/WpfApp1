using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for UnsafeRecordWindow.xaml
    /// </summary>
    public partial class UnsafeRecordWindow : Window
    {
        UnsafeRecord _record;
        bool _isNew;

        public UnsafeRecordWindow()
        {
            InitializeComponent();
            _isNew = true;
        }

        

        public UnsafeRecordWindow(UnsafeRecord record)
        {
            InitializeComponent();
            _isNew = false;
            _record = record;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (_record == null)
                _record = new UnsafeRecord();

            _record.Observer = txtObserver.Text.Trim();
            _record.Observee = txtObservee.Text.Trim();
            _record.Title = txtTitle.Text.Trim();
            _record.Detail = txtDetails.Text.Trim();
            _record.ReportDate = (DateTime)datePickerCreateDate.SelectedDate;

            if (_isNew)
                new UnsafeRecordDAL().Create(_record);
            else
                new UnsafeRecordDAL().Update(_record);

            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(_record!= null)
            {
                txtObserver.Text = _record.Observer;
                txtObservee.Text = _record.Observee;
                txtTitle.Text = _record.Title;
                txtDetails.Text = _record.Detail;
                datePickerCreateDate.SelectedDate = _record.ReportDate;
            }
            else
                datePickerCreateDate.SelectedDate = DateTime.Now;
        }
    }
}
