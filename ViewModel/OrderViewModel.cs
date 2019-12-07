using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;  
using System.ComponentModel;
using A3.Model;

namespace A3.Viewmodel {
    class OrderViewModel {
        private IList<Order> _OrderList;
        //private ContractMarketplace _Marketplace;

        public OrderViewModel() {

        }

        public IList<Order> Orders {
            get { return _OrderList; }
            set { _OrderList = value; }
        }

        // this is going to be irrilavent
        private ICommand mUpdater;

        // this is going to be irrilavent
        public ICommand UpdateCommand {
            get {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set {
                mUpdater = value;
            }
        }

        // this is going to be irrilavent
        private class Updater : ICommand {
            #region ICommand Members  

            public bool CanExecute(object parameter) {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter) {

            }

            #endregion
        }
    }
}
