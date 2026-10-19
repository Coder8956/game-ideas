
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Controls which degrees of freedom are allowed for the simulation of this Rigidbod" +
		"y.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-constraints.html")]
	public sealed class RigidbodyGetConstraints : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Get Rigidbody Constraints")]
		[SerializeField]
		[WriteOnly]
		private RigidbodyConstraintsRef _getConstraints;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _getConstraints);
		}
		
		public override void Execute()
		{
			_getConstraints.Value = _rigidbody.Value.constraints;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} constraints -> {_getConstraints}";
		}
	}
}
