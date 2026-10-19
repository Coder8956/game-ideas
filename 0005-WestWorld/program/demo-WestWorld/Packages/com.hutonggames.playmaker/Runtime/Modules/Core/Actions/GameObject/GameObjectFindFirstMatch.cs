
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameplayTargetingGameObject)]
	[ActionDescription("Finds the first GameObject that matches a list of conditions." +
	                   "\n\nNOTE: This is an expensive action, but can be useful to find specific objects.")]
	[HelpURL("https://hutonggames.com/playmaker/docs/actions/list-actions/")]
	public sealed class GameObjectFindFirstMatch : BaseAction
	{
		[Tooltip(Strings.ConditionTest)]
		[BaseType(typeof(GameObject))]
		[SerializeField]
		private ConditionTest _findFirstGameObjectWhere = new ();
		
		[Tooltip("Include inactive GameObjects in the search.")]
		[SerializeField]
		private BoolVar _includeInactive;
		
		[Tooltip("Store the result in GameObject variable.")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_findFirstGameObjectWhere, _includeInactive, _result);
		}
		
		public override void Execute()
		{
			var include = _includeInactive.Value 
				? FindObjectsInactive.Include 
				: FindObjectsInactive.Exclude;
			var allGameObjects = Internal.CompatibilityShims.FindObjectsByTypeShim<GameObject>(include);
			_result.Value = null;
			foreach (var gameObject in allGameObjects)
			{
				if (!_findFirstGameObjectWhere.Evaluate(gameObject)) continue;
				_result.Value = gameObject;
				break;
			}
		}
		
		public override string GetSummary() => "Find first where {_findFirstGameObjectWhere} -> {_result}";
	}
}
