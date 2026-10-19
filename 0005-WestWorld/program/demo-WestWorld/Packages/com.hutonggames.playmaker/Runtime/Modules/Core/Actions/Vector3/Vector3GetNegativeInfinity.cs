/* use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Shorthand for writing Vector3(float.NegativeInfinity, float.NegativeInfinity, flo" +
		"at.NegativeInfinity).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-negativeInfinity.html")]
	public sealed class Vector3GetNegativeInfinity : BaseAction
	{
		
		[Tooltip("Get Vector3 Negative Infinity")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getNegativeInfinity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getNegativeInfinity);
		}
		
		public override void Execute()
		{
			_getNegativeInfinity.Value = Vector3.negativeInfinity;
		}
		
		public override string GetSummary()
		{
			return "Get Vector3 negativeInfinity -> {_getNegativeInfinity} ";
		}
	}
}
*/