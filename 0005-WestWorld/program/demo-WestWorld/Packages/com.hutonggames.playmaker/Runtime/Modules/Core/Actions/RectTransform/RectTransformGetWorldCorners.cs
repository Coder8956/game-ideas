
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("Get the corners of the calculated rectangle in world space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform.GetWorldCorners.html")]
	public sealed class RectTransformGetWorldCorners : BaseAction
	{
		
		[Tooltip("The RectTransform.")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("The array that corners are filled into.")]
		[SerializeField]
		private Vector3ListVar _fourCornersArray;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _fourCornersArray);
		}
		
		public override void Execute()
		{
			//UnityEngine.RectTransform.GetWorldCorners(UnityEngine.Vector3[]);
			_rectTransform.Value.GetWorldCorners(_fourCornersArray.Values);
		}
		
		public override string GetSummary()
		{
			return "Get {_rectTransform} world corners -> {_fourCornersArray}";
		}
	}
}
