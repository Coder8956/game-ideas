
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("The closest point to the bounding box of the attached colliders.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.ClosestPointOnBounds.html")]
	public sealed class RigidbodyClosestPointOnBounds : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Position.")]
		[SerializeField]
		private Vector3Var _position;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _position, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody.ClosestPointOnBounds(UnityEngine.Vector3);
			_result.Value = _rigidbody.Value.ClosestPointOnBounds(_position.Value);
		}
		
		public override string GetSummary()
		{
			return "Closest point on {_rigidbody} bounds to {_position} -> {_result}";
		}
	}
}
