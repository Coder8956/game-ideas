
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Unique ID of the Renderer\'s sorting layer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-sortingLayerID.html")]
	public sealed class RendererSetSortingLayerID : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Sorting Layer ID")]
		[SerializeField]
		private IntegerVar _setSortingLayerID;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setSortingLayerID);
		}
		
		public override void Execute()
		{
			_renderer.Value.sortingLayerID = _setSortingLayerID.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Sorting Layer ID to {_setSortingLayerID}";
		}
	}
}
