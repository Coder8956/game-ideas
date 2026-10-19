
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RectTransform)]
	[ActionDescription("Set the distance of this rectangle relative to a specified edge of the parent rec" +
		"tangle, while also setting its size.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RectTransform.SetInsetAndSizeFromParentE" +
		"dge.html")]
	public sealed class RectTransformSetInsetAndSizeFromParentEdge : BaseAction
	{
		
		[Tooltip("The RectTransform.")]
		[SerializeField]
		private RectTransformVar _rectTransform;
		
		[Tooltip("The edge of the parent rectangle to inset from.")]
		[SerializeField]
		private RectTransform.Edge _edge;
		
		[Tooltip("The inset distance.")]
		[SerializeField]
		private FloatVar _inset;
		
		[Tooltip("The size of the rectangle along the same direction of the inset.")]
		[SerializeField]
		private FloatVar _size;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rectTransform, _inset, _size);
		}
		
		public override void Execute()
		{
			//UnityEngine.RectTransform.SetInsetAndSizeFromParentEdge(UnityEngine.RectTransform+Edge, System.Single, System.Single);
			_rectTransform.Value.SetInsetAndSizeFromParentEdge(_edge, _inset.Value, _size.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_rectTransform} inset from parent {_edge} edge to {_inset} and size to {_size}";
		}
	}
}
