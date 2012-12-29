using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocab_Builder.Common;

namespace Vocab_Builder.Model
{
    class WordDetails
    {
        [SQLite.PrimaryKey]
        public UInt32 WordKey { get; set; }

        [SQLite.MaxLength(Constants.MaxLength30)]
        public string WordName { get; set; }

        [SQLite.Indexed]
        public UInt32 AntonymId { get; set; }

        [SQLite.MaxLength(Constants.MaxLength200)]
        public string DefinitionAdjective { get; set; }

        [SQLite.MaxLength(Constants.MaxLength200)]
        public string DefinitionAdverb { get; set; }

        [SQLite.MaxLength(Constants.MaxLength200)]
        public string DefinitionNoun { get; set; }

        [SQLite.MaxLength(Constants.MaxLength200)]
        public string DefinitionVerb { get; set; }

        [SQLite.MaxLength(Constants.MaxLength500)]
        public string Sentence { get; set; }

        [SQLite.MaxLength(Constants.MaxLength100)]
        public string Root { get; set; }

        [SQLite.MaxLength(Constants.MaxLength100)]
        public string Mnemonics { get; set; }

        [SQLite.MaxLength(Constants.MaxLength10)]
        public string Derivative { get; set; }

        [SQLite.Indexed]
        public string GroupName { get; set; }

        [SQLite.Indexed]
        public string BaseName { get; set; }

        public DateTime DateModified { get; set; }        
    }
}
