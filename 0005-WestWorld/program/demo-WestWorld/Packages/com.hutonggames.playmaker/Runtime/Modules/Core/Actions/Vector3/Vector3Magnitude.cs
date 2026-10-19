/* Not documented. Use GetMagnitude instead.
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Get the length of a vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.html")]
	public sealed class Vector3Magnitude : BaseAction
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
			//UnityEngine.Vector3.Magnitude(UnityEngine.Vector3);
			_result.Value = Vector3.Magnitude(_vector.Value);
		}
		
		public override string GetSummary()
		{
			return "Vector3 Magnitude: {_vector} -> {_result}";
		}
	}
}
*/