/*
* FILE : CustomerWindow.cs
* PROJECT : Assignment 3
* PROGRAMMER : Robert Ochinski
* FIRST VERSION : 2019-12-06
* DESCRIPTION : 
*
*/

using System.Windows;
using A3.View;
using A3.ViewModel;
using A3.Model;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace A3.View {
    public partial class CustomerWindow : Window {

        private readonly CustomerViewModel _viewModel = new CustomerViewModel();
        private string branchSelected;
        public ObservableCollection<Customer> _CustomerList { get; set; }


        // Method    : 
        // Description : 
        //     
        //      
        //  Parameters  :
        //      
        //  Returns     :
        //      
        public CustomerWindow(string selectedBranch) {
            InitializeComponent();
            DataContext = _viewModel;
            this.branchSelected = selectedBranch;
            this._CustomerList = new ObservableCollection<Customer>();

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
            CreateNewCustomer createnewCustomer = new CreateNewCustomer(branchSelected);
            createnewCustomer.Show();
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
        private void SelectedCustomer_Click(object sender, RoutedEventArgs e) {
            Customer newCustomer = new Customer() {
                CustomerID = (int)CustomerID.Content,
                FirstName = (string)CustomerFirstName.Content,
                LastName = (string)CustomerLastName.Content,
                Telephone = (string)CustomerTelephone.Content
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
        private void CustomerList_Clicked(object sender, SelectionChangedEventArgs e) {
            SelectCustomer.IsEnabled = true;

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
            OrderWindow orderWindow = new OrderWindow(branch,customer);
            orderWindow.Show();
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

    }
}
