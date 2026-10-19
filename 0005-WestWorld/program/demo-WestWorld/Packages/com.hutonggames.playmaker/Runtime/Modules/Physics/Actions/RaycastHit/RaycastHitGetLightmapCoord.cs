
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("The uv lightmap coordinate at the impact point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-lightmapCoord.html")]
	public sealed class RaycastHitGetLightmapCoord : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Get RaycastHit Lightmap Coord")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getLightmapCoord;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _getLightmapCoord);
		}
		
		public override void Execute()
		{
			_getLightmapCoord.Value = _raycastHit.Value.lightmapCoord;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit} Lightmap Coord -> {_getLightmapCoord}";
		}
	}
}
