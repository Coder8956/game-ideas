
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Set the world space position of the Transform.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-position.html")]
	public sealed class TransformSetPosition__XYZ : BaseAction
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
		
		[Tooltip("Set Z Position")]
		[SerializeField]
		private FloatVar _setZPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _setXPosition, _setYPosition, _setZPosition);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			
			var position = transform.position;
			position.x = _setXPosition.Value;
			position.y = _setYPosition.Value;
			position.z = _setZPosition.Value;
			
			transform.position = position;
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} Position to ({_setXPosition},{_setYPosition},{_setZPosition})";
		}
	}
}
