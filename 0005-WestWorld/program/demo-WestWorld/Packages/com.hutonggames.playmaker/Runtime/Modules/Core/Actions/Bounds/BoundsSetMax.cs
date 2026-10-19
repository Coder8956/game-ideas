
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("The maximal point of the box. This is always equal to center+extents.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds-max.html")]
	public sealed class BoundsSetMax : BaseAction
	{
		
		[Tooltip("The Bounds")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Set Bounds Max")]
		[SerializeField]
		private Vector3Var _setMax;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _setMax);
		}
		
		public override void Execute()
		{
			var value = _bounds.Value;
			value.max = _setMax.Value;
			_bounds.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_bounds} max to {_setMax}";
		}
	}
}
