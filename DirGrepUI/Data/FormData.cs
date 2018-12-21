namespace DirGrepUI.Data
{
    public class FormData
    {
        /// <summary>
        /// Gathering of Search Condition
        /// </summary>
        public SearchState SearchState { get; set; }

        /// <summary>
        /// Path and Parameter of TextEditor
        /// </summary>
        public ExportSetting ExportSetting { get; set; }

        /// <summary>
        /// Window's Size and Location
        /// </summary>
        public WindowsState WindowsState { get; set; }

        /// <summary>
        /// Current Language
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public FormData() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="searchState"></param>
        /// <param name="exportSetting"></param>
        /// <param name="windowsState"></param>
        /// <param name="language"></param>
        public FormData(SearchState searchState, ExportSetting exportSetting, WindowsState windowsState, string language)
        {
            SearchState = searchState;
            ExportSetting = exportSetting;
            WindowsState = windowsState;
            Language = language.ToString();
        }
    }
}
