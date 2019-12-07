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
using A3.View;
namespace A3 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window {
        private readonly ProductViewModel _viewModel = new ProductViewModel();
        public ProductWindow() {
            InitializeComponent();
            DataContext = _viewModel;
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
