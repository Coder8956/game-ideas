
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The additional Layers that all Collider2D attached to this Rigidbody2D should inc" +
		"lude when deciding if a contact with another Collider2D should happen or not.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-includeLayers.html")]
	public sealed class Rigidbody2DGetIncludeLayers : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Include Layers")]
		[SerializeField]
		[WriteOnly]
		private LayerMaskRef _getIncludeLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getIncludeLayers);
		}
		
		public override void Execute()
		{
			_getIncludeLayers.Value = _rigidbody2D.Value.includeLayers;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} include layers -> {_getIncludeLayers}";
		}
	}
}
