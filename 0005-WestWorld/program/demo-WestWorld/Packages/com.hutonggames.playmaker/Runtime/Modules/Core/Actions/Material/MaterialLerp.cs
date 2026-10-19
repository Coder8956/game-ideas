
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Material)]
	[ActionDescription("Interpolate properties between two materials.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Material.Lerp.html")]
	public sealed class MaterialLerp : BaseAction
	{
		public override bool CanUsePerSecond => true;
		
		[Tooltip("The Material. Select Owner to use its material.")]
		[SerializeField]
		private MaterialVar _material;
		
		[Tooltip("Start.")]
		[SerializeField]
		private MaterialVar _start;
		
		[Tooltip("End.")]
		[SerializeField]
		private MaterialVar _end;
		
		[Tooltip("Value used to interpolate between Start and End. " + Strings.LerpPerSecondNode)]
		[SerializeField]
		private FloatVar _t;
		
		public override bool CanExecute() => CheckParameters(_material, _start, _end, _t);

		public override void Execute()
		{
			_material.Value.Lerp(_start.Value, _end.Value, _t.Value * PerSecond);
		}
		
		public override string GetSummary() => "Lerp {_material} from {_start} to {_end} at {_t} {PerSecond}";
	}
}
