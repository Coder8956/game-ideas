
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Unique ID of the Renderer\'s sorting layer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-sortingLayerID.html")]
	public sealed class RendererGetSortingLayerID : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Sorting Layer ID")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getSortingLayerID;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getSortingLayerID);
		}
		
		public override void Execute()
		{
			_getSortingLayerID.Value = _renderer.Value.sortingLayerID;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} sortingLayerID -> {_getSortingLayerID}";
		}
	}
}
