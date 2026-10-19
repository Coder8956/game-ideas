
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Shorthand for writing Vector4(0,0,0,0).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4-zero.html")]
	public sealed class Vector4GetZero : BaseAction
	{
		
		[Tooltip("Get Vector4 Zero")]
		[SerializeField]
		[WriteOnly]
		private Vector4Ref _getZero;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getZero);
		}
		
		public override void Execute()
		{
			_getZero.Value = Vector4.zero;
		}
		
		public override string GetSummary()
		{
			return "Get Vector4 zero -> {_getZero} ";
		}
	}
}
