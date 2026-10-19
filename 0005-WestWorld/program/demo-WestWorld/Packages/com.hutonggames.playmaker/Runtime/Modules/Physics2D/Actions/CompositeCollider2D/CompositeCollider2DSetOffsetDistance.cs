
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
	public sealed class CompositeCollider2DSetOffsetDistance : BaseAction
	{
		
		[Tooltip("The CompositeCollider2D")]
		[SerializeField]
		private CompositeCollider2DVar _compositeCollider2D;
		
		[Tooltip("Set CompositeCollider2D Offset Distance")]
		[SerializeField]
		private FloatVar _setOffsetDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_compositeCollider2D, _setOffsetDistance);
		}
		
		public override void Execute()
		{
			_compositeCollider2D.Value.offsetDistance = _setOffsetDistance.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_compositeCollider2D} Offset Distance to {_setOffsetDistance}";
		}
	}
}
