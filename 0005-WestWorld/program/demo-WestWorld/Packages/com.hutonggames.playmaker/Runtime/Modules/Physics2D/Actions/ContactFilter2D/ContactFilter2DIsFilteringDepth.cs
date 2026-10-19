
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Checks if the Transform for obj is within the depth range to be filtered.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D.IsFilteringDepth.html")]
	public sealed class ContactFilter2DIsFilteringDepth : BaseAction
	{
		
		[Tooltip("The ContactFilter2D.")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("The GameObject used to check the z-position (depth) of Transform.position.")]
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
			//UnityEngine.ContactFilter2D.IsFilteringDepth(UnityEngine.GameObject);
			_result.Value = _contactFilter2D.Value.IsFilteringDepth(_obj.Value);
		}
		
		public override string GetSummary()
		{
			return "Is Filtering Depth {_contactFilter2D} {_obj} -> {_result}";
		}
	}
}
