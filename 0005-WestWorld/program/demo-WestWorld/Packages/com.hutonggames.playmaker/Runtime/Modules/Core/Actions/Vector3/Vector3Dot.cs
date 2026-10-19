
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Dot Product of two vectors.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.Dot.html")]
	public sealed class Vector3Dot : BaseAction
	{
		
		[Tooltip("Lhs.")]
		[SerializeField]
		private Vector3Var _vectorA;
		
		[Tooltip("Rhs.")]
		[SerializeField]
		private Vector3Var _vectorB;
		
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
			//UnityEngine.Vector3.Dot(UnityEngine.Vector3, UnityEngine.Vector3);
			_result.Value = Vector3.Dot(_vectorA.Value, _vectorB.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector3 Dot: {_vectorA} {_vectorB} -> {_result}";
		}
	}
}
