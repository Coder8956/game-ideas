
using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Mouse)]
	[ActionDescription("Returns true during the frame the user pressed the given mouse button."
		+ Strings.SupportsBothInputSystems)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input.GetMouseButtonDown.html")]
	public sealed class InputGetMouseButtonDown : BaseTrueFalseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

		[Tooltip("Button values:\n0 = left button\n1 = right button\n2 = middle button.")]
		[SerializeField]
		private IntegerVar _button;

		[Tooltip("Optional: Record the press into a BufferedInput. E.g, for a jump buffer or 'coyote' time.")]
		[SerializeField, OptionalField, WriteOnly, DisplayOrder(1003)]
		private BufferedInputRef _bufferedInput;
		
		[NonSerialized]
		private int _frameHappened;
		
		public override bool CanExecute() => CheckParameters(_button);

		protected override bool Test()
		{
			if (Time.frameCount == _frameHappened)
			{
				return false;
			}

			_frameHappened = Time.frameCount;
			var pressed = InputShim.GetMouseButtonDown(_button.Value);

			if (pressed && !_bufferedInput.IsNone)
			{
				_bufferedInput.Record();
			}

			return pressed;
		}

		protected override string TrueSummary => "{_button:mouseButton} button pressed";
		protected override string FalseSummary => "{_button:mouseButton} button not pressed";

		public override string GetSummary() => base.GetSummary() +
		                                       (_bufferedInput.IsNone ? "" : " (Buffered: {_bufferedInput})");
		
	}
}
