
using System;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteAnimator))]
	public sealed partial class TMP_SpriteAnimatorVariable : Variable<TMPro.TMP_SpriteAnimator>
	{
		
		public TMP_SpriteAnimatorVariable()
		{
		}
		
		public TMP_SpriteAnimatorVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteAnimator))]
	public sealed partial class TMP_SpriteAnimatorListVariable : ListVariable<TMPro.TMP_SpriteAnimator>
	{
		
		public TMP_SpriteAnimatorListVariable()
		{
		}
		
		public TMP_SpriteAnimatorListVariable(string name) : 
				base(name)
		{
		}
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteAnimator))]
	public sealed partial class TMP_SpriteAnimatorRef : BaseComponentRef<TMPro.TMP_SpriteAnimator>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteAnimator))]
	public sealed partial class TMP_SpriteAnimatorVar : BaseComponentVar<TMPro.TMP_SpriteAnimator>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteAnimator))]
	public sealed partial class TMP_SpriteAnimatorListRef : ListVariableRef<TMPro.TMP_SpriteAnimator>
	{
	}
	
	[Serializable]
	[DataType(typeof(TMPro.TMP_SpriteAnimator))]
	public sealed partial class TMP_SpriteAnimatorListVar : ListVariableVar<TMPro.TMP_SpriteAnimator>
	{
	}
}
