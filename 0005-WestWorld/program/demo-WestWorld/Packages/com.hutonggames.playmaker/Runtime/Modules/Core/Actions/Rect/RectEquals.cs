
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rect)]
	[ActionDescription("Check if a Rect is equal to another Rect.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rect-operator_eq.html")]
	public sealed class RectEquals : BaseAction
	{
		
		[Tooltip("The Rect.")]
		[SerializeField]
		private RectRef _rect;
		
		[Tooltip("Other.")]
		[SerializeField]
		private RectVar _other;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rect, _other, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rect.Equals(UnityEngine.Rect);
			_result.Value = _rect.Value.Equals(_other.Value);
		}
		
		public override string GetSummary()
		{
			return "{_rect} equals {_other} -> {_result}";
		}
	}
}
