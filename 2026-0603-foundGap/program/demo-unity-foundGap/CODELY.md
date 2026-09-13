

## Codely Structured Memories

### User

### Feedback

### Project

### Reference
- [2026-09-13 18:05:42] Tuanjie Play Mode 测试中模拟按键:InputState.Change 被 FastKeyboard 布局拦截、静默无效;须用 InputSystem.QueueStateEvent + InputSystem.Update()(并切 InputSettings.UpdateMode.ProcessEventsManually 保证按下沿恰好被一帧 Update 消费),枚举类型为嵌套 InputSettings.UpdateMode 而非 InputSettingsUpdateModes;详见内置 Wiki「输入-控制系统/团结引擎Input-System后端缺陷桥接」
- [2026-09-13 18:05:42] 本机 analyze_multimedia 无法读取 record_game_view 录制的 MP4(报"无附件");运行时验证视频证据改用 ManageScreenshot BeginCapture/CaptureFrame/EndCaptureToGif 出 GIF,再用 PowerShell System.Drawing 逐帧导出拼接网格 PNG 后分析
