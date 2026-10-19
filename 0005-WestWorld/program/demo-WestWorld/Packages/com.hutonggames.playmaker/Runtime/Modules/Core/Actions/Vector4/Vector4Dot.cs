
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Dot Product of two vectors.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4.Dot.html")]
	public sealed class Vector4Dot : BaseAction
	{
		
		[Tooltip("A.")]
		[SerializeField]
		private Vector4Var _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private Vector4Var _b;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_a, _b, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector4.Dot(UnityEngine.Vector4, UnityEngine.Vector4);
			_result.Value = Vector4.Dot(_a.Value, _b.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector4 Dot: {_a} {_b} -> {_result}";
		}
	}
}
