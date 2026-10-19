
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Creates and returns a new entry of NavMesh build settings available for runtime N" +
		"avMesh building.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.CreateSettings.html")]
	public sealed class NavMeshCreateSettings : BaseAction
	{
		
		[Tooltip("The created settings.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshBuildSettingsRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.CreateSettings();
			_result.Value = UnityEngine.AI.NavMesh.CreateSettings();
		}
		
		public override string GetSummary()
		{
			return "Create NavMesh settings -> {_result}";
		}
	}
}
