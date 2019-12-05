using System;
using System.Windows;
using System.Windows.Controls;
using VetClinic.Wpf.Model;
using VetClinic.Wpf.ViewModel;

namespace VetClinic.Wpf.View
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();

            ViewModel = new MainWindowViewModel();
            DataContext = ViewModel;
        }

        /// <summary>
        /// Object responsible for controlling business logic
        /// </summary>
        public MainWindowViewModel ViewModel { get; set; }

        #region Event Handlers

        private void MenuItemLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.ReadXmlData();
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occurred during Load");
            }
        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.SaveXmlData();
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occurred during Save");
            }
        }

        private void MenuItemClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.ClearAllData();
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occurred during Clear");
            }
        }

        private void ButtonAddPatient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dlg = new PatientDialogView(ViewModel.VetClinic.Patients)
                {
                    Owner = this
                };

                dlg.ShowDialog();

                if (dlg.DialogResult == true)
                {
                    ViewModel.AddPatient(dlg.ViewModel.Patient);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occurred during register patient");
            }
        }

        private void ButtonMakeAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dlg = new AppointmentDialogView(ViewModel.VetClinic.Schedule, ViewModel.VetClinic.Patients)
                {
                    Owner = this
                };

                dlg.ShowDialog();

                if (dlg.DialogResult == true)
                {
                    ViewModel.AddAppointment(dlg.ViewModel.Appointment);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occurred during making appointment");
            }
        }

        private void ButtonDisplayPatientList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dlg = new PatientListDialogView(ViewModel)
                {
                    Owner = this
                };

                dlg.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occurred during display patientlist");
            }
        }
        
        private void BtnEditAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var appointment = button.DataContext as Appointment;
                
                var dlg = new AppointmentDialogView(ViewModel.VetClinic.Schedule, ViewModel.VetClinic.Patients, appointment)
                {
                    Owner = this
                };

                dlg.ShowDialog();

                if (dlg.DialogResult == true)
                {
                    ViewModel.EditAppointment(dlg.ViewModel.Appointment);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occurred during editing appointment");
            }
        }

        private void BtnDeleteAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var appointment = button.DataContext as Appointment;

                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    ViewModel.RemoveAppointment(appointment);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occurred during deleting appointment");
            }
        }

        private void ButtonApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.FilterAppointmentsV2();
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occurred during filtering appointments");
            }
        }

        #endregion Event Handlers
    }
}
