/* Not documented
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Performs Vector 4 Sqr Magnitude.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4.SqrMagnitude.html")]
	public sealed class Vector4SqrMagnitude : BaseAction
	{
		
		[Tooltip("A.")]
		[SerializeField]
		private Vector4Var _a;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_a, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector4.SqrMagnitude(UnityEngine.Vector4);
			_result.Value = Vector4.SqrMagnitude(_a.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector4 Sqr Magnitude: {_a} -> {_result}";
		}
	}
}
*/