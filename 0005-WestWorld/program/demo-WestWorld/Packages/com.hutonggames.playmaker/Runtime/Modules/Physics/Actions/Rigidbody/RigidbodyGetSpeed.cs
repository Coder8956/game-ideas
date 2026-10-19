
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Get the speed of the rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-linearVelocity.html")]
	public sealed class RigidbodyGetSpeed : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody speed (velocity.magnitude)")]
		[SerializeField, WriteOnly]
		private FloatRef _getSpeed;
		
		public override bool CanExecute() => CheckParameters(_rigidbody, _getSpeed);

		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			var speed = _rigidbody.Value.linearVelocity.magnitude;
#else
			var speed = _rigidbody.Value.velocity.magnitude;
#endif
			_getSpeed.Value = speed;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} speed -> {_getSpeed}";
		}
	}
}

