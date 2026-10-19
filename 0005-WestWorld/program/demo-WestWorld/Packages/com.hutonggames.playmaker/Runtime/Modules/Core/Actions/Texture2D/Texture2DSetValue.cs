
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Texture)]
	[ActionDescription("Set the value of a Texture2D variable.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Texture2D.html")]
	public sealed class Texture2DSetValue : BaseAction
	{
		
		[DefaultName("Texture2D")]
		[Tooltip("The Texture2D variable to set.")]
		[SerializeField]
		[WriteOnly]
		private Texture2DRef _variable;
		
		[Tooltip("Set Texture2D value.")]
		[SerializeField]
		private Texture2DVar _setValue;
		
		public override bool CanExecute() => !_variable.IsNone;
		
		public override void Execute()
		{
			_variable.Value = _setValue.Value;
		}
		
		public override string GetSummary() => "Set {_variable} to {_setValue}";
	}
}
