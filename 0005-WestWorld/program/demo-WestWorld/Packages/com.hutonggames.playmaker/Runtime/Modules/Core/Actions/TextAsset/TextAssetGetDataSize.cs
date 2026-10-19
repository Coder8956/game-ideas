
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.TextAsset)]
	[ActionDescription("Get the size of the text asset data in bytes. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/TextAsset-dataSize.html")]
	public sealed class TextAssetGetDataSize : BaseAction
	{
		
		[Tooltip("The TextAsset")]
		[SerializeField]
		private TextAssetVar _textAsset;
		
		[Tooltip("The size of the text asset data in bytes. (Read Only)")]
		[SerializeField]
		[WriteOnly]
		private LongRef _getDataSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textAsset, _getDataSize);
		}
		
		public override void Execute()
		{
			_getDataSize.Value = _textAsset.Value.dataSize;
		}
		
		public override string GetSummary()
		{
			return "Get {_textAsset} data size -> {_getDataSize}";
		}
	}
}
