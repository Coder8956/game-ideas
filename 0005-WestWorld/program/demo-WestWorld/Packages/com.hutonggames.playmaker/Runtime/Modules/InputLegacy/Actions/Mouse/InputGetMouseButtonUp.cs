
using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Mouse)]
	[ActionDescription("Returns true during the frame the user releases the given mouse button."
		+ Strings.SupportsBothInputSystems)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input.GetMouseButtonUp.html")]
	public sealed class InputGetMouseButtonUp : BaseTrueFalseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The button values are: 0 for the left button, 1 for the right button, 2 for the middle button.")]
		[SerializeField]
		private IntegerVar _button;
		
		public override bool CanExecute() => CheckParameters(_button);

		[NonSerialized]
		private int _frameHappened;
		
		protected override bool Test()
		{
			if (Time.frameCount == _frameHappened)
			{
				return false;
			}

			_frameHappened = Time.frameCount;
			return InputShim.GetMouseButtonUp(_button.Value);
		}

		protected override string TrueSummary => "{_button:mouseButton} button released";
		protected override string FalseSummary => "{_button:mouseButton} button not released";

	}
}
