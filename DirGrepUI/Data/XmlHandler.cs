using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace DirGrepUI.Data
{
    class XmlHandler
    {
        // File/Folder Name
        const string XmlFolderName = "DirGrep";
        const string XmlFileName = "Setting.xml";
        const string TargetFolderName = "ActySystem";

        // TagName
        const string RootTag = "FormData";
        const string WindowStateTag = "WindowsState";
        const string PositionTag = "Position";
        const string SearchStateTag = "SearchState";
        const string LanguageTag = "Language";
        const string OrTag = "OR";
        const string XTag = "X";
        const string YTag = "Y";

        // DefaultSetting
        const string DefaultLanguage = "en-US";
        const int DefaultXCoordinate = 630;
        const int DefaultYCoordinate = 308;

        /// <summary>
        /// フォームの情報
        /// </summary>
        public FormData FormData { get; private set; } = null;

        /// <summary>
        /// シリアライズのためのコンストラクタ
        /// </summary>
        /// <param name="searchState"></param>
        /// <param name="exportSetting"></param>
        /// <param name="windowsState"></param>
        /// <param name="language"></param>
        public XmlHandler(SearchState searchState, WindowsState windowsState, string language)
        {
            ExportSetting exportSetting = new ExportSetting(EditorPath, Parameter);
            FormData = new FormData(searchState, exportSetting, windowsState, language);
        }

        /// <summary>
        /// シリアライズのためのコンストラクタ
        /// </summary>
        /// <param name="exportSetting"></param>
        public XmlHandler(ExportSetting exportSetting)
        {
            FormData = Deserialize();
            FormData.ExportSetting = exportSetting;
        }

        /// <summary>
        /// データ取得のためのコンストラクタ
        /// </summary>
        public XmlHandler() { }

        /// <summary>
        /// フォーム情報をxmlファイルに記入
        /// </summary>
        public void Serialize()
        {
            // パス作成
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = Path.Combine(path, TargetFolderName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, XmlFolderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, XmlFileName);

            // シリアライズ
            System.Xml.Serialization.XmlSerializer serializer =
               new System.Xml.Serialization.XmlSerializer(typeof(FormData));

            using (StreamWriter sw = new StreamWriter(path, false, new System.Text.UTF8Encoding(false)))
            {
                serializer.Serialize(sw, FormData);
            }
        }

        /// <summary>
        /// Return Xml Data
        /// </summary>
        /// <returns>formData</returns>
        public FormData Deserialize()
        {
            string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string pathXml = Path.Combine(targetPath, TargetFolderName, XmlFolderName, XmlFileName);

            try
            {
                if (File.Exists(pathXml))
                {
                    // デフォルト設定が決まっているものがxmlファイルの要素から消えている場合、デフォルトに設定する
                    XDocument document = XDocument.Load(pathXml);
                    if (document.Element(RootTag).Element(WindowStateTag).Element(PositionTag).Element(XTag) == null)
                    {
                        document.Element(RootTag).Element(WindowStateTag).Element(PositionTag).SetElementValue(XTag, DefaultXCoordinate);
                        document.Save(pathXml);
                    }
                    if (document.Element(RootTag).Element(WindowStateTag).Element(PositionTag).Element(YTag) == null)
                    {
                        document.Element(RootTag).Element(WindowStateTag).Element(PositionTag).SetElementValue(YTag, DefaultYCoordinate);
                        document.Save(pathXml);
                    }
                    if (document.Element(RootTag).Element(SearchStateTag).Element(OrTag) == null)
                    {
                        document.Element(RootTag).Element(SearchStateTag).SetElementValue(OrTag, true);
                        document.Save(pathXml);
                    }

                    // デシリアライズ
                    System.Xml.Serialization.XmlSerializer serializer =
                           new System.Xml.Serialization.XmlSerializer(typeof(FormData));

                    using (StreamReader sr = new StreamReader(pathXml, new System.Text.UTF8Encoding(false)))
                    {
                        FormData = (FormData)serializer.Deserialize(sr);
                    }
                }

                return FormData;
            }
            catch (XmlException)
            {
                // xmlファイルの読み取り失敗の場合、nullを返して続行
                return FormData;
            }
        }

        /// <summary>
        /// Get Language
        /// </summary>
        public string Language
        {
            get
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                path = Path.Combine(path, TargetFolderName, XmlFolderName, XmlFileName);
                string language = null;

                try
                {
                    // xmlファイルが存在する場合
                    if (File.Exists(path))
                    {
                        language = (string)XDocument.Load(path).Element(RootTag).Element(LanguageTag);
                    }

                    if (string.IsNullOrEmpty(language))
                    {
                        language = DefaultLanguage;
                    }

                    return language;
                }
                catch (XmlException)
                {
                    // xmlファイルの中身が不正である場合、DefaultLanguageをreturn
                    return DefaultLanguage;
                }
            }
        }

        /// <summary>
        /// GetEditorPath
        /// </summary>
        public string EditorPath
        {
            get
            {
                FormData = Deserialize();

                if (FormData == null)
                {
                    return string.Empty;
                }
                else
                {
                    return FormData.ExportSetting.Path;
                }
            }
        }

        /// <summary>
        /// GetParameter
        /// </summary>
        public string Parameter
        {
            get
            {
                FormData = Deserialize();

                if (FormData == null)
                {
                    return string.Empty;
                }
                else
                {
                    return FormData.ExportSetting.Parameter;
                }
            }
        }
    }
}
