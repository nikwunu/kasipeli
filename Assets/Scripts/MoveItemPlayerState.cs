using UnityEngine;

public class MoveItemPlayerState : PlayerStateBase
{
    private ThrowableObject draggedObject;

    public override void OnEnter()
    {
        if (Controller.CurrentlyHoveredObject == null)
        {
            Controller.SetState<DefaultPlayerState>();
            return;
        }

        draggedObject = Controller.CurrentlyHoveredObject;
    }

    public override void OnExit()
    {

    }

    public override void UpdateState()
    {
        draggedObject.transform.position = Vector3.Lerp(draggedObject.transform.position, 
            Controller.CursorPosition, Time.deltaTime * 10);
        draggedObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

        if (Input.GetKeyUp(Controller.key_Use))
        {
            draggedObject.GetComponent<Rigidbody2D>().linearVelocity = Controller.CurrentVelocity * 4;
            Controller.SetState<DefaultPlayerState>();
        }
    }
}
