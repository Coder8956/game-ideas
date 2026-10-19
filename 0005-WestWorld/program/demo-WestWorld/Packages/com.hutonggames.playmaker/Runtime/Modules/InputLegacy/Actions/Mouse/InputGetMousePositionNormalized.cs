
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Mouse)]
	[ActionDescription("The current mouse position in normalized coordinates. " +
	                   "The bottom-left of the screen or window is at (0, 0)." +
	                   "The top-right of the screen or window is at (1, 1)."
	                   + Strings.SupportsBothInputSystems)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Input-mousePosition.html")]
	public sealed class InputGetMousePositionNormalized : BaseAction
	{
		
		[Tooltip("Get Normalized Input Mouse Position")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getMousePosition;
		
		public override bool CanExecute() => CheckParameters(_getMousePosition);

		public override void Execute()
		{
			var pos = InputShim.GetMousePosition();
			_getMousePosition.Value = new Vector3(pos.x / Screen.width, pos.y / Screen.height, 0);
		}

		public override string GetSummary() => "Get Normalized Mouse Position -> {_getMousePosition} ";
	}
}
