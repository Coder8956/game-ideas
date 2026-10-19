
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("Returns a formatted string for this Rect.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect.ToString.html")]
	public sealed class RectToString__Format : BaseAction
	{
		
		[Tooltip("The Rect.")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("A numeric format string.")]
		[SerializeField, CanBeNullOrEmpty]
		private StringVar _format;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _format, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rect.ToString(System.String);
			_result.Value = _rect.Value.ToString(_format.Value);
		}
		
		public override string GetSummary()
		{
			return "{_rect} To String  {_format} -> {_result}";
		}
	}
}
