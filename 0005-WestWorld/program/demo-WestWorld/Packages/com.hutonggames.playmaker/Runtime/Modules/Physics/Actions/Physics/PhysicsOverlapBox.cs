
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PhysicsQueries)]
	[ConvertibleGroup("PhysicsOverlap")]
	[ActionDescription("Find all colliders touching or inside of the given box.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.OverlapBox.html")]
	public sealed class PhysicsOverlapBox : BaseAction
	{
		
		[Tooltip("Center of the box.")]
		[SerializeField]
		private Vector3Var _center;
		
		[Tooltip("Half of the size of the box in each dimension.")]
		[SerializeField]
		private Vector3Var _halfExtents;
		
		[Tooltip("Rotation of the box.")]
		[SerializeField]
		private QuaternionVar _orientation;
		
		[Tooltip("A Layer mask defines which layers of colliders to include in the query.")]
		[SerializeField, DefaultValue("Physics.AllLayers")]
		private LayerMaskVar _layerMask;
		
		[Tooltip("Store the result in Collider List variable.")]
		[SerializeField]
		[WriteOnly]
		private ColliderListRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_center, _halfExtents, _orientation, _layerMask, _result);
		}
		
		public override void Execute()
		{
			// ReSharper disable once Unity.PreferNonAllocApi
			_result.Values = Physics.OverlapBox(_center.Value, _halfExtents.Value, _orientation.Value, _layerMask.Value);
		}
		
		public override string GetSummary()
		{
			return "Overlap box {_center} {_halfExtents} {_orientation} {_layerMask} -> {_result}";
		}
	}
}
