
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Returns an existing entry of NavMesh build settings by its ordered index.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.GetSettingsByIndex.html")]
	public sealed class NavMeshGetSettingsByIndex : BaseAction
	{
		
		[Tooltip("The index to retrieve from.")]
		[SerializeField]
		private IntegerVar _index;
		
		[Tooltip("The found settings.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshBuildSettingsRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_index, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.GetSettingsByIndex(System.Int32);
			_result.Value = UnityEngine.AI.NavMesh.GetSettingsByIndex(_index.Value);
		}
		
		public override string GetSummary()
		{
			return "Get NavMesh settings by index {_index} -> {_result}";
		}
	}
}
