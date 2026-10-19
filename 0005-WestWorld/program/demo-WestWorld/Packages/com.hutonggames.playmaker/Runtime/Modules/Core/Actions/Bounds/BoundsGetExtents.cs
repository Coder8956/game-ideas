
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("The extents of the Bounding Box. This is always half of the size of the Bounds.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds-extents.html")]
	public sealed class BoundsGetExtents : BaseAction
	{
		
		[Tooltip("The Bounds")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Get Bounds Extents")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getExtents;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _getExtents);
		}
		
		public override void Execute()
		{
			_getExtents.Value = _bounds.Value.extents;
		}
		
		public override string GetSummary()
		{
			return "Get {_bounds} extents -> {_getExtents}";
		}
	}
}
