
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ConvertibleGroup("Rigidbody2DSetVelocity")]
	[ActionDescription("Set the linear velocity of the Rigidbody in units per second.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-linearVelocity.html")]
	public sealed class Rigidbody2DSetVelocity : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate | UpdateMode.EveryFrame;
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Velocity")]
		[SerializeField]
		private Vector2Var _setVelocity;
		
		[Tooltip("The space to set the velocity relative to.")]
		[SerializeField]
		private SpaceVar _relativeTo;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setVelocity);
		}
		
		public override void Execute()
		{
			if (_rigidbody2D.Value == null) return;
			
			Vector2 velocity = _relativeTo.Value == Space.Self 
				? _rigidbody2D.Value.transform.TransformDirection(_setVelocity.Value) 
				: _setVelocity.Value;
			
#if UNITY_6000_0_OR_NEWER
			_rigidbody2D.Value.linearVelocity = velocity;
#else
			_rigidbody2D.Value.velocity = velocity;
#endif
		}
		
		public override string GetSummary() => "Set {_rigidbody2D} velocity to {_setVelocity}" 
		                                       + (_relativeTo.Value == Space.Self ? " in local space" : "");
	}
}

