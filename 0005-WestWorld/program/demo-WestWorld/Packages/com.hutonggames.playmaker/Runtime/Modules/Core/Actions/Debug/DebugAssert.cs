/* Use Assert actions instead
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Debug)]
	[ActionDescription("Assert a condition and logs an error message to the Unity console on failure.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Debug.Assert.html")]
	public sealed class DebugAssert : BaseAction
	{
		
		[Tooltip("Condition you expect to be true.")]
		[SerializeField]
		private BoolRef _condition;
		
		[OptionalField]
		[Tooltip("String or object to be converted to string representation for display.")]
		[SerializeField]
		private StringVar _message;
		
		[OptionalField]
		[Tooltip("Object to which the message applies.")]
		[SerializeField]
		private ObjectVar _context;
		
		public override bool CanExecute()
		{
			return CheckParameters(_condition, _message, _context);
		}
		
		public override void Execute()
		{
			//UnityEngine.Debug.Assert(System.Boolean, System.String, UnityEngine.Object);
			Debug.Assert(_condition.Value, _message.Value, _context.Value);
		}
		
		public override string GetSummary()
		{
			return "Debug Assert: {_condition} {_message} {_context} ";
		}
	}
}
*/
