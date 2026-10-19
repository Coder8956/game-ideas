
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Like Rigidbody.SweepTest, but returns all hits.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.SweepTestAll.html")]
	public sealed class RigidbodySweepTestAll : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("The direction into which to sweep the rigidbody.")]
		[SerializeField]
		private Vector3Var _direction;
		
		[Tooltip("The length of the sweep.")]
		[SerializeField]
		[DefaultValue("~MathfInfinity")]
		private FloatVar _maxDistance;
		
		[Tooltip("Specifies whether this query should hit Triggers.")]
		[SerializeField]
		private QueryTriggerInteractionVar _hitTriggers;
		
		[Tooltip("Store the result in RaycastHit List variable.")]
		[SerializeField]
		[WriteOnly]
		private RaycastHitListRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _direction, _maxDistance, _hitTriggers, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody.SweepTestAll(UnityEngine.Vector3, System.Single, UnityEngine.QueryTriggerInteraction);
			_result.Values = _rigidbody.Value.SweepTestAll(_direction.Value, _maxDistance.Value, _hitTriggers.Value);
		}
		
		public override string GetSummary()
		{
			return "Sweep test all from {_rigidbody} in {_direction} {_maxDistance} {_hitTriggers} -> {_result}";
		}
	}
}
