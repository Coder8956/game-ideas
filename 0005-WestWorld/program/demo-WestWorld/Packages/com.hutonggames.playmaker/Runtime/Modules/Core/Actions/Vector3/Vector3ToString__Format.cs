
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Returns a formatted string for this vector.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.ToString.html")]
	public sealed class Vector3ToString__Format : BaseAction
	{
		
		[Tooltip("The Vector3.")]
		[SerializeField]
		private Vector3Ref _vector3;
		
		[Tooltip("A numeric format string.")]
		[SerializeField, CanBeNullOrEmpty]
		private StringVar _format;
		
		[Tooltip("Store the result in String variable.")]
		[SerializeField]
		[WriteOnly]
		private StringRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_vector3, _format, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Vector3.ToString(System.String);
			_result.Value = _vector3.Value.ToString(_format.Value);
		}
		
		public override string GetSummary()
		{
			return "{_vector3} To String {_format} -> {_result}";
		}
	}
}
