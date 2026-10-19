
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("The center of the bounding box.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds-center.html")]
	public sealed class BoundsSetCenter : BaseAction
	{
		
		[Tooltip("The Bounds")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Set Bounds Center")]
		[SerializeField]
		private Vector3Var _setCenter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _setCenter);
		}
		
		public override void Execute()
		{
			var value = _bounds.Value;
			value.center = _setCenter.Value;
			_bounds.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_bounds} center to {_setCenter}";
		}
	}
}
