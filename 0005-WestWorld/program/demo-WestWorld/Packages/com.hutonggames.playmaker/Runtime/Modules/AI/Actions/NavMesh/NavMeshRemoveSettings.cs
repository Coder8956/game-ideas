
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Removes the build settings matching the agent type ID.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.RemoveSettings.html")]
	public sealed class NavMeshRemoveSettings : BaseAction
	{
		
		[Tooltip("The ID of the entry to remove.")]
		[SerializeField]
		private IntegerVar _agentTypeID;
		
		public override bool CanExecute()
		{
			return CheckParameters(_agentTypeID);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.RemoveSettings(System.Int32);
			UnityEngine.AI.NavMesh.RemoveSettings(_agentTypeID.Value);
		}
		
		public override string GetSummary()
		{
			return "Remove NavMesh settings {_agentTypeID}";
		}
	}
}
