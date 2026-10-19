
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Renderer\'s order within a sorting layer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-sortingOrder.html")]
	public sealed class RendererSetSortingOrder : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Sorting Order")]
		[SerializeField]
		private IntegerVar _setSortingOrder;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setSortingOrder);
		}
		
		public override void Execute()
		{
			_renderer.Value.sortingOrder = _setSortingOrder.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Sorting Order to {_setSortingOrder}";
		}
	}
}
