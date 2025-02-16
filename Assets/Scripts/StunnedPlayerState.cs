using UnityEngine;

public class StunnedPlayerState : PlayerStateBase
{
    private Vector3 startPosition;
    private float stunTimer = 0;


    private void Start()
    {
        startPosition = transform.position;
    }

    public override void OnEnter()
    {
        Controller.MovementMultiplier = 0;
        Controller.CanInteract = false;
        stunTimer = 3;
    }

    public override void OnExit()
    {
        Controller.MovementMultiplier = 1;
        Controller.CanInteract = true;
    }

    public override void UpdateState()
    {
        Controller.CursorPosition = Vector2.Lerp(Controller.CursorPosition, startPosition, Time.deltaTime * 10);
        stunTimer -= Time.deltaTime;
        if(stunTimer <= 0)
        {
            Controller.SetState<DefaultPlayerState>();
        }
    }
}
