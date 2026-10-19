
using System;
using UnityEngine;


namespace HutongGames.PlayMaker
{
	
	
	[Serializable]
	[DataType(typeof(UnityEngine.SendMessageOptions))]
	public sealed partial class SendMessageOptionsVariable : Variable<SendMessageOptions>
	{
		
		public SendMessageOptionsVariable()
		{
		}
		
		public SendMessageOptionsVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SendMessageOptions))]
	public sealed partial class SendMessageOptionsListVariable : ListVariable<SendMessageOptions>
	{
		
		public SendMessageOptionsListVariable()
		{
		}
		
		public SendMessageOptionsListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SendMessageOptions))]
	public sealed partial class SendMessageOptionsRef : VariableRef<SendMessageOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SendMessageOptions))]
	public sealed partial class SendMessageOptionsVar : VariableVar<SendMessageOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SendMessageOptions))]
	public sealed partial class SendMessageOptionsListRef : ListVariableRef<SendMessageOptions>
	{
	}
	
	[Serializable]
	[DataType(typeof(UnityEngine.SendMessageOptions))]
	public sealed partial class SendMessageOptionsListVar : ListVariableVar<SendMessageOptions>
	{
	}
}
