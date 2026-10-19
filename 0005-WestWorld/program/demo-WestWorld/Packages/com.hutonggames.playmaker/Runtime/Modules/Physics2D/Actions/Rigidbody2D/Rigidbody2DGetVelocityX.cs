
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Get the linear X velocity of the Rigidbody in units per second.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-linearVelocity.html")]
	public sealed class Rigidbody2DGetVelocityX : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Velocity in X")]
		[SerializeField, WriteOnly]
		private FloatRef _getVelocityX;
		
		public override bool CanExecute() => CheckParameters(_rigidbody2D, _getVelocityX);

		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			var velocity = _rigidbody2D.Value.linearVelocity;
#else
			var velocity = _rigidbody2D.Value.velocity;
#endif
			if (_getVelocityX.IsAssigned) _getVelocityX.Value = velocity.x;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} velocity x -> {_getVelocityX}";
		}
	}
}

