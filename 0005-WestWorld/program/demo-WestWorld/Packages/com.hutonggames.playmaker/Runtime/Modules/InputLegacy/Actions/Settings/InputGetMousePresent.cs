
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.InputSettings)]
	[ActionDescription("Indicates if a mouse device is detected.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-mousePresent.html")]
	public sealed class InputGetMousePresent : BaseAction
	{
		
		[Tooltip("Get Input Mouse Present")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getMousePresent;
		
		public override bool CanExecute() => CheckParameters(_getMousePresent);

		public override void Execute() => _getMousePresent.Value = Input.mousePresent;

		public override string GetSummary() => "Get Mouse Present -> {_getMousePresent} ";
	}
}
