using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable, ConstantValue]
    [DataType(typeof(Color))]
    public sealed class ColorBlackValue : Variable<Color>
    {
        public override string Name => "Black";
        public override Color Value => Color.black;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "Black Color (0, 0, 0, 1).";
        
        #endif
    }
    
    [Serializable, ConstantValue]
    [DataType(typeof(Color))]
    public sealed class ColorBlueValue : Variable<Color>
    {
        public override string Name => "Blue";
        public override Color Value => Color.blue;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "Blue Color (0, 0, 1, 1).";
        
        #endif
    }
    
    [Serializable, ConstantValue]
    [DataType(typeof(Color))]
    public sealed class ColorClearValue : Variable<Color>
    {
        public override string Name => "Clear";
        public override Color Value => Color.clear;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "Clear Color (0, 0, 0, 0).";
        
        #endif
    }
    
    [Serializable, ConstantValue]
    [DataType(typeof(Color))]
    public sealed class ColorCyanValue : Variable<Color>
    {
        public override string Name => "Cyan";
        public override Color Value => Color.cyan;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "Cyan Color (0, 1, 1, 1).";
        
        #endif
    }
    
    [Serializable, ConstantValue]
    [DataType(typeof(Color))]
    public sealed class ColorGrayValue : Variable<Color>
    {
        public override string Name => "Gray";
        public override Color Value => Color.gray;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "Gray Color (0.5, 0.5, 0.5, 1).";
        
        #endif
    }
    
    [Serializable, ConstantValue]
    [DataType(typeof(Color))]
    public sealed class ColorGreenValue : Variable<Color>
    {
        public override string Name => "Green";
        public override Color Value => Color.green;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "Green Color (0, 1, 0, 1).";
        
        #endif
    }
    
    [Serializable, ConstantValue]
    [DataType(typeof(Color))]
    public sealed class ColorMagentaValue : Variable<Color>
    {
        public override string Name => "Magenta";
        public override Color Value => Color.magenta;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "Magenta Color (1, 0, 1, 1).";
        
        #endif
    }
    
    [Serializable, ConstantValue]
    [DataType(typeof(Color))]
    public sealed class ColorRedValue : Variable<Color>
    {
        public override string Name => "Red";
        public override Color Value => Color.red;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "Red Color (1, 0, 0, 1).";
        
        #endif
    }
    
    [Serializable, ConstantValue]
    [DataType(typeof(Color))]
    public sealed class ColorWhiteValue : Variable<Color>
    {
        public override string Name => "White";
        public override Color Value => Color.white;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "White Color (1, 1, 1, 1).";
        
        #endif
    }
    
    [Serializable, ConstantValue]
    [DataType(typeof(Color))]
    public sealed class ColorYellowValue : Variable<Color>
    {
        public override string Name => "Yellow";
        public override Color Value => Color.yellow;
        public override bool IsConstant => true;
        
        #if UNITY_EDITOR
        public override string Description => "Yellow Color (1, 0.92, 0.016, 1).";
        
        #endif
    }
}