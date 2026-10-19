
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Name of the Renderer\'s sorting layer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-sortingLayerName.html")]
	public sealed class RendererSetSortingLayerName : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Sorting Layer Name")]
		[SerializeField]
		private StringVar _setSortingLayerName;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setSortingLayerName);
		}
		
		public override void Execute()
		{
			_renderer.Value.sortingLayerName = _setSortingLayerName.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Sorting Layer Name to {_setSortingLayerName}";
		}
	}
}
