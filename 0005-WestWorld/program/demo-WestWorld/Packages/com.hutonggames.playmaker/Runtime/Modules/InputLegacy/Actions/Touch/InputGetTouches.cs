
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Touch)]
	[ActionDescription("Returns list of objects representing status of all touches during last frame. (Re" +
		"ad Only) (Allocates temporary variables).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-touches.html")]
	public sealed class InputGetTouches : BaseAction
	{
		
		[Tooltip("Get Input Touches")]
		[SerializeField]
		[WriteOnly]
		private TouchListRef _getTouches;
		
		public override bool CanExecute() => CheckParameters(_getTouches);

		public override void Execute() => _getTouches.Values = Input.touches;

		public override string GetSummary() => "Get Touches -> {_getTouches} ";
	}
}
