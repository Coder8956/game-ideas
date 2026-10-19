using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    // NOTE: Inherits ObjectPredicates
    // So we only need to define GameObject specific predicates
    
    [Serializable, DisplayName("Has Component")]
    public class GameObjectHasComponentPredicate : BasePredicate<GameObject>
    {
        public TypeVar Parameter;
        
        protected override bool DoEvaluate(GameObject go) => go != null && go.HasComponent(Parameter.Value);
        
        public override string ToString() => $"Has Component {Parameter}";
    }

    [Serializable, DisplayName("Has Data")]
    public class GameObjectHasDataPredicate : BasePredicate<GameObject>
    {
        public DataDefinitionVar Parameter;

        protected override bool DoEvaluate(GameObject go)
        {
            var dataDefinition = Parameter.Value;
            return go != null && dataDefinition != null && DataRecordComponent.FindMatching(go, dataDefinition) != null;
        }

        public override string ToString() => $"Has Data {Parameter}";
    }

    [Serializable, DisplayName("Has Template")]
    public class GameObjectHasTemplatePredicate : BasePredicate<GameObject>
    {
        public FsmTemplateVar Parameter;

        protected override bool DoEvaluate(GameObject go)
        {
            var fsmTemplate = Parameter.Value;
            if (go == null || fsmTemplate == null) return false;

            var components = go.GetComponents<FsmTemplateComponent>();
            foreach (var component in components)
            {
                if (component != null && component.FsmTemplate == fsmTemplate)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString() => $"Has Template {Parameter}";
    }
    
    [Serializable, DisplayName("Has Tag")]
    public class GameObjectHasTagPredicate : BasePredicate<GameObject>
    {
        [TagValue]
        public StringVar Parameter;
        
        protected override bool DoEvaluate(GameObject go) => go != null && !string.IsNullOrEmpty(Parameter.Value) && go.CompareTag(Parameter.Value);

        public override string ToString() => $"Has Tag {Parameter}";
    }

    [Serializable, DisplayName("Layer In Mask")]
    public class GameObjectLayerInMaskPredicate : BasePredicate<GameObject>
    {
        [DefaultValue("Physics.AllLayers")]
        public LayerMaskVar Parameter;

        protected override bool DoEvaluate(GameObject go) => go != null && (Parameter.Value & (1 << go.layer)) != 0;

        public override string ToString() => $"Layer In Mask {Parameter}";
    }

    [Serializable, DisplayName("Layer Not In Mask")]
    public class GameObjectLayerNotInMaskPredicate : BasePredicate<GameObject>
    {
        [DefaultValue("Physics.AllLayers")]
        public LayerMaskVar Parameter;

        protected override bool DoEvaluate(GameObject go) => go != null && (Parameter.Value & (1 << go.layer)) == 0;

        public override string ToString() => $"Layer Not In Mask {Parameter}";
    }
}
