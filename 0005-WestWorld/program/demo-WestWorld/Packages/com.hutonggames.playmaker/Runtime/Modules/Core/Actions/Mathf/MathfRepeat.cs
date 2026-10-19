
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Range)]
	[ActionDescription("Loops the value t, so that it is never larger than length and never smaller than " +
		"0.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.Repeat.html")]
	public sealed class MathfRepeat : BaseAction
	{
		
		[Tooltip("T.")]
		[SerializeField]
		private FloatVar _t;
		
		[Tooltip("Length.")]
		[SerializeField]
		private FloatVar _length;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_t, _length, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Mathf.Repeat(System.Single, System.Single);
			_result.Value = Mathf.Repeat(_t.Value, _length.Value);
		}
		
		public override string GetSummary()
		{
			return "Repeat {_t} {_length} -> {_result}";
		}
	}
}
