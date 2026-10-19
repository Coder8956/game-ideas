
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Quaternion)]
	[ActionDescription("Returns a formatted string for this quaternion.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion.ToString.html")]
	public sealed class QuaternionToString__Format : BaseAction
	{
		
		[Tooltip("The Quaternion.")]
		[SerializeField]
		private QuaternionRef _quaternion;
		
		[Tooltip("A numeric format string.")]
		[SerializeField, CanBeNullOrEmpty]
		private StringVar _format;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_quaternion, _format, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Quaternion.ToString(System.String);
			_result.Value = _quaternion.Value.ToString(_format.Value);
		}
		
		public override string GetSummary()
		{
			return "{_quaternion} To String {_format} -> {_result}";
		}
	}
}
