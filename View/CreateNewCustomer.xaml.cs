/*
* FILE : CustomerWindow.cs
* PROJECT : Assignment 3
* PROGRAMMER : Robert Ochinski
* FIRST VERSION : 2019-12-06
* DESCRIPTION : 
*
*/



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
using System.Windows.Shapes;
using A3.Model;
using A3.ViewModel;

namespace A3.View {
    /// <summary>
    /// Interaction logic for CreateNewCustomer.xaml
    /// </summary>
    public partial class CreateNewCustomer : Window {

        private string branchSelected;
        private CustomerViewModel customerViewModel;
        // Method    : 
        // Description : 
        //     
        //      
        //  Parameters  :
        //      
        //  Returns     :
        //      
        public CreateNewCustomer(string selectedBranch) {
            InitializeComponent();
            this.customerViewModel = new CustomerViewModel();
            this.branchSelected = selectedBranch;
        }

        // Method    : 
        // Description : 
        //     
        //      
        //  Parameters  :
        //      
        //  Returns     :
        //      
        private void ProductBtn_Click(object sender, RoutedEventArgs e) {

        }

        // Method    : 
        // Description : 
        //     
        //      
        //  Parameters  :
        //      
        //  Returns     :
        //      
        private void BranchBtn_Click(object sender, RoutedEventArgs e) {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        // Method    : 
        // Description : 
        //     
        //      
        //  Parameters  :
        //      
        //  Returns     :
        //      
        private void CreateNewCustomer_Click(object sender, RoutedEventArgs e) {
            Customer newCustomer = new Customer() {
                FirstName = (string)FirstNameInput.Text,
                LastName = (string)LastNameInput.Text,
                Telephone = (string)TelephoneInput.Text
            };
            OrderPageWithCustomer(branchSelected, newCustomer);
        }

        // Method    : 
        // Description : 
        //     
        //      
        //  Parameters  :
        //      
        //  Returns     :
        //      
        private void OrderPageWithCustomer(string branch, Customer customer) {
            customerViewModel.UpdateNewCustomer(customer);
            OrderWindow orderWindow = new OrderWindow(branch, customer);
            orderWindow.Show();
            this.Close();
        }

    }
}
