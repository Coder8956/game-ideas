
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("The minimal point of the box. This is always equal to center-extents.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds-min.html")]
	public sealed class BoundsGetMin : BaseAction
	{
		
		[Tooltip("The Bounds")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Get Bounds Min")]
		[SerializeField, WriteOnly]
		private Vector3Ref _getMin;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _getMin);
		}
		
		public override void Execute()
		{
			_getMin.Value = _bounds.Value.min;
		}
		
		public override string GetSummary()
		{
			return "Get {_bounds} min -> {_getMin}";
		}
	}
}
