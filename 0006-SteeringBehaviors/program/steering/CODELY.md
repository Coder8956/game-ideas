

## Codely Structured Memories

### User

### Feedback
- [2026-10-29 15:01:53] Game View 录屏做最终视觉验证时，540p 实时速率的 MP4 曾让视频分析误报场景中有两个球体（与层级扫描计数直接矛盾且自相矛盾）；改用 scale=1.0 全分辨率 + encodeFps=2 慢动作重录后逐帧分析与结构化数据完全吻合。对"场景中物体数量"这类关键结论，优先用 C# 层级扫描做主证据，视频分析结论与之矛盾时先怀疑视频误读并用慢动作全分辨率重录

### Project
- [2026-10-29 15:01:53] 通用/公共工具脚本（如相机射线点击等非转向行为专用的脚本）放在 Assets/Common/，Assets/SteeringBehaviors/ 下的编号目录（如 00-Seek）只放转向行为示例——2026-10-29 用户把新建的 CameraRayClickPlacer.cs 从 Assets/SteeringBehaviors/01-CameraRayClick/ 主动移到了 Assets/Common/
### Reference

