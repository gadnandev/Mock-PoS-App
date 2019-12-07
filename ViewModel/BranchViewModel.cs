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
using System.Windows.Input;  
using System.ComponentModel;
using A3.Model;
using A3.Classes.DataLogic;

namespace A3.ViewModel {
    class BranchViewModel {
        private IList<Branch> _BranchList;
        private WallyWorldData _WallyWord;
        //private ContractMarketplace _Marketplace;

        // Method    : 
        // Description : 
        //     
        //      
        //  Parameters  :
        //      
        //  Returns     :
        //  
        public BranchViewModel() {
            _WallyWord = new WallyWorldData();
            _BranchList = _WallyWord.GetBranches();
        }

        // Method    : 
        // Description : 
        //     
        //      
        //  Parameters  :
        //      
        //  Returns     :
        //  
        public IList<Branch> Branchs {
            get { return _BranchList; }
            set { _BranchList = value; }
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
