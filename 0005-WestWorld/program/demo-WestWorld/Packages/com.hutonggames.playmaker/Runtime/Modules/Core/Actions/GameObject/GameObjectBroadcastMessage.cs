
using JetBrains.Annotations;
using HutongGames.Reflection;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameObject)]
	[ConvertibleGroup("GameObjectSendMessage")]
	[ActionDescription("Calls a method with an optional parameter on every MonoBehaviour in this game object " +
	                   "or any of its children.\n\n" + Strings.SendMessagePerformanceWarning)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.BroadcastMessage.html")]
	public sealed class GameObjectBroadcastMessage : BaseAction
	{
		[OwnerDefaultValue]
		[Tooltip("The GameObject.")]
		[SerializeField]
		private GameObjectVar _gameObject;
		
		[Tooltip("Name of the method to call.")]
		[SerializeField]
		private StringVar _methodName;

		[OptionalField]
		[Tooltip("The type of the optional parameter to pass to the method.")]
		[BaseType(typeof(object))]
		[SerializeField]
		private TypeReference _parameterType;
		
		[OptionalField]
		[MatchType(nameof(_parameterType))]
		[Tooltip("The parameter to pass to the method.")]
		[SerializeReference]
		private IVariableVar _parameter;
		
		[Tooltip("Should an error be raised if the method does not exist for a given target object?")]
		[SerializeField]
		private SendMessageOptionsVar _options;
		
		public override bool CanExecute() => CheckParameters(_gameObject, _methodName, _options);

		public override void Execute() => _gameObject.Value.BroadcastMessage(_methodName.Value, _parameter?.GetValue(),  _options.Value);

		public override string GetSummary() => "Broadcast message {_methodName}({_parameter}) on {_gameObject} {_options}";
	}
}
