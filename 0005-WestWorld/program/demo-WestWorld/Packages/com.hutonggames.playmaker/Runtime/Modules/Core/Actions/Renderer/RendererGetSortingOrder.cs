
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Renderer\'s order within a sorting layer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-sortingOrder.html")]
	public sealed class RendererGetSortingOrder : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Sorting Order")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getSortingOrder;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getSortingOrder);
		}
		
		public override void Execute()
		{
			_getSortingOrder.Value = _renderer.Value.sortingOrder;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} sortingOrder -> {_getSortingOrder}";
		}
	}
}
