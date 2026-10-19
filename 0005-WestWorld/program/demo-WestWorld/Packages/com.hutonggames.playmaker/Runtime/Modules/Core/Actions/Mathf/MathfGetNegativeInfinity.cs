
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MathConstants)]
	[ActionDescription("A representation of negative infinity (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.NegativeInfinity.html")]
	public sealed class MathfGetNegativeInfinity : BaseAction
	{
		
		[Tooltip("Get Mathf Negative Infinity")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getNegativeInfinity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getNegativeInfinity);
		}
		
		public override void Execute()
		{
			_getNegativeInfinity.Value = Mathf.NegativeInfinity;
		}
		
		public override string GetSummary()
		{
			return "Get negative infinity -> {_getNegativeInfinity}";
		}
	}
}

