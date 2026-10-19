
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Creates a rotation which rotates from fromDirection to toDirection.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion.SetFromToRotation.html")]
	public sealed class QuaternionSetFromToRotation : BaseAction
	{
		
		[Tooltip("The Quaternion.")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("From Direction.")]
		[SerializeField]
		private Vector3Var _fromDirection;
		
		[Tooltip("To Direction.")]
		[SerializeField]
		private Vector3Var _toDirection;
		
		public override bool CanExecute()
		{
			return CheckParameters(_quaternion, _fromDirection, _toDirection);
		}
		
		public override void Execute()
		{
			_quaternion.Value.SetFromToRotation(_fromDirection.Value, _toDirection.Value);
		}
		
		public override string GetSummary() => "Set {_quaternion} From {_fromDirection} To {_toDirection} ";
	}
}
