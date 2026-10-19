
using HutongGames.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameObject)]
	[ConvertibleGroup("GameObjectSendMessage")]
	[ActionDescription("Calls a method with an optional parameter on every MonoBehaviour in this GameObject " +
	                   "and on every ancestor of the behaviour." +
	                   "\n\n" + Strings.SendMessagePerformanceWarning)]
	[HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.SendMessageUpwards.html")]
	public sealed class GameObjectSendMessageUpwards : BaseAction
	{
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
		
		[Tooltip("Should an error be raised if the target object doesn't implement the method for the message?")]
		[SerializeField]
		private SendMessageOptionsVar _options;
		
		public override bool CanExecute() => CheckParameters(_gameObject, _methodName, _options);

		public override void Execute() => _gameObject.Value.SendMessageUpwards(_methodName.Value, _parameter?.GetValue(), _options.Value);

		public override string GetSummary() => "Send message upwards {_methodName}({_parameter}) from {_gameObject} {_options}";
	}
}
