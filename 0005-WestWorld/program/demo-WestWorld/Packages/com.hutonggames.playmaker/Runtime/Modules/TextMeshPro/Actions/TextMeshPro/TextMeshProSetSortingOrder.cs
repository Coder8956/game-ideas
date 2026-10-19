
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Sets the Renderer\'s sorting order within the assigned layer.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProSetSortingOrder : BaseAction
	{
		
		[Tooltip("The TextMeshPro")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Set TextMeshPro Sorting Order")]
		[SerializeField]
		private IntegerVar _setSortingOrder;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _setSortingOrder);
		}
		
		public override void Execute()
		{
			_textMeshPro.Value.sortingOrder = _setSortingOrder.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_textMeshPro} sorting order to {_setSortingOrder}";
		}
	}
}
