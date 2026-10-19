
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Trigonometry)]
	[ActionDescription("Degrees-to-radians conversion constant (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Deg2Rad.html")]
	public sealed class MathfGetDeg2Rad : BaseAction
	{
		
		[Tooltip("Get Mathf Deg 2 Rad")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getDeg2Rad;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getDeg2Rad);
		}
		
		public override void Execute()
		{
			_getDeg2Rad.Value = Mathf.Deg2Rad;
		}
		
		public override string GetSummary()
		{
			return "Get deg to rad -> {_getDeg2Rad}";
		}
	}
}

