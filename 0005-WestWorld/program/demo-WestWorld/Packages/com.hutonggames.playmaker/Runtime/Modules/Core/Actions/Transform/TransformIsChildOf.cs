
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Is this transform a child of parent?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform.IsChildOf.html")]
	public sealed class TransformIsChildOf : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Parent.")]
		[SerializeField]
		private TransformVar _parent;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute() => CheckParameters(_transform, _parent, _result);

		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null)
			{
				_result.Value = false;
				return;
			}
			_result.Value = transform.IsChildOf(_parent.Value);
		}
		
		public override string GetSummary() => "Check {_transform} is a child of {_parent} -> {_result}";
	}
}
