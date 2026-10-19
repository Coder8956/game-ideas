/* not documented
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Gets K Epsilon from Vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-kEpsilon.html")]
	public sealed class Vector2GetKEpsilon : BaseAction
	{
		
		[Tooltip("Get Vector2 Epsilon")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getKEpsilon;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getKEpsilon);
		}
		
		public override void Execute()
		{
			_getKEpsilon.Value = Vector2.kEpsilon;
		}
		
		public override string GetSummary()
		{
			return "Get Vector2 kEpsilon -> {_getKEpsilon} ";
		}
	}
}
*/