
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Returns the name associated with the NavMesh build settings matching the provided" +
		" agent type ID.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.GetSettingsNameFromID.html")]
	public sealed class NavMeshGetSettingsNameFromID : BaseAction
	{
		
		[Tooltip("The ID to look for.")]
		[SerializeField]
		private IntegerVar _agentTypeID;
		
		[Tooltip("The name associated with the ID found.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_agentTypeID, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.GetSettingsNameFromID(System.Int32);
			_result.Value = UnityEngine.AI.NavMesh.GetSettingsNameFromID(_agentTypeID.Value);
		}
		
		public override string GetSummary()
		{
			return "Get NavMesh settings name from ID {_agentTypeID} -> {_result}";
		}
	}
}
