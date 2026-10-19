
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshDataInstance)]
	[ActionDescription("True if the NavMesh data is added to the navigation system - otherwise false (Rea" +
		"d Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshDataInstance-valid.html")]
	public sealed class NavMeshDataInstanceGetValid : BaseAction
	{
		
		[Tooltip("The NavMeshDataInstance")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshDataInstanceRef _navMeshDataInstance;
		
		[Tooltip("Get NavMeshDataInstance Valid")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.BoolRef _getValid;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshDataInstance, _getValid);
		}
		
		public override void Execute()
		{
			this._getValid.Value = this._navMeshDataInstance.Value.valid;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshDataInstance} Valid -> {_getValid}";
		}
	}
}
