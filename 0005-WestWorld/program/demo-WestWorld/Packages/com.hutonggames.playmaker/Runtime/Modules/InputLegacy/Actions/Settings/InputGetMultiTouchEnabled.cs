
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSettings)]
	[ActionDescription("Property indicating whether the system handles multiple touches.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-multiTouchEnabled.html")]
	public sealed class InputGetMultiTouchEnabled : BaseAction
	{
		
		[Tooltip("Get Input Multi Touch Enabled")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getMultiTouchEnabled;
		
		public override bool CanExecute() => CheckParameters(_getMultiTouchEnabled);

		public override void Execute() => _getMultiTouchEnabled.Value = Input.multiTouchEnabled;

		public override string GetSummary() => "Get MultiTouchEnabled -> {_getMultiTouchEnabled} ";
	}
}
