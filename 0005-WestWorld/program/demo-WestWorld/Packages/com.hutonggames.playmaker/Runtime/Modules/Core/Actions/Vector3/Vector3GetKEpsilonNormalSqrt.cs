/* not documented
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Gets K Epsilon Normal Sqrt from Vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-kEpsilonNormalSqrt.html")]
	public sealed class Vector3GetKEpsilonNormalSqrt : BaseAction
	{
		
		[Tooltip("Get Vector3 Epsilon Normal Sqrt")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getKEpsilonNormalSqrt;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getKEpsilonNormalSqrt);
		}
		
		public override void Execute()
		{
			_getKEpsilonNormalSqrt.Value = Vector3.kEpsilonNormalSqrt;
		}
		
		public override string GetSummary()
		{
			return "Get Vector3 kEpsilonNormalSqrt -> {_getKEpsilonNormalSqrt} ";
		}
	}
}
*/