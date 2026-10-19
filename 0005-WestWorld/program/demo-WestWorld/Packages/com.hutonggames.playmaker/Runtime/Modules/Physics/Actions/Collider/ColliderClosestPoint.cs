
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider)]
	[ActionDescription("Returns a point on the collider that is closest to a given location.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider.ClosestPoint.html")]
	public sealed class ColliderClosestPoint : BaseAction
	{
		
		[Tooltip("The Collider.")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Location you want to find the closest point to.")]
		[SerializeField]
		private Vector3Var _position;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider, _position, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Collider.ClosestPoint(UnityEngine.Vector3);
			_result.Value = _collider.Value.ClosestPoint(_position.Value);
		}
		
		public override string GetSummary()
		{
			return "Get closest point on {_collider} to {_position} -> {_result}";
		}
	}
}
