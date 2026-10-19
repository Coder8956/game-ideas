
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameObject)]
	[ActionDescription("Returns one active GameObject with the specified tag, optionally matching a name. Returns null if no GameObject was found.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.FindWithTag.html")]
	public sealed class GameObjectFindWithTag : BaseAction
	{
		
		[Tooltip("The tag to search for.")]
		[SerializeField, TagValue]
		private StringVar _tag;

		[Tooltip("Optional GameObject name to match after filtering by tag. Leave empty to return any GameObject with the tag.")]
		[SerializeField]
		[OptionalField]
		private StringVar _name;
		
		[Tooltip("Store the result in GameObject variable.")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tag, _result);
		}
		
		public override void Execute()
		{
			if (string.IsNullOrEmpty(_name?.Value))
			{
				_result.Value = GameObject.FindWithTag(_tag.Value);
				return;
			}

			_result.Value = null;
			foreach (var gameObject in GameObject.FindGameObjectsWithTag(_tag.Value))
			{
				if (gameObject.name != _name.Value) continue;
				_result.Value = gameObject;
				break;
			}
		}
		
		public override string GetSummary()
		{
			return string.IsNullOrEmpty(_name?.Value)
				? "Find GameObject with {_tag} tag -> {_result}"
				: "Find GameObject named {_name} with {_tag} tag -> {_result}";
		}
	}
}
