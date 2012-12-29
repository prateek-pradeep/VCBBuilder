using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocab_Builder.ViewModel
{
    class GroupItems : Vocab_Builder.Common.BindableBase
    {
        #region FIELDS
        private string _groupName;
        private ObservableCollection<WordPreview> _wordList ;                                    
        #endregion

        #region Public PROPERRTY
        public string GroupName
        {
            get { return _groupName; }
            set { this.SetProperty(ref this._groupName, value); }
        }
        public ObservableCollection<WordPreview> WordList
        {
            get { return _wordList; }
            set { this.SetProperty(ref this._wordList, value); }
        }
        #endregion
    }
}
