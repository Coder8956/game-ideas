
using System;
using HutongGames.PlayMaker.Editor.Install;
using Install.Validation;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    /// <summary>
    /// Welcome window to import PlayMaker into a project.
    /// We do this instead of importing PlayMaker directly so
    /// that we have a chance to validate the installation first.
    /// After importing, the WelcomeWindow should open automatically.
    /// </summary>
    [Serializable]
    [EditorWindowTitle(title = Title)]
    internal class InstallWindow : EditorWindow
    {
        private const string Title = "Install PlayMaker";
        
        [MenuItem("PlayMaker/Install...", false, 300)]
        public static void Open() => GetWindow<InstallWindow>(true);

        [SerializeField] private VisualTreeAsset uxml;

        private VisualElement _container;
        private Button _installButton;
        private HelpBox _notes;
        private bool _hasCriticalError;
        
        private void OnEnable()
        {
            titleContent = new GUIContent(Title);
            //minSize = maxSize = new Vector2(250, 250);
        }

        private void CreateGUI()
        {
            var root = rootVisualElement;
            uxml.CloneTree(root);

            // Set root to not grow
            root.style.flexGrow = 0;
            root.style.flexShrink = 0;
            
            UpdateCurrentVersion();
            
            var installVersionLabel = root.Q<Label>("install-version");
            installVersionLabel.text = $"Installer Version: {InstallInfo.InstallerVersionDisplay}";
            
            _installButton = root.Q<Button>("install");
            _installButton.clicked += InstallPlayMaker;
            
            var helpButton = root.Q<Button>("help");
            helpButton.clicked += () => Application.OpenURL("https://hutonggames.com/playmaker/docs/welcome/installation/");
            
            _notes = root.Q<HelpBox>("notes");
            _notes.messageType = HelpBoxMessageType.None;
            _notes.text = "NOTE: PlayMaker2 cannot be installed in the same project as PlayMaker1";
            
            CheckForErrors();

            if (_hasCriticalError)
            {
                _installButton.SetEnabled(false);
            }
            
            _container = root.Q("container");
            _container.RegisterCallback<GeometryChangedEvent>(FitContents);
        }

        private void FitContents(GeometryChangedEvent evt)
        {
            _container.UnregisterCallback<GeometryChangedEvent>(FitContents);
            if (evt.newRect is { width: > 0, height: > 0 })
            {
                // Add small padding to prevent scrollbars
                minSize = maxSize = new Vector2(
                    evt.newRect.width + 6,
                    evt.newRect.height + 16
                );
            }
        }
        
        private void UpdateCurrentVersion()
        {
            InstallInfo.UpdateInfo();

            var currentVersionLabel = rootVisualElement.Q<Label>("current-version");
            if (currentVersionLabel == null) return;
            
            if (InstallInfo.IsPlayMakerInstalled())
            {
                currentVersionLabel.text = $"Current Version: {InstallInfo.InstalledVersionDisplay}";
            }
            else
            {
                currentVersionLabel.style.display = DisplayStyle.None;
            }
        }

        private void InstallPlayMaker()
        {
            if (!EditorUtility.DisplayDialog("Install PlayMaker", 
                    "Installation may take a few moments to complete.",
                    "OK", "Cancel"))
            {
                return;
            }
            
            Installer.InstallPlayMaker();
        }

        private void OnFocus()
        {
            // Haven't found a good callback to update current version ofter importing.
            // (after import, recompile, delayed saving current version file).
            // So just do it here.
            UpdateCurrentVersion();
        }

        private void CheckForErrors()
        {
            _hasCriticalError = false;
            
            var errors = rootVisualElement.Q<HelpBox>("error");
            
            if (PlayMaker1Check.Failed())
            {
                errors.text = "Cannot install PlayMaker 2 in the same project as PlayMaker 1!";
                errors.messageType = HelpBoxMessageType.Error;
                _installButton.SetEnabled(false);
                _notes.style.display = DisplayStyle.None;
                _hasCriticalError = true;
            }
            else if (InstallInfo.InstallerBuildIsOlder)
            {
                errors.text =
                    "The version installed is newer than the version of PlayMaker you are trying to install. " +
                    "\n\nPlease update PlayMaker to the latest version.";
                errors.messageType = HelpBoxMessageType.Warning;
                _notes.style.display = DisplayStyle.None;
            }
            else if (InstallInfo.InstalledUnityVersionMismatch)
            {
                if (InstallInfo.InstallerPackageMatchesCurrentUnityVersion)
                {
                    errors.style.display = DisplayStyle.None;
                }
                else
                {
                    errors.text = InstallInfo.UnityVersionMismatchMessage;
                    errors.messageType = HelpBoxMessageType.Error;
                    _installButton.SetEnabled(false);
                    _notes.style.display = DisplayStyle.None;
                    _hasCriticalError = true;
                }
            }
            #if UNITY_6000_0_OR_NEWER
            else if (UnityVersionCheck.IsUnityVersionInRange("6000.3.0", "6000.3.4"))
            {
                errors.text =
                    "Unity 6000.3.0 through 6000.3.4 contain known Unity editor issues that can affect PlayMaker.\n\n" +
                    "We recommend updating to Unity 6000.3.5f1 or newer.";
                errors.messageType = HelpBoxMessageType.Warning;
                _notes.style.display = DisplayStyle.None;
            }
            #endif
            else
            {
                errors.style.display = DisplayStyle.None;
            }
        }
    }
}
