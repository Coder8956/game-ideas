
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider)]
	[ActionDescription("The closest point to the bounding box of the attached collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider.ClosestPointOnBounds.html")]
	public sealed class ColliderClosestPointOnBounds : BaseAction
	{
		
		[Tooltip("The Collider.")]
		[SerializeField]
		private ColliderVar _collider;
		
		[Tooltip("Position.")]
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
			//UnityEngine.Collider.ClosestPointOnBounds(UnityEngine.Vector3);
			_result.Value = _collider.Value.ClosestPointOnBounds(_position.Value);
		}
		
		public override string GetSummary()
		{
			return "Get closest point on {_collider} bounds to {_position} -> {_result}";
		}
	}
}
