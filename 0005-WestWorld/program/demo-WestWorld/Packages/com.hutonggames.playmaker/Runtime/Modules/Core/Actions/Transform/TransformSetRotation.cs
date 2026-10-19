
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Set the rotation of the Transform in world space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-rotation.html")]
	public sealed class TransformSetRotation : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Transform Rotation")]
		[SerializeField]
		private QuaternionVar _setRotation;
		
		public override bool CanExecute() => CheckParameters(_transform, _setRotation);

		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.rotation = _setRotation.Value;
		}

		public override string GetSummary() => "Set {_transform} rotation to {_setRotation}";
	}
}
