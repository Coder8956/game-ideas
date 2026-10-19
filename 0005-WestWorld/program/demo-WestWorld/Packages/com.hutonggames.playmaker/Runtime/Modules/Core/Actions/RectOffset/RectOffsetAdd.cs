
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectOffset)]
	[ActionDescription("Add the border offsets to a rect.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectOffset.Add.html")]
	public sealed class RectOffsetAdd : BaseAction
	{
		
		[Tooltip("The RectOffset.")]
		[SerializeField]
		private RectOffsetRef _rectOffset;
		
		[Tooltip("Rect.")]
		[SerializeField]
		private RectVar _rect;
		
		[Tooltip("Store the result in Rect variable.")]
		[SerializeField]
		[WriteOnly]
		private RectRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectOffset, _rect, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.RectOffset.Add(UnityEngine.Rect);
			_result.Value = _rectOffset.Value.Add(_rect.Value);
		}
		
		public override string GetSummary()
		{
			return "Add {_rectOffset} {_rect} -> {_result}";
		}
	}
}
