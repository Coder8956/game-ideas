/* Use PhysicsAllLayersValue instead
 
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.PhysicsInternal)]
	[ActionDescription("Layer mask constant to select all layers.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Physics.AllLayers.html")]
	public sealed class PhysicsGetAllLayers : BaseAction
	{
		
		[Tooltip("Get Physics All Layers")]
		[SerializeField]
		[WriteOnly]
		private LayerMaskRef _getAllLayers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getAllLayers);
		}
		
		public override void Execute()
		{
			_getAllLayers.Value = Physics.AllLayers;
		}
		
		public override string GetSummary()
		{
			return "Get Physics AllLayers -> {_getAllLayers} ";
		}
	}
}
*/
