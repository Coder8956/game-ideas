/* not documented
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Gets K Epsilon from Vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-kEpsilon.html")]
	public sealed class Vector3GetKEpsilon : BaseAction
	{
		
		[Tooltip("Get Vector3 Epsilon")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getKEpsilon;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getKEpsilon);
		}
		
		public override void Execute()
		{
			_getKEpsilon.Value = Vector3.kEpsilon;
		}
		
		public override string GetSummary()
		{
			return "Get Vector3 kEpsilon -> {_getKEpsilon} ";
		}
	}
}
*/