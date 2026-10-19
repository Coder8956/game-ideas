
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ConvertibleGroup("Rigidbody2DSetVelocity")]
	[ActionDescription("Set the Y velocity of the Rigidbody in units per second. Keeps any velocity on the X axis. Can be set in world or local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-linearVelocity.html")]
	public sealed class Rigidbody2DSetVelocityY : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate | UpdateMode.EveryFrame;
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Velocity in Y")]
		[SerializeField]
		private FloatVar _setVelocityY;

		[Tooltip("The space to set the velocity relative to.")]
		[SerializeField]
		private SpaceVar _relativeTo;
		
		public override bool CanExecute() => CheckParameters(_rigidbody2D, _setVelocityY);

		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			var velocity = _rigidbody2D.Value.linearVelocity;
			if (_relativeTo.Value == Space.Self)
			{
				Vector3 localVelocity = _rigidbody2D.Value.transform.InverseTransformDirection(velocity);
				localVelocity.y = _setVelocityY.Value;
				Vector3 worldVelocity = _rigidbody2D.Value.transform.TransformDirection(localVelocity);
				velocity = new Vector2(worldVelocity.x, worldVelocity.y);
			}
			else
			{
				velocity.y = _setVelocityY.Value;
			}
			_rigidbody2D.Value.linearVelocity = velocity;
#else
			var velocity = _rigidbody2D.Value.velocity;
			if (_relativeTo.Value == Space.Self)
			{
				Vector3 localVelocity = _rigidbody2D.Value.transform.InverseTransformDirection(velocity);
				localVelocity.y = _setVelocityY.Value;
				Vector3 worldVelocity = _rigidbody2D.Value.transform.TransformDirection(localVelocity);
				velocity = new Vector2(worldVelocity.x, worldVelocity.y);
			}
			else
			{
				velocity.y = _setVelocityY.Value;
			}
			_rigidbody2D.Value.velocity = velocity;
#endif
		}
		
		public override string GetSummary() => "Set {_rigidbody2D} y velocity to {_setVelocityY}" + 
		                                       (_relativeTo.Value == Space.Self ? " in local space" : "");
	}
}

