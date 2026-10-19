
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CompositeCollider2D)]
	[ActionDescription("The number of paths in the Collider.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CompositeCollider2D-pathCount.html")]
	public sealed class CompositeCollider2DGetPathCount : BaseAction
	{
		
		[Tooltip("The CompositeCollider2D")]
		[SerializeField]
		private CompositeCollider2DVar _compositeCollider2D;
		
		[Tooltip("Get CompositeCollider2D Path Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getPathCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_compositeCollider2D, _getPathCount);
		}
		
		public override void Execute()
		{
			_getPathCount.Value = _compositeCollider2D.Value.pathCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_compositeCollider2D} pathCount -> {_getPathCount}";
		}
	}
}
