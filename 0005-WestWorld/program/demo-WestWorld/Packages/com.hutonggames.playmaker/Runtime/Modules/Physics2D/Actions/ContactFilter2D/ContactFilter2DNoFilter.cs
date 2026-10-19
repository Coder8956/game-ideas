
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("Sets the contact filter to not filter any ContactPoint2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D-noFilter.html")]
	public sealed class ContactFilter2DNoFilter : BaseAction
	{
		
		[Tooltip("The ContactFilter2D.")]
		[SerializeField]
		private ContactFilter2DRef _contactFilter2D;
		
		[Tooltip("Store the result in ContactFilter2D variable.")]
		[SerializeField]
		[WriteOnly]
		private ContactFilter2DRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_contactFilter2D, _result);
		}
		
		public override void Execute()
		{
#if UNITY_6000_2_OR_NEWER
            // Unity 6.2+: new static property
            _result.Value = ContactFilter2D.noFilter;
#else
			// Unity 2022.3�6.1: only the old instance method exists
#pragma warning disable CS0618
			_result.Value = _contactFilter2D.Value.NoFilter();
#pragma warning restore CS0618
#endif
		}
		
		public override string GetSummary()
		{
			return "No Filter {_contactFilter2D} -> {_result}";
		}
	}
}

