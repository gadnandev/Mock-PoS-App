/*
* FILE : CustomerWindow.cs
* PROJECT : Assignment 3
* PROGRAMMER : Robert Ochinski
* FIRST VERSION : 2019-12-06
* DESCRIPTION : 
*
*/

using System.Windows;
using A3.ViewModel;
using System.Windows.Controls;
using A3.Model;
using System.Collections.ObjectModel;
using System;

namespace A3 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window {
        public ObservableCollection<Product> _ProdToOrder { get; set; }

        private readonly ProductViewModel _viewModel = new ProductViewModel();
        private Customer selectedCustomer;

        // Method    : 
        // Description : 
        //     
        //      
        //  Parameters  :
        //      
        //  Returns     :
        //      
        public OrderWindow(string selectedBranch, Customer newCustomer) {
            InitializeComponent();
            DataContext = _viewModel;
            BranchSelected.Content = selectedBranch;
            selectedCustomer = newCustomer;
            CustomerSelected.Content = selectedCustomer.FullName;
            this._ProdToOrder = new ObservableCollection<Product>();

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
        private void AddToOrder_Click(object sender, RoutedEventArgs e) {
            Product newProduct = new Product() {
                SKU = (int)productSKU.Content,
                Name = (string)productName.Content,
                WholeSalePrice = Math.Round((decimal)productPrice.Content * (decimal)1.40 * int.Parse(productQuantity.Text),2),
                Quantity = int.Parse(productQuantity.Text)
            };
            if (newProduct.Quantity <= (int)productStock.Content) {
                if (!this._ProdToOrder.Contains(newProduct)) {
                    this._ProdToOrder.Add(newProduct);
                }
            }
            lvProductOrder.ItemsSource = _ProdToOrder;
        }

        // Method    : 
        // Description : 
        //     
        //      
        //  Parameters  :
        //      
        //  Returns     :
        //      
        private void ProductList_Clicked(object sender, SelectionChangedEventArgs e) {
            AddToOrder.IsEnabled = true;

        }

        // Method    : 
        // Description : 
        //     
        //      
        //  Parameters  :
        //      
        //  Returns     :
        //      
        private void productQuantity_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e) {

        }
    }
}
