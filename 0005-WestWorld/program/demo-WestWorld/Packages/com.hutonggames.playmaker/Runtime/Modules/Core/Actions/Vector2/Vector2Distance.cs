
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Returns the distance between a and b.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2.Distance.html")]
	public sealed class Vector2Distance : BaseAction
	{
		
		[Tooltip("A.")]
		[SerializeField]
		private Vector2Var _a;
		
		[Tooltip("B.")]
		[SerializeField]
		private Vector2Var _b;
		
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
			//UnityEngine.Vector2.Distance(UnityEngine.Vector2, UnityEngine.Vector2);
			_result.Value = Vector2.Distance(_a.Value, _b.Value);
		}
		
		public override string GetSummary()
		{
			return "Get distance from {_a} to {_b} -> {_result}";
		}
	}
}
