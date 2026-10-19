
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.TextAsset)]
	[ActionDescription("Get the raw bytes of the text asset. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/TextAsset-bytes.html")]
	public sealed class TextAssetGetBytes : BaseAction
	{
		
		[Tooltip("The TextAsset")]
		[SerializeField]
		private TextAssetVar _textAsset;
		
		[Tooltip("The raw bytes of the text asset. (Read Only)")]
		[SerializeField]
		[WriteOnly]
		private ByteListRef _getBytes;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textAsset, _getBytes);
		}
		
		public override void Execute()
		{
			_getBytes.Values = _textAsset.Value.bytes;
		}
		
		public override string GetSummary()
		{
			return "Get {_textAsset} bytes -> {_getBytes}";
		}
	}
}
