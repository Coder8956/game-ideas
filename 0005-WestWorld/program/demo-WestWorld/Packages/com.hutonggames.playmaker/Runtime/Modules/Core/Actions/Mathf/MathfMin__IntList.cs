
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Integer)]
	[ActionDescription("Returns the smallest of two or more values.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Min.html")]
	public sealed class MathfMin__IntList : BaseAction
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
			//UnityEngine.Mathf.Min(System.Int32[]);
			_result.Value = Mathf.Min(_values.Values);
		}
		
		public override string GetSummary()
		{
			return "Min {_values} -> {_result}";
		}
	}
}
