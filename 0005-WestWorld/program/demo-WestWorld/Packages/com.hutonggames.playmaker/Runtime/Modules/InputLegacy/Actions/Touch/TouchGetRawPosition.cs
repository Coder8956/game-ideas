
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Touch)]
	[ActionDescription("The first position of the touch contact in screen space pixel coordinates.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Touch-rawPosition.html")]
	public sealed class TouchGetRawPosition : BaseAction
	{
		
		[Tooltip("The Touch")]
		[SerializeField]
		private TouchRef _touch;
		
		[Tooltip("Get Touch Raw Position")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getRawPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_touch, _getRawPosition);
		}
		
		public override void Execute()
		{
			_getRawPosition.Value = _touch.Value.rawPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_touch} rawPosition -> {_getRawPosition}";
		}
	}
}
