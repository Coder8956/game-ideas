
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Shorthand for writing Vector4(float.PositiveInfinity, float.PositiveInfinity, flo" +
		"at.PositiveInfinity, float.PositiveInfinity).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4-positiveInfinity.html")]
	public sealed class Vector4GetPositiveInfinity : BaseAction
	{
		
		[Tooltip("Get Vector4 Positive Infinity")]
		[SerializeField]
		[WriteOnly]
		private Vector4Ref _getPositiveInfinity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getPositiveInfinity);
		}
		
		public override void Execute()
		{
			_getPositiveInfinity.Value = Vector4.positiveInfinity;
		}
		
		public override string GetSummary()
		{
			return "Get Vector4 positiveInfinity -> {_getPositiveInfinity} ";
		}
	}
}
