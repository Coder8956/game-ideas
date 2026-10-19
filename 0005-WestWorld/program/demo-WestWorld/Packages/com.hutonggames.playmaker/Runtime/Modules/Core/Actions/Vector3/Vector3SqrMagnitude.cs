/* Not documented. Use GetSqrMagnitude
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Gets the squared length of a vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.SqrMagnitude.html")]
	public sealed class Vector3SqrMagnitude : BaseAction
	{
		
		[Tooltip("Vector.")]
		[SerializeField]
		private Vector3Var _vector;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector3.SqrMagnitude(UnityEngine.Vector3);
			_result.Value = Vector3.SqrMagnitude(_vector.Value);
		}
		
		public override string GetSummary()
		{
			return " {_vector} Sqr Magnitude: -> {_result}";
		}
	}
}
*/