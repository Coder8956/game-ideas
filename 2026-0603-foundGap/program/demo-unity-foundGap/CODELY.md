

## Codely Structured Memories

### User

### Feedback

### Project

### Reference
- [2026-09-13 19:20:00] Tuanjie Play Mode 测试中模拟按键:InputState.Change 被 FastKeyboard 布局拦截、静默无效;须用 InputSystem.QueueStateEvent + InputSystem.Update()(并切 InputSettings.UpdateMode.ProcessEventsManually 保证按下沿恰好被一帧 Update 消费),枚举类型为嵌套 InputSettings.UpdateMode 而非 InputSettingsUpdateModes;详见内置 Wiki「输入-控制系统/团结引擎Input-System后端缺陷桥接」;鼠标按键模拟为 new MouseState().WithButton(MouseButton.Left)(Tuanjie 无 MouseState.Button 嵌套枚举);滚轮模拟 new MouseState{scroll=new Vector2(0,±y)} 在清零前每帧 LateUpdate 都会消费,缩放会被多次应用直至 Clamp 边界,断言应读实际相机距离而非假设单次应用;编辑器失焦被节流至约4fps时,手动模式下按下沿可能被2帧消费、单次点击可能生成2个实例(测试现象,真实输入不受影响)


- [2026-09-13 18:55:39] 本机 analyze_multimedia 无法读取 record_game_view 录制的 MP4(报"无附件");运行时验证视频证据改用 ManageScreenshot BeginCapture/CaptureFrame/EndCaptureToGif 出 GIF,再用 PowerShell System.Drawing 逐帧导出拼接网格 PNG 后分析;GIF 提帧须用 [System.Drawing.Imaging.FrameDimension]::Time 静态属性(手拼 GUID 会报 GDI+ 错误);网格 PNG 过大(2880px宽)会致 analyze_multimedia 超时268s,应缩至约1920px内;analyze_multimedia 可直接读 GIF 但只见单帧,不能作为动态证据
- [2026-09-13 19:08:47] [reference] SurroundViewCamera 以目标为中心每帧重摆位置，"子物体随目标平移"在追踪相机画面上不可见（相机随动补偿）；视觉验证父子随动应改为旋转目标、观察附着物随之转动（本机管线：GIF→FrameDimension::Time 提帧→≤1920px 网格→analyze_multimedia）
