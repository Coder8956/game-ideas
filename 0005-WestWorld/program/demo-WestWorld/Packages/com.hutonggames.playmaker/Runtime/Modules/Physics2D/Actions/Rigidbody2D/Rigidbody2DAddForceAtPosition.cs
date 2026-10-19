
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Apply a force at a given position in space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.AddForceAtPosition.html")]
	public sealed class Rigidbody2DAddForceAtPosition : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Components of the force in the X and Y axes.")]
		[SerializeField]
		private Vector2Var _force;
		
		[Tooltip("Position in world space to apply the force.")]
		[SerializeField]
		private Vector2Var _position;
		
		[Tooltip("The method used to apply the specified force.")]
		[SerializeField]
		private ForceMode2DVar _mode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _force, _position, _mode);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.AddForceAtPosition(UnityEngine.Vector2, UnityEngine.Vector2, UnityEngine.ForceMode2D);
			_rigidbody2D.Value.AddForceAtPosition(_force.Value, _position.Value, _mode.Value);
		}
		
		public override string GetSummary()
		{
			return "Add {_force} to {_rigidbody2D} at {_position} as {_mode}";
		}
	}
}
