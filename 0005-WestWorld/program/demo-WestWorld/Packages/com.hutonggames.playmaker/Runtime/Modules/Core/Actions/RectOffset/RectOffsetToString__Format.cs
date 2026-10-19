
using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectOffset)]
	[ActionDescription("Returns a formatted string for this RectOffset.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectOffset.ToString.html")]
	[MovedFrom(true, null, null, "RectOffsetToString1__Format")]
	public sealed class RectOffsetToString__Format : BaseAction
	{
		
		[Tooltip("The RectOffset.")]
		[SerializeField]
		private RectOffsetRef _rectOffset;
		
		[Tooltip("A numeric format string.")]
		[SerializeField, CanBeNullOrEmpty]
		private StringVar _format;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectOffset, _format, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.RectOffset.ToString(System.String);
			_result.Value = _rectOffset.Value.ToString(_format.Value);
		}
		
		public override string GetSummary()
		{
			return "{_rectOffset} To String {_format} -> {_result}";
		}
	}
}
