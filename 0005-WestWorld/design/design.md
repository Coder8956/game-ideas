# 西部世界设计

> 设计来源：《Programming Game AI by Example》第 2 章示例 **WestWorldWithMessaging**（带消息传递的西部世界，C++ 参考工程）
> 本文归纳参考工程中**矿工 Bob** 与**矿工妻子 Elsa** 的角色、状态机与消息系统设计，作为 UnityWestWorld 实践项目的设计依据。

---

## 环境设计

世界共有 4 个地点，定义于 `Locations.h`（枚举 `location_type`，隐式编号 shack=0、goldmine=1、bank=2、saloon=3）：

### 金矿（goldmine）
- Bob 的"上班地点"：进入 `EnterMineAndDigForNugget` 状态时走到这里；
- 每挖一步：口袋金块 +1、疲劳 +1；
- 口袋满（≥ 3）就去银行存钱。

### 银行（bank）
- 进入 `VisitBankAndDepositGold` 状态时走到这里；
- 把口袋里的金块**全部**转为存款，口袋清零；
- 存款 ≥ 5（ComfortLevel）就心满意足回家，否则回金矿继续挖。

### 酒吧间（saloon）
- 进入 `QuenchThirst` 状态时走到这里；
- 买一杯威士忌：口渴清零、存款 -2；
- 喝完回金矿继续挖矿。

### Bob家（shack）
- Bob 的家：疲劳 > 5（TirednessThreshold）时回家睡觉，每睡一步疲劳 -1；
- Elsa 平时也在这里做家务；Bob 进家门时会给 Elsa 发"我回来了"消息。

---

## 角色设计

### 矿工Bob（Miner）

#### 位置
- 成员 `m_Location`（类型 `location_type`），出生初始化为 `shack`；
- 通过 `Location()` 读取、`ChangeLocation()` 搬移；状态进入时若不在目标地点，先搬过去再行动。

#### 携带的矿石
- 成员 `m_iGoldCarried`（口袋金块数），初始 0；
- 上限 `MaxNuggets = 3`：`PocketsFull()` 判断口袋是否装满；
- 挖矿 +1（`AddToGoldCarried`，带防负保护）；存钱时全部转存款并清零。

#### 矿工存款
- 成员 `m_iMoneyInBank`，初始 0；
- 存款目标 `ComfortLevel = 5`：达到即回家休息（`AddToWealth` 同样防负）；
- 喝酒会扣款 2（`BuyAndDrinkAWhiskey`）。

#### 口渴值
- 成员 `m_iThirst`，初始 0；**每帧 Update +1**；
- 阈值 `ThirstLevel = 5`：`Thirsty()` 用 **≥** 判断，达到就去酒吧。

#### 疲劳度
- 成员 `m_iFatigue`，初始 0；挖矿 +1，睡觉 -1；
- 阈值 `TirednessThreshold = 5`：`Fatigued()` 用 **>** 判断，超过就回家睡觉；
- 睡觉状态每帧 `DecreaseFatigue()`，睡到不累为止。

#### 状态机设计（5 个状态，初始 = 回家睡觉，**无全局状态**）
所有状态为单例，实现 Enter / Execute / Exit / OnMessage 四个接口；状态切换统一走 `GetFSM()->ChangeState(下一状态::Instance())`。

| 状态 | 进入 Enter | 每帧 Execute | 切换条件 |
|---|---|---|---|
| ① EnterMineAndDigForNugget 挖矿 | 走到金矿 | 金块 +1、疲劳 +1 | 口袋满 → ②；口渴 → ④ |
| ② VisitBankAndDepositGold 存钱 | 走到银行 | 金块全转存款、口袋清零 | 存款 ≥5 → ③；否则 → ① |
| ③ GoHomeAndSleepTilRested 睡觉 | 走回家，**即时发"我回来了"给妻子** | 不累 → ①；累 → 疲劳 -1 | 收到"炖菜好了" → ⑤ |
| ④ QuenchThirst 喝酒 | 走到酒吧 | 买酒（口渴清零、-2） | 喝完 → ① |
| ⑤ EatStew 吃炖菜 | 夸妻子 | 吃完 `RevertToPreviousState` | 回到进入前状态 |

```
状态切换图：
  ③ 回家睡觉 ──(睡醒，不累)──▶ ① 挖矿金块 ──(口袋满≥3)──▶ ② 银行存钱 ──(存款≥5)──▶ ③ 回家睡觉
      ▲                            ▲                           │
      │                            └───────(存款<5)─────────────┘
      │
      └──(收到"炖菜好了"消息)──▶ ⑤ 吃炖菜 ──(吃完)──▶ RevertToPreviousState 回到③

  ① 挖矿 ──(口渴≥5)──▶ ④ 酒吧解渴 ──(喝完)──▶ 回①挖矿
```

### 矿工妻子Elsa（MinersWife）

#### 位置
- 成员 `m_Location`，初始 `shack`（基本总在家，仅"去厕所"属临时地点切换）。

#### 在做饭吗
- 成员 `m_bCooking`（布尔开关），初始 `false`；
- `Cooking()` / `SetCooking()` 读写；炖菜进入时若已在炖则不重复放菜、不重复发延迟消息，炖完关闭。

#### 状态机设计（4 个状态，当前 = 做家务，**有全局状态**）
与 Bob 的关键差异：Elsa 设置了**全局状态** `WifesGlobalState`，`StateMachine::Update` 每帧**先执行全局状态、再执行当前状态**。

