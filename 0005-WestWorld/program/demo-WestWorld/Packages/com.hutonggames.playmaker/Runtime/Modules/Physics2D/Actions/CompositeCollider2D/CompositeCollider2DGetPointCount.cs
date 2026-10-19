
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CompositeCollider2D)]
	[ActionDescription("Gets the total number of points in all the paths within the Collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CompositeCollider2D-pointCount.html")]
	public sealed class CompositeCollider2DGetPointCount : BaseAction
	{
		
		[Tooltip("The CompositeCollider2D")]
		[SerializeField]
		private CompositeCollider2DVar _compositeCollider2D;
		
		[Tooltip("Get CompositeCollider2D Point Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getPointCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_compositeCollider2D, _getPointCount);
		}
		
		public override void Execute()
		{
			_getPointCount.Value = _compositeCollider2D.Value.pointCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_compositeCollider2D} pointCount -> {_getPointCount}";
		}
	}
}
