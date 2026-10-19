
using System.Collections.Generic;
using JetBrains.Annotations;
using HutongGames.Reflection;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameObject)]
	[ActionDescription("Gets references to all components of type T on the specified GameObject, and any " +
		"parent of the GameObject. By default, Unity includes components on the root GameObject.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.GetComponentsInParent.html")]
	public sealed class GameObjectGetComponentsInParent : BaseAction
	{
		
		[Tooltip("The GameObject.")]
		[SerializeField]
		private GameObjectVar _gameObject;
		
		[FormerlySerializedAs("_type")]
		[Tooltip("The type of component to search for.")]
		[SerializeField, BaseType(typeof(Component))]
		private TypeReference _componentType;

		[Tooltip("Exclude components on the root GameObject from the results.")]
		[SerializeField]
		private BoolVar _excludeRoot = new();
		
		[MatchType(nameof(_componentType))]
		[Tooltip("Store the result in Component List variable.")]
		[SerializeReference, WriteOnly]
		private IListVariableRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_gameObject, _componentType, _result);
		}
		
		public override void Execute()
		{
			var components = _gameObject.Value.GetComponentsInParent(_componentType.Type);
			if (_excludeRoot is { Value: true })
			{
				var root = _gameObject.Value;
				var filteredComponents = new List<Component>(components.Length);
				foreach (var component in components)
				{
					if (component == null || component.gameObject != root)
					{
						filteredComponents.Add(component);
					}
				}

				_result.SetValue(filteredComponents);
				return;
			}

			_result.SetValue(components);
		}
		
		public override string GetSummary()
		{
			return "Get {_componentType} components in {_gameObject} parent -> {_result}" +
				(_excludeRoot is { Value: true } ? " (excluding root)" : "");
		}
	}
}
