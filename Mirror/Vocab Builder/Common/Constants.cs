using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocab_Builder.Common
{
    public static class Constants
    {
        #region Integer
        public const int MaxLength10 = 10;
        public const int MaxLength30 = 30;
        public const int MaxLength100 = 100;
        public const int MaxLength200 = 200;
        public const int MaxLength500 = 500;
        public const int MaxLength2000 = 2000;
        public const int AsciiValueOfA = 65;
        #endregion

        #region Character
        public const char CapsA = 'A';
        public const char CapsZ = 'Z';
        #endregion

        #region String

        public const string DatabaseFileName = "VocabData.sqlite";
        public const string GroupDescription = "This group contains all the words starting with the alphabet {0}.";

        #region Parameter
        public const string ParameterAllGroups = "AllGroups";
        #endregion

        #region Exception Message
        public const string ExceptionMsg101 = "Only 'AllGroups' is supported as a collection of groups";
        #endregion

        #endregion
    }
}
 