
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Returns a vector that is made from the largest components of two vectors.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2.Max.html")]
	public sealed class Vector2Max : BaseAction
	{
		
		[Tooltip("Lhs.")]
		[SerializeField]
		private Vector2Var _vectorA;
		
		[Tooltip("Rhs.")]
		[SerializeField]
		private Vector2Var _vectorB;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vectorA, _vectorB, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector2.Max(UnityEngine.Vector2, UnityEngine.Vector2);
			_result.Value = Vector2.Max(_vectorA.Value, _vectorB.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector2 Max: {_vectorA} {_vectorB} -> {_result}";
		}
	}
}
