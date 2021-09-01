using Character;
using State;
using UnityEngine;
using Yarn.Unity;

public class CustomCommands : MonoBehaviour
{
    private DialogueRunner _dialogue;
    private StationBehavior _stationBehavior;

    private void Start()
    {
        _dialogue = FindObjectOfType<DialogueRunner>();
        _stationBehavior = FindObjectOfType<StationBehavior>();
        
        _dialogue.AddCommandHandler("StopTimeState", SwitchStopTimeState);
        _dialogue.AddCommandHandler("WorkState", SwitchWorkState);
        _dialogue.AddCommandHandler("IdleState", SwitchIdleState);
        _dialogue.AddCommandHandler("DrinkCoffeeState", SwitchDrinkCoffeeState);
        _dialogue.AddCommandHandler("RestState", SwitchRestState);
        _dialogue.AddCommandHandler("PlayerMovement", PlayerMovement);
    }

    private void SwitchStopTimeState(string[] parameters)
    {
        _stationBehavior.SwitchState<StopTimerState>();
    }
    
    private void SwitchWorkState(string[] parameters)
    {
        _stationBehavior.SwitchState<WorkState>();
    }
    
    private void SwitchIdleState(string[] parameters)
    {
        _stationBehavior.SwitchState<IdleState>();
    }
    
    private void SwitchDrinkCoffeeState(string[] parameters)
    {
        _stationBehavior.SwitchState<DrinkCoffeeState>();
    }
    
    private void SwitchRestState(string[] parameters)
    {
        _stationBehavior.SwitchState<RestState>();
    }

    private void PlayerMovement(string[] parameters)
    {
        if (parameters[0] == "move")
            PlayerInput.IsCanMove = true;
        else if(parameters[0] == "stop")
            PlayerInput.IsCanMove = false;
    }
}
