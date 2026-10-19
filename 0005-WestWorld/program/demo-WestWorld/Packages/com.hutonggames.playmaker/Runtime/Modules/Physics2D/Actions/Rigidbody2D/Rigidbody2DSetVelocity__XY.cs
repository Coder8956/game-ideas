
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ConvertibleGroup("Rigidbody2DSetVelocity")]
	[ActionDescription("Sets the linear velocity of the Rigidbody in units per second using X and Y values.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-linearVelocity.html")]
	public sealed class Rigidbody2DSetVelocity__XY : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate | UpdateMode.EveryFrame;
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Velocity in X")]
		[SerializeField]
		private FloatVar _setVelocityX;
		
		[Tooltip("Set Rigidbody2D Velocity in Y")]
		[SerializeField]
		private FloatVar _setVelocityY;
		
		[Tooltip("The space to set the velocity relative to.")]
		[SerializeField]
		private SpaceVar _relativeTo;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setVelocityX, _setVelocityY);
		}
		
		public override void Execute()
		{
			Vector2 velocity = _relativeTo.Value == Space.Self 
				? _rigidbody2D.Value.transform.TransformDirection(new Vector2(_setVelocityX.Value, _setVelocityY.Value)) 
				: new Vector2(_setVelocityX.Value, _setVelocityY.Value);
			
#if UNITY_6000_0_OR_NEWER
			_rigidbody2D.Value.linearVelocity = velocity;
#else
			_rigidbody2D.Value.velocity = velocity;
#endif
		}
		
		public override string GetSummary() => "Set {_rigidbody2D} velocity to x {_setVelocityX} y {_setVelocityY}" + 
		                                       (_relativeTo.Value == Space.Self ? " in local space" : "");
	}
}

