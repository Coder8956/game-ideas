
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("Shorthand for writing new Rect(0,0,0,0).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-zero.html")]
	public sealed class RectGetZero : BaseAction
	{
		
		[Tooltip("Get Rect Zero")]
		[SerializeField]
		[WriteOnly]
		private RectRef _getZero;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getZero);
		}
		
		public override void Execute()
		{
			_getZero.Value = Rect.zero;
		}
		
		public override string GetSummary()
		{
			return "Get Rect zero -> {_getZero} ";
		}
	}
}
