
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit)]
	[ActionDescription("The uv texture coordinate at the collision location.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit-textureCoord.html")]
	public sealed class RaycastHitGetTextureCoord : BaseAction
	{
		
		[Tooltip("The RaycastHit")]
		[SerializeField]
		private RaycastHitRef _raycastHit;
		
		[Tooltip("Get RaycastHit Texture Coord")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getTextureCoord;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit, _getTextureCoord);
		}
		
		public override void Execute()
		{
			_getTextureCoord.Value = _raycastHit.Value.textureCoord;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit} Texture Coord -> {_getTextureCoord}";
		}
	}
}
