using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicSpatial)]
    [ConvertibleGroup("CheckRect")]
    [ActionDescription("Check if a Rect contains a given point.")]
    public class CheckRectContains : BaseTrueFalseAction
    {
        [Tooltip("The Rect.")]
        public RectVar Rect;

        [Tooltip("Check if the Rect contains this point.")]
        public Vector2Var Point;
        
        protected override string TrueSummary => "{Rect} contains {Point}";
        protected override string FalseSummary => "{Rect} does not contain {Point}";
        
        public override bool CanExecute() => CheckParameters(Rect, Point);

        protected override bool Test() => Rect.Value.Contains(Point.Value);
    }
}