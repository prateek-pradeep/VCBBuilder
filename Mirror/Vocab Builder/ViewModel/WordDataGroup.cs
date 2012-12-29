using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocab_Builder.Business_Logic
{
    public class WordDataGroup : Vocab_Builder.Common.BindableBase
    {
        private string _groupName;

        public string GroupName
        {
            get { return _groupName; }
            set { this.SetProperty(ref this._groupName, value); }
        }
        
        private ObservableCollection<WordDataDetail> _items = new ObservableCollection<WordDataDetail>();
        public ObservableCollection<WordDataDetail> Items
        {
            get
            {
                return _items;
            }
        }

        public IEnumerable<WordDataDetail> TopItems
        {
            get
            {
                return this._items.Take(12);
            }
        }
    }
    

}
