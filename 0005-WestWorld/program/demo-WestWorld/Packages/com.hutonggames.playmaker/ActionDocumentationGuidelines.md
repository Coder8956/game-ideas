# Template to create action documentation

This file contains guidelines for JetBrains AI Assistant to create markdown documentation using action source code.

Use this format for md files:

```
# Action Name

Action Description extracted from ActionDescriptionAttribute

| Parameter         | Description            |
|-------------------|------------------------|
| SerializableField | From TooltipAttribute. |

## Details

Detailed description about the action.

## Use Cases

Example use cases.

## Related Actions

- [AnotherAction](another-action.md) - Short description.
```

For example, for SendEvent:

```
# Send Event

Send an event to the running FSM.

|Parameter | Description                                         |
|-|-----------------------------------------------------|
| Event | The event to send.                                  |
| Data | Optional data to send with the event.               |
| Delay | Optional delay in seconds before sending the event. |

## Details

...

## Use Cases

...

## Related Actions

...

```

## Links

