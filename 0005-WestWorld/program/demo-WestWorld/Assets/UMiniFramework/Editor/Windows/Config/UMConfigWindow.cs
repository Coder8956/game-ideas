using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace UMiniFramework.Editor
{
    public class UMConfigWindow : EditorWindow
    {
        private const string KeyConfigPath = "UMCFG_CONFIG_PATH";
        private const string KeyScriptsPath = "UMCFG_SCRIPTS_PATH";
        private const string KeyDataPath = "UMCFG_DATA_PATH";
        private const string KeyLangTableName = "UMCFG_LANG_TABLE_NAME";

        private const string ReadFilesTip1 = "Please click read button";
        private const string ReadFilesTip2 = "The configuration file was not read";
        private const string ReadFilesTip3 = "{0} configuration files were read";

        private const string GuiStyleHelpBox = "HelpBox";

        private const int LineHeight = 20;
        private const int MaxScrollHeight = 400;


        private string m_configInputDir;
        private string m_scriptOutputDir;
        private string m_jsonOutputDir;
        private string m_langTableName;

        private string m_readFilesTip;

        private GUIStyle m_redLabelStyle;
        private GUIStyle m_yellowLabelStyle;

        private Vector2 m_scrollPosition;
        private float m_scrollViewHeight;

        private readonly List<string> m_configFiles = new();
        
        [MenuItem("UMini/Window/Update Config")]
        private static void ShowWindow()
        {
            UMConfigWindow window = GetWindow<UMConfigWindow>();
            window.titleContent = new GUIContent("UMOConfig Editor");
            window.Show();
        }
        
        private void OnEnable()
        {
            ReadPaths();
            m_readFilesTip = ReadFilesTip1;
        }

        private void OnGUI()
        {
            InitStyles();

            DrawFolderPath(
                "Config Input Directory",
                ref m_configInputDir,
                KeyConfigPath,
                "Select Config Input Folder",
                true);
            
            DrawReadConfigFiles();
            
            GUI.enabled = m_configFiles.Count > 0;

            try
            {
                DrawFolderPath(
                    "Config Script Output Directory",
                    ref m_scriptOutputDir,
                    KeyScriptsPath,
                    "Select Script Output Folder");


                DrawFolderPath(
                    "Config Json Output Directory",
                    ref m_jsonOutputDir,
                    KeyDataPath,
                    "Select Json Output Folder");


                DrawOutputDirWarning();

                DrawUpdateButtons();
            }
            finally
            {
                GUI.enabled = true;
            }
        }
        
        private void DrawFolderPath(
            string title,
            ref string path,
            string prefsKey,
            string dialogTitle,
            bool showOpen = false)
        {
            EditorGUILayout.BeginHorizontal();

            GUILayout.Label(title, GUILayout.Width(180), GUILayout.Height(LineHeight));

            if (GUILayout.Button("Select",
                    GUILayout.Width(50),
                    GUILayout.Height(LineHeight)))
            {
                string result =
                    EditorUtility.OpenFolderPanel(
                        dialogTitle,
                        Application.dataPath,
                        "");


                if (!string.IsNullOrEmpty(result))
                {
                    path = result;
                    EditorPrefs.SetString(prefsKey, path);

                    if (prefsKey == KeyConfigPath)
                    {
                        m_readFilesTip = ReadFilesTip1;
                        m_configFiles.Clear();
                    }
                }
            }

            if (GUILayout.Button("Clear",
                    GUILayout.Width(50),
                    GUILayout.Height(LineHeight)))
            {
                path = string.Empty;
                EditorPrefs.SetString(prefsKey, path);

                if (prefsKey == KeyConfigPath)
                {
                    m_configFiles.Clear();
                }
            }

            if (showOpen &&
                GUILayout.Button("Open",
                    GUILayout.Width(50),
                    GUILayout.Height(LineHeight)))
            {
                OpenFolder(path);
            }

            GUILayout.Label(
                path,
                GuiStyleHelpBox,
                GUILayout.Height(LineHeight));

            EditorGUILayout.EndHorizontal();
        }
        
        private void DrawReadConfigFiles()
        {
            if (string.IsNullOrEmpty(m_configInputDir))
                return;

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label(
                "Language Table Name",
                GUILayout.Width(180),
                GUILayout.Height(LineHeight));
            var newLangName = EditorGUILayout.TextField(
                m_langTableName,
                GUILayout.Height(LineHeight));
            if (newLangName != m_langTableName)
            {
                m_langTableName = newLangName;
                EditorPrefs.SetString(KeyLangTableName, m_langTableName);
            }
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Read Config Files"))
            {
                m_configFiles.Clear();

                UMConfigHandler.GetAllExcelFiles(
                    m_configInputDir,
                    m_configFiles);
                
                if (m_configFiles.Count == 0)
                {
                    m_readFilesTip = ReadFilesTip2;
                }
                else
                {
                    m_readFilesTip =
                        string.Format(
                            ReadFilesTip3,
                            m_configFiles.Count);
                }

                m_scrollViewHeight =
                    Mathf.Clamp(
                        m_configFiles.Count * LineHeight,
                        0,
                        MaxScrollHeight);
            }
            
            GUILayout.Label(
                m_readFilesTip,
                GuiStyleHelpBox,
                GUILayout.Height(LineHeight));
            
            if (m_configFiles.Count == 0)
                return;
            
            m_scrollPosition =
                GUILayout.BeginScrollView(
                    m_scrollPosition,
                    GUILayout.Height(m_scrollViewHeight));

            for (int i = 0; i < m_configFiles.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();

                GUILayout.Label(
                    $"Config-{i:D5}",
                    GUILayout.Width(100));

                string fileName = Path.GetFileNameWithoutExtension(m_configFiles[i]);
                bool isLangFile = !string.IsNullOrEmpty(m_langTableName) &&
                                  fileName.Equals(m_langTableName, System.StringComparison.OrdinalIgnoreCase);

                if (isLangFile)
                {
                    GUILayout.Label("[lang]", m_yellowLabelStyle, GUILayout.Width(50));
                }
                else
                {
                    GUILayout.Label("", GUILayout.Width(50));
                }

                GUILayout.Label(m_configFiles[i]);

                EditorGUILayout.EndHorizontal();
            }
            
            GUILayout.EndScrollView();
        }
        
        private void DrawOutputDirWarning()
        {
            GUILayout.Label(
                "The output directory is cleared when an update is performed.",
                m_redLabelStyle);
        }

        private void DrawUpdateButtons()
        {
            if (string.IsNullOrEmpty(m_jsonOutputDir) ||
                string.IsNullOrEmpty(m_scriptOutputDir))
                return;

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Update Data"))
            {
                UMConfigHandler.UpdateConfig(
                    m_configFiles,
                    m_scriptOutputDir,
                    m_jsonOutputDir,
                    UMConfigUpdateMode.Data,
                    m_langTableName);
            }

            if (GUILayout.Button("Update Scripts"))
            {
                UMConfigHandler.UpdateConfig(
                    m_configFiles,
                    m_scriptOutputDir,
                    m_jsonOutputDir,
                    UMConfigUpdateMode.Scripts,
                    m_langTableName);
            }

            if (GUILayout.Button("Update Data&Scripts"))
            {
                UMConfigHandler.UpdateConfig(
                    m_configFiles,
                    m_scriptOutputDir,
                    m_jsonOutputDir,
                    UMConfigUpdateMode.DataAndScripts,
                    m_langTableName);
            }

            EditorGUILayout.EndHorizontal();
        }
        
        private void InitStyles()
        {
            if (m_redLabelStyle != null)
                return;


            m_redLabelStyle =
                new GUIStyle(GUI.skin.label)
                {
                    normal =
                    {
                        textColor = Color.red
                    }
                };

            m_yellowLabelStyle =
                new GUIStyle(GUI.skin.label)
                {
                    normal =
                    {
                        textColor = Color.yellow
                    }
                };
        }

        private void OpenFolder(string path)
        {
            if (Directory.Exists(path))
            {
                EditorUtility.RevealInFinder(path);
            }
            else
            {
                EditorUtility.DisplayDialog(
                    "Invalid Config Directory",
                    "Please select a valid directory.",
                    "OK");
            }
        }

        private void ReadPaths()
        {
            m_configInputDir =
                EditorPrefs.GetString(KeyConfigPath, "");


            m_scriptOutputDir =
                EditorPrefs.GetString(KeyScriptsPath, "");


            m_jsonOutputDir =
                EditorPrefs.GetString(KeyDataPath, "");


            m_langTableName =
                EditorPrefs.GetString(KeyLangTableName, "");
        }
    }
}