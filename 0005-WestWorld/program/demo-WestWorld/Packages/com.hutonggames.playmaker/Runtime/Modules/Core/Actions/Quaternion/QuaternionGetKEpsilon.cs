/* Not documented
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Gets K Epsilon from Quaternion.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion-kEpsilon.html")]
	public sealed class QuaternionGetKEpsilon : BaseAction
	{
		
		[Tooltip("Get Quaternion Epsilon")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getKEpsilon;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getKEpsilon);
		}
		
		public override void Execute()
		{
			_getKEpsilon.Value = Quaternion.kEpsilon;
		}
		
		public override string GetSummary()
		{
			return "Get Quaternion kEpsilon -> {_getKEpsilon} ";
		}
	}
}
*/