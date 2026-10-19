
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Multiplies two vectors component-wise.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.Scale.html")]
	public sealed class Vector3Scale : BaseAction
	{
		
		[Tooltip("A.")]
		[SerializeField]
		private Vector3Var _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private Vector3Var _b;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_a, _b, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector3.Scale(UnityEngine.Vector3, UnityEngine.Vector3);
			_result.Value = Vector3.Scale(_a.Value, _b.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector3 Scale: {_a} {_b} -> {_result}";
		}
	}
}
