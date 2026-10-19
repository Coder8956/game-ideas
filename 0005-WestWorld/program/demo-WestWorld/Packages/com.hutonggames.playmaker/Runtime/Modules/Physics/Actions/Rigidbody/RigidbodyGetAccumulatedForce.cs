
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Returns the force that the Rigidbody has accumulated before the simulation step.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.GetAccumulatedForce.html")]
	public sealed class RigidbodyGetAccumulatedForce : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody.GetAccumulatedForce();
			_result.Value = _rigidbody.Value.GetAccumulatedForce();
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} accumulated force -> {_result}";
		}
	}
}
