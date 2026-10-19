
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Touch)]
	[ActionDescription("The position of the touch in screen space pixel coordinates.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Touch-position.html")]
	public sealed class TouchGetPosition : BaseAction
	{
		
		[Tooltip("The Touch")]
		[SerializeField]
		private TouchRef _touch;
		
		[Tooltip("Get Touch Position")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_touch, _getPosition);
		}
		
		public override void Execute()
		{
			_getPosition.Value = _touch.Value.position;
		}
		
		public override string GetSummary()
		{
			return "Get {_touch} position -> {_getPosition}";
		}
	}
}
