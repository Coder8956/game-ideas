using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.UI
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Canvas)]
    [ActionDescription("Open a modal canvas and request game pause. See Online Help for details.")]
    [HelpURL("https://hutonggames.com/playmaker/docs/")]
    public sealed class OpenModalCanvas : BaseAction
    {
        [NotOwnerDefaultValue]
        [Tooltip("The modal Canvas to open.")]
        [SerializeField]
        private CanvasVar _canvas;

        public override bool CanExecute()
        {
            return CheckParameters(_canvas);
        }

        public override void Execute()
        {
            if (_canvas.Value == null) return;

            if (_canvas.Value.gameObject.activeSelf) return;
            
            _canvas.Value.gameObject.SetActive(true);
            PauseManager.RequestPause(GetPauseOwner());
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
            return "Open {_canvas} modal canvas";
        }
    }
}
