using System;
using System.Collections.ObjectModel;
using System.Windows;
using VetClinic.Wpf.Model;
using VetClinic.Wpf.ViewModel;

namespace VetClinic.Wpf.View
{
    /// <summary>
    /// Interaction logic for CustomerDialogView.xaml
    /// </summary>
    public partial class PatientDialogView : Window
    {
        public PatientDialogView(ObservableCollection<Pet> registeredPets, Pet patient = null)
        {
            InitializeComponent();

            ViewModel = new PatientDialogViewModel(registeredPets, patient);
            DataContext = ViewModel;
        }

        /// <summary>
        /// Object responsible for controlling business logic
        /// </summary>
        public PatientDialogViewModel ViewModel { get; set; }

        /// <summary>
        /// Button Ok event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ViewModel.CheckFields())
                {
                    DialogResult = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occurred during patient registration");
            }
        }

        /// <summary>
        /// Button Cancel event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
