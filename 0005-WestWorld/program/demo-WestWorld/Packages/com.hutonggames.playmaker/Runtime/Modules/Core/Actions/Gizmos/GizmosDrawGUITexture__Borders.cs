
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("Draw a texture in the Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos.DrawGUITexture.html")]
	public sealed class GizmosDrawGUITexture__Borders : BaseAction
	{
		
		[Tooltip("The size and position of the texture on the \"screen\" defined by the XY plane.")]
		[SerializeField]
		private RectVar _screenRect;
		
		[Tooltip("The texture to be displayed.")]
		[SerializeField]
		private TextureVar _texture;
		
		[Tooltip("Inset from the rectangle's left edge.")]
		[SerializeField]
		private IntegerVar _leftBorder;
		
		[Tooltip("Inset from the rectangle's right edge.")]
		[SerializeField]
		private IntegerVar _rightBorder;
		
		[Tooltip("Inset from the rectangle's top edge.")]
		[SerializeField]
		private IntegerVar _topBorder;
		
		[Tooltip("Inset from the rectangle's bottom edge.")]
		[SerializeField]
		private IntegerVar _bottomBorder;
		
		[Tooltip("An optional material to apply the texture.")]
		[SerializeField]
		private MaterialVar _mat;
		
		public override bool CanExecute() => 
			CheckParameters(_screenRect, _texture, _leftBorder, _rightBorder, _topBorder, _bottomBorder, _mat);

#if UNITY_EDITOR	
		
		public override bool HasGizmos => true;
		
		public override void OnDrawGizmosSelected()
		{
			Gizmos.DrawGUITexture(_screenRect.Value, _texture.Value, _leftBorder.Value, _rightBorder.Value, _topBorder.Value, _bottomBorder.Value, _mat.Value);
		}
#endif
		
		public override string GetSummary()
		{
			return "Draw GUI Texture:{_texture} Rect: {_screenRect} Borders: {_leftBorder} {_rightBorder} {_topBorder} {_bottomBorder} " +
			       (_mat.Value != null ? "Material: {_mat}" : "");
		}
	}
}
