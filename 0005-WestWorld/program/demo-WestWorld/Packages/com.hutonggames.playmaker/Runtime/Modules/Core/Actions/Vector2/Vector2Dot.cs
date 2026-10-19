
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Dot Product of two vectors.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2.Dot.html")]
	public sealed class Vector2Dot : BaseAction
	{
		
		[Tooltip("Lhs.")]
		[SerializeField]
		private Vector2Var _vectorA;
		
		[Tooltip("Rhs.")]
		[SerializeField]
		private Vector2Var _vectorB;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vectorA, _vectorB, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector2.Dot(UnityEngine.Vector2, UnityEngine.Vector2);
			_result.Value = Vector2.Dot(_vectorA.Value, _vectorB.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector2 Dot: {_vectorA} {_vectorB} -> {_result}";
		}
	}
}
