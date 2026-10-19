# Changelog

All notable changes to this package are documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## Online Documentation

Check out the [online documentation](https://hutonggames.com/playmaker/docs/welcome/)

## Known Issues

- Unity 6.3 is supported in 6000.3.5f1 and higher.
- The GraphView does not currently have a light theme. Other parts of the UI might also be less optimal in the light theme. Please report any problems you see when using the light editor theme.

## [2.0.0 beta 88] - 2026-9-26

### ADDED

- Added Tag option to 2D Physics event actions.
- Added optional StoreGameObject to Physics and 2D Physics event actions.
- Added **DataTableGetRandomWeightedRecord** action for randomly selecting rows in a table with a weights column.
- Added xml documentation for PlayMaker dlls. Useful for Intellisense and coding agents.
- Added upgrade checks to warn when PlayMaker needs to be re-imported after changing Unity versions.
- Added Name Width options in Variables list view, from Default (30%) to Maximum (60%).
- Added Show/Hide FSM Header option to secondary FSM windows menu (e.g. Variables Window).
- Added *Open in New Window* in Events and Variables menus.

### FIXED

- Fixed Debug Step not advancing FSMs.
- Fixed creating new variables/events inside existing groups.
- Fixed ProjectDatabase sometimes becoming very big and slowing down finding usages.

## [2.0.0 beta 87] - 2026-9-20

### API

- FSM owner references are no longer serialized. Custom tools that access deserialized FsmNode data directly should restore the owner via SetOwner(...) before initialization or traversal.
- Added GlobalEventAsset.Broadcast(object eventData, Component sender)

### ADDED

- Added GameObject child hierarchy actions: **GameObjectGetChild**, **GameObjectGetChildren**, **GameObjectGetChildCount**, **GameObjectFindChild**, and **GameObjectFindChildWithTag**.
- Added **GameObjectFindFirstChildMatch** and **GameObjectFindChildMatches** actions to search a GameObject hierarchy with Condition Tests.
- Added **ParticleSystemCollisionSetPlane** action.
- Added + button to DataTableComponent inspector to quickly make a new DataTable.
- Added Diagnostic setting for extra logging to find slowdowns etc.

### FIXED

- Allow scene objects in Play Mode global value fields.
- Fixed FSM Templates not responding to some local events in Unity 6.6 player builds, including events sent from UnityEvents.
- Fixed asset browser sorting so assets without a Group appear at the top of the list, and improved list refresh performance.
- Fixed player build warnings for unused editor-only fields in some components.
- Fixed Variables tooltips on Watch button and Used Count.
- Fixed list equality tests in **CheckVariableEquals**, **AssertAreEqual**, and **AssertAreNotEqual**

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

- Added LayerMask filter to **GameObjectFindClosest** actions.

### FIXED

- Fixed Enum Definition editor error when selecting Flags option.
- Fixed Transform-to-GameObject variable conversion for GameObject fields.
- Fixed alignment of Enum flag fields in action editors.
- Fixed Markdown inline code rendering adding extra lines.
- Fixed internal _assetGuid migration issue in beta 84.
- Fixed warnings in Unity 6.6.

## [2.0.0 beta 84] - 2026-9-1

### CHANGED

- **ApplicationQuit** action now exits play mode in the editor.
- **IntegerOperator** summary now uses mathematical symbols (+ instead of Add).

### ADDED

- Added **DisableRegion**, **EnableRegion**, and **SetRegionEnabled** actions.
- Added parameters and changed **ListGetNextItem** and **ListGetPreviousItem** so they work more like they did in PM1. Note: CurrentIndex now sets the starting point for the navigation.
- Added **LoopStop** variants to check float, integer, string, etc.
- Added **AnimatorTransitionInfo** actions.
- Added **GameObjectFindAncestorWithTag** action.
- Added **ConvertIntegerToFloat** action.
- Added UseVariableTokens option to **StringSelectValue** action.
- Added gravity options to **TransformFastProjectile** action.
- Added Show Active State setting in Debug toolbar menu.

### FIXED

- Fixed Group foldouts not working in FSM Inputs and Outputs.
- Fixed null error when using global variables in **CallComponentMethod** action.
- Fixed loop bug in **AnimatorCheckIsPlaying** action.
- Fixed an issue where using an Integer variable via automatic conversion in Float fields could read as 0 instead of the variable’s actual value.
- Fixed EveryFrame mode for **SceneManagerLoadSceneAsync** actions.
- Fixed FsmTemplateComponent Edit button to View the running FSM while playing.
- Fixed **Flappy** sample. Wasn't using Realtime in Wait actions.

## [2.0.0 beta 83] - 2026-8-25

### ADDED

- Added network syncing of variables. Use a PlayMaker Network Variable Sync component on the same GameObject as the FSM you want to sync.
- Added more networking actions. Update the **Networking** addon and then the **Netcode for GameObjects** addon.
- Added more **networking samples scenes**.
- Added optional name field to **GameObjectFindWithTag** action.
- Added **ListAddItems** action so you can add multiple variables to a list.
- Added *Add Global Transition* to Parent State context menu.
- Added image drag and drop onto the graph view to create a new Image node.
- Added *Select Icon* to Image nodes to make it easier to select built-in icons.
- Added Size control to Image nodes to size the node using the native image size.
- Added an installer warning for Unity versions 6.3.0 - 6.3.4 that had compatibility issues with third party tools.
- Added some colors to the node colors palette.

### FIXED

- Fixed **String Split** errors when selecting Options: Everything.
- Fixed math functions in **ExpressionEvaluatorEvaluate** actions.
- Fixed an issue where nested event transitions could leave a parallel region with no active state.
- Fixed duplicate OnMouseXXX system events when only the new Input System is enabled.
- Fixed Animate Variable actions sometimes entering an infinite transition loop when short-duration animations completed immediately on the first frame after entering Play Mode.
- Fixed InputShim compile errors with Input System package versions earlier than 1.14.0.
- Fixed a null reference error when checking unused events in prefab FSMs.
- Fixed **SpaceShooter** InputSystem requirement when importing.

## [2.0.0 beta 82] - 2026-8-19

### CHANGED

- Updated the FSM data version. Existing FSMs are upgraded automatically when scenes are opened, which may mark those scenes as dirty.

### ADDED

- ALPHA RELEASE of **Networking** addon. It currently supports **Netcode for GameObjects** but is extensible to other networking solutions. NOTE: This is an ALPHA RELEASE and is not yet ready for production use. There is no automatic variable syncing yet.
- Added parameter browsing support to Animator actions.
- Added Space option to **RigidbodyGetVelocity** actions.
- Added HitEvent, NotHitEvent, and DidHit to **Physics2DRaycast**, **Physics2DLinecast**, and **PhysicsLinecast** actions.
- Added Exclude Root option to **GameObjectGetComponentsInChildren** and **GameObjectGetComponentsInParent** actions.
- Added (Hold) to **InputGetKey**, **InputGetAnyKey**, and **InputGetButton** names
- Added **GameObjectGetAncestor** and **GameObjectGetAncestors** actions.

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
- Added **PlayerInputButtonEvents** action.
- Added FSM Input/Output support for InputSystem variables.
- Added [Export/Import CSV](https://hutonggames.com/playmaker/docs/guides/data-tables/data-table-csv/) support for [DataTableComponents](https://hutonggames.com/playmaker/docs/components/data-table/).
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
- Added Recursive option to **ForEachChild** action.
- Added optional output variable to **FloatRemap** action.
- Added **TweenTransformLocalRotation** action.

### Fixed

- Fixed debug values for input variables.
- Fixed NullReferenceException when selecting a list variable in actions like List Remove.
- Fixed the occasional NullReferenceException when deleting states in prefabs.
- Fixed AnimationCurve and Gradient values not always saving when creating variables in the new variable dialog from an action field.
- Fixed auto-selection of new Result variable in **GameObjectGetComponentsInChildren** action. 
- Fixed **CheckGameObject** and **LoopSkip__CheckGameObject** to allow checking against null.
- Fixed Comment Node checkboxes not updating the Markdown source.
- Fixed **TransformSetLocalRotation** so you can enter a constant value.
- Fixed [editor crashes on Linux](https://hutonggames.com/playmakerforum/index.php?topic=26922.0).
- Hide WorldUp in **TransformLookAtDirection** when not used.

## [2.0.0 beta 79] - 2026-8-4

### Added

- Added Runtime Errors for actions that report runtime errors or throw exceptions. These errors are shown on actions and in the error finders.
- Added **LoadGameFromString** and **SaveGameToString** actions.
- Added **EncryptString** and **DecryptString** actions.
- Added **UnityWebRequest** addon.
- Added **AssetBundle** addon.
- Added **Tools > Custom Action Wizard**. This is a 1.0 version that makes the outline of an action; you still need to implement the Execute method.
- Added Smooth Time and Max Speed options to **TransformAlignToDirection** and **TransformAlignToDirection2D** actions.
- Added Space setting and debug gizmos to **AimCanShootAtPoint** action.
- Added API to set [custom action category icons](https://hutonggames.com/playmaker/docs/api/custom-actions/action-category-icons/).

## [2.0.0 beta 78] - 2026-8-1

### Changed

- Added **PlayerInput** and **InputAction** actions to base install (instead of an Addon).
- Optimized textures in **Space Shooter** sample to reduce install package size.

### Added

- Added a note to InputAction actions about enabling the InputAction.
- Added **PlayerInputSimpleLook** and **InputActionSimpleLook** actions.
- Ctrl+click Edit buttons in FSM Component inspectors to open the FSM in a new window.

### Fixed

- Fixed [OnBecameInvisible](https://hutonggames.com/playmaker/docs/guides/system-events/) system event.
- Fixed list view focus when switching tabs so delete, ctrl+c, ctrl+v, and ctrl+x work as expected.
- Fixed [GameObject Tag actions re-entry bug](https://hutonggames.com/playmakerforum/index.php?topic=26897.0).
- Fixed Scene GUI errors in **TransformClampRotation** and **TransformMoveTowardsPosition** actions when using variables.
- Fixed **TransformCheckIsVisible** missing description.
- Fixed FSM log errors not added before Error Pause breaks.
- Fixed console errors when hovering variable selectors in the Action Browser preview.
- Fixed auto-selection of new FSMs when multiple FSM Editors are open.

## [2.0.0 beta 77] - 2026-7-26

### Improved

- Improved performance when running many FSMs.

### Added

- Added PlayerInputGetMoveVector2/Vector3 actions in **PlayerInput Addon**.
- Added InputActionGetMoveVector2/Vector3 actions in **InputAction Addon**.
- Added CHANGELOG.md to install package.

### Fixed

- Fixed [Global Variables occasionally losing their type](https://hutonggames.com/playmakerforum/index.php?topic=26887.0).
- Fixed [variable selection errors after deleting global variables](https://hutonggames.com/playmakerforum/index.php?topic=26887.0).
- Fixed an infinite loop when a DataRecord had a field using the same DataDefinition as the record itself.
- Fixed **CharacterControllerMoveOnGround** [downward velocity bug](https://hutonggames.com/playmakerforum/index.php?topic=26886.0).
- Fixed **NextFrameEvent** update mode (it requires EveryFrame).
- Fixed **SetObjectProperty** not selecting the GameObject Active (Bool) property.
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

- Added **WaitForFrames** action.
- Added DidHit output to Raycast actions.

### Fixed

- Fixed null ref error when removing DataDefinition from a DataComponent.
- Fixed new state name when dragging some actions (e.g., Loop State or Tween actions) into the graph view.

## [2.0.0 beta 74] - 2026-7-4

### Changed

- Show relative path in search result action category headers.
- Allow IntegerRef and FloatRef write conversions in actions.

### Added

- Added **TransformMoveAwayFromPosition** action.
- Added **FloatSpring**, **Vector2Spring**, **Vector3Spring** for spring like oscillations.
- Added **TransformSquashAndStretch** and **TransformSquashAndStretch2D** actions. **FloatSpring** is a good input to control these if you want bouncy reactions.
- Added **RandomGetGaussian**, **RandomGetGaussianVector2**, **RandomGetGaussianVector3** and actions.
- Added **PostProcessStackV2 Addon** and **URP Volumes Addons** for post-processing control.
- Added a Hide button to **Addons Browser** to hide tags you're not interested in.
- Added experimental **Sketch Addon** and **Sketch Samples** for [Processing](https://processing.org/) style sketching.
- Added experimental **Image Processing Addon** for performant image processing.
- Added dotted lines to show **GotoState** connections in the Graph View.
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

- Better summaries for **DataTableAddRow** and **DataTableSetRowValues** actions.

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

- Added raycast outputs to **InputMousePickEvent** action.
- Added **NavMeshPathDebugDraw** action to debug NavMeshPaths.
- Added **NavMeshPathGetNextCorner** action to more easily use a NavMeshPath without a NavMeshAgent.
- Added documentation for [Global Variable Text Binding](https://hutonggames.com/playmaker/docs/guides/ui-widgets/helpers/global-variable-text-binding/).
- Added a few more controls to  **UIToolkit Samples**.
- Added screenshots for all samples in **Addons**.

### Fixed

- Fixed null exception errors **NavMeshCalculatePath** actions.
- Fixed disabling [Debug FSM](https://hutonggames.com/playmaker/docs/components/debug-fsm/) while playing.
- Fixed missing UI Tag in **UGUI Samples**.
- Fixed NavMeshPath variable icon.
## [2.0.0 beta 70] - 2026-6-13

### Changed

- Removed some internal PlayMaker methods from **CallComponentMethod** method selectors.
- Tweaked formatting of method return type in CallMethod actions.
- Improved the Save System Settings inspector.

### Added

- Added **TouchEvent** and **TouchObjectEvent** actions for the new Input System.
- Added **InputTouchEvent** and **InputTouchObjectEvent** actions for the legacy input system.
- Added **GetFsmState**, **GotoPreviousState**, and **GetPreviousStateName**.
- Added **ListGetLastItem**, **ListGetPreviousItem**, and **ListSwapItems**.
- Added some sound effects to **Space Shooter** sample.

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

- More work on **SpaceShooter Sample**. It's changed enough that you should delete the folder before re-importing it.
  - Re-worked movement tutorial to advance on player progress.
  - Added collect beacons flight training.
  - Added shoot sentry turrets combat training.
  - Added SOS mission and pirate ambush.
- Changed graph view Broadcast Icon to show events sent to other GameObjects (not just Broadcast Events).

### Added

- Added pasting of copied regions as new FSMs.
- Added Rect variable properties: center, position, and size.
- Added option to use first string field in the DataDefinition as the DataTable key.
- Added **UIToolkit Addon** and **UIToolkit Samples**. Not 100% complete, but should cover common UI needs.
- Added EnhancedTouch actions to Input System **Touch Addon** actions.
- Added TargetCone generator and validator blocks for [FindValidRandomPosition] action.
- Added TrueEvent and FalseEvent to **EvaluateBooleanExpression**.
- Added **TransformOnChildCountChanged** action.
- Added **FlickerCanvasGroup** and **FlickerGraphic** actions.
- Added Use Variable Tokens option to more actions. E.g. **GameObjectSetName**.
- Added **DebugVariable** action to debug a specific variable while in a state.
- Added Debug Panel Scale setting in **PlayMaker Settings**.

### Fixed

- Fixed Exclude Self in **BroadcastEvent**. It could sometimes interrupt ForEach loops.
- Fixed <, >, and & rendering in action summaries, e.g., in ExpressionEvaluator actions.
- Fixed re-importing Playmaker after previously removing it from the project.
- Fixed GlobalObjectId warnings after deleting assets.
- Fixed sample billboard components in URP.

## [2.0.0 beta 67] - 2026-5-24

### Interactables

- [Interactable system](https://hutonggames.com/playmaker/docs/guides/interactables/) has changed a bit in this release. This might require setup changes in your project.
- Added [Interactor component](https://hutonggames.com/playmaker/docs/guides/interactables/interactor-component/). Use **InteractorUpdate** instead of GameObjectUpdateInteractables (now obsolete).
- Streamlined [Interactable component](https://hutonggames.com/playmaker/docs/guides/interactables/interactable-component/). Added **Inside Trigger** and **Measurement Space** options.
- Added docking setup to [Interactable component](https://hutonggames.com/playmaker/docs/guides/interactables/interactable-component/). Used by **GameObjectDockWithInteractable** action.
- Added **PlayMaker > Browsers > Interactables** to browse all interactable objects in the scene.
- Reworked **First Person Samples** to use the new Interactor component and actions.

### Changed

- Improved action summary tooltips. Shows parameter name and description.
- Allow selection of compatible variable properties (not just exact types).
- Meter components now set the current value in OnEnable.
- Show regions in the minimap.

### Added

- Added **PlayMaker > Debug > Find Obsolete Actions** to make it easier to find deprecated actions.
- Added **RowNotFound** policy to DataTable actions like **DataTableGetRowValues**.
- Added constraints to **CharacterControllerClimb** action.
- Added a tilted ladder to ClimbLadder scene in **First Person Samples**.
- Added line docking to ClimbWall scene in **First Person Samples**.
- Added **RigidbodyPickUp**, **RigidbodyDrop**, and **RigidbodyThrow** actions. Updated Pickup and Throw scenes in **First Person Samples**.
- Added **Rigidbody2DPickUp**, **Rigidbody2DDrop**, and **Rigidbody2DThrow** actions.
- Added **RandomGetPointOffscreen** action and offscreen blocks for **FindValidRandomPosition** and **FindValidRandomPosition2D** actions.
- Added Enemy scenes to **Top-Down Shooter Samples**.

### Fixed

- Fixed actions that should be allowed to set null values. E.g., **ImageSetSprite**.
- Fixed **CharacterControllerClimb** action so LookDirection respect input direction. Forward moves in look direction, back moves in opposite direction.
- Fixed **CharacterControllerCheckIsGrounded (SphereCast)** action false positives.
- Fixed Stopwatch meter in **Shooting Gallery Sample**.

## [2.0.0 beta 66] - 2026-5-8

### Changed

- Improved transition and logging performance. This is actually fairly invasive, so please report any issues you encounter.
- Restored icon, name, and description editing in FSM Inspector.
- Changed **CharacterControllerJump** to output a jump velocity that you then use in "In Air" actions like **CharacterControllerMoveInAir**. This fixes hitches in the hand-off between Jump and other movement actions.
- Tweaked Jump scenes in **First Person Samples** to better handle falling and ramps.
- Moved Require Raycast Hit from actions to the Interactable component – it's part of the setup of an interactable object.
- Converted ButtonDoor buttons in **First Person Samples** to use Interactables.
- Only dim PlayMaker hierarchy icon if all FSMs on the GameObject are disabled.

### Added

- Added root canvas menu to make it easier to add a second FSM and select FSMs on a GameObject.
- Added **CharacterControllerMoveOnGround** action that applies downward velocity to stick to ramps etc.
- Added **FloatSelectValue**, **IntegerSelectValue**, etc. to select a value based on a Bool. They're conceptually similar to ConvertBoolToFloat etc. but with that emphasis on the target type.
- Added DebugInfo to **PhysicsCheckCollider** action.
- Added PressurePlateDoor scene to **First Person Samples**.
- Added logging tools to PlayMaker/Tools. If you have many FSMs updating often, you can disable logging on them to improve performance. The trade-off is the FSM Log and Debug Flow will not work on those FSMs. NOTE: Logging is always off in builds.
- Added a separate Enable Variable History setting in the Debug settings. Recording variable history can be expensive. The trade-off is that you won't see old variable values as you step Prev/Next states using Debug Flow.

### Fixed

- Fixed infinite loop checking in **Loop State** action with Forever setting.
- Fixed **ListFind** error with GameObjectList and Name tests.
- Fixed random null ref error when editing prefabs.
- Fixed Global variables losing type information.

## [2.0.0 beta 65] - 2026-5-6

### Changed

- FSM Component inspector header is now readonly. Click **Edit** to edit the icon, name, description, etc.
- Double-click Global Events and Variables to open them in browser windows.
- Tweaked Crouch scenes in **First Person** samples.
- Changed Inputs sync mode from a toggle to a popup menu.

### Added

- Added foldout to FSM Component inspector so you can collapse details.
- Added PerSecond, CanFinish, and FinishDistance to make all MoveTowards actions consistent. You can ignore FinishDistance by setting it to -1. You may need to set this in actions that previously used to run forever.
- Added [Interactable](https://hutonggames.com/playmaker/docs/guides/interactables/) component and **actions**. Use the [Interactables](https://hutonggames.com/playmaker/docs/guides/interactables/) system to manage interactions: set up interactions, select valid interactions, trigger interaction events, and end the interaction.
- Added UseInteractable scene and tweaked Elevator scene in **First Person** samples to show how to use Interactables.
- Added CharacterController actions: **ApplyGravity**, **ApplyPlatformMotion**, **Climb**, and **CheckIsGrounded** variants.
- Added MovingPlatforms, ClimbLadder, and ClimbWall scenes to **First Person** samples.
- Added Smooth Time to **Rigidbody** and **Rigidbody2D MoveTowards** actions.
- Added **ConvertStringToStringMap** action.
- Added **SendEventToRegion** action.

### Fixed

- Fixed FSM Component inspector performance issues.
- Fixed Regions not finishing when substates finished.
- Fixed last displayed tooltip sometimes re-appearing.
- Fixed double-clicking a variable in Variables list not focusing the name field.

## [2.0.0 beta 64] - 2026-4-28

### Fixed

- Fixed performance regression in beta 63.

## [2.0.0 beta 63] - 2026-4-27

### Changed

- Changed how Enum variables are serialized. Old saved data should be migrated.
- Tweaked prefab instance editing rules: See [docs](https://hutonggames.com/playmaker/docs/guides/editing-prefab-instances/) for more info.

### Added

- Added Unity 6.4 install package for 6.4+.
- Added prefab override indicators on nodes in the graph view.
- Show prefab override panel on all nodes (e.g. transitions, comments... )
- Added Revert and Apply to node context menus.
- Added Revert and Apply buttons to FSM component inspector.

### Fixed

- Fixed warnings in Unity 6.4.

## [2.0.0 beta 62] - 2026-4-23

### Changed

- Allow drag from the ActionSelectorPopup.
- Use ` shortcut to open ActionSelectorPopup. Configure in *Shortcuts > PlayMaker*.

### Added

- Added **TransformListSort**, **TransformListGetClosest**, and **TransformListGetFurthest** actions.
- Added **CharacterControllerCrouch** and **CharacterControllerCheckHasHeadroom** actions.
- Added crouch hold and toggle sample scenes to **First Person** samples.
- Added **InputConsumeKeyDown** action, for when you only want to respond to a key press once in a frame.
- Alt+Click a selected variable or event in the action editor to edit it in a popup editor.
- Added Input/Output settings to new variable editor in the variable selector.
- Added version info to addons.

### Fixed

- Fixed Revert All and Apply All errors on Nodes added in prefab instances.
- Fixed "Event not used..." error shown even when it is used.
- Fixed Recent action category not always updating.
- Fixed initial rotation in **InputMouseLook** action.
- Fixed tooltips on FSM component inputs.

## [2.0.0 beta 61] - 2026-4-21

### Event Changes

- If the sending state does not handle an event, it continues propagating upward through parent states and into other regions where appropriate.
- A region only processes a given event dispatch once, which makes accidental infinite loops less likely.

### Changed

- Made entering playmode smoother when not using fast play mode.
- Reset Action Browser search when opening instead of remembering last search.
- Tweaked Action Browser search to handle mixed space queries.
- Global Event in Events tab now shows usages in that FSM instead of all usages.
- Selecting a node while playing turns off Sync so you're not fighting auto-selection.
- Added keyboard shortcut to toggle Sync (Alt + S). You can change this in *Shortcuts > Playmaker*.
- Moved Update Inputs Every Frame setting from action Update Mode to the Inputs header, e.g., in **RunTemplate**.
- Consistency pass on Physics cast actions so they all have the same core parameters.
- Support asset relative paths in [EnumDefinitions](https://hutonggames.com/playmaker/docs/components/enum-definition/) output folder.
- Improved [EnumDefinitions](https://hutonggames.com/playmaker/docs/components/enum-definition/) so you can safely add and re-order enum items without updating FSMs that use the enum.
- Inline code blocks in Markdown are now rendered on their own line.
- Removed *Tools/PlayMaker/Clear Type Icon Cache*.

### Added

- Added Save Screenshot in Graph View FSM Context Menu.
- Added Inputs Sync Mode in Inputs header. Controls if inputs are applied once at start or every frame.
- Added **PhysicsSphereCast**, **PhysicsCapsuleCast**, and **PhysicsCapsuleCastAll** actions.
- Added RandomChild and RandomChild2D generators to **FindValidRandomPosition** actions.
- Added ProjectDownToSurface and SnapToGrid modifiers to **FindValidRandomPosition** actions.
- Added Tag to **Collision/TriggerEvent** actions (matches PM1 actions).
- Added LayerMask to **PhysicsOverlap** actions (you might need to set the layers in existing usages).
- Added HasOverlaps and NoOverlaps events to **PhysicsCheck** actions.
- Added **PhysicsOverlapCollider** and **PhysicsCheckCollider** actions that set-up overlap parameters using colliders.
- Added **CharacterControllerTeleport** action.
- Added CollectItems, Doors and Elevator scenes to **First Person Samples** addon.
- Added Found, FoundEvent and Not Found Event to **ListFind** actions.
- Added **ListAddUnique** action. Adds an item to a list if it doesn't already exist.
- Added support for Abs() in **ExpressionEvaluator** actions.
- Added support for {variable} in **DebugLog** and **SetText** actions. E.g., Go to {NextFloor} in {Duration} seconds
- Added **EventSystemInteractAtCursor** for world space UI. Gated by distance and works with locked cursors.
- Added Sent By... in Event/Transition context menus.
- Added **UGUI Samples**.

### Fixed

- Fixed Run Template inputs [bugs](https://hutonggames.com/playmakerforum/index.php?topic=26797.0).
- Fixed editor slowing down over time with fast play mode enabled.
- Fixed Previous FSM button not working after *Run Template > New*. It now takes you back to the FSM with the Run Template action.
- Fixed DataTableEditor scene in **DataTables** sample.
- Fixed BaseDelayedEventAction showing in convert menu.
- Fixed **ListFindLastIndex** action.
- Fixed errors when recompiling while playing.

## [2.0.0 beta 60] - 2026-4-8

### Changed

- Tweaked Action Selector Popup hover preview.
- Improved action selection menu when dragging variables into the Action list.
- Lots of GetSummary tweaks so action summaries are clearer and more consistent.

### Added

- Added documentation for [Action Blocks](https://hutonggames.com/playmaker/docs/actions/action-editor/#action-blocks).
- Added [Data Visualizer](https://hutonggames.com/playmaker/docs/components/data-visualizer/) component to bind gizmos to [Data Component](https://hutonggames.com/playmaker/docs/components/data-component) fields.
- Added **Cinemachine3** addon (Unity 6+). First pass at actions, focusing on clear runtime usages.
- Added **Splines** addon for Unity.Splines support. Runtime spline editing will be supported in a separate addon.
- Added core **PlayableDirector** actions as builtin. Advanced actions are still in the **PlayableDirector** addon.
- Added **FindValidRandomPosition** and **FindValidRandomPosition2D** actions. These let you use one or more validators to check random positions, e.g., not in collision with another object, minimum clearance from tilemap walls, etc.
- Added [ImageSpriteMeter](https://hutonggames.com/playmaker/docs/guides/ui-widgets/meters/image-sprite-meter/) widget and actions.
- Added color gradient to [Meter Label](https://hutonggames.com/playmaker/docs/guides/ui-widgets/meters/meter-label/) component.
- Added Ctrl-Click shortcuts to open [Events](https://hutonggames.com/playmaker/docs/fsm-editor/events-inspector/) and [Variables](https://hutonggames.com/playmaker/docs/fsm-editor/variables-inspector/) tabs in new window.
- Added more scenes to **Third Person** sample.
- Added **MathfMapRange**, **MathfDistanceFalloff**, and **AnimationCurveEvaluateRange** actions.
- Added **TransformMatchTarget** action.
- Added **Meter Widgets** sample.

### Fixed

- Fixed pasting Regions. Always creates a new Region instead of pasting substates.
- Fixed Markdown check boxes in [PlayMaker Notes](https://hutonggames.com/playmaker/docs/components/playmaker-notes) components. Changes are now saved.
- Fixed action quick filters not working in nested categories (e.g. "t look at").
- Fixed max acceleration in **Transform Track Position** action.
- Fixed action selector preview size bug.

## [2.0.0 beta 59] - 2026-3-31

### Changed

- Simplified how we pick an invader to shoot in the **Invaders** sample game.

### Added

- Added UPM dependency support for sample packages.
- Added [TilemapMinimap](https://hutonggames.com/playmaker/docs/guides/ui-widgets/target-managers/tilemap-minimap/) widget and actions. Used in **Lander** sample game.
- Added [ImageMinimap](https://hutonggames.com/playmaker/docs/guides/ui-widgets/target-managers/image-minimap/) widget and actions. Used in **Minimaps** sample.
- Added **InputMouseOrbit** action. Used in **ThirdPerson** sample.
- Added more scenes to **ThirdPerson** sample.
- Added **Zoom Sensitivity** in **PlayMaker Settings**.

### Fixed

- Fixed **Procedural** samples. It needs the **2D Tilemap Extras** package.
- Fixed **Invaders** HighScores table.
- Fixed errors when deleting Variables used as a property in an action.
- Fixed Markdown links in all samples.
- Fixed zoom speed on Mac.

## [2.0.0 beta 58] - 2026-3-28

### Changed

- Better DataRow comparison UI in DataTable find actions.
- Unparent children before destroying in **GameObjectDestroyChildren** action so ChildCount returns 0 immediately.

### Added

- Added Prefab, Instance, and Template headings in the graph view.
- Added FSM Pause Mode in Advanced Settings. Works with the [Pause System](https://hutonggames.com/playmaker/docs/actions/time-actions/pause-system/)
- Added action category navigation in search results. Click a category to narrow the search. Click Back to widen the search.
- Added DataDefinition find usages in DataComponents and DataTableComponents.
- Added High Scores and difficulty progression to **Invaders** sample game.
- Added **FloatAddWrap** and **IntegerAddWrap** actions. Adds and then wraps a value.
- Added **RigidbodyTranslate** and **Rigidbody2DTranslate** actions using MovePosition.
- Added **TransformSnapToPixelGrid** action.
- Added **WaitForFsmFinished** action.
- Added AutoGroup option to GroupAssets.
- Added Input/Output support to more variable types.

### Fixed

- Fixed Markdown links in FsmTemplateComponent descriptions.
- Fixed version control noise in FsmTemplateComponents.
- Fixed tilemap seams in **Zombie Survivor** sample.
- Fixed errors when recompiling while playing.

## [2.0.0 beta 57] - 2026-3-24

### Changed

- Added **Gameplay** action categories. Higher-level gameplay actions were mixed in with lower-level API actions. This organization should make it easier to find gameplay actions.
- Preserve Event Data when changing Transition event if possible.
- Resize nodes around center when edited.

### Added

- Added asset reference support in [Save System](https://hutonggames.com/playmaker/docs/guides/save-system/).
- Added local DataTable variable support in the FSM.
- Added support for [UI Navigation](https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-table-navigation/) in DataTableWidget.
- Added **Update Label** option in [FilledImageMeter](https://hutonggames.com/playmaker/docs/guides/ui-widgets/meters/filled-image-meter/) and [TiledImageMeter](https://hutonggames.com/playmaker/docs/guides/ui-widgets/meters/tiled-image-meter/) widgets.
- Added **Timer** type and actions.
- Added **SetValues** actions for Meter Widgets. E.g. set min and max values as well as the current value.
- Added [SpriteMeter](https://hutonggames.com/playmaker/docs/guides/ui-widgets/meters/sprite-meter/) for meters made using a sprite.
- Added **SendEventToScenePath** action.
- Added **SkipLoop** action variants.
- Added access to Owner properties in [Variable Selector](https://hutonggames.com/playmaker/docs/actions/action-editor/variable-selector/). E.g., Owner.name etc.
- Added [Group](https://hutonggames.com/playmaker/docs/components/group-asset/) support to [DataTable Assets](https://hutonggames.com/playmaker/docs/components/data-table/).
- Added **Data Table Browser**.
- Added **DataTableGetSelection** and **DataTableSetSelection** actions.
- Added **DataTableFindRow** and **DataTableFilterRows** for data table queries.
- Added Enemy Waves sample to **Data Tables** sample.
- Added Level Ups to **Zombie Survivor**. Uses the new data workflow.
- Added ObjectPool max size policy.

### Fixed

- Fixed events not sent to FSMs that are not active yet in that frame.
- Fixed re-ordering DataTable rows in Inspector.
- Fixed duplicated DataDefinition fields editing the same field.
- Fixed Fsm Component description and error icon not updating immediately.
- Fixed actions sometimes changing global variable default values instead of runtime values.
- Fixed DataRecordList items added in Variables Editor not being unique instances.
- Fixed groups not showing in **Data Definition Browser**
- Fixed version control noise in prefabs after playing in the editor.
- Fixed converted actions not always keeping update mode.
- Fixed FsmTemplateComponent not showing description.
- Fixed Serializable warnings in 6.3+.

## [2.0.0 beta 56] - 2026-3-1

### Added

- Added [DataItemAction](https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-table-widget/#components-used) components send UI events to the FSM on the root item. E.g., **OnEndDrag** event.
- Added **OnLongPress** system event. Also sent by [DataItemLongPressAction](https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-item-long-press-action/) component.
- Added [DataTableWidget](https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-table-widget/) animation for re-ordering and adding/removing rows.
- Added **Then By** to **DataTableSort** action.
- Added **Leaderboard** scene in **DataTable sample**.
- Added **Spacer** items in editor list views.
- Added **Get/SetFsmXXXList** actions.

### Fixed

- Fixed [DataTableWidget](https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-table-widget/) not always updating while playing.
- Fixed **DataTableSetCellValue** action not detecting the cell value type.
- Fixed duplicate variables when copy/pasting into a [Data Definition](https://hutonggames.com/playmaker/docs/components/data-definition/).
- Fixed "Use Constant Value" not always updating the UI in Input Controls.
- Fixed List.Count property selection in Variable Selector.
- Fixed deleting Groups in Event Controls.

## [2.0.0 beta 55] - 2026-2-26

### Added

- Added Button Filters to **uGUI Event actions**.
- Added **EventSystemRaycastAll** and **EventSystemClickEvent** actions.
- Added RaycastResult variable and **actions** for uGUI Raycasts.
- Added Vector2 **LowPassFilter** and **HighPassFilter** actions.
- Added Vector3 **LowPassFilter** and **HighPassFilter** actions.
- Added a lot of missing action help pages.

### Fixed

- Fixed pooled object not being destroyed when released and the pool is gone.
- Fixed occasional errors when alt dragging transitions.
- Fixed FSM Editor losing Lock when another window was maximized.
- Fixed controls in locked list views still being editable. E.g., Icon button in groups, comment text.
- Fixed action search sometimes failing (e.g., Set Float Value)
- Fixed debug values field not updating when converted variable values change.
- Fixed stable FSM Component guids in assets.
- Fixed help links in many actions.

### Removed

- Removed **Enum** type from **Set FSM Variable** action. Use **Set FSM Enum** instead.

## [2.0.0 beta 54] - 2026-2-20

### Added

- Added more online help for the data workflow.

### Fixed

- Fixed null errors when selecting Use Variable in template inputs.
- Fixed GotoState action not exiting parent states.
- Fixed Pool Clear actions not deleting instances in the scene.

## [2.0.0 beta 53] - 2026-2-19

### Changed

- Changed some data component naming. You might need to re-add or edit existing usages.

### Added 

- Added item selection and item actions to **DataTableWidget**.
- Added a **TableEditor** scene in **DataTables** samples to show how to use **DataTable** item actions.
- Added an auto-bind option for **Data Item UI** components. Tries to match UI to data field names.
- Added **TargetData** scene to **First Person** samples. Shows how to add custom data to GameObjects.
- In play-mode, *Shift+Click* a transition to send its event. *Shift+Click* anywhere else to select an event to send.

### Improved

- Better Data component editors. 
- Better DataTable UI. Supports multi-select and move.
- Added Touch support to [WaitForAnyKeyDown]() action.

### Fixed

- Fixed bug re-entering Parent State with multiple Regions.
- Fixed ObjectPool errors after reloading scenes.
- Fixed **WaitForVariableValue** with value types.
- Fixed **OnVariableValueChanged** not triggering with null Object values.
- Fixed compile errors when new Input System is enabled but not imported.
- Fixed summaries in **Resources Load** actions.
- Fixed **ConvertSecondsToString** format field.
- Fixed error when Alt+Clicking on a global transition.
- Fixed play-mode Send Event shortcut conflict.

## [2.0.0 beta 52] - 2026-2-10

### Action Browser

- Improved search results using aliases for common types:
  - For type hierarchies. E.g., **Image Set Color** returns **Graphic Set Color**.
  - For legacy PM1 action names. E.g., **SampleCurve** returns **AnimationCurveEvaluate**.
  - For common synonyms. E.g., searching for "follow" will find actions with "towards" and vice versa.
- More focused results for get/set action searches.
- Use quotes for exact phrase matching, e.g., "set text"
- Cleaner formatting of search results.
- Added **Show Preview** option in settings menu.
- Improved **Recent** and **Favorites** management.

### Added

- [DataDefinitions](https://hutonggames.com/playmaker/docs/components/data-definition/) and [DataTables](https://hutonggames.com/playmaker/docs/components/data-tables/). See **DataTables Sample**.
- [EnumDefinition](https://hutonggames.com/playmaker/docs/components/enum-definition/) assets to make custom enums (similar to Enum Creator Wizard in PM1).
- [Target Manager UI Widgets](https://hutonggames.com/playmaker/docs/guides/ui-widgets/target-managers/). OffscreenIndicator, TargetIndicator, and Radar widgets. Minimap coming soon.
- **TransformRandomize** action to randomize position, rotation, and scale.
- **TextAsset** actions.
- **InputActionMouseVirtualJoystick** action for joystick like input using the mouse.
- **InstantiateRandomObjectsInBox** and **InstantiateRandomObjectsInSphere** actions.
- **Async Scene Loading** actions.
- **Flight System** (components and actions) for 3d flight AI and movement.
- **TransformFastProjectile** action for fast-moving projectiles like laser bolts. 
- **TransformGetNextSibling** and **TransformGetPreviousSibling** actions.
- **FxDriver** actions to map values to various fx.
- **Stat** actions that combine math and threshold events.
- Added Error Icon in FSM Component inspector if the FSM has errors.
- Added Alt and Ctrl shortcuts to UpdateMode button.
- Added Shift+Alt+Click shortcut to delete a transition.
- Added Alt+Click shortcut to create a new target state from a transition. This is quicker than Alt dragging a new target state. The new state's position is determined by where you click in the transition.
- Added Component enable/disable actions that automatically find the proper enabled property on the target. E.g., a CharacterController is a Collider not a Behaviour.
- Added UI Value Changed system events. E.g., OnToggleValueChangedEvent.
- More Convert actions.
- New **Space Shooter Sample** (WIP). Uses:
  - **InputAction** actions (new InputSystem) for keyboard controls.
  - **InputActionMouseVirtualJoystick** for mouse movement.
  - **Flight** actions for flight controls.
  - [Target Manager UI Widgets](https://hutonggames.com/playmaker/docs/guides/ui-widgets/target-managers/) for targeting.

### Improved

- Organized Variable Type Selector.
- Organized Logic action category.
- Added icons for various types.
- Update Variable Property values in debug field. E.g., GameObject.position

### Fixed

- Fixed event data sometimes not copied with transition.
- Fixed usages not found in nested properties.
- Fixed missing custom editors, e.g., for NavGrid assets.
- Fixed search result exposing rich text tags.
- Fixed errors thrown by actions when the app was quitting. E.g., trying to instantiate objects.
- Fixed duplicate tooltips on elided action fields.

### Removed

- Removed ContactPair actions and variables. They are part of a low-level physics API that we would need to do more work to integrate properly.

## [2.0.0 beta 51] - 2025-12-5

### Added

- **InputActionMap** and **InputActionAsset** actions for new [Input System](https://hutonggames.com/playmaker/docs/actions/input-system-actions/).
- **InputActionReadFloatValueSmooth** action that smooths the value.
- **GetFsmComponent** action to get an FSM Component on a GameObject by name.
- **GetFsmTemplateComponent** action to get an FSM Template Component on a GameObject.
- **GetFsmNames** action to get the names of all FSMs on a GameObject.
- **ParticleSystemWrapInSphere** action. For starfields, rain, snow, etc. that surround the player.
- Use **Alt+Up/Down** to move selected items up/down in editor list views (e.g. Actions List).

### Changed

- **InputAction** actions now use **InputActionReference** instead of **InputActionProperty**. This means no inline InputActions (Unity has moved away from inline InputActions). You will need to re-assign InputAction references in existing projects.
- **InputAction** actions no longer auto-enable the action. Instead, use **InputActionMapEnable** or **InputActionAssetEnable** actions.
- Changed **ParticleSystem** action namespace. You will need to replace ParticleSystem actions in existing projects. If you have many, you can search/replace in scene/prefab files: `HutongGames.PlayMaker.Actions.ParticleSystem` -> `HutongGames.PlayMaker.Actions`
- Added World/Local Space option to **RigidbodySetVelocity** actions.

### Fixed

- Fixed mouse system events (OnMouseDown etc.) when only the new Input System is installed.

#### Get/SetFsmVariable actions:
- Fixed error when linking to a variable in a group
- Fixed editing of variable names. Was snapping back to the linked variable's name.
- Log a warning at runtime if the name is ambiguous. (e.g., `Health` with `GroupA/Health` and `GroupB/Health`)


## [2.0.0 beta 50] - 2025-11-30

### Added

- [Buffered Input actions](https://hutonggames.com/playmaker/docs/actions/input-actions/buffered-input/) for jump buffering, coyote time, input chords, etc.
- Added missing WheelCollider Friction actions.

### Changes

- Added browse button and variable links for [Get/Set FSM Variable](https://hutonggames.com/playmaker/docs/actions/state-machine-actions/get-fsm-variable/) actions.
  NOTE: This requires new data. Old data is migrated in this release but will eventually be removed.
- Made common legacy input actions work with the new input system (e.g., all keyboard and mouse actions, and button and axis actions with default Input Manager names)
- Most Device actions (e.g., Accelerometer, HumiditySensor, etc.) now use `[device].current` and no longer have variables. 99.9% of devices have only one sensor.
- Changed Gamepad actions to use Gamepad Index. Removed Gamepad variables. Added a few utility actions.
- Tweaked MouseLook sensitivity. Exposed inputs in First Person samples.

### Fixed

- Performance: Fixed editor performance issues in beta 49.
- Samples: Updated all sample scenes to work with both the old and new input system without changing project settings.
- Editor: Fixed selection of Global Events and Variables in Project Browsers in Unity 6+
- Editor: Fixed finding variable usages in Run Template action.

## [2.0.0 beta 49] - 2025-11-21

### New

- [Save System](docs:guides/save-system/) to save/load FSM and global variables.
- [NavGrid](docs:guides/nav-grid/) system and actions for movement and pathfinding on a 2D grid.
- [UI Widget](docs:guides/ui-widgets/) components and actions for common Game UI.
- [Prefab Override](docs:guides/editing-prefab-instances/#prefab-overrides) info and options in FSM and Node Inspectors.
- MazeChase game sample. A complete pac-man style game.
- Lander game sample. Simple Lunar Lander game.

### Changes

- Events are now processed [bottom up](docs:actions/event-actions/#hierarchical-event-flow) (deepest active sub-state -> root). This is pretty standard for hierarchical FSMs, but it might result in subtle changes in your existing FSMs.
- Graph View: Added a turn-cost to Node links. Circuit links in particular should behave better.
- Action Editor: Changed "playing" icon back to a green-tinted toggle (like PM1).
- Hierarchy Icon is dimmed if FSM Component is disabled.
- Graph View: Made Minimap opaque.

### Actions

- Removed **Keep Largest Region** from Procedural Generators. Use [Filter](action:FilterCellsKeepLargestRegions) instead.
- Added Procedural Generation Filter actions.
- Added **Keep Existing** to BuildRandomRects action. For example, to seed the list with a Start Room and an End Room with other rooms generated around them.
- Added ListSum and AddMultiple actions for float, integer, Vector2 and Vector3 variables.
- Added Tilemap Snapshot actions for saving/restoring tilemaps.
- Added BoundsInt addon.
- Added AnimationCurveSetValue action.

### Fixed

- ActionBrowser: Fixed search in categories with multiple parts. E.g., Curve now finds AnimationCurve actions.
- Fixed renamed global events and variables updating in the FSM Editor.
- Fixed double-clicking an item in Events/Variables tab to focus the name field (for quick editing).

## [2.0.0 beta 48] - 2025-10-30

### Actions

- Added Tilemaps support as an Addon (also Clear and Fill variants to replace the Unity BoxFill, which is terrible!).
- Added Procedural Generation actions and samples. So far: Boids, random characters, various map generators.
- Added LoopGrid2D action. Great for looping through x/y positions.

### Editor

- Added **Skip Active State** option to Global Transitions to not re-enter a state if it's already active.
- Change Lock behavior for **Groups** and added Lock toggle. See [this thread](https://hutonggames.com/playmakerforum/index.php?topic=26652)
- Ctrl+Click **Add Global Event/Variable** buttons to open browsers.
- Changed Variable Toggle selected icon. Was an X to indicate "Click to remove variable," but it was confusing when used in a list view (it could mean remove the list item).
- Don't remove variable references when hidden in the UI. Instead, the usage finder will show that the usage is hidden.
- Tweaked Group title size.

### Fixed

- Fixed drag and dropping multiple items into list parameters in an Action.
- Fixed parsing errors in EvaluateBooleanExpression action.
- Fixed UI hitches in Icon Popup. Time-slice loading icons.
- Fixed exception when trying to set a Vector3 variable assigned to a Vector2 field.
- Fixed very long strings (and UI warnings) when debugging list variables. String is truncated now with "+ x more items" at the end.
- Markdown: Fixed rendering of wide tables.

## [2.0.0 beta 47] - 2025-10-20

### Editor

- Added keyboard navigation, transition shortcuts, and animated framing in Graph View.
- Use short event and variable names in UI labels.
- Use either short or full variable name in Get/Set FSM Variable actions.
- Use either short or full event name in Send FSM Event action.
- Fixed duplicate events when copy/pasting events.
- Made Group title font and icon a little bigger.

## [2.0.0 beta 46] - 2025-10-17

### Actions

- Added **Inclusive** option to RandomGetIntegerInRange action.
- Added **Falloff** curves to RandomGetPointInCircle and RandomGetFloatAroundCenter actions.
- Fixed distribution in RandomGetPointInRectRing action.
- Nicer display names in Get/SetComponentProperty actions. The actual property name is still visible as a tooltip.
- Updated [Script Action docs](https://hutonggames.com/playmaker/docs/actions/script-actions/) with a video showing how to drag and drop components.
- Updated [Transform](https://hutonggames.com/playmaker/docs/actions/transform-actions/) and [Random Actions](https://hutonggames.com/playmaker/docs/actions/random-actions/) docs.


### Editor

- Added obsolete action support:
  - Added obsolete action warnings in Action Editor. Displays any message set in the ObsoleteAttribute.
  - Hide obsolete actions in Action Browser (still shown if you use **Find In Action Browser**).
  - Use **Show Obsolete Actions** setting to show obsolete actions in the action list.
  - Obsolete actions continue to work, but you should replace them with the recommended action.
- Unifying pass on **TransformLookAt** and **TransformMoveTowards** actions:
  - Added **SmoothTime** and **MaxSpeed** to all LookAt and MoveTowards actions.
  - Added **Facing Axis** and **RotationConstraint** to Lookat actions. You might need to set the facing axis again, Z (Forward) for a regular 3D look at.
  - Renamed **TransformMouseLook2D** to [TransformLookAtMouse2D](action:TransformLookAtMouse2D).
  - Made old **TransformSmoothLookAt** actions obsolete.
- Added **Known Issues** section to the Welcome Window.
- Fixed Action Browser scroll position jumping when selecting actions.

## [2.0.0 beta 45] - 2025-10-13

### Actions

- Added OnAnimationEvent action. Use *FsmComponent > OnAnimationEvent* method as the event Function in the AnimationClip.

### Editor

- Fixed pasting regions in the Graph View.
- Added *Paste As Substates* to state nodes in the Graph View.
- Fixed Icon Selector not having an empty slot to select None.
- Handle "Group/Name" format in Event and Variable names better. See this [thread](https://hutonggames.com/playmakerforum/index.php?topic=26639.msg113629#msg113629)
- Fixed Global Variable changed event getting sent when the variable was selected in the inspector.
- Fixed validation of transitions after pasting (e.g., so they don't link to states in another region hierarchy).

## [2.0.0 beta 44] - 2025-10-11

### Changed

- Find variable and event usages in disabled actions. (We still don't look for errors in disabled actions, but might add this as a setting.)
- Find variable usages in string expressions, e.g., `{Health}`
- Better Acronym matches in search (e.g., t2 finds Texture2D, ue finds UnityEvent).
- Highlight search matches in variable type selector.
- API: Added OnStateEnter and OnStateExit to BaseAction.
- API: Removed OnInitialize from BaseAction.

### Removed

- Removed actions that used undocumented Unity code: 
  - CameraGetSceneViewFilterMode (editor only)
  - MathfGamma
  - GetKEpsilon actions
  - Static Magnitude actions (use GetMagnitude instead)
  - Static SqrMagnitude actions (use GetSqrMagnitude instead)
  - TimeGetRenderedFrameCount
  - ContactFilter2DGetNormalAngleUpperLimit

### Added

- Added EvaluateBooleanExpression action, e.g., `{Health} > 0 && {Health} < 100`
- Added support for variable properties in expressions, e.g., `{Position.x}`.
- Added CheckFloat and other type-specific variations on the CheckVariable action.
- Added CheckDistance action.
- Added Ignore Z option to TransformLookAtTarget2D action.
- Added Max Speed parameter to LookAt actions.
- Added Smooth Time parameter to SmoothLookAt actions.
- Added TransformSmooth actions. These are post-process actions that continuously smooth out previous changes to the transform.

### Fixed

- Fixed error in console when dragging actions with Weighted Lists, e.g., GetRandomGameObject
- Fixed (PerSecond) appearing in summary when Per Second was not set.
- Fixed TODO descriptions in default actions.
- Faster Icon Picker when first opened.

## [2.0.0 beta 43] - 2025-10-02

### Changed

- Allow sending Finished event in SendEvent.
- Send Finished event in ListGetNextItem if list is empty.
- Resized pickable node Icons to 64 x 64. They were 128 x 128 to support using them as larger images on the canvas, but 64 x 64 is probably fine.

### Added

- Added First Person Shooting samples.
- Added Spawning samples.
- Added more GettingStarted samples (LoopNextItem, WaitActions).
- Added custom KeyCode popup (instead of the long enum menu).
- Added "Open in new FSM Editor" context menu item in the Finder window. The FSM Component needs to be loaded to see it (not in an unloaded scene).
- Added more RaycastHit variable properties, including **normalRotationUp** and **normalRotationForward** for aligning instantiated objects to the hit surface.
- Actions:
  - Added AnimationCurveEvaluateScaled action. Use an animation curve to scale a variable, e.g., scale *Damage* with *Distance* using a *Damage Falloff* curve.
  - Added RandomGetDirectionInSphere and RandomGetDirectionInCone actions.
  - Added ObjectCheckIsNotNull action (reads better than ObjectCheckIsNull false in some situations).
  - Added InputButtonEvent and InputKetEvent actions. Sends an event while the button is down (vs. when pressed or released).
  - Added Vector3Rotate and QuaternionMultiply actions.
  - Added Multiplier and InvertDirection options to AddForce actions.
  - Added Multiply and Divide options to Vector3Operator.
  - Added RandomGetFloatAroundZero action. Useful shortcut for getting a float in a positive/negative range.
  - Added PerSecond option to Lerp actions. Use EveryFrame + PerSecond and set T to the lerp speed (1 = 1 second).
  
### Fixed

- Fixed Next State errors with multiple Regions.
- Fixed undo errors in Comment editor.
- Fixed group item undo (properly handles renaming).
- Fixed Debug FSM component not showing info after being disabled/enabled.
- Fixed variable and event usages not found inside Run Template action.
- Fixed output event selection in Run Template action.
- Fixed errors trying to quick add variables when we don't know the data type.
- Removed **Popup Asylum/Capture Inspector** menu item.
- Markdown: Fixed error with leading spaces.

## [2.0.0 beta 42] - 2025-09-25

### Changed

- Better summary for ConditionTests in ListFind, GameObjectFindFirstMatch, etc.
- Disable Debug Flow if the variable list changes while playing (e.g., if you add or remove variables).

### Added

- New Welcome Window.
- Added more Getting Started scenes.
- Actions:
  - Added Include Inactive parameter to Find actions.
  - Added GameObjectFindAllMatches action.
- Shortcut Links: Hovering over the to button shows all transitions to the state.
- Links: Tooltips show multiple transitions if they overlap.

### Fixed 

- Fixed Debug Flow Prev/Next button
- Fixed Tween Transform Scale z value.
- Fixed Object Pool window hanging the editor when a pool was added.
- Fixed List Sort with GameObject variables. Added a default sort by name for Unity Objects.

## [2.0.0 beta 41] - 2025-09-20

### Changed

- Added Start/EndValues to AnimateFloat actions. You will need to set these new parameters if you've used these actions.
- Added Check parameter to FloatSwitch. The check defaults to Equals, which is different from the old default behavior (less than).
- Added Check parameter to StringSwitch. Defaults to Equals, so should behave the same, but now you can check for Contains, StartsWith, and EndsWith.
- Simplified StringEquals to be consistent with other Equals actions. Use CheckStringEquals for True/False events.

### Added

- Added more Getting Started samples.
- Added Sent By section to Transition Inspector. Use this to store sent by information from the event.
- Added player and pickups to PixelPlatformer sample.
- Added an infinite terrain and level up system to ZombieSurvivor sample.
- Variable Selector: 
  - Added Transform name and parent properties.
  - Added Collider2D Rigidbody2D property.
- Actions: 
  - Added ParticleSystem actions.
  - Added Relative option to Tween actions (tween to an offset value).
  - Added Collision2DGetContact action.
  - Added Center parameter to RandomGetPointInCircle and RandomGetPointInRect.
  - Added SpriteRendererSetAlpha action, to set alpha separately from color.
  - Added RandomGetPointOnRect, RandomGetPointInRing, RandomGetPointInRectRing, RandomGetPointInCollider2D, and RandomGetPointOnCollider2D actions.
  - Added TransformMoveAwayFromTarget, TransformCheckHasChild, TransformCheckHasChildren, TransformFindAncestor, and TransformCheckIsVisible actions.
  - Added GameObjectSetChildrenActive and GameObjectActivateChildren actions.
  - Added more AnimateFloat actions.
  - Added SceneGUI to RandomGetPointXXX actions.
  - Added IntegerSwitch and IntegerThresholdEvent actions.

### Fixed

- Fixed copy/pasting global variables between FSMs. Was pasting as a new local variable.
- Fixed null ref errors in CallStaticMethod and CallComponentMethod actions.
- Fixed pasted states sometimes having appended numbers when not needed.
- Fixed initialization order of pooled objects.
- Action Browser: Fixed Show Used Actions Only option not showing actions in nested categories.
- Actions: Round Euler display of Quaternion rotations so, for example, entering 20 doesn't become 20.00001
- Markdown: Fixed ordered list numbers not rendering.
- Fixed an error when pausing after adding a variable while playing. There are probably some rough edges still when editing FSMs while playing.

## [2.0.0 beta 40] - 2025-09-11

### Added

- Minimap now shows active states while playing.
- Added Getting Started samples and online documentation.
- Addons Browser now uses Markdown on the description page. This Markdown document can also be found in the sample's root folder after importing.
- You can now click an action in the Addon Usages list to open it in the Action Browser.
- Actions: Added StringTypewriter and TransformShakePosition actions.

### Fixed 

- Fixed renaming a state in the graph view not updating the name in the inspector.
- Event Selector: Fixed System Events not sorting alphabetically.
- Actions: Fixed TransformRotateX and TransformRotateY (they were rotating on Z).
- Actions: Fixed RigidBodySetDensity obsolete warning in Unity 6.1+.

## [2.0.0 beta 39] - 2025-09-06

### Changed

- Changed GetFloatPerSecond float parameter to FloatVar. You will need to re-set this parameter wherever it's used in your project.
- Finished ShootingGallery game sample. It's a good demo for a lot of simple game systems.
- Text-only comment items in list views are slightly dimmed to reduce visual clutter. A comment is considered text-only if it does not start with '#' (a Markdown header). Markdown is not dimmed because we assume the information is more important.

### Added

- Added TweenTransform actions.
- Added TransformGetLocalPosition2D and TransformMoveTowardsLocalPosition actions.
- Added Input/Output support to more list variable types.

### Fixed

- Fixed assigning converted Global Variables in actions.
- Fixed event usages not found in global transitions. Fixes used count and copy/paste.
- Fixed FSM Editor breaking the open prefab arrows in the hierarchy window.
- Fixed conversion of Transform variable to Component. E.g., Using Transform in Get/Set FSM actions.
- Fixed quick add variable shortcut occasionally adding list data type instead of data type.
- Fixed the changed event not being sent when editing a global variable value in its inspector.
- Fixed undo/redo when locking/unlocking transition ports in the graph view.
- Fixed auto-selection of Template when selecting a GameObject with a PlayMaker FSM (Template) component.
- Fixed the empty hint in the graph view to open the prefab when selecting a prefab in the project view.

## [2.0.0 beta 38] - 2025-09-02

### Changed

- API: Changed the BaseVariableProperty signature. If you made any custom variable property types, you need to add the variable data type as a generic parameter.  
For example: `public class FloatIsNegativeVariable : BaseVariableProperty<float, bool>`
- Reorganized samples. Split Core Samples into separate packages for easier searching and updating.

### Added

- Added Enabled toggle on regions in Region Inspector. Use this to enable/disable regions while testing.
- Added Component to Transform conversion, so you can select Component variables in Transform actions.
- Added Goto Parent Group button and Child Groups list to Group Inspector.
- Added Enum actions: Get/Set FSM Enum, Enum Equals and Enum Check Equals.
- Added Prev/Next buttons and shortcuts to Usage finder windows.
- Added PlayMaker/Documentation asset. Use Markdown to document your project.
- Added AnimatorSetTriggerRepeated action.

### Fixed

- Fixed entering negative numbers in Quaternion fields.
- Fixed Tween UI not updating after adding/removing blocks.
- Fixed image aspect ratios not adapting to layout in Markdown render.
- Fixed accessing global variable properties in Variable Selector.
- Fixed finding Global Events and Variable usages in the Finder.
- Fixed the Alt key sometimes getting stuck in the Graph View (it would act like you were alt-dragging).
- Fixed broken editor UI if an action editor throws an exception. Instead, it shows an error box and gives you options to fix the problem.
- Verify update mode when converting actions (sometimes the new action needs a different update mode).

## [2.0.0 beta 37] - 2025-08-25

### Changed

- Added Markdown support in more places:
  - State and node descriptions.
  - Comment nodes and list items. 
  - Removed separate Notes node and list item. Use Comments instead.
  - Removed Icon control from comment nodes and list items. Use Markdown instead. I debated this, but the duplication didn't make sense. It's a little more work to add an icon in Markdown, but a lot more flexible. And hopefully, the Markdown editor will evolve over time.
  - NOTE: Markdown formatting is a little different from plain text, so you may need to reformat existing comments (e.g. paragraph breaks).
- Improved navigation and focus handling in the Finder window.
- Incremented the database version. You may see a console message about updating the database.
- Renamed System Events: InputSystem category to UI Events because the events are not specific to the new Input System.
- Removed duplicate GameObjectGetIsActive and GameObjectGetIsActiveInHierarchy actions. Use GameObjectGetActiveSelf and GameObjectGetActiveInHierarchy instead.
- Renamed Mathf GetClamp actions to GetClamped.

### Added

- Added new sample games: PinWheel based on the "aa" mobile game and BlockDodger. These are good samples to get started—simple but still doing some interesting stuff.
- Added Add Global buttons to Events and Variables inspectors.
- Added Open Prefab button to Selection Toolbar when editing a prefab instance.
- Added prev/next error buttons to Debug Toolbar.
- Added Usages section to Addons Preview. Currently shows used actions.
- Added Samples section to Action Browser Preview. Shows if the action is used in any samples.
- Added ConvertEnumToInteger action and intValue property to convert enums to an int value.
- Alt-clicking a group foldout opens/closes all groups in the list.
- Finder Scene Item tooltip shows Ctrl/Cmd tip to load the scene additively.
- Added Ping Object to asset records in Finder.
- Added more info to proxy event components.
- Added Float Variable Negate property.
- Added Integer variable properties.

### Fixed

- Better handling of prefab overrides in the editor.
- Fixed Finder search results when Asset Paths or Scene Paths were checked.
- Fixed ugly undo labels with cryptic property paths. If you still see any, please post on the forums.
- Fixed some light theme styles (watch variable labels, play icons...)
- Fixed Alt-Click in Inspectors conflict with Alt-Clicking foldouts.
- Fixed Finder Hierarchy view if the loaded scene asset was deleted.
- Fixed display of errors inside Switch action lists.
- Fixed selection issues in Addons Browser.

## [2.0.0 beta 36] - 2025-08-05

### Fixed

- Fixed list actions with GameObject variables.
- Fixed missing URP materials in samples.
- Fixed the installer still showing the currently installed version after removing the package.

## [2.0.0 beta 35] - 2025-08-04

### Fixed

- Fixed list variable selection.
- Real fix for output variable selection bug.

## [2.0.0 beta 34] - 2025-08-02

### Changed

- Improved Run Template summary in action titlebar. Shows inputs and outputs with tooltips.

### Added

- OnControllerColliderHit action and ControllerColliderHit variable debugging.
- Added missing actions to ConfigurableJoint addon.
- Added UnityEvent variable Input option.

### Fixed

- Fixed errors when Legacy Input System is not installed (e.g., default 6.1 installation)
- Fixed errors when re-ordering FSM Components.
- Fixed errors when selecting a template output variable.
- Fixed errors pasting actions while editing a comment.
- Fixed controls updating when an input/output variable was deleted.
- Fixed Vector3SetXYZ and Vector2SetXY (renamed from Vector2SetXYZ) actions.
- Fixed ctrl-click shortcut in Inspectors conflicting with selection. Use alt-click instead to open action selector, add event, add variable, etc.
- Fixed `Drags can only be started from MouseDown or MouseDrag events` errors in inspector list views.
- Fixed some sprite references in samples (default sprite texture are not portable?!)

## [2.0.0 beta 33] - 2025-07-30

### Added

- Added FloatSwitch action.
- Added GotoState action. Transitions directly to a state without using an event.
- Added support for targeting base Component variables in Get/SetComponentProperty and CallMethod actions, for example, after using GetComponent. When targeting a base Component variable, you also have to specify the expected component type.
- Added more List Contains actions: ContainsAll, ContainsAny, ContainsOnly

### Fixed

- Fixed selection bugs after focusing a docked FSM Editor.
- Fixed errors when duplicating node hierarchies (Ctr-D).
- Fixed errors when adding FSM Components while playing.
- Fixed dragging components into the Variables Inspector—it now makes a variable for the dropped component.
- Fixed Convert Menu not showing all options (e.g., Vector2SetX).
- Fixed error highlights in CallMethod action.

## [2.0.0 beta 32] - 2025-07-27

### Fixed

- Fixed selection of list variables.

## [2.0.0 beta 31] - 2025-07-25

### Changed

- Moved Component variable type to dll. You may need to re-make any instances of these in your project.

### Added

- Added On FSM State Changed action.
- Added Default Value parameter to Get FSM variable actions.
- Added `FirstPerson > Interaction` samples.
- GameObject variable `isNull` and `isNotNull` properties (in variable selector > Properties)
- Added Rigidbody Lerp Position and Lerp Rotation actions.

### Fixed

- Fixed global transitions with Global Events.
- Fixed paste errors and inconsistencies (Ctrl-V vs Paste in menus).
- Fixed layout when adding new region in between other regions.
- Fixed Action List jumping sometimes when it got focus.
- Fixed random editor errors due to stale callbacks.
- Fixed GlobalVariableType resetting (added logging to see if it still happens).

## [2.0.0 beta 30] - 2025-07-21

### Added

- System Event Browser to find system event usages.
- Allow alt-clicking outside FSM bounds to add a new state.

### Fixed

- Fixed global transitions not working.
- Fixed Actions that reference Objects dragged into the State Inspector.
- Fixed console errors in GetComponent actions.
- Fixed null ref exceptions in GetComponents actions.
- Fixed null ref exception when deleting transition from a state.
- Fixed selection of variables in some actions with lists (e.g., CheckBoolAllFalse)
- Fixed FSM Updater duplicating global transitions.
- Fixed empty Inspector when navigating back in history.
- Fixed alt-click target bug (clicking in resized FSM).
- Fixed the [DebugFSM Component](https://hutonggames.com/playmaker/docs/components/debug-fsm/) help url.
- Markdown: Fixed anchor names for headers with inline images.

## [2.0.0 beta 29] - 2025-07-18

### Big Changes

#### Quick Actions

Shortcut actions are now triggered with *Alt-Click* instead of *Ctrl-Click*.
For example, use *Alt-Click* to quick-add a transition to a state, or quick-add a variable to use in an action.
This was changed to be consistent with other Unity graph tools where Ctrl-Click is used for selection only.

#### Debug FSM Component

Added a debug system that anchors debug info to the screen or GameObjects. 
Add a [Debug FSM](https://hutonggames.com/playmaker/docs/components/debug-fsm/) component to debug an FSM.
The system is quite flexible so let us know what other debug components you'd like to see!

#### Markdown Support

Added Markdown support to [PlayMaker Notes](https://hutonggames.com/playmaker/docs/components/playmaker-notes/) 
and new [Notes Node](https://hutonggames.com/playmaker/docs/fsm-editor/editor-nodes/) and Note Item in list views. 
Custom Markdown extensions let you link to FSMs, Variables, Events, etc.

#### Node Layout

Improved Node layout rules:

- Regions and Parent States are no longer allowed to overlap nodes outside their bounds.
This visually clarifies state hierarchies, and you spend less time moving regions around to fix overlaps.
- Resizing Regions and Parent States pushes other nodes away to avoid overlaps.
- Moving other nodes over these nodes is not allowed unless holding Alt.
- Hold Alt while dragging to move nodes in and out of Regions and Parent States.
- Copy/Pasting uses the same overlap rules, so other nodes are moved to prevent overlaps.
- Duplicating (*Ctrl-D*) duplicates the nodes inside their respective regions.
(Unlike copying, which collects nodes from different regions.)

### Changed

- Improved handling of layout with regions, substates, and parent states. See above.
- Improved handling of transition links to composite states (can connect to an edge instead of a single point).
- Edit button in FSM Template selector now opens in the same window. Use *Ctrl-Click* to edit in a new window.
- Added hover link arrows to state transition nodes so transition nodes are consistent.
- *Ctrl-Click* to add new actions, events, and variables in respective inspectors.
- Allow "Add Parent" with multiple states selected.
- Better handling of layout with Undo/Redo.

### Added

- *Alt-drag* nodes in and out of regions and states.
- Added transition arrows to State Transitions so all transitions are consistent.
- Added lock state to transition arrows. Click or drag from link arrows to lock the start position. Click the arrow to toggle the lock.
- Added Fit Contents button to resizable node title bar.
- While playing, *Alt-Click* a transition event to send it.
- Added ResetVariableValue and ResetAllVariables actions.
- Added **Reset Variables** setting in FSM Inspector.
- Added Rotation and Tint to Image Widget. NOTE: You may need to manually set Tint to white on saved image nodes.
- Added Mouse samples scenes.

### Fixed

- Fixed finished Regions not re-entering properly when FSM was restarted.
- Fixed an error when deleting a region and using Fit Contents.
- Fixed the drop menu opened for components so it includes Script actions.
- Fixed BehaviourCheckIsEnabled so it can accept constant values.
- Fixed CharacterControllerFall action.

## [2.0.0 beta 28] - 2025-05-19

### Changed

- Search by acronyms in type selector (e.g., v3 matches Vector3, dow matches DayOfWeek).
- Sticky headers in selector popups to show the current category even if offscreen.

### Added

- Added [Get/SetProperty and CallMethod actions](https://hutonggames.com/playmaker/docs/actions/script-actions/).
- Added CheckFsmState action to check if an FSM is in a given state.
- Added FsmStateSwitch action to send events based on the state of an FSM.
- Added BehaviourCheckIsEnabled action.

### Fixed

- Fixed broken UI in CreateNewGameObjectWithComponents and GameObjectGetComponentInChildren.
- Fixed *Show Debug Info* toggle in the action titlebar. Some actions have debug info that can be toggled on/off.
- Fixed console errors when selecting other actions when Run Template was in the list.
- Fixed single letter searches in Action Browser.
- Fixed category sort in search results.

## [2.0.0 beta 27] - 2025-05-04

### Changed

- Use LayerMask variables for Light and Camera Culling Mask actions.
- Lock FSM Editor Window when opened as a popup. E.g. Edit Template in Run Template action.
- Disable *Edit Script...* for built-in actions.
- Changed FSM component name to PlayMaker FSM.
- Changed variable toggle icons and hints.
- Better searching in Addons browser.

### Added

- Added Enum variable type and actions. 
- Added OnAnimatorMove update mode. Used for modifying hierarchy after animations have updated but before IK is applied.
- Added ExpressionEvaluator actions.
- Added sticky headers in Action Browser.
- Added support for dragging actions onto the Graph View and into other states. Hover over a state while dragging to select it.
- Added Create New FSM Template option in empty FSM Editor context menu.
- API: Added ```FsmNode.Variables.GetGlobalVariables()``` method.
- API: Added ```UpdateManager.GetAllActiveFsmNodes()``` method.

### Fixed

- Fixed errors editing prefab instances with FSMs.
- Fixed Child item type in ForEachChild action when Parent was not a GameObject.
- Fixed errors in Animator IK actions.
- Fixed "Could Not Find Script" error when selecting built-in actions in Action Browser.
- Fixed Send Event action runtime errors with Delay set to None.
- Fixed Quick Add on event fields that require a global event. Opens a new Global Event popup.
- Fixed Global Events, Global Variable, FSM Template project windows list when first opened.
- Fixed Usage Finders sometimes not highlighting found items.

## [2.0.0 beta 26] - 2025-04-5

### Changed

- Clicking the root item in the [Selection Toolbar](https://hutonggames.com/playmaker/docs/fsm-editor/selection-toolbar/) selects the GameObject/FsmTemplate that owns the FSM.
- Added Addons tab when opening the ActionBrowser to try and expose Addons more.
- Added tooltip to Templates in FSM Template browser. Double-click to edit the template.

### Added

- Added Name, Description, and Files to Addons Search Field. Matching text is highlighted.
- Added DotProduct, Distance, Scale, and Angle to Vector3Operator.
- Added DotProduct, Distance and Angle to Vector2Operator action.
- Added Modulus to IntegerOperator action.
- Added Rigidbody Linear Damping actions (Unity6+)
- Added new Logic actions: CheckBoolAnyTrue, CheckBoolAnyFalse.
- Added Android actions from Ecosystem as Addons.

### Fixed

- Allow null in GameObjectSetValue action.
- Fixed RunTemplate hanging when Template had inputs.
- Fixed RunTemplate styles when action editor was narrow (Edit button was offscreen).
- Fixed CheckBoolAllTrue and CheckBoolAllFalse actions.

## [2.0.0 beta 25] - 2025-03-31

### Changed

- Made Owner a reserved variable name.
- Changed ConditionTest empty hint (e.g., List Find)

### Added

- AI > NavMesh actions. More advanced actions are in Addons (e.g. to build nav meshes at runtime).
- Added option to show delete buttons in Events and Variables editors.

### Fixed

- Fixed actions referencing Component variables of derived types.
- Fixed null reference error when editing UnityEvent variable.
- Fixed action errors not updating after converting an action.
- Fixed actions not running in the state triggered by OnDisable.
- Fixed global list variables resetting after pausing in the editor.
- Fixed error checking and old variable references in fields hidden by HideIfAttribute.
- Fixed Breadcrumbs not updating when GameObject name changed.
- Fixed HelpUrl links for new online docs.

## [2.0.0 beta 24] - 2025-02-9

### Changed

- Changed event buffering system. See: https://hutonggames.com/playmaker/docs/guides/how-to/buffer-events/
- Tweaked Start Arrow style.

### Added

- Added InputSystem actions to Addons. Supports 3 main workflows:
  - Direct access to device (e.g., Gamepad, Keyboard, Mouse...)
  - InputAction actions for inline actions or action asset references.
  - PlayerInput actions for higher level control.
  - NOTE: Touch actions are WIP.

### Fixed

- Fixed Fsm Info errors with FSM Templates.
- Fixed null ref errors in editor with missing actions (e.g., action was removed or renamed).

## [2.0.0 beta 23] - 2025-01-20

### Changed

- Show multiple loop action error if state has more than one loop action.
- Action Browser: Show action usages as bars instead of numbers.
- Reorganized PlayMaker Project Settings page.
- Reorganized online documents and filled it out with some more content.

### Fixed

- Fixed global event names in transitions when 2 global events have the same name.
- Fixed empty Prefabs record in Finder.
- Fixed Show Packages filter in Finder.
- Fixed scene unload warning when scanning project.

## [2.0.0 beta 22] - 2025-01-15

### Changed

- Added Tag and Layer dropdowns to GameObject actions.
- Component actions can now convert Transform variables in variable selector. The goal is to need less intermediate variables, so if you find a common case please submit an issue.

### Added

- Added LoopSkip and LoopStop actions. These work like Continue and Break in traditional programming languages.
- Added SetPosition variants for XY and XYZ.
- Added MemoryGame sample scene.

### Fixed

- Fixed bad variable references in copied List actions.
- Fixed action search not finding the part in parentheses, e.g., Physics Ray Cast (Mouse)
- Fixed warnings when changing Global Event data type.
- Fixed 0,0,0 not registering in Quaternion fields.
- Fixed custom tooltip order in Inspector window.

## [2.0.0 beta 21] - 2024-12-30

### Changed

- Made FSM, Parent State, and Region nodes resizable. Drag borders to resize, use Fit Contents in context menu to auto-size to contents.
- Made links less likely to intersect states. E.g., in a vertical flow, a link back up a chain of states will go around the states instead of through them.
- Removed event colors in Events tab. Too hard to read in some situations.
- DebugFlow no longer records list variable values because it's too expensive. We may add this back as an option.
- Added CanBeNullOrEmpty to Set Text actions (because you can use the action to clear the text).
- Tweaked Start and End arrows. Old versions were more standard, but new versions' meaning should be more obvious.
- Removed Set Scale, Push States and Push Regions Apart context menu items. These were experimental feature not ready for release.
- Work on Invaders and AnimalMatch samples. Invaders is a good example of the new ForEach actions. See FSMs on Invaders GameObject.

### Added

- ForEachListItem and ForEachChild actions. Easier iteration over a list or children of a GameObject in a single state. See Invaders sample for examples.
- Added Apply Styles context menu for states selected in the Graph View. Lets you quickly apply color and icons to multiple states. 
- Exposed Loop Count Limit setting in FSM Inspector. Changed default limit to 50 from 1000. Expensive operations with a high limit could still feel like a crashed editor, so we lowered the limit. But we plan to supplement this method of loop detection with edit time analysis, and elapsed frame time thresholds. Then maybe we can increase the default limit again.
- Added ClampPosition actions.

### Fixed

- Fixed copy/pasting State with substates.
- Fixed list variables sometimes losing values when un-pausing in editor.
- Fixed duplicate Global Variables in Group Inspector.
- Fixed global events icon and color in Graph View.

## [2.0.0 beta 20] - 2024-12-16

### Changed

- Added PlayMaker items to Hierarchy Context Menu.
- Modified TopDownShooter sample to use mouse look.
- Made global transitions groupable in Graph View.
- Moved end node to bottom right to avoid overlaps with links from other states.
- Removed parent state color from global transition border.
- Added slight background tint color to parent states and regions.
- Added Set Parent option to Pool Spawn actions.
- Removed ToString actions. Every type is convertible to string, so we don't need the actions. Use ToString__Format when a type supports numeric formatting. Leave the format empty to use default formatting.
- Moved advanced material actions to addons.

### Added

- Exposed List Count and Is Empty properties in Variable Selector.
- Exposed common PointerEventData properties in Variable Selector.
- Added SendFsmEvent action to send an event to an FSM by name.
- Added Finished Event Never Sent error. Flags Finished transitions that will never trigger because the state has actions that don't finish.
- Added OnVariableValueChanged action to listen for changes in a variable.
- Added BoolInvert and ConvertBoolToSprite actions.
- Added RectTransform Translate, BringToFront, and SendToBack actions.
- Added missing GetComponent actions (in children and parent).
- Added Bounds actions, including GameObjectGetBounds (include children) and GameObjectGetApproximateBounds (cheaper than using GetComponents)
- Added TransformMouseLook2D action, e.g., for topdown shooter games. You can achieve the same thing with 3 low level actions, but our philosophy is to provide a single action for common use cases.
- Added TransformTranslate2D action for convenient use with Vector2 variables.
- Added AnimalMatch drag and drop game sample. (WIP)
- Added Invaders game sample. (WIP)
- Added UI DragImage sample scenes.
- Added UFO test scene to Asteroids sample, to show how to set up quick test scenes with prefabs.

### Fixed

- Fixed record not found errors when editing new prefab FSM.
- Fixed GameObjectAddComponent and GetComponent actions.
- Fixed GroupAssetEditor errors.
- Fixed ActionEditor errors when a target component is missing (e.g., was deleted).
- Fixed Get FSM Variable type selector.
- Fixed debug value for PointerEventData not updating.
- Fixed node icon background color not updating when no icon was selected.
- Fixed action used counts not always updating in Action Browser.

## [2.0.0 beta 19] - 2024-12-8

### Changed

- Improved editor performance while playing in the editor, especially when rapidly switching states with Sync enabled. This was a fairly big change so let me know if it broke anything!
- Moved less common ColliderDistance2D, UI, Gradient, and Light property actions to addons
- Removed Touch set actions. It doesn't make a lot of sense to set touch properties. I guess there could be use cases, but it adds noise. We could add them back as an addon if there is demand.
- Formatted Flappy sample to use Device Simulator.

### Added

- More variable property selectors: 
- FloatIsNegative, FloatIsPositive, FloatIsZero, FloatIsNotZero, GameObjectParent, GameObjectName, GameObjectTag, GameObjectPosition2D
- TransformGetLocalScale_XYZ action.
- FlipX and FlipY actions for SpriteRenderer and Transform.
- 2D Platformer sample scenes for Wall Slide and Wall Jump.
- Added Only Actions That Can Finish option to Wait For All Finished action.
- InputSwipeEvent action and sample scene.
- InputTapEvent action, used in Flappy sample scene.
- UI Volume Slider, Drag, and HealthBar sample scenes.
- TopDownShooter sample scenes.

### Fixed

- Fixed glitchy editing of Global Event test data.
- Fixed drag selection consistency in nested states.
- Fixed Direct Link picking.
- Fixed OnBeginDrag event not firing.

## [2.0.0 beta 18] - 2024-12-03

### Changed

- Faster and more reliable scanning of project. No need to save open scenes before scanning. The project database should now update automatically when adding/removing assets and components, editing prefabs, adding scenes, etc. If you find situations where the database is not updated, please submit a bug report.
- Better positioning of Usage Finder windows opened from Used Count labels.
- Moved AnimationClip, AnimationCurve, AnimationEvent, Gradient, AudioClip, and some AudioSource actions to Addons. Those properties are normally set at edit time, but you can import the addons if you need runtime access.

### Added

- Added Scan Project setting to PlayMaker project settings.
- Open PlayMaker Settings in FSM Editor window menu and _Main Menu > Project_.

### Fixed

- List variable initialization (#19)
- List actions not working on Global List Variables (#18)
- Global List Variable not resetting after exiting playmode.
- Null ref error when adding a region (#13)
- Event usages not found in global transitions (#8)
- Addon status not updating after installing an addon (#5)
- GetComponentCount action error in Unity versions below 2022.3.20f1 (#16)
- Grouped assets not appearing in Group Inspector. This was a side effect of the project database not being up to date, specifically after importing a package, like a sample from Addons. The database is now automatically updated after importing a package. If you turn that setting off in PlayMaker project settings then a Scan Project button is shown in the Group Inspector.
- List variable icons occasionally not showing.
- Fixed type selector search (no longer requires exact word matches).
- List item alignment bug (#17)

## [2.0.0 beta 17] - 2024-11-27

**NOTE: This release includes breaking changes. Please install in a fresh project to avoid issues.**

### Changed

- **BREAKING CHANGE:** Event Data is now a single variable instead of a list.
- Reworked List Get Next Item action to use a Current Index and removed the Reset Flag. This is more flexible, letting you share this index with other actions. If you don't supply an index variable the action uses an internal counter.
- Made TMP_Text actions Owner default (#7)

### Added

- **Global Variable Changed Event.** Option to send a Global Event when a Global Variable value changes. Use this to decouple systems. For example, UI FSMs can listen for changes in variables to update the UI instead of you having to send an event to update the UI.
- **Action Debug Info.** Actions can show debug info in action editors; E.g. MoveTowards actions show the current distance. Toggle on/off with the titlebar Debug icon (only shown if the action has debug info)
- **Outputs in FSM Inspector.** You can assign a global variable to store an output value.
- **Variable Properties.** Added Properties category in Variable Selector to select common variable properties. E.g., access Vector3 x, y, z, magnitude or float.absolute directly from the Variable Selector. This should reduce the number of intermediate variables needed for complex operations. For example, you can reference speed.absolute instead of using an action to store the absolute speed. 
- **Get/Set FSM Variable actions.** These actions let you get/set variables in other FSMs. NOTE: These variable usages are currently not found in Finder searches.

### Fixed

- Fixed ListGetNextItem looping and resetting (#4)
- Fixed breadcrumb FSM selection menu when multiple FSMs had the same name (#12)
- Fixed Rigidbody2D Dash action not resetting properly.

## [2.0.0 beta 16] - 2024-11-15

### Added

- Support for fast playmode entering.
- Watch Variable toggle in Variables tab. Shows values in graph view when playing.
- Event buffering. For example, to respond to a jump event sent just before entering the On Ground State. Note, only the Input Button Down Event uses buffering right now. Buffering will be added to more actions. Use Send Buffered Event to send a recently buffered event.
- Use the *Debug &gt; Event Buffer* window to see buffered events.
- TimeCheckElapsedTime action. Checks if a certain amount of time has passed since a recorded time.
- More options for locking link routes in Transition Inspector > Link Settings.

### Changed

- Reworked Platformer sample scenes to make them more flexible and less reliant on custom actions. The idea is that you could experiment with different implementations of move, jump, dash etc. while keeping the states and events the same.
- Cached Animator state and parameter name IDs in Animator actions for better performance.
- Moved less used Animator actions to Addons.

### Fixed

- Fixed Breakpoints (#141).
- Issues pasting transitions with events (#146).
- Error in console when moving assets (#135).
- Switching to State tab when clicking on an already selected state (#142).
- MatchType broken with global list variables (#144).
- Error when stopping scene playback (#140).
- Fixed errors when opening Addons window (#139).
- Fixed setting Default Link Style in PlayMaker settings.
- Fixed ActionBrowser panels overlapping when small.
- Fixed typo in CheckIntLessThanOrEqual action name.






































































































































































































































































































