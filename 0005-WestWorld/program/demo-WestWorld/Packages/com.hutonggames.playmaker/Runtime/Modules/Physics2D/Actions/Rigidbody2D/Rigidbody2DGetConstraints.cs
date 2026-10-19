
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
	public sealed class Rigidbody2DGetConstraints : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Constraints")]
		[SerializeField]
		[WriteOnly]
		private RigidbodyConstraints2DRef _getConstraints;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getConstraints);
		}
		
		public override void Execute()
		{
			_getConstraints.Value = _rigidbody2D.Value.constraints;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} constraints -> {_getConstraints}";
		}
	}
}
