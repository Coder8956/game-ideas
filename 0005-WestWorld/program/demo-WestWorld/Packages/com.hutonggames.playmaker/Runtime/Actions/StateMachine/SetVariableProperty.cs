/* WIP
// https://stackoverflow.com/questions/1402479/using-reflection-to-set-a-property-of-a-property-of-an-object

using System;
using HutongGames.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set a Variable's property using a property path." +
                       "\n\nNote, this is an advanced action for those familiar with the properties in a type.")]
    public class SetVariableProperty : BaseAction
    {
        [SerializeReference]
        [BaseType(typeof(object))]
        [Tooltip("The Variable to examine.")]
        [SerializeField]
        private AnyVariableRef _variable;
        
        [Tooltip("The path to the property.")]
        [SerializeField]
        private StringVar _propertyPath;
        
        [BaseType(typeof(object))]
        [Tooltip("The property type.")]
        [SerializeField]
        private TypeReference _propertyType;
        
        [SerializeReference]
        [MatchType(nameof(_propertyType))]
        [Tooltip("Get the property value and store it in a variable.")]
        private IVariableVar _setValue;

        public override bool CanExecute() => CheckParameters(_variable, _propertyPath, _propertyType, _setValue);

        public override void Execute()
        {
            var lambdaType = typeof(Action<,>).MakeGenericType(_variable.Variable.DataType, _propertyType.Type);
            var setter = Expressions.CreateGetter(lambdaType, _variable.Variable.DataType, _propertyPath.Value);
            setter.DynamicInvoke(_variable.GetValue());
        }

        public override string GetSummary() => "Set {_variable} property {_propertyPath} -> {_setValue}";
    }
}
*/