
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
	public sealed class RigidbodySetConstraints : BaseAction
	{
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set Rigidbody Constraints")]
		[SerializeField]
		private RigidbodyConstraintsVar _setConstraints;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _setConstraints);
		}
		
		public override void Execute()
		{
			_rigidbody.Value.constraints = _setConstraints.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody} constraints to {_setConstraints}";
		}
	}
}
