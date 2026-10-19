
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Float)]
	[ActionDescription("Returns the smallest of two or more values.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Min.html")]
	public sealed class MathfMin__List : BaseAction
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
			//UnityEngine.Mathf.Min(System.Single[]);
			_result.Value = Mathf.Min(_values.Values);
		}
		
		public override string GetSummary()
		{
			return "Min {_values} -> {_result}";
		}
	}
}
