namespace DirGrepUI.Process
{
    public class ResultData
    {
        /// <summary>
        /// ファイル名
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// 見つかった文字の行
        /// </summary>
        public string LineNum { get; private set; }

        /// <summary>
        /// ファイルパス
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="lineNum"></param>
        /// <param name="filePath"></param>
        public ResultData(string fileName, string lineNum, string filePath)
        {
            FileName = fileName;
            LineNum = lineNum;
            FilePath = filePath;
        }
    }
}
