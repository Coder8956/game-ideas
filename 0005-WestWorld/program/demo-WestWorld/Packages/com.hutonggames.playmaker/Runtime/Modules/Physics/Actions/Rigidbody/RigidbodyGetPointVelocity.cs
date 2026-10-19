
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The velocity of the rigidbody at the point worldPoint in global space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.GetPointVelocity.html")]
	public sealed class RigidbodyGetPointVelocity : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("World Point.")]
		[SerializeField]
		private Vector3Var _worldPoint;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _worldPoint, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody.GetPointVelocity(UnityEngine.Vector3);
			_result.Value = _rigidbody.Value.GetPointVelocity(_worldPoint.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody} point velocity at {_worldPoint} -> {_result}";
		}
	}
}
