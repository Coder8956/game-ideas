
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets the contact filter to filter the results that only include Collider2D on the" +
		" layers defined by the layer mask.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D-layerMask.html")]
	public sealed class ContactFilter2DGetLayerMask : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Get ContactFilter2D Layer Mask")]
		[SerializeField]
		[WriteOnly]
		private LayerMaskRef _getLayerMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _getLayerMask);
		}
		
		public override void Execute()
		{
			_getLayerMask.Value = _contactFilter2D.Value.layerMask;
		}
		
		public override string GetSummary()
		{
			return "Get {_contactFilter2D} layerMask -> {_getLayerMask}";
		}
	}
}
