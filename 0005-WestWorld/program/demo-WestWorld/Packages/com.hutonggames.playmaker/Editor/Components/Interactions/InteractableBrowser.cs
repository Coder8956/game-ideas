using HutongGames.Editor;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Editor
{
    [EditorWindowTitle(title = Title)]
    public sealed class InteractableBrowser : EditorWindow
    {
        private const string Title = "Interactables";
        private const string ViewDataKey = "PlayMaker.InteractableBrowser";

        private InteractableBrowserView _view;

        [MenuItem(PlayMakerMenu.InteractableBrowser, false, PlayMakerMenu.InteractableBrowserPriority)]
        private static void Open() => GetWindow<InteractableBrowser>();

        private void OnEnable()
        {
            titleContent = new GUIContent(Title, Icons.PlayMakerWindowIcon);
        }

        private void CreateGUI()
        {
            titleContent = new GUIContent(Title, Icons.PlayMakerWindowIcon);
            rootVisualElement.viewDataKey = ViewDataKey;
            UITK.LoadEditorStyles(rootVisualElement);

            _view = new InteractableBrowserView();
            rootVisualElement.Add(_view);
        }
    }
}
