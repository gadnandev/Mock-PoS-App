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
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace A3 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window {  //, INotifyPropertyChanged <- Removed as part of the search feature
        public ObservableCollection<Product> _ProdToOrder { get; set; }
        private readonly ProductViewModel _viewModel = new ProductViewModel();
        private Order newOrder;
        private Customer selectedCustomer;
        private List<Product> prodOrders;
        private string date;
        // ** ATTEMPT AT BUILDING A SEARCH FEATURE ** //


        //private string _searchText;

        //public string SearchText {
        //    get { return _searchText; }
        //    set {
        //        _searchText = value;

        //        OnPropertyChanged("SearchText");
        //        OnPropertyChanged("MyFilteredItems");
        //    }
        //}

        //public ObservableCollection<Product> _ProdToOrderFiltered { get; set; }

        //public IEnumerable<Product> MyFilteredItems {
        //    get {
        //        if (SearchText == null) return _ProdToOrder;

        //        return _ProdToOrder.Where(x => x.Name.ToUpper().StartsWith(SearchText.ToUpper()));
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        //void OnPropertyChanged(string name) {
        //    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        //}

        // Method    : OrderWindow
        // Description : Constructor that takes in the selected branch and the customer for the order to create an order
        //     
        //      
        //  Parameters  : string selectedBranch, Customer newCustomer : this is the branch that is selected and the customer
        //      
        //  Returns     : void
        //      
        public OrderWindow(string selectedBranch, Customer newCustomer) {
            InitializeComponent();
            DateTime tmpDate = new DateTime();
            date = tmpDate.ToShortDateString(); 
            DataContext = _viewModel;
            BranchSelected.Content = selectedBranch;
            selectedCustomer = newCustomer;
            CustomerSelected.Content = selectedCustomer.FullName;
            _ProdToOrder = new ObservableCollection<Product>();
            newOrder = new Order();
            prodOrders = new List<Product>();
            newOrder.Date = date;
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

        // Method    : BranchBtn_Click
        // Description :  Opens the branch, or 'Main Menu'
        //     
        //      
        //  Parameters  : Button Event
        //      
        //  Returns     : void
        //      
        private void BranchBtn_Click(object sender, RoutedEventArgs e) {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        // Method    : AddToOrder_Click
        // Description : This method creates a new object based on the object selected. It has binding method to elements where a ListView item is clicked and populated.
        //     These elements are hidden and are used to populate the product. Once clicked, it is added to the product order item source binding. They are also added toa list that is added to an order object.
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
            prodOrders.Add(newProduct);
            CompleteOrder.IsEnabled = true;
        }

        // Method    : 
        // Description : 
        //     
        //      
        //  Parameters  :
        //      
        //  Returns     :
        //      
        private void ProductList_Clicked (object sender, SelectionChangedEventArgs e) {
            AddToOrder.IsEnabled = true;

        }

        private void CommitOrder_Click (object sender, RoutedEventArgs e) {
            

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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

        }
    }
}
