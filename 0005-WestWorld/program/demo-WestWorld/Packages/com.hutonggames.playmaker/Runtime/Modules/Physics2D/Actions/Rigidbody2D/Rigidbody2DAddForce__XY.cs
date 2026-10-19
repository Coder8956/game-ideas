
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Apply a force to the rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.AddForce.html")]
	public sealed class Rigidbody2DAddForce__XY : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Components of the force in the X axes.")]
		[SerializeField]
		private FloatVar _x;
		
		[Tooltip("Components of the force in the Y axes.")]
		[SerializeField]
		private FloatVar _y;
		
		[Tooltip("The method used to apply the specified force.")]
		[SerializeField]
		private ForceMode2DVar _mode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _x, _y, _mode);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.AddForce(new Vector2(_x.Value, _y.Value), _mode.Value);
		}
		
		public override string GetSummary()
		{
			return "Add ({_x},{_y}) to {_rigidbody2D} as {_mode}";
		}
	}
}
