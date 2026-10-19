
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Returns the torque that the Rigidbody has accumulated before the simulation step.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.GetAccumulatedTorque.html")]
	public sealed class RigidbodyGetAccumulatedTorque : BaseAction
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
			//UnityEngine.Rigidbody.GetAccumulatedTorque();
			_result.Value = _rigidbody.Value.GetAccumulatedTorque();
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} accumulated torque -> {_result}";
		}
	}
}
