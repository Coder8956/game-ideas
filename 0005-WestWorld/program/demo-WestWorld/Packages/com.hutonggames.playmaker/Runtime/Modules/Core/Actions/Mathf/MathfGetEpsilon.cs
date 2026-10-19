
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MathConstants)]
	[ActionDescription("A tiny floating point value (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Epsilon.html")]
	public sealed class MathfGetEpsilon : BaseAction
	{
		
		[Tooltip("Get Mathf Epsilon")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getEpsilon;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getEpsilon);
		}
		
		public override void Execute()
		{
			_getEpsilon.Value = Mathf.Epsilon;
		}
		
		public override string GetSummary()
		{
			return "Get epsilon -> {_getEpsilon}";
		}
	}
}

