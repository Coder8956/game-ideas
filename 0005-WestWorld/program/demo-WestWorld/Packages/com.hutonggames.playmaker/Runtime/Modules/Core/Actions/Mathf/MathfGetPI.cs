
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MathConstants)]
	[ActionDescription("The well-known 3.14159265358979... value (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.PI.html")]
	public sealed class MathfGetPI : BaseAction
	{
		
		[Tooltip("Get Mathf PI")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getPI;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getPI);
		}
		
		public override void Execute()
		{
			_getPI.Value = Mathf.PI;
		}
		
		public override string GetSummary()
		{
			return "Get PI -> {_getPI}";
		}
	}
}

