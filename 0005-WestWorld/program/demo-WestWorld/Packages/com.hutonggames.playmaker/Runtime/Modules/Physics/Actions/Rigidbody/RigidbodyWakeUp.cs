
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Forces a rigidbody to wake up.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.WakeUp.html")]
	public sealed class RigidbodyWakeUp : BaseAction
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
			//UnityEngine.Rigidbody.WakeUp();
			_rigidbody.Value.WakeUp();
		}
		
		public override string GetSummary()
		{
			return "Wake up {_rigidbody}";
		}
	}
}
