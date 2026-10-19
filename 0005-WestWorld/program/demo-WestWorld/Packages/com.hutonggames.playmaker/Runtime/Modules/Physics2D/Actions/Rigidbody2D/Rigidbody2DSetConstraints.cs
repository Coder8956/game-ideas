
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Controls which degrees of freedom are allowed for the simulation of this Rigidbod" +
		"y2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-constraints.html")]
	public sealed class Rigidbody2DSetConstraints : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Constraints")]
		[SerializeField]
		private RigidbodyConstraints2DVar _setConstraints;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setConstraints);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.constraints = _setConstraints.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} constraints to {_setConstraints}";
		}
	}
}
