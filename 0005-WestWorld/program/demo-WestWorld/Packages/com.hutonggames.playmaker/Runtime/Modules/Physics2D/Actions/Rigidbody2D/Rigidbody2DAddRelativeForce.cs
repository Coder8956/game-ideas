
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Adds a force to the rigidbody2D relative to its coordinate system.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.AddRelativeForce.html")]
	public sealed class Rigidbody2DAddRelativeForce : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Components of the force in the X and Y axes.")]
		[SerializeField]
		private Vector2Var _relativeForce;
		
		[Tooltip("The method used to apply the specified force.")]
		[SerializeField]
		private ForceMode2DVar _mode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _relativeForce, _mode);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.AddRelativeForce(UnityEngine.Vector2, UnityEngine.ForceMode2D);
			_rigidbody2D.Value.AddRelativeForce(_relativeForce.Value, _mode.Value);
		}
		
		public override string GetSummary()
		{
			return "Add relative force {_relativeForce} to {_rigidbody2D} as {_mode}";
		}
	}
}
