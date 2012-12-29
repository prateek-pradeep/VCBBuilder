using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocab_Builder.Common;

namespace Vocab_Builder.Model
{
    public class WordBase
    {
        [SQLite.PrimaryKey, SQLite.MaxLength(Constants.MaxLength10)]
        public string BaseName { get; set; }
    }
}
