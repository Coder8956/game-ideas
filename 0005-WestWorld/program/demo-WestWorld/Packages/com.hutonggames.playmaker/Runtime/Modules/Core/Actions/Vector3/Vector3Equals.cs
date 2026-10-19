
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Returns true if the given vector is exactly equal to this vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.Equals.html")]
	public sealed class Vector3Equals : BaseAction
	{
		
		[Tooltip("The Vector3.")]
		[SerializeField]
		private Vector3Ref _vector3;
		
		[Tooltip("Other.")]
		[SerializeField]
		private Vector3Var _other;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector3, _other, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector3.Equals(UnityEngine.Vector3);
			_result.Value = _vector3.Value.Equals(_other.Value);
		}
		
		public override string GetSummary()
		{
			return "{_vector3} equals {_other} -> {_result}";
		}
	}
}
