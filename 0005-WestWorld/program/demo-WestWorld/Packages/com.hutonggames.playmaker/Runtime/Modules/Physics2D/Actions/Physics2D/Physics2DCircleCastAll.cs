
using System;
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI, Serializable]
	[ActionCategory(Category.Physics2DQueries)]
	[ActionDescription("Casts a circle against Colliders in the Scene, returning all Colliders that contact with it.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics2D.CircleCastAll.html")]
	public sealed class Physics2DCircleCastAll : BaseAction
	{
		
		[Tooltip("The point in 2D space where the circle originates.")]
		[SerializeField]
		private Vector2Var _origin;
		
		[Tooltip("The radius of the circle.")]
		[SerializeField]
		[DefaultValue(1f)]
		private FloatVar _radius;
		
		[Tooltip("A vector representing the direction of the circle.")]
		[SerializeField]
		private Vector2Var _direction;
		
		[Tooltip("The maximum distance over which to cast the circle.")]
		[SerializeField]
		[DefaultValue("~MathfInfinity")]
		private FloatVar _maxDistance;
		
		[Tooltip("The contact filter used to filter the results differently, such as by layer mask," +
		         " Z depth, or normal angle.")]
		[SerializeField]
		private ContactFilter2DVar _contactFilter;
		
		[WriteOnly]
		[Tooltip("Store the result in RaycastHit2D List variable.")]
		[SerializeField]
		private RaycastHit2DListRef _result;

		private RaycastHit2D[] _resultBuffer;
		
		[WriteOnly]
		[OptionalField]
		[Tooltip("Store the number of results in Integer variable.")]
		[SerializeField]
		private IntegerRef _resultCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_origin, _radius, _direction, _maxDistance, _contactFilter, _result);
		}
		
		public override void Execute()
		{
			if (!_result.TryGetNonAllocBuffer(ref _resultBuffer))
			{
				return;
			}

			var resultCount = Physics2D.CircleCast(_origin.Value, _radius.Value, _direction.Value, _contactFilter.Value, _resultBuffer, _maxDistance.Value);
			_result.CopyFromNonAllocBuffer(_resultBuffer);
			if (_resultCount.HasValue())
			{
				_resultCount.Value = resultCount;
			}
		}
		
		public override string GetSummary()
		{
			return "Physics2D Circle Cast All: {_origin} {_radius} {_direction} -> {_result}";
		}
	}
}
