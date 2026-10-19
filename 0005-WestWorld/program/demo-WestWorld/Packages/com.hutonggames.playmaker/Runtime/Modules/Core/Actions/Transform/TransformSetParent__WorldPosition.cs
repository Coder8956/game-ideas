
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Set the parent of the transform.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform.SetParent.html")]
	public sealed class TransformSetParent__WorldPosition : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("The parent Transform to use.")]
		[SerializeField]
		private TransformVar _parent;
		
		[Tooltip("If true, the parent-relative position, scale and rotation are modified such that " +
			"the object keeps the same world space position, rotation and scale as before.")]
		[SerializeField]
		private BoolVar _worldPositionStays;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _parent, _worldPositionStays);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.SetParent(_parent.Value, _worldPositionStays.Value);
		}
		
		public override string GetSummary()
		{
			return "Set Parent {_transform} {_parent} {_worldPositionStays} ";
		}
	}
}
