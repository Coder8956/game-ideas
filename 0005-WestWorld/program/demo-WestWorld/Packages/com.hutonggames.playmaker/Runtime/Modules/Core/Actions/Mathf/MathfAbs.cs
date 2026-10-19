
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Get the absolute value of a float.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Abs.html")]
	public sealed class MathfAbs : BaseAction
	{
		
		[FormerlySerializedAs("_f")]
		[Tooltip("The Float value.")]
		[SerializeField]
		private FloatVar _value;
		
		[Tooltip("Store the result in a Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_value, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.Abs(System.Single);
			_result.Value = Mathf.Abs(_value.Value);
		}
		
		public override string GetSummary()
		{
			return "Abs {_value} -> {_result}";
		}
	}
}
