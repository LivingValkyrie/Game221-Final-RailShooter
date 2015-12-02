using UnityEngine;
using System.Collections;

public class MenuTransitions
{
    MenuStates currentState;
    MenuCommands command;

    public MenuTransitions(MenuStates thisState, MenuCommands thisCommand)
    {
        currentState = thisState;
        command = thisCommand;
    }

    public override int GetHashCode()
    {
        return 17 + 31 * currentState.GetHashCode() + 31 * command.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        MenuTransitions other = obj as MenuTransitions;
        return other != null && this.currentState == other.currentState && this.command == other.command;
    }

}

