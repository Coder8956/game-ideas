
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("The maximal point of the box. This is always equal to center+extents.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds-max.html")]
	public sealed class BoundsGetMax : BaseAction
	{
		
		[Tooltip("The Bounds")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Get Bounds Max")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getMax;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _getMax);
		}
		
		public override void Execute()
		{
			_getMax.Value = _bounds.Value.max;
		}
		
		public override string GetSummary()
		{
			return "Get {_bounds} max -> {_getMax}";
		}
	}
}
