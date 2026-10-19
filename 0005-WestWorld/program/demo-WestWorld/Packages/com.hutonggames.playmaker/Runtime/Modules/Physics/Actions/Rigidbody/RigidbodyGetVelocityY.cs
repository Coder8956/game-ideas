
using JetBrains.Annotations;
using HutongGames.PlayMaker.Internal;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Get the Y velocity of the rigidbody in either world or local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-linearVelocity.html")]
	public sealed class RigidbodyGetVelocityY : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Velocity in Y")]
		[SerializeField, WriteOnly]
		private FloatRef _getVelocityY;

		[Tooltip("Select if the velocity is in world or local space")]
		[SerializeField, DefaultValue(Space.World)]
		private SpaceVar _space = new() { Value = Space.World };
		
		public override bool CanExecute() => CheckParameters(_rigidbody, _getVelocityY);

		public override void Execute()
		{
			var velocity = _rigidbody.Value.GetVelocityShim();
			if (SpaceValue == Space.Self)
			{
				velocity = _rigidbody.Value.transform.InverseTransformDirection(velocity);
			}
			_getVelocityY.Value = velocity.y;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} velocity Y -> {_getVelocityY}" +
			       (SpaceValue != Space.World ? " (local)" : string.Empty);
		}

		private Space SpaceValue => _space?.Value ?? Space.World;
	}
}
