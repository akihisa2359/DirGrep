using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DirGrepUI.Data
{
    public class SearchState
    {
        /// <summary>
        /// Directory where Grep Start
        /// </summary>
        public string SearchPlace { get; set; }

        /// <summary>
        /// Extention
        /// </summary>
        [XmlArray("SearchTargetList")]
        [XmlArrayItem("SearchTarget")]
        public List<string> SearchTarget { get; set; }

        /// <summary>
        /// Whether Search Sub Folder or Not
        /// </summary>
        [XmlElement("SearchSubFolder")]
        public bool IsSearchSubFolder { get; set; }

        /// <summary>
        /// Words or Letters to Find Same Ones with
        /// </summary>
        [XmlArray("SearchTextList")]
        [XmlArrayItem("SearchText")]
        public List<string> SearchText { get; set; }

        /// <summary>
        /// All Words or Letters Have to Correspond
        /// </summary>
        [XmlElement("AND")]
        public bool IsAnd { get; set; }

        /// <summary>
        /// Any of Words or Letters Corresponds
        /// </summary>
        [XmlElement("OR")]
        public bool IsOr { get; set; }

        /// <summary>
        /// Ignore Capital or Small Case
        /// </summary>
        [XmlElement("IgnoreCase")]
        public bool IsIgnoreCase { get; set; }

        /// <summary>
        /// Match Word Exactly
        /// </summary>
        [XmlElement("SearchByWord")]
        public bool IsSearchByWord { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public SearchState() { }
        public SearchState(string searchPlace, ComboBox.ObjectCollection searchTarget, bool IsSubFolder, ComboBox.ObjectCollection searchText,
            bool isAnd, bool isOr, bool isIgnoreCase, bool isSearchByWord)
        {
            SearchPlace = searchPlace;
            SearchTarget = searchTarget.Cast<string>().ToList();
            IsSearchSubFolder = IsSubFolder;
            SearchText = searchText.Cast<string>().ToList();
            IsAnd = isAnd;
            IsOr = isOr;
            IsIgnoreCase = isIgnoreCase;
            IsSearchByWord = isSearchByWord;
        }
    }
}
