
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Returns a vector that is made from the largest components of two vectors.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4.Max.html")]
	public sealed class Vector4Max : BaseAction
	{
		
		[Tooltip("Lhs.")]
		[SerializeField]
		private Vector4Var _lhs;
		
		[Tooltip("Rhs.")]
		[SerializeField]
		private Vector4Var _rhs;
		
		[Tooltip("Store the result in Vector4 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector4Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_lhs, _rhs, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector4.Max(UnityEngine.Vector4, UnityEngine.Vector4);
			_result.Value = Vector4.Max(_lhs.Value, _rhs.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector4 Max: {_lhs} {_rhs} -> {_result}";
		}
	}
}
