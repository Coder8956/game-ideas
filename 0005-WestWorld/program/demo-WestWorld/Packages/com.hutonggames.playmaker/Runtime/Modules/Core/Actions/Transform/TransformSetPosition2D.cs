
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Set the world space position of the Transform in X and Y.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-position.html")]
	public sealed class TransformSetPosition2D : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Transform Position")]
		[SerializeField]
		private Vector2Var _setPosition;

		[Tooltip("Keep the Z value of the position.")]
		[SerializeField]
		private BoolVar _keepZ;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _setPosition);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;

			if (!_keepZ.Value)
			{
				transform.position = _setPosition.Value;
			}
			else
			{
				transform.position = new Vector3(_setPosition.Value.x, _setPosition.Value.y, transform.position.z);
			}
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} Position to {_setPosition}";
		}
	}
}
