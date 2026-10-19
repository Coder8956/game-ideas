
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The rotation of the Rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-rotation.html")]
	public sealed class RigidbodyGetRotation : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Rotation")]
		[SerializeField]
		[WriteOnly]
		private QuaternionRef _getRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getRotation);
		}
		
		public override void Execute()
		{
			_getRotation.Value = _rigidbody.Value.rotation;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} rotation -> {_getRotation}";
		}
	}
}
