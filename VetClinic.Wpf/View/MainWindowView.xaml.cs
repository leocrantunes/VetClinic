﻿using System;
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
                    ViewModel.VetClinic.Patients.Add(dlg.ViewModel.Patient);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occurred during register patient");
            }
        }

        #endregion Event Handlers
    }
}