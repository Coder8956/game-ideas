
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Returns a formatted string for this vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4.ToString.html")]
	public sealed class Vector4ToString__Format : BaseAction
	{
		
		[Tooltip("The Vector4.")]
		[SerializeField]
		private Vector4Ref _vector4;
		
		[Tooltip("A numeric format string.")]
		[SerializeField, CanBeNullOrEmpty]
		private StringVar _format;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector4, _format, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector4.ToString(System.String);
			_result.Value = _vector4.Value.ToString(_format.Value);
		}
		
		public override string GetSummary()
		{
			return "{_vector4} To String {_format} -> {_result}";
		}
	}
}
