using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{


	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameplayTargetingGameObject)]
	[ActionDescription("Finds the closest GameObject that matches a list of conditions." +
	                   "\n\nNOTE: This is an expensive action, but can be useful to find specific objects.")]
	[HelpURL("actions/gameobject-actions/query/game-object-find-closest-match/")]
	public sealed class GameObjectFindClosestMatch : BaseAction
	{
		[Tooltip("The GameObject to measure from.")]
		[SerializeField, OwnerDefaultValue]
		private GameObjectVar _gameObject;

		[Tooltip("Conditions to test.")]
		[BaseType(typeof(GameObject))]
		[SerializeField]
		private ConditionTest _findClosestGameObjectWhere = new ();

		[Tooltip("Exclude GameObjects further than this distance.")]
		[SerializeField, DefaultValue(1000f)]
		private FloatVar _maxDistance;

		[Tooltip("Exclude children from the search.")]
		[SerializeField]
		private BoolVar _excludeChildren;

		[Tooltip("Include inactive GameObjects in the search.")]
		[SerializeField]
		private BoolVar _includeInactive;

		[ActionHeader("Result")]
		
		[Tooltip("Store the result in GameObject variable (null if none found).")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _closest;

		[Tooltip("Store the distance to the closest GameObject, or -1 if none found.")]
		[SerializeField, OptionalField, WriteOnly]
		private FloatRef _distance;

		public override bool CanExecute() =>
			CheckParameters(_gameObject, _findClosestGameObjectWhere, _maxDistance, _excludeChildren, _includeInactive, _closest);

		public override void Execute()
		{
			var myTransform = _gameObject.Value.transform;
			GameObject closestGameObject = null;
			var maxDistance = _maxDistance.Value;
			var closestDistance = maxDistance * maxDistance;

			var include = _includeInactive.Value
				? FindObjectsInactive.Include
				: FindObjectsInactive.Exclude;
			var allGameObjects = Internal.CompatibilityShims.FindObjectsByTypeShim<GameObject>(include);
			foreach (var gameObject in allGameObjects)
			{
				if (gameObject == _gameObject.Value) continue;
				if (_excludeChildren.Value && gameObject.transform.IsChildOf(myTransform)) continue;

				var distance = (gameObject.transform.position - myTransform.position).sqrMagnitude;
				if (!(distance < closestDistance)) continue;
				if (!_findClosestGameObjectWhere.Evaluate(gameObject)) continue;

				closestGameObject = gameObject;
				closestDistance = distance;
			}

			_closest.Value = closestGameObject;
			if (_distance is { IsAssigned: true })
			{
				_distance.Value = closestGameObject != null ? Mathf.Sqrt(closestDistance) : -1f;
			}
		}

		public override string GetSummary() =>
			"Find closest to {_gameObject} where {_findClosestGameObjectWhere} -> {_closest} {_distance:output}";
	}
}
