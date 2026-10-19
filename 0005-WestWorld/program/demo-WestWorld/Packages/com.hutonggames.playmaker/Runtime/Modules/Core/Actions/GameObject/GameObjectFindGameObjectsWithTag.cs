
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameObject)]
	[ActionDescription("Returns an array of active GameObjects tagged tag. Returns empty array if no Game" +
		"Object was found.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html")]
	public sealed class GameObjectFindGameObjectsWithTag : BaseAction
	{
		
		[Tooltip("The name of the tag to search GameObjects for.")]
		[SerializeField, TagValue]
		private StringVar _tag;
		
		[Tooltip("Store the result in GameObject List variable.")]
		[SerializeField]
		[WriteOnly]
		private GameObjectListRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tag, _result);
		}
		
		public override void Execute()
		{
			_result.Values = GameObject.FindGameObjectsWithTag(_tag.Value);
		}
		
		public override string GetSummary()
		{
			return "Find GameObjects with tag {_tag} -> {_result}";
		}
	}
}
