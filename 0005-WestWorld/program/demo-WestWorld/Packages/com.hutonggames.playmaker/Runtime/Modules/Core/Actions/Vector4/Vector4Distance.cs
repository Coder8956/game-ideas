
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Returns the distance between a and b.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4.Distance.html")]
	public sealed class Vector4Distance : BaseAction
	{
		
		[Tooltip("A.")]
		[SerializeField]
		private Vector4Var _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private Vector4Var _b;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_a, _b, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector4.Distance(UnityEngine.Vector4, UnityEngine.Vector4);
			_result.Value = Vector4.Distance(_a.Value, _b.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector4 Distance: {_a} {_b} -> {_result}";
		}
	}
}
