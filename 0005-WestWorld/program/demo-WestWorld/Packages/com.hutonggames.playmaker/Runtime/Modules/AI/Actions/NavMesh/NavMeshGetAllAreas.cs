
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Area mask constant that includes all NavMesh areas.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.AllAreas.html")]
	public sealed class NavMeshGetAllAreas : BaseAction
	{
		
		[Tooltip("Get NavMesh All Areas")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getAllAreas;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getAllAreas);
		}
		
		public override void Execute()
		{
			_getAllAreas.Value = UnityEngine.AI.NavMesh.AllAreas;
		}
		
		public override string GetSummary()
		{
			return "Get NavMesh all areas -> {_getAllAreas}";
		}
	}
}

