
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Trigonometry)]
	[ActionDescription("Radians-to-degrees conversion constant (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Rad2Deg.html")]
	public sealed class MathfGetRad2Deg : BaseAction
	{
		
		[Tooltip("Get Mathf Rad 2 Deg")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getRad2Deg;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getRad2Deg);
		}
		
		public override void Execute()
		{
			_getRad2Deg.Value = Mathf.Rad2Deg;
		}
		
		public override string GetSummary()
		{
			return "Get rad to deg -> {_getRad2Deg}";
		}
	}
}

