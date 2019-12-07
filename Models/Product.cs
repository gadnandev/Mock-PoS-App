using System.ComponentModel;

namespace A3.Model {
    public class Product : INotifyPropertyChanged {
        private int sku;
        private string name;
        private decimal wPrice;
        private int stock;
        private int quantity;
        public int SKU {
            get {
                return sku;
            }
            set {
                sku = value;
                OnPropertyChanged("SKU");
            }
        }
        public string Name {
            get {
                return name;
            }
            set {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public decimal WholeSalePrice {
            get {
                return wPrice;
            }
            set {
                wPrice = value;
                OnPropertyChanged("WholeSalePrice");
            }
        }
        public int Stock {
            get {
                return stock;
            }
            set {
                stock = value;
                OnPropertyChanged("Stock");
            }
        }

        public int Quantity {
            get {
                return quantity;
            }
            set {
                quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
