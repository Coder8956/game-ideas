
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Returns the largest of two or more values. When comparing negative values, values" +
		" closer to zero are considered larger.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Max.html")]
	public sealed class MathfMax__List : BaseAction
	{
		
		[Tooltip("Values.")]
		[SerializeField]
		private FloatListRef _values;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_values, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.Max(System.Single[]);
			_result.Value = Mathf.Max(_values.Values);
		}
		
		public override string GetSummary()
		{
			return "Max {_values} -> {_result}";
		}
	}
}
