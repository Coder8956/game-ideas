
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("The total size of the box. This is always twice as large as the extents.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds-size.html")]
	public sealed class BoundsGetSize : BaseAction
	{
		
		[Tooltip("The Bounds")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Get Bounds Size")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _getSize);
		}
		
		public override void Execute()
		{
			_getSize.Value = _bounds.Value.size;
		}
		
		public override string GetSummary()
		{
			return "Get {_bounds} size -> {_getSize}";
		}
	}
}
