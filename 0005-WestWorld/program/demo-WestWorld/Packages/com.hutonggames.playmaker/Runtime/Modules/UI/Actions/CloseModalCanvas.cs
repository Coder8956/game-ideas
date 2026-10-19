using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.UI
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Canvas)]
    [ActionDescription("Close a modal canvas and request game resume. See Online Help for details.")]
    [HelpURL("https://hutonggames.com/playmaker/docs/")]
    public sealed class CloseModalCanvas : BaseAction
    {
        [Tooltip("The modal Canvas to close.")]
        [SerializeField]
        private CanvasVar _canvas;

        public override bool CanExecute()
        {
            return CheckParameters(_canvas);
        }

        public override void Execute()
        {
            if (_canvas.Value != null && _canvas.Value.gameObject.activeSelf)
            {
                _canvas.Value.gameObject.SetActive(false);
            }

            PauseManager.RemovePauseRequest(GetPauseOwner());
        }

        private Object GetPauseOwner()
        {
            if (_canvas.Value != null) return _canvas.Value.gameObject;
            return GetOwner();
        }

        private Object GetOwner()
        {
            if (OwnerFsmComponent != null) return OwnerFsmComponent;
            if (OwnerGameObject != null) return OwnerGameObject;
            return Owner;
        }

        public override string GetSummary()
        {
            return "Close {_canvas} modal canvas";
        }
    }
}
