using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocab_Builder.ViewModel
{
    class WordPreview:Vocab_Builder.Common.BindableBase
    {
        #region FIELDS
        private uint _wordKey;
        private string _wordName;
        private string _wordBase;                                        
        #endregion

        #region Public PROPERTY
        public uint WordKey
        {
            get { return _wordKey; }
            set { this.SetProperty(ref this._wordKey, value); }
        }

        public string WordName
        {
            get { return _wordName; }
            set { this.SetProperty(ref this._wordName, value); }
        }

        public string WordBase
        {
            get { return _wordBase; }
            set { this.SetProperty(ref this._wordBase, value); }
        }
        #endregion
    }
}
