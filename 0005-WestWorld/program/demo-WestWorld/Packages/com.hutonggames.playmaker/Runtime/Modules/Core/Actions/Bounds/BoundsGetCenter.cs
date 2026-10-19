
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("The center of the bounding box.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds-center.html")]
	public sealed class BoundsGetCenter : BaseAction
	{
		
		[Tooltip("The Bounds")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Get Bounds Center")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getCenter;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _getCenter);
		}
		
		public override void Execute()
		{
			_getCenter.Value = _bounds.Value.center;
		}
		
		public override string GetSummary()
		{
			return "Get {_bounds} center -> {_getCenter}";
		}
	}
}
