
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Name of the Renderer\'s sorting layer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-sortingLayerName.html")]
	public sealed class RendererGetSortingLayerName : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Sorting Layer Name")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getSortingLayerName;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getSortingLayerName);
		}
		
		public override void Execute()
		{
			_getSortingLayerName.Value = _renderer.Value.sortingLayerName;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} sortingLayerName -> {_getSortingLayerName}";
		}
	}
}
