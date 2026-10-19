
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Negates a vector.\n\nEach component in the result is negated.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4-operator_subtract.html")]
	public sealed class Vector4Negate : BaseAction
	{
		
		[Tooltip("The Vector4.")]
		[SerializeField]
		private Vector4Ref _Vector4;
		
		public override bool CanExecute() => CheckParameters(_Vector4);

		public override void Execute() => _Vector4.Value = -_Vector4.Value;

		public override string GetSummary() => "Negate {_Vector4} ";
	}
}
