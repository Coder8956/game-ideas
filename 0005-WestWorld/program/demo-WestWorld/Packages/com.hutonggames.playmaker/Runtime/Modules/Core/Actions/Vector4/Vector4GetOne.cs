
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Vector4)]
	[ActionDescription("Shorthand for writing Vector4(1,1,1,1).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Vector4-one.html")]
	public sealed class Vector4GetOne : BaseAction
	{
		
		[Tooltip("Get Vector4 One")]
		[SerializeField]
		[WriteOnly]
		private Vector4Ref _getOne;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getOne);
		}
		
		public override void Execute()
		{
			_getOne.Value = Vector4.one;
		}
		
		public override string GetSummary()
		{
			return "Get Vector4 one -> {_getOne} ";
		}
	}
}
