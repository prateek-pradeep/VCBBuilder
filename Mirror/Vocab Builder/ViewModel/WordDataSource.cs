using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocab_Builder.Business_Logic;
using Vocab_Builder.Common;
using Windows.UI.Xaml;

namespace Vocab_Builder.Model
{
    public class WordDataSource
    {
        private static Vocab_Builder.App app = (Application.Current as App);

        private static WordDataSource _wordDataSource = new WordDataSource();

        private ObservableCollection<WordDataGroup> _allGroups = new ObservableCollection<WordDataGroup>();
        public ObservableCollection<WordDataGroup> AllGroups
        {
            get { return _allGroups; }
        }

        public static IEnumerable<WordDataGroup> GetGroups(string uniqueId)
        {
            if (!uniqueId.Equals(Constants.ParameterAllGroups)) throw new ArgumentException(Constants.ExceptionMsg101);
            return _wordDataSource.AllGroups;
        }

        public static WordDataGroup GetGroup(string groupName)
        {
            var match = _wordDataSource.AllGroups.FirstOrDefault((group) => group.GroupName.Equals(groupName));
                if(match!=null) return match;
                return null;
        }

        public static WordDataDetail GetItem(uint wordkey)
        {
            //uint key;
            //uint.TryParse(wordkey, out key);
            var match = _wordDataSource.AllGroups.SelectMany(group => group.Items).FirstOrDefault((item) => item.WordKey == wordkey);
            if (match != null) return match;
            return null;
        }
        public static async Task LoadLocalDataAsync()
        {
            try
            {
                using (var db = new SQLite.SQLiteConnection(app.DBPath))
                {
                    var wordGroupQuery = db.Table<WordGroup>().OrderBy(groupItem => groupItem.GroupName);
                    var wordItemQuery = db.Table<WordDetails>().OrderBy(wordItem => wordItem.WordKey);

                    foreach (var group in wordGroupQuery)
                    {
                        if (!_wordDataSource._allGroups.Any(item => item.GroupName.Equals(group.GroupName)))
                        {
                            _wordDataSource.AllGroups.Add(new WordDataGroup() { GroupName = group.GroupName });
                        }
                    }

                    string lastGroupName = string.Empty;
                    WordDataDetail wordDataDetail;
                    int index = 0;
                    foreach (var item in wordItemQuery)
                    {
                        if (!lastGroupName.Equals(item.GroupName))
                        {
                            index = (int)item.GroupName[0] - Constants.AsciiValueOfA;
                        }
                        wordDataDetail = new WordDataDetail();

                        wordDataDetail.AntonymId = item.AntonymId;
                        wordDataDetail.DateModified = item.DateModified;
                        wordDataDetail.Definition = new Definitions() { DefinitionAdverb = item.DefinitionAdverb, DefinitoinAdjective = item.DefinitionAdjective, DefinitionNoun = item.DefinitionNoun, DefinitionVerb = item.DefinitionVerb };
                        wordDataDetail.Group = _wordDataSource._allGroups[index];
                        wordDataDetail.Mnemonics = item.Mnemonics;
                        wordDataDetail.Root = item.Root;
                        wordDataDetail.Sentence = item.Sentence;
                        wordDataDetail.WordKey = item.WordKey;
                        wordDataDetail.WordName = item.WordName;
                        wordDataDetail.BaseName = item.BaseName;

                        _wordDataSource._allGroups[index].Items.Add(wordDataDetail);
                    }
                }
            }
            catch (Exception ex) { }
        }

    }
}
