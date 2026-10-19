
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("The rotation as Euler angles in degrees.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-eulerAngles.html")]
	public sealed class TransformSetEulerAngles : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set Transform Euler Angles")]
		[SerializeField]
		private Vector3Var _setEulerAngles;
		
		public override bool CanExecute()
		{
			return CheckParameters(_transform, _setEulerAngles);
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			transform.eulerAngles = _setEulerAngles.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_transform} Euler Angles to {_setEulerAngles}";
		}
	}
}
