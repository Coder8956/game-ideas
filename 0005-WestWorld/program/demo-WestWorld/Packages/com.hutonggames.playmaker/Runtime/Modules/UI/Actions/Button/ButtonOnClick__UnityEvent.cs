
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Button)]
	[ActionDescription("UnityEvent that is triggered when the button is pressed.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Button.html")]
	public sealed class ButtonOnClick__UnityEvent : BaseAction
	{
		
		[Tooltip("The Button")]
		[SerializeField]
		private UI.ButtonVar _button;
		
		[Tooltip("Set Button On Click")]
		[SerializeField]
		private UI.Button_ButtonClickedEventVar _setOnClick;
		
		public override bool CanExecute()
		{
			return CheckParameters(_button, _setOnClick);
		}
		
		public override void Execute()
		{
			_button.Value.onClick = _setOnClick.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_button} on click to {_setOnClick}";
		}
	}
}
