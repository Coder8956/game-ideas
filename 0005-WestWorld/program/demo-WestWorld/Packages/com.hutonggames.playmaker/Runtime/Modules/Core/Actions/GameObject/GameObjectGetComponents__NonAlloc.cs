/* TODO: ComponentListRef should be able to reference variables derived from ListVariableRef<Component>
using JetBrains.Annotations;
using HutongGames.Reflection;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[PublicAPI]
	[ActionCategory(Category.GameObject)]
	[ActionDescription("Gets references to all components of type T on the specified GameObject.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.GetComponents.html")]
	public sealed class GameObjectGetComponents__NonAlloc : BaseAction
	{
		
		[Tooltip("The GameObject.")]
		[SerializeField]
		private GameObjectVar _gameObject;
		
		[Tooltip("The type of component to search for.")]
		[SerializeField]
		private TypeReference _type;
		
		[Tooltip("A list to use for the returned results.")]
		[SerializeField]
		private ComponentListRef _results;
		
		public override bool CanExecute()
		{
			return CheckParameters(_gameObject, _type, _results);
		}
		
		public override void Execute()
		{ 
			_gameObject.Value.GetComponents(_type.Type, _results.Value);
		}
		
		public override string GetSummary() => "Get {_type} Components on {_gameObject} -> {_results} ";
	}
}
*/