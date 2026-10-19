
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Returns the number of registered NavMesh build settings.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.GetSettingsCount.html")]
	public sealed class NavMeshGetSettingsCount : BaseAction
	{
		
		[Tooltip("The number of registered entries.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.GetSettingsCount();
			_result.Value = UnityEngine.AI.NavMesh.GetSettingsCount();
		}
		
		public override string GetSummary()
		{
			return "Get NavMesh settings count -> {_result}";
		}
	}
}
