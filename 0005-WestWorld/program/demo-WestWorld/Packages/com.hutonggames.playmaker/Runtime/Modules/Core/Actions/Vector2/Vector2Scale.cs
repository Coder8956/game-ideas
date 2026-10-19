
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Multiplies two vectors component-wise.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2.Scale.html")]
	public sealed class Vector2Scale : BaseAction
	{
		
		[Tooltip("A.")]
		[SerializeField]
		private Vector2Var _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private Vector2Var _b;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_a, _b, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector2.Scale(UnityEngine.Vector2, UnityEngine.Vector2);
			_result.Value = Vector2.Scale(_a.Value, _b.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector2 Scale: {_a} {_b} -> {_result}";
		}
	}
}
