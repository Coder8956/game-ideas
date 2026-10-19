
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.TextAsset)]
	[ActionDescription("Get the text contents of the file as a string. (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/TextAsset-text.html")]
	public sealed class TextAssetGetText : BaseAction
	{
		
		[Tooltip("The TextAsset")]
		[SerializeField]
		private TextAssetVar _textAsset;
		
		[Tooltip("The text contents of the file as a string. (Read Only)")]
		[SerializeField]
		[WriteOnly]
		private StringRef _getText;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textAsset, _getText);
		}
		
		public override void Execute()
		{
			_getText.Value = _textAsset.Value.text;
		}
		
		public override string GetSummary()
		{
			return "Get {_textAsset} text -> {_getText}";
		}
	}
}
