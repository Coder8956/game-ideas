
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ModifiableContactPair)]
	[ActionDescription("Get the index of a face a particular contact point belongs to in this contact pai" +
		"r. Use this with Mesh.triangles.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ModifiableContactPair.GetFaceIndex.html")]
	public sealed class ModifiableContactPairGetFaceIndex : BaseAction
	{
		
		[Tooltip("The ModifiableContactPair.")]
		[SerializeField]
		private ModifiableContactPairRef _modifiableContactPair;
		
		[Tooltip("Index of the contact point.")]
		[SerializeField]
		private IntegerVar _i;
		
		[Tooltip("Store the result in Unsigned Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private UIntRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_modifiableContactPair, _i, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.ModifiableContactPair.GetFaceIndex(System.Int32);
			_result.Value = _modifiableContactPair.Value.GetFaceIndex(_i.Value);
		}
		
		public override string GetSummary()
		{
			return "Get Face Index {_modifiableContactPair} {_i} -> {_result}";
		}
	}
}
