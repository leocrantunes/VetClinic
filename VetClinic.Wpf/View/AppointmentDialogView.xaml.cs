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
    /// Interaction logic for AppointmentDialogView.xaml
    /// </summary>
    public partial class AppointmentDialogView : Window
    {
        public AppointmentDialogView(Schedule schedule, ObservableCollection<Pet> registeredPets, Appointment appointment = null)
        {
            InitializeComponent();

            ViewModel = new AppointmentDialogViewModel(schedule, registeredPets, appointment);
            DataContext = ViewModel;
        }

        /// <summary>
        /// Object responsible for controlling business logic
        /// </summary>
        public AppointmentDialogViewModel ViewModel { get; set; }

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