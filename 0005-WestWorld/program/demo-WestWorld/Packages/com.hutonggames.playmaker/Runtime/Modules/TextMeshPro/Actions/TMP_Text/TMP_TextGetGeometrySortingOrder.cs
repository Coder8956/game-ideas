
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Determines the sorting order of the geometry of the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextGetGeometrySortingOrder : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Get TMP_Text Geometry Sorting Order")]
		[SerializeField]
		[WriteOnly]
		private VertexSortingOrderRef _getGeometrySortingOrder;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _getGeometrySortingOrder);
		}
		
		public override void Execute()
		{
			_getGeometrySortingOrder.Value = _tMP_Text.Value.geometrySortingOrder;
		}
		
		public override string GetSummary()
		{
			return "Get {_tMP_Text} geometry sorting order -> {_getGeometrySortingOrder}";
		}
	}
}
