# AI Assistant for Unity and PlayMaker Development

This file contains guidelines for JetBrains AI Assistant when working on PlayMaker development in Unity.

## Fields

- *Private Fields* Use `_name` convention.
- Prefer `var` to explicit type.
- Prefer `Mathf` to `Math`.

## Strings constant class

The Strings.cs class contains constant strings used to maintain consistency and platform-specific terminology.
Use these in UI, help, or tooltip text instead of inline constants.
For example, instead of "Ctrl Click the button" use $"{String.ActionClick} the button"

## Shortcuts

Format compound actions as: ++Ctrl-"click"++, ++Alt-"drag"++, ++Double-"click"++
Use lowercase key names, with hyphens between key and action.
Use quotes around keys not recognized by mkdocs.
Do not use all-caps or quote individual keys unless quoting exact UI labels.

## Definitions

To keep it clean, modern, and slightly friendlier:

Use : in inline definitions and tables
e.g. **Speed**: How fast the player moves.

Use — in “See Also” lists and bullet-pointed overviews
e.g. - [Actions](actions.md) — Use variables as parameters in FSM logic.

This way:

Colons feel precise when you need them.

Em dashes (or spaced —) give breathing room in supplementary or list-style contexts.

## File Output Paths
Root path for all PlayMaker files: `Packages/com.hutonggames.playmaker/`

Files must be placed in the appropriate assembly folder:
- Runtime code: `Runtime/` (for code that runs in builds)
- Editor code: `Editor/` (for Unity Editor-only code)
- Tests: `Tests/` (subdivided into `Editor` and `Runtime` for respective test types)

Within each assembly folder, follow context:
- When extending or deriving from an existing class, place the new file in the same subfolder as the base class
- When creating related functionality, maintain the existing folder structure
- Common subfolders pattern:
  - Actions: `Actions/`
  - Core: `Core/`
  - Documentation: `Documentation/`

Example paths:
- New runtime action: `Runtime/Actions/`
- Editor-only inspector: `Editor/Inspector/`
- Runtime tests: `Tests/Runtime/`
- Editor tests: `Tests/Editor/`