/*
using System;
using HutongGames.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get a Variable's property using a property path." +
                       "\n\nNote, this is an advanced action for those familiar with the properties in a type.")]
    public class GetVariableProperty : BaseAction
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
        private IVariableRef _getValue;

        public override bool CanExecute() => CheckParameters(_variable, _propertyPath, _propertyType, _getValue);

        public override void Execute()
        {
            var fastGetter = new FastGetter(_propertyPath.Value);
            _getValue.SetValue(fastGetter.Invoke(_variable.GetValue()));

            
            //var lambdaType = typeof(Func<,>).MakeGenericType(_variable.Variable.DataType, _propertyType.Type);
            //var getter = Expressions.CreateGetter(lambdaType, _variable.Variable.DataType, _propertyPath.Value);
            //_getValue.SetValue( getter.DynamicInvoke(_variable.GetValue()));
        }

        public override string GetSummary() => "Get {_variable} property {_propertyPath} -> {_getValue}";
    }
}
*/