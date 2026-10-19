
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.UI
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.UGUI_Button)]
    [ActionDescription("Send an Event when a button is clicked.")]
    [HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Button.html")] 
    public sealed class ButtonOnClick : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
        
        [Tooltip("The Button")]
        [SerializeField] 
        private ButtonVar _button;

        [Tooltip("Send event when button is clicked")] 
        [SerializeField] 
        private EventRef _sendEvent;
		
        public override bool CanExecute() => CheckParameters(_button, _sendEvent);

        public override void OnStart()
        {
            if (_button.Value == null) return;
            _button.Value.onClick.AddListener(DoOnClick);
        }
        
        public override void OnStop()
        {
            if (_button.Value == null) return;
            _button.Value.onClick.RemoveListener(DoOnClick);
        }

        private void DoOnClick()
        {
            SendEvent(_sendEvent);
        }
		
        public override string GetSummary() => "On {_button} click {_sendEvent}";
    }
}
