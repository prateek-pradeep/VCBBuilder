using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocab_Builder.Business_Logic
{
    public class Definitions:Vocab_Builder.Common.BindableBase
    {
        private string _definitoinAdjective;

        public string DefinitoinAdjective
        {
            get { return _definitoinAdjective; }
            set { this.SetProperty(ref this._definitoinAdjective, value); }
        }
        private string _definitoinAdverb;

        public string DefinitionAdverb
        {
            get { return _definitoinAdverb; }
            set { this.SetProperty(ref this._definitoinAdverb, value); }
        }

        private string _definitionNoun;

        public string DefinitionNoun
        {
            get { return _definitionNoun; }
            set { this.SetProperty(ref this._definitionNoun, value); }
        }

        private string _definitionVerb;

        public string DefinitionVerb
        {
            get { return _definitionVerb; }
            set { this.SetProperty(ref this._definitionVerb, value); }
        }
        
        
    }
}
