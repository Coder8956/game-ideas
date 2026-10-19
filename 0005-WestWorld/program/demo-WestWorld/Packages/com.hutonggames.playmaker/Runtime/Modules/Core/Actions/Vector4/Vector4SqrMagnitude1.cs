/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Performs Vector 4 Sqr Magnitude.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4.SqrMagnitude.html")]
	public sealed class Vector4SqrMagnitude1 : BaseAction
	{
		
		[Tooltip("The Vector4.")]
		[SerializeField]
		private Vector4Ref _vector4;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector4, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector4.SqrMagnitude();
			_result.Value = _vector4.Value.SqrMagnitude();
		}
		
		public override string GetSummary()
		{
			return "Sqr Magnitude {_vector4} -> {_result}";
		}
	}
}
*/