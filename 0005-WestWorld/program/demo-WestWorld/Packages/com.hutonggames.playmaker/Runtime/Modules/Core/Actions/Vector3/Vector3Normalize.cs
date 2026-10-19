
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Returns a normalized vector based on the given vector. The normalized vector has " +
		"a magnitude of 1 and is in the same direction as the given vector. Returns a zer" +
		"o vector If the given vector is too small to be normalized.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.Normalize.html")]
	public sealed class Vector3Normalize : BaseAction
	{
		
		[Tooltip("The vector to be normalized.")]
		[SerializeField]
		private Vector3Var _value;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_value, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector3.Normalize(UnityEngine.Vector3);
			_result.Value = Vector3.Normalize(_value.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector3 Normalize: {_value} -> {_result}";
		}
	}
}
