
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Set the local space position of the Transform in X and Y.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-position.html")]
	public sealed class TransformSetLocalPosition__XY : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set X Position")]
		[SerializeField]
		private FloatVar _setXPosition;
		
		[Tooltip("Set Y Position")]
		[SerializeField]
		private FloatVar _setYPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _setXPosition, _setYPosition);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			
			var position = transform.localPosition;
			position.x = _setXPosition.Value;
			position.y = _setYPosition.Value;
			
			_transform.Value.localPosition = position;
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} Local Position to X {_setXPosition} Y {_setYPosition}";
		}
	}
}
