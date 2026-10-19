
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputButton)]
	[ConvertibleGroup(ConvertibleGroup.InputButton)]
	[ActionDescription("Returns true the first frame the user releases the virtual button identified by " +
		"buttonName." + Strings.LimitedButtonSupport)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input.GetButtonUp.html")]
	public sealed class InputGetButtonUp : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("Button Name.")]
		[SerializeField, DefaultValue("Fire1")]
		private StringVar _buttonName;
		
		[Tooltip("Event to send if the button is released.")]
		[SerializeField, OptionalField]
		private EventRef _sendEvent;
		
		[FormerlySerializedAs("_result")]
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField, OptionalField, WriteOnly]
		private BoolRef _storeResult;
		
		private int _lastTriggeredFrame;
		
		public override bool CanExecute() => CheckParameters(_buttonName);

		public override void Execute()
		{
			var released  = InputShim.GetButtonUp(_buttonName.Value);
			_storeResult.Value = released;

			if (released && _lastTriggeredFrame != Time.frameCount)
			{
				_lastTriggeredFrame = Time.frameCount;
				
				SendEvent(_sendEvent);
			}
		}

		public override string GetSummary() => "If {_buttonName} released {_storeResult:output} {_sendEvent}";
	}
}
