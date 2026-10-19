
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MathConstants)]
	[ActionDescription("A representation of positive infinity (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Infinity.html")]
	public sealed class MathfGetInfinity : BaseAction
	{
		
		[Tooltip("Get Mathf Infinity")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getInfinity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getInfinity);
		}
		
		public override void Execute()
		{
			_getInfinity.Value = Mathf.Infinity;
		}
		
		public override string GetSummary()
		{
			return "Get infinity -> {_getInfinity}";
		}
	}
}

