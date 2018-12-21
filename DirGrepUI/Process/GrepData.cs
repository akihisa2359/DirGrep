namespace DirGrepUI.Process
{
    public class GrepData
    {
        /// <summary>
        /// 検索対象フォルダ
        /// </summary>
        public string SearchPlace { get; private set; }

        /// <summary>
        /// 拡張子
        /// </summary>
        public string SearchTarget { get; private set; }

        /// <summary>
        /// 検索文字
        /// </summary>
        public string SearchText { get; private set; }

        /// <summary>
        /// 子フォルダも含める
        /// </summary>
        public bool IsSubDir { get; private set; }

        /// <summary>
        /// 大文字小文字無視
        /// </summary>
        public bool IsIgnoreCase { get; private set; }

        /// <summary>
        /// 単語検索
        /// </summary>
        public bool IsSearchByWord { get; private set; }

        /// <summary>
        /// And検索
        /// </summary>
        public bool IsAnd { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="textBox_SearchPlace"></param>
        /// <param name="comboBox_SearchTarget"></param>
        /// <param name="comboBox_SearchText"></param>
        /// <param name="checkBox_SubDir"></param>
        /// <param name="checkBox_Ignore"></param>
        /// <param name="checkBox_SearchByWord"></param>
        /// <param name="button_AND"></param>
        public GrepData(string textBox_SearchPlace, string comboBox_SearchTarget, string comboBox_SearchText,
            bool checkBox_SubDir, bool checkBox_Ignore, bool checkBox_SearchByWord, bool button_AND)
        {
            SearchPlace = textBox_SearchPlace;
            SearchTarget = comboBox_SearchTarget;
            SearchText = comboBox_SearchText;
            IsSubDir = checkBox_SubDir;
            IsIgnoreCase = checkBox_Ignore;
            IsSearchByWord = checkBox_SearchByWord;
            IsAnd = button_AND;
        }
    }
}
