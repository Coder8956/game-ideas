
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Projects a vector onto another vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4.Project.html")]
	public sealed class Vector4Project : BaseAction
	{
		
		[Tooltip("A.")]
		[SerializeField]
		private Vector4Var _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private Vector4Var _b;
		
		[Tooltip("Store the result in Vector4 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector4Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_a, _b, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector4.Project(UnityEngine.Vector4, UnityEngine.Vector4);
			_result.Value = Vector4.Project(_a.Value, _b.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector4 Project: {_a} {_b} -> {_result}";
		}
	}
}
