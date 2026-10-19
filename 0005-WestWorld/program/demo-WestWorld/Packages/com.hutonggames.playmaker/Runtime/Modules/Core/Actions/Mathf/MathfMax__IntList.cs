
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Integer)]
	[ActionDescription("Returns the largest value. When comparing negative values, values closer to zero " +
		"are considered larger.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Max.html")]
	public sealed class MathfMax__IntList : BaseAction
	{
		
		[Tooltip("Values.")]
		[SerializeField]
		private IntegerListRef _values;
		
		[Tooltip("Store the result in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_values, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.Max(System.Int32[]);
			_result.Value = Mathf.Max(_values.Values);
		}
		
		public override string GetSummary()
		{
			return "Max {_values} -> {_result}";
		}
	}
}
