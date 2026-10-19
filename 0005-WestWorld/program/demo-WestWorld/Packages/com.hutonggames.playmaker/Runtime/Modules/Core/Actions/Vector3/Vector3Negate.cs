
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Negates a vector.\n\nEach component in the result is negated.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-operator_subtract.html")]
	public sealed class Vector3Negate : BaseAction
	{
		
		[Tooltip("The Vector3.")]
		[SerializeField]
		private Vector3Ref _vector3;
		
		public override bool CanExecute() => CheckParameters(_vector3);

		public override void Execute() => _vector3.Value = -_vector3.Value;

		public override string GetSummary() => "Negate {_vector3} ";
	}
}
