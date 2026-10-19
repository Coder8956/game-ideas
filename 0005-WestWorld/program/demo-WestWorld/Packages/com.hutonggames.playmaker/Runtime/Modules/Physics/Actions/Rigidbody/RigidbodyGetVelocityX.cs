
using JetBrains.Annotations;
using HutongGames.PlayMaker.Internal;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Get the X velocity of the rigidbody in either world or local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-linearVelocity.html")]
	public sealed class RigidbodyGetVelocityX : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Velocity in X")]
		[SerializeField, WriteOnly]
		private FloatRef _getVelocityX;

		[Tooltip("Select if the velocity is in world or local space")]
		[SerializeField, DefaultValue(Space.World)]
		private SpaceVar _space = new() { Value = Space.World };
		
		public override bool CanExecute() => CheckParameters(_rigidbody, _getVelocityX);

		public override void Execute()
		{
			var velocity = _rigidbody.Value.GetVelocityShim();
			if (SpaceValue == Space.Self)
			{
				velocity = _rigidbody.Value.transform.InverseTransformDirection(velocity);
			}
			_getVelocityX.Value = velocity.x;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} velocity X -> {_getVelocityX}" +
			       (SpaceValue != Space.World ? " (local)" : string.Empty);
		}

		private Space SpaceValue => _space?.Value ?? Space.World;
	}
}
