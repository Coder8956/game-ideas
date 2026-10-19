
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Set the local rotation of the transform around its Z axis.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localRotation.html")]
	public sealed class TransformSetLocalRotationZ : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Local Rotation around Z")]
		[SerializeField]
		private FloatVar _zRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _zRotation);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			
			var eulerAngles = transform.localRotation.eulerAngles; 
			eulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, _zRotation.Value);
			_transform.Value.localRotation = Quaternion.Euler(eulerAngles);
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} local Z rotation to {_zRotation}";
		}
	}
}
