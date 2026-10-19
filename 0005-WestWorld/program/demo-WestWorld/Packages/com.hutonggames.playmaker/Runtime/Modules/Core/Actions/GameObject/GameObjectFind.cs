
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameObject)]
	[ActionDescription("Finds a GameObject by name and returns it.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.Find.html")]
	public sealed class GameObjectFind : BaseAction
	{
		
		[Tooltip("Name.")]
		[SerializeField]
		private StringVar _name;
		
		[Tooltip("Store the result in GameObject variable.")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_name, _result);
		}
		
		public override void Execute()
		{
			_result.Value = GameObject.Find(_name.Value);
		}
		
		public override string GetSummary()
		{
			return "Find GameObject named {_name} -> {_result}";
		}
	}
}
