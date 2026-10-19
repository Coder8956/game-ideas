
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("Returns true if the other rectangle overlaps this one. If allowInverse is present" +
		" and true, the widths and heights of the Rects are allowed to take negative valu" +
		"es (ie, the min value is greater than the max), and the test will still work.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect.Overlaps.html")]
	public sealed class RectOverlaps__AllowInverse : BaseAction
	{
		
		[Tooltip("The Rect.")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Other rectangle to test overlapping with.")]
		[SerializeField]
		private RectVar _other;
		
		[Tooltip("Does the test allow the widths and heights of the Rects to be negative?")]
		[SerializeField]
		private BoolVar _allowInverse;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _other, _allowInverse, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rect.Overlaps(UnityEngine.Rect, System.Boolean);
			_result.Value = _rect.Value.Overlaps(_other.Value, _allowInverse.Value);
		}
		
		public override string GetSummary()
		{
			return "Overlaps {_rect} {_other} {_allowInverse} -> {_result}";
		}
	}
}
