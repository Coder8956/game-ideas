#if UNITY_6000_0_OR_NEWER
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Get all the NavMesh area names.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.GetAreaNames.html")]
	public sealed class NavMeshGetAreaNames : BaseAction
	{
		
		[Tooltip("Store the result in String List variable.")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.StringListRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.GetAreaNames();
			_result.Values = UnityEngine.AI.NavMesh.GetAreaNames();
		}
		
		public override string GetSummary()
		{
			return "Get NavMesh area names -> {_result}";
		}
	}
}
#endif
