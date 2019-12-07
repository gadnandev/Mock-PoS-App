using System.ComponentModel;
using System.Collections.Generic;

namespace A3.Model {
    public class Order : INotifyPropertyChanged {
        private int orderID;
        private string date;
        private List<Product> product;
        private float sPrice;
        public int OrderID {
            get {
                return orderID;
            }
            set {
                orderID = value;
                OnPropertyChanged("OrderID");
            }
        }
        public string Date {
            get {
                return date;
            }
            set {
                date = value;
                OnPropertyChanged("Date");
            }
        }
        public List<Product> Product {
            get {
                return product;
            }
            set {
                product = value;
                OnPropertyChanged("Product");
            }
        }
        public float SalePrice {
            get {
                return sPrice;
            }
            set {
                sPrice = value;
                OnPropertyChanged("SalePrice");
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
