# :feather: Changelog

A running log of recent changes.  
See the package CHANGELOG for a full list of changes.

## [2.0.0 beta 87] - 2026-9-20

### API

- FSM owner references are no longer serialized. Custom tools that access deserialized FsmNode data directly should restore the owner via SetOwner(...) before initialization or traversal.
- Added GlobalEventAsset.Broadcast(object eventData, Component sender)

### ADDED

- Added GameObject child hierarchy actions: [GameObjectGetChild](action:GameObjectGetChild), [GameObjectGetChildren](action:GameObjectGetChildren), [GameObjectGetChildCount](action:GameObjectGetChildCount), [GameObjectFindChild](action:GameObjectFindChild), and [GameObjectFindChildWithTag](action:GameObjectFindChildWithTag).
- Added [GameObjectFindFirstChildMatch](action:GameObjectFindFirstChildMatch) and [GameObjectFindChildMatches](action:GameObjectFindChildMatches) actions to search a GameObject hierarchy with Condition Tests.
- Added [ParticleSystemCollisionSetPlane](action:ParticleSystemCollisionSetPlane ) action.
- Added + button to DataTableComponent inspector to quickly make a new DataTable.
- Added Diagnostic setting for extra logging to find slowdowns etc.

### FIXED

- Allow scene objects in Play Mode global value fields.
- Fixed FSM Templates not responding to some local events in Unity 6.6 player builds, including events sent from UnityEvents.
- Fixed asset browser sorting so assets without a Group appear at the top of the list, and improved list refresh performance.
- Fixed player build warnings for unused editor-only fields in some components.
- Fixed Variables tooltips on Watch button and Used Count.
- Fixed list equality tests in [CheckVariableEquals](action:CheckVariableEquals), [AssertAreEqual](action:AssertAreEqual), and [AssertAreNotEqual](action:AssertAreNotEqual)

## [2.0.0 beta 86] - 2026-9-9

### ADDED

- Added GlobalVariableRef for use in Monobehaviours that want to send events to FSMs.

### FIXED

- Fixed actions in copied states or regions sometimes changing when the original action was edited.
- Fixed NonAlloc actions not updating List results (e.g., PhysicsOverlapBoxNonAlloc).
- Fixed variable Object fields allowing scene object selection in assets.

## [2.0.0 beta 85] - 2026-9-4

### CHANGED

- Enum Definitions now generate next to their `.asset` by default instead of under a separate generated enums folder.

### ADDED

- Added LayerMask filter to [GameObjectFindClosest](action:GameObjectFindClosest) actions.

### FIXED

- Fixed Enum Definition editor error when selecting Flags option.
- Fixed Transform-to-GameObject variable conversion for GameObject fields.
- Fixed alignment of Enum flag fields in action editors.
- Fixed Markdown inline code rendering adding extra lines.
- Fixed internal _assetGuid migration issue in beta 84.
- Fixed warnings in Unity 6.6.

## [2.0.0 beta 84] - 2026-9-1

### CHANGED

- [ApplicationQuit](action:ApplicationQuit) action now exits play mode in the editor.
- [IntegerOperator](action:IntegerOperator) summary now uses mathematical symbols (+ instead of Add).

### ADDED

- Added [DisableRegion](action:DisableRegion), [EnableRegion](action:EnableRegion), and [SetRegionEnabled](action:SetRegionEnabled) actions.
- Added parameters and changed [ListGetNextItem](action:ListGetNextItem) and [ListGetPreviousItem](action:ListGetPreviousItem) so they work more like they did in PM1. Note: CurrentIndex now sets the starting point for the navigation.
- Added [LoopStop](action:LoopStop) variants to check float, integer, string, etc.
- Added [AnimatorTransitionInfo](action:AnimatorGetCurrentTransitionInfo) actions.
- Added [GameObjectFindAncestorWithTag](action:GameObjectFindAncestorWithTag) action.
- Added [ConvertIntegerToFloat](action:ConvertIntegerToFloat) action.
- Added UseVariableTokens option to [StringSelectValue](action:StringSelectValue) action.
- Added gravity options to [TransformFastProjectile](action:TransformFastProjectile) action.
- Added Show Active State setting in Debug toolbar menu.

### FIXED

