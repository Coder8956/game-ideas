
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("Set the value of a Rect variable.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect.html")]
	public sealed class RectSetValue : BaseAction
	{
		
		[DefaultName("Rect")]
		[Tooltip("The Rect variable to set.")]
		[SerializeField]
		[WriteOnly]
		private RectRef _variable;
		
		[Tooltip("Set Rect value.")]
		[SerializeField]
		private RectVar _setValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_variable, _setValue);
		}
		
		public override void Execute()
		{
			_variable.Value = _setValue.Value;
		}
		
		public override string GetSummary() => "Set {_variable} to {_setValue}";
	}
}
