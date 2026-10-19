
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
	public sealed class ContactFilter2DSetLayerMask : BaseAction
	{
		
		[Tooltip("The ContactFilter2D")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Set ContactFilter2D Layer Mask")]
		[SerializeField]
		private LayerMaskVar _setLayerMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _setLayerMask);
		}
		
		public override void Execute()
		{
			var value = _contactFilter2D.Value;
			value.layerMask = _setLayerMask.Value;
			_contactFilter2D.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_contactFilter2D} Layer Mask to {_setLayerMask}";
		}
	}
}
