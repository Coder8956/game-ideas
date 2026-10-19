
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("Draw a texture in the Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos.DrawGUITexture.html")]
	public sealed class GizmosDrawGUITexture : BaseAction
	{
		
		[Tooltip("The size and position of the texture on the \"screen\" defined by the XY plane.")]
		[SerializeField]
		private RectVar _screenRect;
		
		[Tooltip("The texture to be displayed.")]
		[SerializeField]
		private TextureVar _texture;
		
		[Tooltip("An optional material to apply the texture.")]
		[SerializeField]
		private MaterialVar _mat;
		
		public override bool CanExecute() => CheckParameters(_screenRect, _texture, _mat);

#if UNITY_EDITOR	

		public override bool HasGizmos => true;
		
		public override void OnDrawGizmosSelected() => 
			Gizmos.DrawGUITexture(_screenRect.Value, _texture.Value, _mat.Value);
#endif
		
		public override string GetSummary() =>
			"Draw GUI Texture: {_texture} Rect: {_screenRect} " +
			(_mat.Value ? "Material: {_mat}" : "");
	}
}
