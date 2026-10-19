
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("The total size of the box. This is always twice as large as the extents.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds-size.html")]
	public sealed class BoundsSetSize : BaseAction
	{
		
		[Tooltip("The Bounds")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Set Bounds Size")]
		[SerializeField]
		private Vector3Var _setSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _setSize);
		}
		
		public override void Execute()
		{
			var value = _bounds.Value;
			value.size = _setSize.Value;
			_bounds.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_bounds} size to {_setSize}";
		}
	}
}
