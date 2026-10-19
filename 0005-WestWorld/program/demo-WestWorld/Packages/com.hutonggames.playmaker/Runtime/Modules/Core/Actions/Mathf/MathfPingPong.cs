
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Range)]
	[ActionDescription("PingPong returns a value that increments and decrements between zero and the length. " +
	                   "It follows the triangle wave formula where the bottom is set to zero and the peak is set to length.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Mathf.PingPong.html")]
	public sealed class MathfPingPong : BaseAction
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
		
		public override bool CanExecute() => CheckParameters(_t, _length, _result);

		public override void Execute() => _result.Value = Mathf.PingPong(_t.Value, _length.Value);

	public override string GetSummary() => "Ping pong {_t} {_length} -> {_result}";
	}
}
