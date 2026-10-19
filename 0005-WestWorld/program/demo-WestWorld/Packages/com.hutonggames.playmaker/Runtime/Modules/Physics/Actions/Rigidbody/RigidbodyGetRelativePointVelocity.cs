
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The velocity relative to the rigidbody at the point relativePoint.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.GetRelativePointVelocity.html")]
	public sealed class RigidbodyGetRelativePointVelocity : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Relative Point.")]
		[SerializeField]
		private Vector3Var _relativePoint;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _relativePoint, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody.GetRelativePointVelocity(UnityEngine.Vector3);
			_result.Value = _rigidbody.Value.GetRelativePointVelocity(_relativePoint.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} relative point velocity at {_relativePoint} -> {_result}";
		}
	}
}
