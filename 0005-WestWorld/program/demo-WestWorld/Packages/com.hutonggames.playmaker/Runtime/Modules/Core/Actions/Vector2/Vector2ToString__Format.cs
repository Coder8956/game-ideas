
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector2)]
	[ActionDescription("Returns a formatted string for this vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector2.ToString.html")]
	public sealed class Vector2ToString__Format : BaseAction
	{
		
		[Tooltip("The Vector2.")]
		[SerializeField]
		private Vector2Ref _vector2;
		
		[Tooltip("A numeric format string.")]
		[SerializeField, CanBeNullOrEmpty]
		private StringVar _format;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector2, _format, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector2.ToString(System.String);
			_result.Value = _vector2.Value.ToString(_format.Value);
		}
		
		public override string GetSummary()
		{
			return "{_vector2} To String {_format} -> {_result}";
		}
	}
}
