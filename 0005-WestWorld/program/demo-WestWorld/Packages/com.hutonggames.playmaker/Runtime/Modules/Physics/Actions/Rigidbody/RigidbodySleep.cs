
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Forces a rigidbody to sleep at least one frame.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.Sleep.html")]
	public sealed class RigidbodySleep : BaseAction
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
			//UnityEngine.Rigidbody.Sleep();
			_rigidbody.Value.Sleep();
		}
		
		public override string GetSummary()
		{
			return "Sleep {_rigidbody}";
		}
	}
}