| 状态 | 进入 Enter | 每帧 Execute | 切换条件 |
|---|---|---|---|
| ① WifesGlobalState 全局状态 | 空实现（永远在场） | 10% 概率且不在厕所 → ③ | 收到"我回来了" → ④ |
| ② DoHouseWork 做家务 | 开始干活 | 随机三选一：拖地 / 洗碗 / 铺床 | — |
| ③ VisitBathroom 去厕所 | 走向厕所 | 上完 `RevertToPreviousState` | 回到进入前状态 |
| ④ CookStew 炖菜 | 放菜进烤箱，**给自己发延迟 1.5 秒"炖菜好了"**，打开开关 | 忙着做吃的 | 收到"炖菜好了" → 通知丈夫、关开关 → ② |

```
状态切换图：
  (每帧最先执行) ① 全局状态 ──(10%概率 且 不在厕所)──▶ ③ 去厕所 ──(上完)──▶ 回到上一状态(通常②)
        │
        └──(收到"我回来了"消息)──▶ ④ 炖菜 ──(1.5秒后收到自己的延迟消息)──▶ 通知丈夫"炖菜好了" → ② 做家务
  ② 做家务 ◀────────────────────────────────────────────────────────────────┘
```

---

## 消息系统设计

### 消息类型（MessageTypes.h）
| 消息 | 编号 | 发送方 → 接收方 | 场景 |
|---|---|---|---|
| Msg_HiHoneyImHome（亲爱的我回来了） | 0 | Bob → Elsa（即时） | Bob 进入睡觉状态时发送 |
| Msg_StewReady（炖菜好了） | 1 | Elsa → 自己（延迟 1.5s）→ Bob（即时） | 自提醒取菜 / 通知丈夫吃饭 |

### 消息信封（Telegram）
字段：投递时间 DispatchTime、发送方 Sender、接收方 Receiver、消息编号 Msg、附加信息 ExtraInfo（无则传 0）。

### 邮局 MessageDispatcher（单例，宏 `Dispatch`）
- `DispatchMessage(延迟, 发送方, 接收方, 消息, 附加信息)`：
  - 延迟 ≤ 0 → 立即 `Discharge`（调用接收者的 HandleMessage）；
  - 延迟 > 0 → 计算投递时间（当前时间 + 延迟）存入 `PriorityQ`（std::set 按投递时间自动排序）。
- `DispatchDelayedMessages()`：主循环每帧调用，把到期的队头消息投递并删除。

### 户口本 EntityManager（单例，宏 `EntityMgr`）
- `std::map<编号, 实体指针>`：`RegisterEntity` / `GetEntityFromID` / `RemoveEntity`；
- 消息系统凭**编号**查人，发送方无需持有接收方指针——这是消息解耦的关键。

---

## 框架设计（Common 共享库）

| 组件 | 职责 |
|---|---|
| BaseGameEntity | 角色基类：唯一编号 ID（静态计数器自增、SetID 校验）、纯虚 `Update()`、纯虚 `HandleMessage()` |
| State\<T\> | 状态接口：Enter / Execute / Exit / OnMessage |
| StateMachine\<T\> | 状态机模板：当前 / 上一 / 全局三个状态指针；`Update` 先全局后当前；`ChangeState` = 记录上一状态 → 旧状态 Exit → 换指针 → 新状态 Enter；`RevertToPreviousState`；`isInState`；`HandleMessage` 先当前后全局 |
| 单例三件套 | 私有构造 + 私有拷贝/赋值 + 静态 `Instance()`（状态类与管理器通用，状态本身无数据，全局一份即可） |

---

## 主循环与剧情闭环

```
main：
  1. 创建 Bob（new Miner(0)）、Elsa（new MinersWife(1)），构造函数内搭好状态机
  2. EntityMgr->RegisterEntity(Bob / Elsa)   // 上户口
  3. 循环 30 次：
       Bob->Update()         // 口渴+1 → 状态机跑当前状态
       Elsa->Update()        // 先全局状态 → 再当前状态
       Dispatch->DispatchDelayedMessages()   // 投递到期的延迟消息
       Sleep(800ms)          // 0.8 秒一幕
```

一次完整消息剧情：
1. Bob 回家（进入睡觉状态）→ 即时发"我回来了"给 Elsa；
2. Elsa **全局状态**收到 → 切到炖菜 → 放菜进烤箱，**给自己发延迟 1.5 秒**的"炖菜好了"，打开 m_bCooking；
3. 等待期间每帧 Elsa 执行"忙着做吃的"，全局状态每帧仍有 10% 概率去厕所；
4. 1.5 秒后主循环 `DispatchDelayedMessages` 投递到期消息 → Elsa **炖菜状态**收到 → 即时发"炖菜好了"给 Bob、关开关、切回做家务；
5. Bob **睡觉状态**收到 → 切到吃炖菜 → 吃完 `RevertToPreviousState` 回到睡觉；
6. 循环往复，直到 30 幕结束。

---

## 设计要点小结（Unity 实践提示）

- **状态机差异**：Bob 无全局状态、Elsa 有全局状态；"先全局后当前"的执行顺序由 `StateMachine::Update` 统一实现，角色自身只需调用 `m_pStateMachine->Update()`；
- **状态闪回（state blip）**：EatStew、VisitBathroom 都依赖 `RevertToPreviousState` 回到进入前状态，上一状态由 `ChangeState` 自动记录；
- **消息解耦**：发送方只传接收方编号，投递由邮局 + 户口本完成；角色只要实现 `HandleMessage` 即可收信；
- **延迟消息 = 自提醒**：Elsa 给自己发延迟消息，实现"1.5 秒后提醒我"；
- **阈值细节**：`Thirsty()` 用 ≥、`Fatigued()` 用 >（源码细节，Unity 复刻时保持一致）；
- **消息处理优先级**：状态机先问当前状态、再问全局状态；矿工只在睡觉状态处理"炖菜好了"，妻子在全局状态处理"我回来了"、在炖菜状态处理"炖菜好了"——两种处理位置都有示范。
