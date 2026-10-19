
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Set the local rotation of the transform around its X axis.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localRotation.html")]
	public sealed class TransformSetLocalRotationX : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Local Rotation around X")]
		[SerializeField]
		private FloatVar _xRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _xRotation);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			
			var eulerAngles = transform.localRotation.eulerAngles; 
			eulerAngles = new Vector3(_xRotation.Value, eulerAngles.y, eulerAngles.z);
			_transform.Value.localRotation = Quaternion.Euler(eulerAngles);
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} local X rotation to {_xRotation}";
		}
	}
}
