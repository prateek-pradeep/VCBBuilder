using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocab_Builder.Common;

namespace Vocab_Builder.Model
{
    public partial class WordGroup
    {        
        [SQLite.PrimaryKey, SQLite.MaxLength(Constants.MaxLength10)]
        public string GroupName { get; set; }
        [SQLite.MaxLength(Constants.MaxLength2000)]
        public string Description { get; set; }
    }
}
