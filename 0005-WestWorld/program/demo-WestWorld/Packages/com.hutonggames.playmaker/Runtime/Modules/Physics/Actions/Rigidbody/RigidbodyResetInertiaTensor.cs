
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Reset the inertia tensor value and rotation.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.ResetInertiaTensor.html")]
	public sealed class RigidbodyResetInertiaTensor : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody.ResetInertiaTensor();
			_rigidbody.Value.ResetInertiaTensor();
		}
		
		public override string GetSummary()
		{
			return "Reset {_rigidbody} inertia tensor";
		}
	}
}
