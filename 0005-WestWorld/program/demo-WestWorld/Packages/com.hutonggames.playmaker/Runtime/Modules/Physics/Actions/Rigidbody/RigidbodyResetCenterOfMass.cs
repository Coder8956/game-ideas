
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Reset the center of mass of the rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.ResetCenterOfMass.html")]
	public sealed class RigidbodyResetCenterOfMass : BaseAction
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
			//UnityEngine.Rigidbody.ResetCenterOfMass();
			_rigidbody.Value.ResetCenterOfMass();
		}
		
		public override string GetSummary()
		{
			return "Reset {_rigidbody} center of mass";
		}
	}
}
