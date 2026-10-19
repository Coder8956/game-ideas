
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Cursor)]
	[ActionDescription("Sets a custom cursor to use as your cursor.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Cursor.SetCursor.html")]
	public sealed class CursorSetCursor : BaseAction
	{
		
		[Tooltip("The texture to use for the cursor. To use a texture, import it with `Read/Write` enabled. " +
		         "Alternatively, you can use the default cursor import setting. If you created your cursor texture " +
		         "from code, it must be in RGBA32 format, have alphaIsTransparency enabled," +
		         " and have no mip chain. To use the default cursor, set the texture to `Null`.")]
		[SerializeField, OptionalField]
		private Texture2DVar _texture;
		
		[Tooltip("The offset from the top left of the texture to use as the target point. This must" +
			" be in the bounds of the cursor.")]
		[SerializeField]
		private Vector2Var _hotspot;
		
		[Tooltip("Whether to render this cursor as a hardware cursor on supported platforms, or force software cursor.")]
		[SerializeField]
		private CursorMode _cursorMode;
		
		public override bool CanExecute() => _texture.HasValue(true) && CheckParameters(_hotspot, _cursorMode);

		public override void Execute() => Cursor.SetCursor(_texture.Value, _hotspot.Value, _cursorMode);

		public override string GetSummary() => "Set Cursor {_texture} {_hotspot} Mode {_cursorMode} ";
	}
}
