
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Sets the rotation of the Rigidbody2D to the z-axis rotation extracted from the fu" +
		"ll 3D rotation.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.SetRotation.html")]
	public sealed class Rigidbody2DSetRotation__Quaternion : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Full 3D rotation used to extract only the z-axis rotation.")]
		[SerializeField]
		private QuaternionVar _rotation;
		
		public override bool CanExecute() => CheckParameters(_rigidbody2D, _rotation);

		public override void Execute() => _rigidbody2D.Value.SetRotation(_rotation.Value);

		public override string GetSummary() => "Set {_rigidbody2D} rotation to {_rotation}";
	}
}
