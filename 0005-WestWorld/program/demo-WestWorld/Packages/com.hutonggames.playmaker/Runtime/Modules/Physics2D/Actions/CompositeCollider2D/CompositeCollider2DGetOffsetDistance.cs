
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CompositeCollider2D)]
	[ActionDescription("Vertices are offset by this distance when compositing multiple physic shapes. Any" +
		" vertices between shapes within this distance are combined.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CompositeCollider2D-offsetDistance.html")]
	public sealed class CompositeCollider2DGetOffsetDistance : BaseAction
	{
		
		[Tooltip("The CompositeCollider2D")]
		[SerializeField]
		private CompositeCollider2DVar _compositeCollider2D;
		
		[Tooltip("Get CompositeCollider2D Offset Distance")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getOffsetDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_compositeCollider2D, _getOffsetDistance);
		}
		
		public override void Execute()
		{
			_getOffsetDistance.Value = _compositeCollider2D.Value.offsetDistance;
		}
		
		public override string GetSummary()
		{
			return "Get {_compositeCollider2D} offsetDistance -> {_getOffsetDistance}";
		}
	}
}
