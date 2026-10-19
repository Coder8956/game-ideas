
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Returns true if the given vector is exactly equal to this vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4.Equals.html")]
	public sealed class Vector4Equals : BaseAction
	{
		
		[Tooltip("The Vector4.")]
		[SerializeField]
		private Vector4Ref _vector4;
		
		[Tooltip("Other.")]
		[SerializeField]
		private Vector4Var _other;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector4, _other, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector4.Equals(UnityEngine.Vector4);
			_result.Value = _vector4.Value.Equals(_other.Value);
		}
		
		public override string GetSummary()
		{
			return "{_vector4} equals {_other} -> {_result}";
		}
	}
}