- Fixed Group foldouts not working in FSM Inputs and Outputs.
- Fixed null error when using global variables in [CallComponentMethod](action:CallComponentMethod) action.
- Fixed loop bug in [AnimatorCheckIsPlaying](action:AnimatorCheckIsPlaying) action.
- Fixed an issue where using an Integer variable via automatic conversion in Float fields could read as 0 instead of the variable’s actual value.
- Fixed EveryFrame mode for [SceneManagerLoadSceneAsync](action:SceneManagerLoadSceneAsyncByName) actions.
- Fixed FsmTemplateComponent Edit button to View the running FSM while playing.
- Fixed [Flappy](addon:samples.flappy) sample. Wasn't using Realtime in Wait actions.

## [2.0.0 beta 83] - 2026-8-25

### ADDED

- Added network syncing of variables. Use a PlayMaker Network Variable Sync component on the same GameObject as the FSM you want to sync.
- Added more networking actions. Update the [Networking](addon:networking) addon and then the [Netcode for GameObjects](addon:netcode-for-gameobjects) addon.
- Added more [networking samples scenes](addon:samples.networking).
- Added optional name field to [GameObjectFindWithTag](action:GameObjectFindWithTag) action.
- Added [ListAddItems](action:ListAddItems) action so you can add multiple variables to a list.
- Added *Add Global Transition* to Parent State context menu.
- Added image drag and drop onto the graph view to create a new Image node.
- Added *Select Icon* to Image nodes to make it easier to select built-in icons.
- Added Size control to Image nodes to size the node using the native image size.
- Added an installer warning for Unity versions 6.3.0 - 6.3.4 that had compatibility issues with third party tools.
- Added some colors to the node colors palette.

### FIXED

- Fixed [String Split](action:StringSplit) errors when selecting Options: Everything.
- Fixed math functions in [ExpressionEvaluatorEvaluate](action:ExpressionEvaluatorEvaluate) actions.
- Fixed an issue where nested event transitions could leave a parallel region with no active state.
- Fixed duplicate OnMouseXXX system events when only the new Input System is enabled.
- Fixed Animate Variable actions sometimes entering an infinite transition loop when short-duration animations completed immediately on the first frame after entering Play Mode.
- Fixed InputShim compile errors with Input System package versions earlier than 1.14.0.
- Fixed a null reference error when checking unused events in prefab FSMs.
- Fixed [SpaceShooter](addon:samples.space-shooter) InputSystem requirement when importing.

## [2.0.0 beta 82] - 2026-8-19

### CHANGED

- Updated the FSM data version. Existing FSMs are upgraded automatically when scenes are opened, which may mark those scenes as dirty.

### ADDED

- ALPHA RELEASE of [Networking](addon:networking) addon. It currently supports [Netcode for GameObjects](addon:netcode-for-gameobjects) but is extensible to other networking solutions. NOTE: This is an ALPHA RELEASE and is not yet ready for production use. There is no automatic variable syncing yet.
- Added parameter browsing support to Animator actions.
- Added Space option to [RigidbodyGetVelocity](action:RigidbodyGetVelocity) actions.
- Added HitEvent, NotHitEvent, and DidHit to [Physics2DRaycast](action:Physics2DRaycast), [Physics2DLinecast](action:Physics2DLinecast), and [PhysicsLinecast](action:PhysicsLinecast) actions.
- Added Exclude Root option to [GameObjectGetComponentsInChildren](action:GameObjectGetComponentsInChildren) and [GameObjectGetComponentsInParent](action:GameObjectGetComponentsInParent) actions.
- Added (Hold) to [InputGetKey](action:InputGetKey), [InputGetAnyKey](action:InputGetAnyKey), and [InputGetButton](action:InputGetButton) names
- Added [GameObjectGetAncestor](action:GameObjectGetAncestor) and [GameObjectGetAncestors](action:GameObjectGetAncestors) actions.

### FIXED

- Fixed Get FSM list actions sharing source list.
- Fixed FSM Input/Output settings not always updating.
- Fixed first-field as key sometimes not working in builds.
- Fixed selected FSM in an additively loaded scene getting "lost" when exiting play mode.
- Fixed EnumList fields in DataDefinitions and DataComponents.

## [2.0.0 beta 81] - 2026-8-11

### CHANGED

- Zoom with right-click drag instead of Alt middle/right click drag.

### IMPROVED

- Improved performance when editing graphs with many regions.

### ADDED

