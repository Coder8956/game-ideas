
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("The minimal point of the box. This is always equal to center-extents.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds-min.html")]
	public sealed class BoundsSetMin : BaseAction
	{
		
		[Tooltip("The Bounds")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Set Bounds Min")]
		[SerializeField]
		private Vector3Var _setMin;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _setMin);
		}
		
		public override void Execute()
		{
			var value = _bounds.Value;
			value.min = _setMin.Value;
			_bounds.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_bounds} min to {_setMin}";
		}
	}
}
