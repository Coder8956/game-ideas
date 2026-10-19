
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Sets the Renderer\'s sorting order within the assigned layer.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProGetSortingOrder : BaseAction
	{
		
		[Tooltip("The TextMeshPro")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Get TextMeshPro Sorting Order")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getSortingOrder;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _getSortingOrder);
		}
		
		public override void Execute()
		{
			_getSortingOrder.Value = _textMeshPro.Value.sortingOrder;
		}
		
		public override string GetSummary()
		{
			return "Get {_textMeshPro} sorting order -> {_getSortingOrder}";
		}
	}
}
