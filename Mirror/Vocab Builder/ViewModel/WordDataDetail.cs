using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocab_Builder.Model;

namespace Vocab_Builder.Business_Logic
{
    public class WordDataDetail:Vocab_Builder.Common.BindableBase
    {
        private UInt32 _wordKey;

        public UInt32 WordKey
        {
            get { return _wordKey; }
            set { this.SetProperty(ref this._wordKey, value); }
        }

        private string _wordName;

        public string WordName
        {
            get { return _wordName; }
            set { this.SetProperty(ref this._wordName, value); }
        }

        private string _baseName;

        public string BaseName
        {
            get { return _baseName; }
            set { this.SetProperty(ref this._baseName, value); }
        }
        
        private UInt32 _antonymId;

        public UInt32 AntonymId
        {
            get { return _antonymId; }
            set { this.SetProperty(ref this._antonymId, value); }
        }

        private Definitions _definition;

        public Definitions Definition
        {
            get { return _definition; }
            set { this.SetProperty(ref this._definition, value); }
        }

        private string _sentence;

        public string Sentence
        {
            get { return _sentence; }
            set { this.SetProperty(ref this._sentence, value); }
        }

        private string _root;

        public string Root
        {
            get { return _root; }
            set { this.SetProperty(ref this._root, value); }
        }

        private string _mnemonics;

        public string Mnemonics
        {
            get { return _mnemonics; }
            set { this.SetProperty(ref this._mnemonics, value); }
        }

        private Vocab_Builder.Common.EnumResources.Derivative _derivative;

        public Vocab_Builder.Common.EnumResources.Derivative Derivative
        {
            get { return _derivative; }
            set { this.SetProperty(ref this._derivative, value); }
        }

        private DateTime _dateModified;

        public DateTime DateModified
        {
            get { return _dateModified; }
            set { this.SetProperty(ref this._dateModified, value); }
        }

        private WordDataGroup _group;

        public WordDataGroup Group
        {
            get { return _group; }
            set { this.SetProperty(ref this._group, value); }
        }
        


                      
    }
}
