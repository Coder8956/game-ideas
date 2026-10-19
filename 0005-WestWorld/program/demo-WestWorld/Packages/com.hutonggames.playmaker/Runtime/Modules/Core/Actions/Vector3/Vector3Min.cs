
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Returns a vector that is made from the smallest components of two vectors.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.Min.html")]
	public sealed class Vector3Min : BaseAction
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
			//UnityEngine.Vector3.Min(UnityEngine.Vector3, UnityEngine.Vector3);
			_result.Value = Vector3.Min(_vectorA.Value, _vectorB.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector3 Min: {_vectorA} {_vectorB} -> {_result}";
		}
	}
}
