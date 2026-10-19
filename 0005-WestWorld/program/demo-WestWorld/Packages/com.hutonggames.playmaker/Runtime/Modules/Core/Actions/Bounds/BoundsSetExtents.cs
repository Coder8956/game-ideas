
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("The extents of the Bounding Box. This is always half of the size of the Bounds.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds-extents.html")]
	public sealed class BoundsSetExtents : BaseAction
	{
		
		[Tooltip("The Bounds")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Set Bounds Extents")]
		[SerializeField]
		private Vector3Var _setExtents;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _setExtents);
		}
		
		public override void Execute()
		{
			var value = _bounds.Value;
			value.extents = _setExtents.Value;
			_bounds.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_bounds} extents to {_setExtents}";
		}
	}
}
