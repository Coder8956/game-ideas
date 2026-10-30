# 生成脚本 Pursuit

## Pursuit脚本文件路径
- [Pursuit脚本文件路径](../program/steering/Assets/SteeringBehaviors/03-Pursuit/Pursuit.cs)

## 参考脚本
- [SteeringBehaviors.cpp](../../../game-ai-by-example/Buckland_Chapter3-Steering%20Behaviors/SteeringBehaviors.cpp) 

## 相关脚本
- [CameraRayClickPlacer](../program/steering/Assets/Common/CameraRayClickPlacer.cs)会生成全局唯一的球体名字是`PlacedSphere`.

## 生成要求
- 阅读[参考脚本](#参考脚本)完成[Pursuit](#Pursuit脚本文件路径)脚本.
- 代码功能严格参照C++[参考脚本](#参考脚本)
- 只生成 Pursuit 相关的行为.
- 脚本加上详细的注释.
    - 涉及数学&物理运算的代码加上对应的计算过程注释.
- `目标地点`是鼠标点击产生的球体(PlacedSphere),本脚本不需要目标地点.
- 代码格式标准参考文件[Seek脚本](../program/steering/Assets/SteeringBehaviors/00-Seek/Seek.cs)
- C++源代码`Vehicle`类型的参数调整为`GameObject`类型的参数
- 追逐目标可配置(配置值为GameObject name 默认值`Tank-Wander`)