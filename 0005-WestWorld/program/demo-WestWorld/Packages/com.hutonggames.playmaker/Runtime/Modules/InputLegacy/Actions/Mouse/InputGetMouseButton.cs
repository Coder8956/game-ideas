
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Mouse)]
	[ActionDescription("Returns whether the given mouse button is held down." 
	                   + Strings.SupportsBothInputSystems)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input.GetMouseButton.html")]
	public sealed class InputGetMouseButton : BaseTrueFalseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The button values are: 0 for the left button, 1 for the right button, 2 for the middle button.")]
		[SerializeField]
		private IntegerVar _button;
		
		public override bool CanExecute() => CheckParameters(_button);
		
		protected override bool Test() => InputShim.GetMouseButton(_button.Value);

		protected override string TrueSummary => "{_button:mouseButton} Mouse Button";
		protected override string FalseSummary => "Not {_button:mouseButton} Mouse Button";
	}
}
