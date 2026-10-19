
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Get if 2 rotations are equal.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion-operator_eq.html")]
	public sealed class QuaternionEquals : BaseAction
	{
		
		[Tooltip("The Quaternion.")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("Other.")]
		[SerializeField]
		private QuaternionVar _other;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute() => CheckParameters(_quaternion, _other, _result);

		public override void Execute()
		{
			//UnityEngine.Quaternion.Equals(UnityEngine.Quaternion);
			_result.Value = _quaternion.Value.Equals(_other.Value);
		}
		
		public override string GetSummary() => "{_quaternion} equals {_other} -> {_result}";
	}
}
