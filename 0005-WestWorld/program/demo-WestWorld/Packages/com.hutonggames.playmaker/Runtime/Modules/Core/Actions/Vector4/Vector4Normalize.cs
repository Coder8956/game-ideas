
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Returns a normalized vector based on the given vector. The normalized vector has " +
		"a magnitude of 1 and is in the same direction as the given vector. Returns a zer" +
		"o vector If the given vector is too small to be normalized.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4.Normalize.html")]
	public sealed class Vector4Normalize : BaseAction
	{
		
		[Tooltip("The vector to be normalized.")]
		[SerializeField]
		private Vector4Var _a;
		
		[Tooltip("Store the result in Vector4 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector4Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_a, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector4.Normalize(UnityEngine.Vector4);
			_result.Value = Vector4.Normalize(_a.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector4 Normalize: {_a} -> {_result}";
		}
	}
}
