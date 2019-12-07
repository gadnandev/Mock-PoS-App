using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;  
using System.ComponentModel;
using A3.Model;
using A3.Classes.DataLogic;

namespace A3.ViewModel {
    class ProductViewModel {
        private IList<Product> _ProductList;
        private WallyWorldData _WallyWord;
        
        public ProductViewModel() {
            _WallyWord = new WallyWorldData();
            _ProductList = _WallyWord.GetProducts();
        }

        public IList<Product> Products {
            get { return _ProductList; }
            set { _ProductList = value; }
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
