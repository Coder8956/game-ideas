
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("The secondary uv texture coordinate at the impact point.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-textureCoord2.html")]
	public sealed class RaycastHitGetTextureCoord2 : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Get RaycastHit Texture Coord 2")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getTextureCoord2;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _getTextureCoord2);
		}
		
		public override void Execute()
		{
			_getTextureCoord2.Value = _raycastHit.Value.textureCoord2;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit} Texture Coord2 -> {_getTextureCoord2}";
		}
	}
}
