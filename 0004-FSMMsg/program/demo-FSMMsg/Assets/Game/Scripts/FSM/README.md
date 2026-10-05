# UGU.Runtime.FSM — Unity 通用有限状态机

一套轻量、纯 C# 的 FSM 系统，适用于 Unity 6（C# 9）。核心类不依赖 `UnityEngine`，可复用、可单测；`FSMMachineBehaviour` 负责与 Unity 生命周期对接。

## 文件清单

| 文件 | 作用 |
| --- | --- |
| `FSMState.cs` | 状态基类：OnEnter / OnExit / OnUpdate / OnFixedUpdate / OnLateUpdate |
| `FSMTransition.cs` | 转移定义：目标状态 ID + 触发条件委托 |
| `FSMMachine.cs` | 状态机核心：注册状态/转移、驱动切换、切换事件 |
| `FSMMachineBehaviour.cs` | MonoBehaviour 驱动器：转发 Update/FixedUpdate/LateUpdate |
| `FSMDemoEnemy.cs` | 使用示例（Idle / Patrol / Chase / Stunned），可删除 |

## 快速上手

```csharp
public class EnemyBrain : FSMMachineBehaviour
{
    private enum StateId { Idle, Patrol, Attack }

    private void Start()
    {
        Machine.AddState(StateId.Idle,   new IdleState(this));
        Machine.AddState(StateId.Patrol, new PatrolState(this));
        Machine.AddState(StateId.Attack, new AttackState(this));

        Machine.AddTransition(StateId.Idle,   StateId.Patrol, () => HasTarget());
        Machine.AddTransition(StateId.Patrol, StateId.Idle,   () => !HasTarget());
        Machine.AddTransition(StateId.Patrol, StateId.Attack, () => InAttackRange());
        Machine.AddTransition(StateId.Attack, StateId.Patrol, () => !InAttackRange());

        StartMachine(StateId.Idle);
    }

    private sealed class IdleState : FSMState
    {
        private readonly EnemyBrain m_owner;
        public IdleState(EnemyBrain owner) => m_owner = owner;
        public override void OnUpdate(float dt) { /* 待机逻辑 */ }
    }
    // PatrolState / AttackState 同理
}
```

也可不继承 `FSMMachineBehaviour`，直接在任意 MonoBehaviour 中持有 `FSMMachine`，自行在 `Update()` 里调用 `m_fsm.Update(Time.deltaTime)`。

## API 一览

| API | 说明 |
| --- | --- |
| `AddState(Enum id, FSMState state)` | 注册状态；同一实例只能属于一个状态机 |
| `AddTransition(Enum from, Enum to, Func<bool> condition)` | 注册普通转移，按注册顺序求值，命中即切换 |
| `AddAnyTransition(Enum to, Func<bool> condition)` | 任意状态转移，优先于普通转移（全局打断用） |
| `Start(Enum initialState)` | 启动；已启动则忽略，初始状态未注册抛异常 |
| `ChangeState(Enum id, bool force = false)` | 立即切换；force=true 可重进当前状态 |
| `Update / FixedUpdate / LateUpdate(dt)` | 逐帧驱动，先求值转移再派发当前状态回调 |
| `Stop()` | 停止并退出当前状态，可再次 Start |
| `GetState / IsInState` | 查询 |
| `StateChanged` 事件 | `Action<Enum from, Enum to>`，首次进入 from 为 null |

## 设计说明

- **状态 ID**：任意枚举即类型安全的 ID，注册/转移/切换传同一枚举值。
- **转移求值顺序**：每帧先查任意转移（AnyTransition），再查当前状态的普通转移；先命中先切换。
- **生命周期**：切换帧内先执行旧状态 `OnExit`，再执行新状态 `OnEnter`，随后新状态收到本帧 `OnUpdate`。
- **上下文**：`FSMMachine(context)` 的 context 默认是持有它的 MonoBehaviour，状态内用 `Context` 访问持有者数据。
- **失败即报错**：转移目标或启动状态未注册时抛异常，配置错误在开发期直接暴露。

## 常见问题

- **同帧重复切换**：`ChangeState` 到相同状态默认忽略；需要重置行为用 `force: true`。
- **状态实例复用**：一个状态实例只能注册进一个状态机，重复注册抛异常。
- **未注册目标**：转移条件满足但目标未注册会抛异常，检查是否漏了 `AddState`。
