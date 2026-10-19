
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets the layerMask filter property using the layerMask parameter provided and als" +
		"o enables layer mask filtering by setting useLayerMask to true.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D.SetLayerMask.html")]
	public sealed class ContactFilter2DSetLayerMask1 : BaseAction
	{
		
		[Tooltip("The ContactFilter2D.")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("The value used to set the layerMask.")]
		[SerializeField]
		private LayerMaskVar _layerMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _layerMask);
		}
		
		public override void Execute()
		{
			//UnityEngine.ContactFilter2D.SetLayerMask(UnityEngine.LayerMask);
			_contactFilter2D.Value.SetLayerMask(_layerMask.Value);
		}
		
		public override string GetSummary()
		{
			return "Set Layer Mask {_contactFilter2D} {_layerMask} ";
		}
	}
}
