
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("The rotation as Euler angles in degrees relative to the parent transform\'s rotati" +
		"on.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localEulerAngles.html")]
	public sealed class TransformSetLocalEulerAngles : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Transform Local Euler Angles")]
		[SerializeField]
		private Vector3Var _setLocalEulerAngles;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _setLocalEulerAngles);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.localEulerAngles = _setLocalEulerAngles.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} Local Euler Angles to {_setLocalEulerAngles}";
		}
	}
}
