
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameplayTargetingGameObject)]
	[ActionDescription("Find all GameObjects that match a list of conditions." +
	                   "\n\nNOTE: This is an expensive action, but can be useful to find specific objects.")]
	[HelpURL("actions/gameobject-actions/query/game-object-find-all-matches/")]
	public sealed class GameObjectFindAllMatches : BaseAction
	{
		[Tooltip(Strings.ConditionTest)]
		[BaseType(typeof(GameObject))]
		[SerializeField]
		private ConditionTest _findAllGameObjectWhere = new ();
		
		[Tooltip("Include inactive GameObjects in the search.")]
		[SerializeField]
		private BoolVar _includeInactive;
		
		[Tooltip("Store the result in GameObject list variable.")]
		[SerializeField]
		[WriteOnly]
		private GameObjectListRef _result;
		
		public override bool CanExecute() => CheckParameters(_findAllGameObjectWhere, _includeInactive, _result);

		public override void Execute()
		{
			var include = _includeInactive.Value 
				? FindObjectsInactive.Include 
				: FindObjectsInactive.Exclude;
			var allGameObjects = Internal.CompatibilityShims.FindObjectsByTypeShim<GameObject>(include);
			var matches = new List<GameObject>();
			foreach (var gameObject in allGameObjects)
			{
				if (_findAllGameObjectWhere.Evaluate(gameObject))
				{
					matches.Add(gameObject);
				}
			}
			_result.Value = matches;
		}
		
		public override string GetSummary() => "Find all where {_findAllGameObjectWhere} -> {_result}";
	}
}
