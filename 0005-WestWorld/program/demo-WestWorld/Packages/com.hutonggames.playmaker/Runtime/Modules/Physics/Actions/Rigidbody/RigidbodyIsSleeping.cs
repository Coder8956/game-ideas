
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Is the rigidbody sleeping?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.IsSleeping.html")]
	public sealed class RigidbodyIsSleeping : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody.IsSleeping();
			_result.Value = _rigidbody.Value.IsSleeping();
		}
		
		public override string GetSummary()
		{
			return "Check {_rigidbody} is sleeping -> {_result}";
		}
	}
}
