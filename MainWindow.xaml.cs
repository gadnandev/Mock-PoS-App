using System.Windows;
using A3.ViewModel;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using A3.View;

namespace A3 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly BranchViewModel _viewModel = new BranchViewModel();
        public MainWindow() {

            InitializeComponent();
            DataContext = _viewModel;
        }

        private void ProductBtn_Click(object sender, RoutedEventArgs e) {
            ProductWindow productWindow = new ProductWindow();
            productWindow.Show();
            this.Close();
        }
        private void BranchBtn_Click(object sender, RoutedEventArgs e) {
            OrderOverViewWindow orderWindow = new OrderOverViewWindow();
            orderWindow.Show();
            this.Close();
        }

        private void BeginOrder_Click(object sender, RoutedEventArgs e) {
            CustomerWindow customerWindow = new CustomerWindow(BrandName_Selected.Text);
            customerWindow.Show();
            this.Close();
            //OrderWindow orderWindow = new OrderWindow(BrandName_Selected.Text);
            //orderWindow.Show();
            //this.Close();
        }

        
        //private void 
        //private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
        //    var item = sender as ListViewItem;
        //    if (item != null && item.IsSelected) {

        //        Select_Branch.Content = "Begin Order";
        //        Select_Branch.IsEnabled = true;
        //    } else {
        //        Select_Branch.Content = "Please Select Branch";
        //        Select_Branch.IsEnabled = false;
        //    }
        //}
        private void BranchGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            Select_Branch.Content = BrandName_Selected.Text + " Selected - Begin Order";
            Select_Branch.IsEnabled = true;
        }


    }
}
