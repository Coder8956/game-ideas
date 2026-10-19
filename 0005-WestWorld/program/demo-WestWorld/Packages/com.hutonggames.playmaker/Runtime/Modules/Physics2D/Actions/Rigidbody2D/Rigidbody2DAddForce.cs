
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Apply a force to the rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.AddForce.html")]
	public sealed class Rigidbody2DAddForce : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Components of the force in the X and Y axes.")]
		[SerializeField]
		private Vector2Var _force;
		
		[Tooltip("The method used to apply the specified force.")]
		[SerializeField]
		private ForceMode2DVar _mode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _force, _mode);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.AddForce(_force.Value, _mode.Value);
		}
		
		public override string GetSummary()
		{
			return "Add {_force} to {_rigidbody2D} as {_mode}";
		}
	}
}
