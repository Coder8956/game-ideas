
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Get the linear velocity of the Rigidbody in units per second.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-linearVelocity.html")]
	public sealed class Rigidbody2DGetVelocity : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Velocity")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getVelocity);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getVelocity.Value = _rigidbody2D.Value.linearVelocity;
#else
			_getVelocity.Value = _rigidbody2D.Value.velocity;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} velocity -> {_getVelocity}";
		}
	}
}

