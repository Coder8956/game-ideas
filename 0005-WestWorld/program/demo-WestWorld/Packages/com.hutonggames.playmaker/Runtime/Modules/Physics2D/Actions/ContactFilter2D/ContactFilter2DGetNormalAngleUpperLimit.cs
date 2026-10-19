/* Not documented
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.ContactFilter2D)]
	[ActionDescription("A constant value (359.9999f)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ContactFilter2D-NormalAngleUpperLimit.html")]
	public sealed class ContactFilter2DGetNormalAngleUpperLimit : BaseAction
	{
		
		[Tooltip("Get ContactFilter2D Normal Angle Upper Limit")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getNormalAngleUpperLimit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getNormalAngleUpperLimit);
		}
		
		public override void Execute()
		{
			_getNormalAngleUpperLimit.Value = ContactFilter2D.NormalAngleUpperLimit;
		}
		
		public override string GetSummary()
		{
			return "Get ContactFilter2D NormalAngleUpperLimit -> {_getNormalAngleUpperLimit} ";
		}
	}
}
*/