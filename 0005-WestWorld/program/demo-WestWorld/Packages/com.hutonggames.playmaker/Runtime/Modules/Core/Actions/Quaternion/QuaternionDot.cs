
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("The dot product between two rotations.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion.Dot.html")]
	public sealed class QuaternionDot : BaseAction
	{
		
		[Tooltip("Rotation A.")]
		[SerializeField]
		private QuaternionVar _a;
		
		[Tooltip("Rotation B.")]
		[SerializeField]
		private QuaternionVar _b;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute() => CheckParameters(_a, _b, _result);

		public override void Execute()
		{
			//UnityEngine.Quaternion.Dot(UnityEngine.Quaternion, UnityEngine.Quaternion);
			_result.Value = Quaternion.Dot(_a.Value, _b.Value);
		}
		
		public override string GetSummary() => "Quaternion Dot: {_a} {_b} -> {_result}";
	}
}
