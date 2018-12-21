using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace DirGrepUI.Process
{
    public class SearchProcessor
    {
        /// <summary>
        /// 一度にアウトプットする単位
        /// </summary>
        const int ListOutputUnit = 100;

        /// <summary>
        /// 検索をキャンセルするためのトークン
        /// </summary>
        public CancellationTokenSource TokenSource { get; set; }

        /// <summary>
        /// Grep中に発生したエラーメッセージ
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// スレッドの終了を管理するための変数
        /// </summary>
        public Task Task { get; set; }

        /// <summary>
        /// 検索途中に閉じる処理がされたときのフラグ
        /// </summary>
        public bool IsClose { get; set; }

        /// <summary>
        /// ログを出力するための変数
        /// </summary>
        private log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 検索Hit時に項目を格納
        /// </summary>
        private List<ResultData> _resultList = new List<ResultData>();

        /// <summary>
        /// 検索中に開けなかったファイル
        /// </summary>
        private List<string> _fileNotOpened = new List<string>();

        /// <summary>
        /// プログレスバーを更新する
        /// </summary>
        private Action<int, int> _actionUpdateProgress;

        /// <summary>
        /// 結果を通知する
        /// </summary>
        private Action<List<ResultData>> _atcioinNotifyResult;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="updateProgress"></param>
        /// <param name="notifyResult"></param>
        /// <param name="setMessage"></param>
        public SearchProcessor(Action<int, int> actionUpdateProgress, Action<List<ResultData>> actionNotifyResult)
        {
            _actionUpdateProgress = actionUpdateProgress;
            _atcioinNotifyResult = actionNotifyResult;
        }

        /// <summary>
        /// SearchFiles : SearchFiles and Add items in listview
        /// </summary>
        public async Task SearchFiles(GrepData grepData)
        {
            try
            {
                TokenSource = new CancellationTokenSource();
                Message = null;
                string[] paths = GetPath(grepData);
                string[] searchTexts = GetSearchText(grepData);
                int totalFileNum = paths.Length;
                int fileCount = 0;

                Task = Task.Run(() =>
                {
                    foreach (string path in paths)
                    {
                        fileCount++;

                        try
                        {
                            // プログレスバーを更新
                            _actionUpdateProgress(fileCount, totalFileNum);

                            // 検索文字列が含まれるファイルをListViewに追加
                            SearchText(grepData, path, searchTexts, TokenSource.Token);
                        }
                        // キャンセル要求されたときの例外
                        catch (OperationCanceledException)
                        {
                            _logger.Info("検索が中止されました");
                            return;
                        }
                        catch (Exception e)
                        {
                            _logger.Error(e);
                            return;
                        }
                    }

                    // _itemListの余った項目をアウトプットして終了
                    _atcioinNotifyResult(_resultList);
                }, TokenSource.Token);

                await Task;

                if (IsClose)
                {
                    return;
                }

                if (_fileNotOpened.Count != 0)
                {
                    string Message = Resources.language.FileOpenFailed + Environment.NewLine;
                    foreach (string file in _fileNotOpened)
                    {
                        Message += string.Format("・{0}\n", file);
                    }
                }
            }
            catch (Exception e)
            {
                _logger.Error(e.StackTrace);
            }
        }

        /// <summary>
        /// Return Path
        /// </summary>
        /// <returns>paths</returns>
        private string[] GetPath(GrepData grepData)
        {
            string[] paths;

            // 子フォルダも含めて検索
            if (grepData.IsSubDir)
            {
                paths = System.IO.Directory.GetFiles(grepData.SearchPlace, '*' + grepData.SearchTarget, System.IO.SearchOption.AllDirectories);
            }
            // 選択したフォルダ内のみ検索
            else
            {
                paths = System.IO.Directory.GetFiles(grepData.SearchPlace, '*' + grepData.SearchTarget, System.IO.SearchOption.TopDirectoryOnly);
            }

            if (paths.Length == 0)
            {
                Message = Resources.language.TargetNotExist;
            }

            return paths;
        }

        /// <summary>
        /// Return SearchText
        /// </summary>
        /// <returns>searchTexts</returns>
        private string[] GetSearchText(GrepData grepData)
        {
            int index = 0;
            string separator = " | ";
            string[] searchTexts = Strings.Split(grepData.SearchText, separator);

            // 大文字小文字を区別しない
            if (grepData.IsIgnoreCase)
            {
                foreach (string str in searchTexts)
                {
                    searchTexts[index++] = str.ToLower();
                }
            }
            index = 0;

            // 単語一致
            if (grepData.IsSearchByWord)
            {
                foreach (string str in searchTexts)
                {
                    searchTexts[index++] = @"\b" + str + @"\b";
                }
            }

            return searchTexts;
        }

        /// <summary>
        /// Search matching word and add listview
        /// </summary>
        /// <param name="path"></param>
        /// <param name="searchTexts"></param>
        /// <param name="add"></param>
        /// <returns>Continue Or Cancel</returns>
        private void SearchText(GrepData grepData, string path, string[] searchTexts, CancellationToken token)
        {
            int lineCount = 0;
            string line = null;
            string fileName = Path.GetFileName(path);

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        // キャンセル要求があれば例外スロー
                        token.ThrowIfCancellationRequested();

                        lineCount++;

                        // Hitすればarrにリストの要素を格納する
                        if (IsHit(grepData, line, searchTexts))
                        {
                            _resultList.Add(new ResultData(fileName, lineCount.ToString(), path));
                        }

                        // ListOutputUnitの数だけ格納したら、アウトプット
                        if (_resultList.Count == ListOutputUnit)
                        {
                            _atcioinNotifyResult(_resultList);
                            _resultList.Clear();
                        }

                    }
                }
            }
            catch (IOException e)
            {
                _fileNotOpened.Add(Path.GetFileName(path));
                _logger.Error(e.StackTrace);
            }
        }

        /// <summary>
        /// Return Hit Or Not
        /// </summary>
        /// <param name="line"></param>
        /// <param name="searchTexts"></param>
        /// <returns>true Or false</returns>
        private bool IsHit(GrepData grepData, string line, string[] searchTexts)
        {
            //大文字小文字を区別しない
            if (grepData.IsIgnoreCase)
            {
                line = line.ToLower();
            }

            // AND検索
            if (grepData.IsAnd)
            {
                if (searchTexts.All(str => Regex.IsMatch(line, str)))
                {
                    return true;
                }
            }
            // OR検索
            else
            {
                if (searchTexts.Any(str => Regex.IsMatch(line, str)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

