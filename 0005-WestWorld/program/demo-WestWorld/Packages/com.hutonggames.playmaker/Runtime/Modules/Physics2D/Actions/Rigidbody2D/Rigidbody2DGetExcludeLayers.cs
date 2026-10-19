
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The additional Layers that all Collider2D attached to this Rigidbody2D should exc" +
		"lude when deciding if a contact with another Collider2D should happen or not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-excludeLayers.html")]
	public sealed class Rigidbody2DGetExcludeLayers : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Exclude Layers")]
		[SerializeField]
		[WriteOnly]
		private LayerMaskRef _getExcludeLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getExcludeLayers);
		}
		
		public override void Execute()
		{
			_getExcludeLayers.Value = _rigidbody2D.Value.excludeLayers;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} exclude layers -> {_getExcludeLayers}";
		}
	}
}
