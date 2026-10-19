
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TMP_Text)]
	[ActionDescription("Determines the sorting order of the geometry of the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Text.html")]
	public sealed class TMP_TextSetGeometrySortingOrder : BaseAction
	{
		
		[Tooltip("The TextMeshPro - Text component")]
		[SerializeField]
		private TMP_TextVar _tMP_Text;
		
		[Tooltip("Set TMP_Text Geometry Sorting Order")]
		[SerializeField]
		private VertexSortingOrderVar _setGeometrySortingOrder;
		
		public override bool CanExecute()
		{
			return CheckParameters(_tMP_Text, _setGeometrySortingOrder);
		}
		
		public override void Execute()
		{
			_tMP_Text.Value.geometrySortingOrder = _setGeometrySortingOrder.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_tMP_Text} geometry sorting order to {_setGeometrySortingOrder}";
		}
	}
}
