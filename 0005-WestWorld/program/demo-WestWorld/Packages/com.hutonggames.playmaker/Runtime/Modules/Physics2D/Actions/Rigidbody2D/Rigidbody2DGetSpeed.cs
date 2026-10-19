
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Get the speed of the Rigidbody in units per second.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-linearVelocity.html")]
	public sealed class Rigidbody2DGetSpeed : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Velocity")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getSpeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getSpeed);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getSpeed.Value = _rigidbody2D.Value.linearVelocity.magnitude;
#else
			_getSpeed.Value = _rigidbody2D.Value.velocity.magnitude;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} speed -> {_getSpeed}";
		}
	}
}

