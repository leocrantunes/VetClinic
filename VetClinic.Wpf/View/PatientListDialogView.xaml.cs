using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using VetClinic.Wpf.Model;
using VetClinic.Wpf.ViewModel;

namespace VetClinic.Wpf.View
{
    /// <summary>
    /// Interaction logic for PatientListDialogView.xaml
    /// </summary>
    public partial class PatientListDialogView : Window
    {
        public PatientListDialogView(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            ViewModel = new PatientListDialogViewModel(mainWindowViewModel);
            DataContext = ViewModel;
        }

        /// <summary>
        /// Object responsible for controlling business logic
        /// </summary>
        public PatientListDialogViewModel ViewModel { get; set; }

        /// <summary>
        /// Button Ok event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        
        private void BtnEditPatient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var pet = button.DataContext as Pet;

                var dlg = new PatientDialogView(ViewModel.MainWindowViewModel.VetClinic.Patients, pet)
                {
                    Owner = this
                };

                dlg.ShowDialog();

                if (dlg.DialogResult == true)
                {
                    ViewModel.EditPatient(pet, dlg.ViewModel.Patient);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occurred during editing patient");
            }
        }

        private void BtnDeletePatient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var pet = button.DataContext as Pet;

                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    ViewModel.RemovePatient(pet);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occurred during deleting patient");
            }
        }

    }
}