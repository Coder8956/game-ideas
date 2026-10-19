# :star: What's New

For a full list of changes, see the ChangeLog.

## [2.0.0 beta 88] - 2026-9-26

### ADDED

- Added Tag option to 2D Physics event actions.
- Added optional StoreGameObject to Physics and 2D Physics event actions.
- Added [DataTableGetRandomWeightedRecord](action:DataTableGetRandomWeightedRecord) action for randomly selecting rows in a table with a weights column.
- Added xml documentation for PlayMaker dlls. Useful for Intellisense and coding agents.
- Added upgrade checks to warn when PlayMaker needs to be re-imported after changing Unity versions.
- Added Name Width options in Variables list view, from Default (30%) to Maximum (60%).
- Added Show/Hide FSM Header option to secondary FSM windows menu (e.g. Variables Window).
- Added *Open in New Window* in Events and Variables menus.

### FIXED

- Fixed Debug Step not advancing FSMs.
- Fixed creating new variables/events inside existing groups.
- Fixed ProjectDatabase sometimes becoming very big and slowing down finding usages.
