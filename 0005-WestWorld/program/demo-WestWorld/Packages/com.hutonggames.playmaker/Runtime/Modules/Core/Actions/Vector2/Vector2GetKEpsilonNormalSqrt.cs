/* not documented
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Gets K Epsilon Normal Sqrt from Vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2-kEpsilonNormalSqrt.html")]
	public sealed class Vector2GetKEpsilonNormalSqrt : BaseAction
	{
		
		[Tooltip("Get Vector2 Epsilon Normal Sqrt")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getKEpsilonNormalSqrt;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getKEpsilonNormalSqrt);
		}
		
		public override void Execute()
		{
			_getKEpsilonNormalSqrt.Value = Vector2.kEpsilonNormalSqrt;
		}
		
		public override string GetSummary()
		{
			return "Get Vector2 kEpsilonNormalSqrt -> {_getKEpsilonNormalSqrt} ";
		}
	}
}
*/