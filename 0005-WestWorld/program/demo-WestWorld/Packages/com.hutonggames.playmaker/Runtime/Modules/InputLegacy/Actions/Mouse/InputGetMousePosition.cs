
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Mouse)]
	[ActionDescription("The current mouse position in pixel coordinates. " +
	                   "The bottom-left of the screen or window is at (0, 0). " +
	                   "The top-right of the screen or window is at (Screen.width, Screen.height)."
	                   + Strings.SupportsBothInputSystems)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-mousePosition.html")]
	public sealed class InputGetMousePosition : BaseAction
	{
		
		[Tooltip("Get Input Mouse Position")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getMousePosition;
		
		public override bool CanExecute() => CheckParameters(_getMousePosition);

		public override void Execute() => _getMousePosition.Value = InputShim.GetMousePosition();

		public override string GetSummary() => "Get Mouse Position -> {_getMousePosition} ";
	}
}
