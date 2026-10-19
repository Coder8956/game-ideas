
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Returns the distance between a and b.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.Distance.html")]
	public sealed class Vector3Distance : BaseAction
	{
		
		[Tooltip("A.")]
		[SerializeField]
		private Vector3Var _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private Vector3Var _b;
		
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
			//UnityEngine.Vector3.Distance(UnityEngine.Vector3, UnityEngine.Vector3);
			_result.Value = Vector3.Distance(_a.Value, _b.Value);
		}
		
		public override string GetSummary()
		{
			return "Get Distance from {_a} to {_b} -> {_result}";
		}
	}
}
