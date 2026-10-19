
using JetBrains.Annotations;
using HutongGames.PlayMaker.Internal;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Get the velocity vector of the rigidbody in either world or local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-linearVelocity.html")]
	public sealed class RigidbodyGetVelocity : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Velocity")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getVelocity;

		[Tooltip("Select if the velocity is in world or local space")]
		[SerializeField, DefaultValue(Space.World)]
		private SpaceVar _space = new() { Value = Space.World };
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getVelocity);
		}
		
		public override void Execute()
		{
			var velocity = _rigidbody.Value.GetVelocityShim();
			if (SpaceValue == Space.Self)
			{
				velocity = _rigidbody.Value.transform.InverseTransformDirection(velocity);
			}
			_getVelocity.Value = velocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} velocity -> {_getVelocity}" +
			       (SpaceValue != Space.World ? " (local)" : string.Empty);
		}

		private Space SpaceValue => _space?.Value ?? Space.World;
	}
}

