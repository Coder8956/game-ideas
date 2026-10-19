using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Sets a GameObject's Layer.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-layer.html")]
    public class GameObjectSetLayer : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The target GameObject.")]
        public GameObjectVar GameObject;
        
        [LayerValue]
        [Tooltip("Sets the GameObject's Layer.")]
        public IntegerVar SetLayer;
        
        public override bool CanExecute() => CheckParameters(GameObject);
        
        public override void Execute() => GameObject.Value.layer = SetLayer.Value;

        public override string GetSummary() => "Set {GameObject} layer to {SetLayer}";
    }
}
