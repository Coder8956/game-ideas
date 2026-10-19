/* Not documented

using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Gets K Epsilon from Vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4-kEpsilon.html")]
	public sealed class Vector4GetKEpsilon : BaseAction
	{
		
		[Tooltip("Get Vector4 Epsilon")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getKEpsilon;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getKEpsilon);
		}
		
		public override void Execute()
		{
			_getKEpsilon.Value = Vector4.kEpsilon;
		}
		
		public override string GetSummary()
		{
			return "Get Vector4 kEpsilon -> {_getKEpsilon} ";
		}
	}
}
*/