
using JetBrains.Annotations;
using UnityEngine;
using System;


namespace HutongGames.PlayMaker.Actions
{
#if UNITY_6000_0_OR_NEWER
	[Obsolete("UsedByComposite has been deprecated. Use Collider2D.compositeOperation instead")]	
#endif	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Sets whether the Collider will be used or not used by a CompositeCollider2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D.html")]
	public sealed class Collider2DGetUsedByComposite : BaseAction
	{
		
		[Tooltip("The Collider2D")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Get Collider2D Used By Composite")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUsedByComposite;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _getUsedByComposite);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_getUsedByComposite.Value = _collider2D.Value.compositeOperation != Collider2D.CompositeOperation.None;
#else
			_getUsedByComposite.Value = _collider2D.Value.usedByComposite;
#endif
		}
		
		public override string GetSummary()
		{
			return "Get {_collider2D} used by composite -> {_getUsedByComposite}";
		}
	}
}


