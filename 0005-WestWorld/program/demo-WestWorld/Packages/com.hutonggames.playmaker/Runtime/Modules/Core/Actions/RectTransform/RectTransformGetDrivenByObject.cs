
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("The object that is driving the values of this RectTransform. Value is null if not" +
		" driven.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform-drivenByObject.html")]
	public sealed class RectTransformGetDrivenByObject : BaseAction
	{
		
		[Tooltip("The RectTransform")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("Get RectTransform Driven By Object")]
		[SerializeField]
		[WriteOnly]
		private ObjectRef _getDrivenByObject;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _getDrivenByObject);
		}
		
		public override void Execute()
		{
			_getDrivenByObject.Value = _rectTransform.Value.drivenByObject;
		}
		
		public override string GetSummary()
		{
			return "Get {_rectTransform} driven by object -> {_getDrivenByObject}";
		}
	}
}
