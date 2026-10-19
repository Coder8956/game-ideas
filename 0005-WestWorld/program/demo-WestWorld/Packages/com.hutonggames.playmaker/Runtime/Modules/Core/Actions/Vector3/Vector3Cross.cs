
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Cross Product of two vectors.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.Cross.html")]
	public sealed class Vector3Cross : BaseAction
	{
		
		[Tooltip("Lhs.")]
		[SerializeField]
		private Vector3Var _vectorA;
		
		[Tooltip("Rhs.")]
		[SerializeField]
		private Vector3Var _vectorB;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vectorA, _vectorB, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector3.Cross(UnityEngine.Vector3, UnityEngine.Vector3);
			_result.Value = Vector3.Cross(_vectorA.Value, _vectorB.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector3 Cross: {_vectorA} {_vectorB} -> {_result}";
		}
	}
}
