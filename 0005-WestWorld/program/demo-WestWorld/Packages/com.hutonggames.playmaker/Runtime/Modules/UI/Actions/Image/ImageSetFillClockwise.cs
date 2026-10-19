
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Image)]
	[ActionDescription("Whether the Image should be filled clockwise (true) or counter-clockwise (false)." +
		"")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Image.html")]
	public sealed class ImageSetFillClockwise : BaseAction
	{
		
		[Tooltip("The Image")]
		[SerializeField]
		private ImageVar _image;
		
		[Tooltip("Set Image Fill Clockwise")]
		[SerializeField]
		private BoolVar _setFillClockwise;
		
		public override bool CanExecute()
		{
			return CheckParameters(_image, _setFillClockwise);
		}
		
		public override void Execute()
		{
			_image.Value.fillClockwise = _setFillClockwise.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_image} fill clockwise to {_setFillClockwise}";
		}
	}
}
