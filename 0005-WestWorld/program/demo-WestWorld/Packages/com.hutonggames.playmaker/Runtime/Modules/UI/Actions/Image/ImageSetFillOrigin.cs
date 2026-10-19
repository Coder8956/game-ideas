
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Image)]
	[ActionDescription("Controls the origin point of the Fill process. Value means different things with " +
		"each fill method.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Image.html")]
	public sealed class ImageSetFillOrigin : BaseAction
	{
		
		[Tooltip("The Image")]
		[SerializeField]
		private ImageVar _image;
		
		[Tooltip("Set Image Fill Origin")]
		[SerializeField]
		private IntegerVar _setFillOrigin;
		
		public override bool CanExecute()
		{
			return CheckParameters(_image, _setFillOrigin);
		}
		
		public override void Execute()
		{
			_image.Value.fillOrigin = _setFillOrigin.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_image} fill origin to {_setFillOrigin}";
		}
	}
}
