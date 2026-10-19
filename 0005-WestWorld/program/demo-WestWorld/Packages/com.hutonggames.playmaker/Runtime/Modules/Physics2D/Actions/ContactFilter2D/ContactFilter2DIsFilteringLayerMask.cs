
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Checks if the GameObject.layer for obj is included in the layerMask to be filtere" +
		"d.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D.IsFilteringLayerMask.htm" +
		"l")]
	public sealed class ContactFilter2DIsFilteringLayerMask : BaseAction
	{
		
		[Tooltip("The ContactFilter2D.")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("The GameObject used to check the GameObject.layer.")]
		[SerializeField]
		private GameObjectVar _obj;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _obj, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.ContactFilter2D.IsFilteringLayerMask(UnityEngine.GameObject);
			_result.Value = _contactFilter2D.Value.IsFilteringLayerMask(_obj.Value);
		}
		
		public override string GetSummary()
		{
			return "Is Filtering Layer Mask {_contactFilter2D} {_obj} -> {_result}";
		}
	}
}
