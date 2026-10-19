
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("An overload of MoveRotation that allows a full 3D rotation as an argument.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.MoveRotation.html")]
	public sealed class Rigidbody2DMoveRotation__Quaternion : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Full 3D rotation used to extract only the z-axis rotation.")]
		[SerializeField]
		private QuaternionVar _rotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _rotation);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.MoveRotation(UnityEngine.Quaternion);
			_rigidbody2D.Value.MoveRotation(_rotation.Value);
		}
		
		public override string GetSummary()
		{
			return "Move {_rigidbody2D} rotation to {_rotation}";
		}
	}
}
