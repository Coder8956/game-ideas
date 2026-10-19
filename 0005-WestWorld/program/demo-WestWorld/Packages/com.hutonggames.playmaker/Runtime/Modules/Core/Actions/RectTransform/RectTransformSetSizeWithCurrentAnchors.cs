
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("Makes the RectTransform calculated rect be a given size on the specified axis.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform.SetSizeWithCurrentAnchors." +
		"html")]
	public sealed class RectTransformSetSizeWithCurrentAnchors : BaseAction
	{
		
		[Tooltip("The RectTransform.")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("The axis to specify the size along.")]
		[SerializeField]
		private RectTransform.Axis _axis;
		
		[Tooltip("The desired size along the specified axis.")]
		[SerializeField]
		private FloatVar _size;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _axis, _size);
		}
		
		public override void Execute()
		{
			//UnityEngine.RectTransform.SetSizeWithCurrentAnchors(UnityEngine.RectTransform+Axis, System.Single);
			_rectTransform.Value.SetSizeWithCurrentAnchors(_axis, _size.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_rectTransform} {_axis} size to {_size}";
		}
	}
}
