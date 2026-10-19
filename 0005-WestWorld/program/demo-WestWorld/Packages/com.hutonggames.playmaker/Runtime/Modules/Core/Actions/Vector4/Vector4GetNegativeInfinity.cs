
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Shorthand for writing Vector4(float.NegativeInfinity, float.NegativeInfinity, flo" +
		"at.NegativeInfinity, float.NegativeInfinity).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4-negativeInfinity.html")]
	public sealed class Vector4GetNegativeInfinity : BaseAction
	{
		
		[Tooltip("Get Vector4 Negative Infinity")]
		[SerializeField]
		[WriteOnly]
		private Vector4Ref _getNegativeInfinity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getNegativeInfinity);
		}
		
		public override void Execute()
		{
			_getNegativeInfinity.Value = Vector4.negativeInfinity;
		}
		
		public override string GetSummary()
		{
			return "Get Vector4 negativeInfinity -> {_getNegativeInfinity} ";
		}
	}
}
