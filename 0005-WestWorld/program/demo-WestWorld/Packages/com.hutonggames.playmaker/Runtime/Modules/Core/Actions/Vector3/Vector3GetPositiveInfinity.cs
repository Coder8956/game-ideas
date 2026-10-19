/* use constant
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.Vector3)]
	[ActionDescription("Shorthand for writing Vector3(float.PositiveInfinity, float.PositiveInfinity, flo" +
		"at.PositiveInfinity).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector3-positiveInfinity.html")]
	public sealed class Vector3GetPositiveInfinity : BaseAction
	{
		
		[Tooltip("Get Vector3 Positive Infinity")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getPositiveInfinity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getPositiveInfinity);
		}
		
		public override void Execute()
		{
			_getPositiveInfinity.Value = Vector3.positiveInfinity;
		}
		
		public override string GetSummary()
		{
			return "Get Vector3 positiveInfinity -> {_getPositiveInfinity} ";
		}
	}
}
*/