- Added InputSystem binding actions.
- Added [PlayerInputButtonEvents](action:PlayerInputButtonEvents) action.
- Added FSM Input/Output support for InputSystem variables.
- Added [Export/Import CSV](docs:guides/data-tables/data-table-csv/) support for [DataTableComponents](docs:components/data-table/).
- Added Ctrl/Cmd + Alt Click on variable toggles to make a new variable and keep the current value.

### FIXED

- Fixed occasional console errors while editing templates.
- Fixed RunTemplate update timing, especially for physics actions in templates.
- Fixed empty Addons list if there are any empty json files (or read errors).
- Fixed [editor crashes on Linux](https://hutonggames.com/playmakerforum/index.php?topic=26922.0).

## [2.0.0 beta 80] - 2026-8-7

### Added

- Added Copy/Paste support in quaternion action fields.
- Added alt-drag middle or right mouse button to zoom the graph view (useful for wacom support).
- Added Recursive option to [ForEachChild](action:ForEachChild) action.
- Added optional output variable to [FloatRemap](action:FloatRemap) action.
- Added [TweenTransformLocalRotation](action:TweenTransformLocalRotation) action.

### Fixed

- Fixed debug values for input variables.
- Fixed NullReferenceException when selecting a list variable in actions like List Remove.
- Fixed the occasional NullReferenceException when deleting states in prefabs.
- Fixed AnimationCurve and Gradient values not always saving when creating variables in the new variable dialog from an action field.
- Fixed auto-selection of new Result variable in [GameObjectGetComponentsInChildren](action:GameObjectGetComponentsInChildren) action.
- Fixed [CheckGameObject](action:CheckGameObject) and [LoopSkip__CheckGameObject](action:LoopSkip__CheckGameObject) to allow checking against null.
- Fixed Comment Node checkboxes not updating the Markdown source.
- Fixed [TransformSetLocalRotation](action:TransformSetLocalRotation) so you can enter a constant value.
- Hide WorldUp in [TransformLookAtDirection](action:TransformLookAtDirection) when not used.

## [2.0.0 beta 79] - 2026-8-4

### Added

- Added Runtime Errors for actions that report runtime errors or throw exceptions. These errors are shown on actions and in the error finders.
- Added [LoadGameFromString](action:LoadGameFromString) and [SaveGameToString](action:SaveGameToString) actions.
- Added [EncryptString](action:EncryptString) and [DecryptString](action:DecryptString) actions.
- Added [UnityWebRequest](addon:unity-web-request) addon.
- Added [AssetBundle](addon:asset-bundle) addon.
- Added [Tools > Custom Action Wizard](menu:PlayMaker/Tools/Custom Action Wizard...). This is a 1.0 version that makes the outline of an action; you still need to implement the Execute method.
- Added Smooth Time and Max Speed options to [TransformAlignToDirection](action:TransformAlignToDirection) and [TransformAlignToDirection2D](action:TransformAlignToDirection2D) actions.
- Added Space setting and debug gizmos to [AimCanShootAtPoint](action:AimCanShootAtPoint) action.
- Added API to set [custom action category icons](docs:api/custom-actions/action-category-icons/).

## [2.0.0 beta 78] - 2026-8-1

### Changed

- Added [PlayerInput](category:InputSystem/PlayerInput) and [InputAction](category:InputSystem/InputAction) actions to base install (instead of an Addon).
- Optimized textures in [Space Shooter](addon:space-shooter) sample to reduce install package size.

### Added

- Added a note to InputAction actions about enabling the InputAction.
- Added [PlayerInputSimpleLook](action:PlayerInputSimpleLook) and [InputActionSimpleLook](action:InputActionSimpleLook) actions.
- Ctrl+click Edit buttons in FSM Component inspectors to open the FSM in a new window.

### Fixed

- Fixed [OnBecameInvisible](docs:guides/system-events/) system event.
- Fixed list view focus when switching tabs so delete, ctrl+c, ctrl+v, and ctrl+x work as expected.
- Fixed [GameObject Tag actions re-entry bug](https://hutonggames.com/playmakerforum/index.php?topic=26897.0).
- Fixed Scene GUI errors in [TransformClampRotation](action:TransformClampRotation) and [TransformMoveTowardsPosition](action:TransformMoveTowardsPosition) actions when using variables.
- Fixed [TransformCheckIsVisible](action:TransformCheckIsVisible) missing description.
- Fixed FSM log errors not added before Error Pause breaks.
- Fixed console errors when hovering variable selectors in the Action Browser preview.
- Fixed auto-selection of new FSMs when multiple FSM Editors are open.

## [2.0.0 beta 77] - 2026-7-26

### Improved

- Improved performance when running many FSMs.

### Added

- Added PlayerInputGetMoveVector2/Vector3 actions in [PlayerInput Addon](addon:input-system.player-input).
- Added InputActionGetMoveVector2/Vector3 actions in [InputAction Addon](addon:input-system.input-action).
- Added CHANGELOG.md to install package.

### Fixed

- Fixed [Global Variables occasionally losing their type](https://hutonggames.com/playmakerforum/index.php?topic=26887.0).
- Fixed [variable selection errors after deleting global variables](https://hutonggames.com/playmakerforum/index.php?topic=26887.0).
- Fixed an infinite loop when a DataRecord had a field using the same DataDefinition as the record itself.
- Fixed [CharacterControllerMoveOnGround](action:CharacterControllerMoveOnGround) [downward velocity bug](https://hutonggames.com/playmakerforum/index.php?topic=26886.0).
- Fixed [NextFrameEvent](action:NextFrameEvent) update mode (it requires EveryFrame).
- Fixed [SetObjectProperty](action:SetObjectProperty) not selecting the GameObject Active (Bool) property.
- Fixed property setter dropdowns showing read-only instance properties.
- Fixed [namespace conflict](https://hutonggames.com/playmakerforum/index.php?topic=26883.msg114590) with StateMachine.
- Fixed [LoadSceneByIndex needing a Result variable](https://hutonggames.com/playmakerforum/index.php?topic=26888.0).
- Fixed optional fields being required in some actions.
- Fixed Auto Process Prefabs setting when updating samples to URP.

## [2.0.0 beta 76] - 2026-7-10

### Fixed

- Fixed Bool Is True summary.
- Fixed alignment of Enum Flags fields.

## [2.0.0 beta 75] - 2026-7-7

## Added

- Added [WaitForFrames](action:WaitForFrames) action.
- Added DidHit output to Raycast actions.

### Fixed

- Fixed null ref error when removing DataDefinition from a DataComponent.
- Fixed new state name when dragging some actions (e.g., Loop State or Tween actions) into the graph view.

## [2.0.0 beta 74] - 2026-7-4

### Changed

- Show relative path in search result action category headers.
- Allow IntegerRef and FloatRef write conversions in actions.

### Added

- Added [TransformMoveAwayFromPosition](action:TransformMoveAwayFromPosition) action.
- Added [FloatSpring](action:FloatSpring), [Vector2Spring](action:Vector2Spring), [Vector3Spring](action:Vector3Spring) for spring like oscillations.
- Added [TransformSquashAndStretch](action:TransformSquashAndStretch) and [TransformSquashAndStretch2D](action:TransformSquashAndStretch2D) actions. [FloatSpring](action:FloatSpring) is a good input to control these if you want bouncy reactions.
- Added [RandomGetGaussian](action:RandomGetGaussian), [RandomGetGaussianVector2](action:RandomGetGaussianVector2), [RandomGetGaussianVector3](action:RandomGetGaussianVector3) and actions.
- Added [PostProcessStackV2 Addon](addon:post-processing-stack-v2) and [URP Volumes Addons](addon:universal-render-pipeline-volumes) for post-processing control.
- Added a Hide button to [Addons Browser](menu:PlayMaker/Addons) to hide tags you're not interested in.
- Added experimental [Sketch Addon](addon:sketch) and [Sketch Samples](addon:samples.sketch) for [Processing](https://processing.org/) style sketching.
- Added experimental [Image Processing Addon](addon:image-processing) for performant image processing.
- Added dotted lines to show [GotoState](action:GotoState) connections in the Graph View.
- Added a Restore On Exit option to Flicker actions.

### Fixed

- Fixed undo/redo when swapping an action with the convert menu.
- Fixed editor performance when selecting a state that rapidly enters/exits while playing, such as a tight loop between two states.
- Fixed editor performance when many visible variable values change rapidly while playing.
- Fixed dropping actions into manually resized parent states so the new state is in the parent state.
- Fixed expanding parent state sometimes overlapping other states.
- Fixed rendering artifacts when pasting text into a Markdown edit field.
- Fixed URP shader errors in samples when URP was not enabled.

## [2.0.0 beta 73] - 2026-6-23

### Changed

- Removed private beta information from the Welcome Window in preparation for public release.
- Tweaked category list view headers:
  - The main header and sticky header are now separate.
  - The main header always shows the selected category and has clickable breadcrumbs. This makes it clearer which category you're searching inside.
  - The sticky header shows the last category that scrolled offscreen.

### Improved

- Better summaries for [DataTableAddRow](action:DataTableAddRow) and [DataTableSetRowValues](action:DataTableSetRowValues) actions.

### Fixed

- Fixed shortened string values disappearing in action summaries.

## [2.0.0 beta 72] - 2026-6-19

### Changed

- Improved [Global Variable Text Binding](https://hutonggames.com/playmaker/docs/guides/ui-widgets/helpers/global-variable-text-binding/) UI.

### Added

- Added an Orange and Blue color to the node color picker.

### Fixed

- Fixed errors in Unity 6.5 (use the new 6.5 unitypackage)
- Fixed missing Sent By section in Transition inspector.

## [2.0.0 beta 71] - 2026-6-16

### Added

- Added raycast outputs to [InputMousePickEvent](action:InputMousePickEvent) action.
- Added [NavMeshPathDebugDraw](action:NavMeshDebugDraw) action to debug NavMeshPaths.
- Added [NavMeshPathGetNextCorner](action:NavMeshPathGetNextCorner) action to more easily use a NavMeshPath without a NavMeshAgent.
- Added documentation for [Global Variable Text Binding](https://hutonggames.com/playmaker/docs/guides/ui-widgets/helpers/global-variable-text-binding/).
- Added a few more controls to  [UIToolkit Samples](addon:samples.ui-toolkit).
- Added screenshots for all samples in [Addons](menu:PlayMaker/Addons).

### Fixed

- Fixed null exception errors [NavMeshCalculatePath](action:NavMeshCalculatePath) actions.
- Fixed disabling [Debug FSM](docs:components/debug-fsm/) while playing.
- Fixed missing UI Tag in [UGUI Samples](addon:ui).
- Fixed NavMeshPath variable icon.

## [2.0.0 beta 70] - 2026-6-13

### Changed

- Removed some internal PlayMaker methods from [CallComponentMethod](action:CallComponentMethod) method selectors.
- Tweaked formatting of method return type in CallMethod actions.
- Improved the Save System Settings inspector.

### Added

- Added [TouchEvent](action:TouchEvent) and [TouchObjectEvent](action:TouchObjectEvent) actions for the new Input System.
- Added [InputTouchEvent](action:InputTouchEvent) and [InputTouchObjectEvent](action:InputTouchObjectEvent) actions for the legacy input system.
- Added [GetFsmState](action:GetFsmState), [GotoPreviousState](action:GotoPreviousState), and [GetPreviousStateName](action:GetPreviousStateName).
- Added [ListGetLastItem](action:ListGetLastItem), [ListGetPreviousItem](action:ListGetPreviousItem), and [ListSwapItems](action:ListSwapItems).
- Added some sound effects to [Space Shooter](addon:space-shooter) sample.

### Fixed

- Fixed Null reference exception in CallMethod selector.

## [2.0.0 beta 69] - 2026-6-10

### Changed

- Moved WebCam and Location Services to addons so you don't need to set permissions if you don't use them.
- Addons now use version info to measure Needs Update. If local files differ from the package you still get a refresh option.
- Improved action browser search by replacing the old search index with a simpler in-memory search system.

### Added

- Added Check Usages and Remove buttons in the Addons window.

## [2.0.0 beta 68] - 2026-6-2

### Changed

- More work on [SpaceShooter Sample](addon:space-shooter). It's changed enough that you should delete the folder before re-importing it.
    - Re-worked movement tutorial to advance on player progress.
    - Added collect beacons flight training.
    - Added shoot sentry turrets combat training.
    - Added SOS mission and pirate ambush.
- Changed graph view Broadcast Icon to show events sent to other GameObjects (not just Broadcast Events).

### Added

- Added pasting of copied regions as new FSMs.
- Added Rect variable properties: center, position, and size.
- Added option to use first string field in the DataDefinition as the DataTable key.
- Added [UIToolkit Addon](addon:ui-toolkit) and [UIToolkit Samples](addon:samples.ui-toolkit). Not 100% complete, but should cover common UI needs.
- Added EnhancedTouch actions to Input System [Touch Addon](addon:input-system.touch) actions.
- Added TargetCone generator and validator blocks for [FindValidRandomPosition] action.
- Added TrueEvent and FalseEvent to [EvaluateBooleanExpression](action:EvaluateBooleanExpression).
- Added [TransformOnChildCountChanged](action:TransformOnChildCountChanged) action.
- Added [FlickerCanvasGroup](action:FlickerCanvasGroup) and [FlickerGraphic](action:FlickerGraphic) actions.
- Added Use Variable Tokens option to more actions. E.g. [GameObjectSetName](action:GameObjectSetName).
- Added [DebugVariable](action:DebugVariable) action to debug a specific variable while in a state.
- Added Debug Panel Scale setting in [PlayMaker Settings](menu:PlayMaker/Help/Settings).

### Fixed

- Fixed Exclude Self in [BroadcastEvent](action:BroadcastEvent). It could sometimes interrupt ForEach loops.
- Fixed <, >, and & rendering in action summaries, e.g., in ExpressionEvaluator actions.
- Fixed re-importing Playmaker after previously removing it from the project.
- Fixed GlobalObjectId warnings after deleting assets.
- Fixed sample billboard components in URP.

## [2.0.0 beta 67] - 2026-5-24

### Interactables

- [Interactable system](docs:guides/interactables/) has changed a bit in this release. This might require setup changes in your project.
- Added [Interactor component](docs:guides/interactables/interactor-component/). Use [InteractorUpdate](action:InteractorUpdate) instead of GameObjectUpdateInteractables (now obsolete).
- Streamlined [Interactable component](docs:guides/interactables/interactable-component/). Added **Inside Trigger** and **Measurement Space** options.
- Added docking setup to [Interactable component](docs:guides/interactables/interactable-component/). Used by [GameObjectDockWithInteractable](action:GameObjectDockWithInteractable) action.
- Added [PlayMaker > Browsers > Interactables](menu:PlayMaker/Browsers/Interactables) to browse all interactable objects in the scene.
- Reworked [First Person Samples](addon:first-person) to use the new Interactor component and actions.

### Changed

- Improved action summary tooltips. Shows parameter name and description.
- Allow selection of compatible variable properties (not just exact types).
- Meter components now set the current value in OnEnable.
- Show regions in the minimap.

### Added

- Added [PlayMaker > Debug > Find Obsolete Actions](menu:PlayMaker/Debug/Find Obsolete Actions) to make it easier to find deprecated actions.
- Added **RowNotFound** policy to DataTable actions like [DataTableGetRowValues](action:DataTableGetRowValues).
- Added constraints to [CharacterControllerClimb](action:CharacterControllerClimb) action.
- Added a tilted ladder to ClimbLadder scene in [First Person Samples](addon:first-person).
- Added line docking to ClimbWall scene in [First Person Samples](addon:first-person).
- Added [RigidbodyPickUp](action:RigidbodyPickUp), [RigidbodyDrop](action:RigidbodyDrop), and [RigidbodyThrow](action:RigidbodyThrow) actions. Updated Pickup and Throw scenes in [First Person Samples](addon:first-person).
- Added [Rigidbody2DPickUp](action:Rigidbody2DPickUp), [Rigidbody2DDrop](action:Rigidbody2DDrop), and [Rigidbody2DThrow](action:Rigidbody2DThrow) actions.
- Added [RandomGetPointOffscreen](action:RandomGetPointOffscreen) action and offscreen blocks for [FindValidRandomPosition](action:FindValidRandomPosition) and [FindValidRandomPosition2D](action:FindValidRandomPosition2D) actions.
- Added Enemy scenes to [Top-Down Shooter Samples](addon:top-down-shooter).

### Fixed

- Fixed actions that should be allowed to set null values. E.g., [ImageSetSprite](action:ImageSetSprite).
- Fixed [CharacterControllerClimb](action:CharacterControllerClimb) action so LookDirection respect input direction. Forward moves in look direction, back moves in opposite direction.
- Fixed [CharacterControllerCheckIsGrounded (SphereCast)](action:CharacterControllerCheckIsGrounded__SphereCast) action false positives.
- Fixed Stopwatch meter in [Shooting Gallery Sample](addon:shooting-gallery).


