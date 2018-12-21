namespace DirGrepUI.Data
{
    public class ExportSetting
    {
        /// <summary>
        /// TextEditor's Path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Parameter
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ExportSetting() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameter"></param>
        public ExportSetting(string path, string parameter)
        {
            Path = path;
            Parameter = parameter;
        }
    }
}
