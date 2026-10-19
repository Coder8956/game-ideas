
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSettings)]
	[ActionDescription("Property indicating whether the system handles multiple touches.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-multiTouchEnabled.html")]
	public sealed class InputSetMultiTouchEnabled : BaseAction
	{
		
		[Tooltip("Set Input Multi Touch Enabled")]
		[SerializeField]
		private BoolVar _setMultiTouchEnabled;
		
		public override bool CanExecute() => CheckParameters(_setMultiTouchEnabled);

		public override void Execute() => Input.multiTouchEnabled = _setMultiTouchEnabled.Value;

		public override string GetSummary() => "Set MultiTouchEnabled to {_setMultiTouchEnabled}";
	}
}
