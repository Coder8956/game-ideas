
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Returns the area index for a named NavMesh area type.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.GetAreaFromName.html")]
	public sealed class NavMeshGetAreaFromName : BaseAction
	{
		
		[Tooltip("Name of the area to look up.")]
		[SerializeField]
		private StringVar _areaName;
		
		[Tooltip("Index if the specified area name exists, or -1 if no area type has the specified " +
			"name.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_areaName, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.GetAreaFromName(System.String);
			_result.Value = UnityEngine.AI.NavMesh.GetAreaFromName(_areaName.Value);
		}
		
		public override string GetSummary()
		{
			return "Get NavMesh area from name {_areaName} -> {_result}";
		}
	}
}
