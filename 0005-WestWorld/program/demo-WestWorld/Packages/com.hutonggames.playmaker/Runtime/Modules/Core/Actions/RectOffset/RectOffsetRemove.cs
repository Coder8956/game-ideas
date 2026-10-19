
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectOffset)]
	[ActionDescription("Remove the border offsets from a rect.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectOffset.Remove.html")]
	public sealed class RectOffsetRemove : BaseAction
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
			//UnityEngine.RectOffset.Remove(UnityEngine.Rect);
			_result.Value = _rectOffset.Value.Remove(_rect.Value);
		}
		
		public override string GetSummary()
		{
			return "Remove {_rectOffset} {_rect} -> {_result}";
		}
	}
}
