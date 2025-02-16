using UnityEngine;

public class DrawPlayerState : PlayerStateBase
{
    public Transform penTransform;
    public Transform penObjectTransform;
    public Vector2 penLocalTargetPos;
    public Vector3 penLocalTargetRot;
    public DrawPaper drawPaper;

    private Vector3 penStartPosition;
    private bool isActive = false;

    private void Start()
    {
        penStartPosition = penTransform.position;
    }

    public override void OnEnter()
    {
        Controller.MovementMultiplier = 0.75f;
        drawPaper.PenActive = true;
        isActive = true;
    }

    public override void OnExit()
    {
        Controller.MovementMultiplier = 1;
        drawPaper.PenActive = false;
        isActive = false;
    }

    private void Update()
    {
        if (!isActive)
        {
            penObjectTransform.localPosition = Vector3.Lerp(penObjectTransform.localPosition, 
                Vector3.zero, Time.deltaTime * 20);

            penObjectTransform.localRotation = Quaternion.Lerp(penObjectTransform.localRotation, 
                Quaternion.identity, Time.deltaTime * 20);

            penTransform.position = Vector3.Lerp(penTransform.position,
                penStartPosition, 10 * Time.deltaTime);
        }
    }

    public override void UpdateState()
    {
        penObjectTransform.localPosition = Vector3.Lerp(penObjectTransform.localPosition,
            penLocalTargetPos, Time.deltaTime * 20);

        penObjectTransform.localRotation = Quaternion.Lerp(penObjectTransform.localRotation,
            Quaternion.Euler(penLocalTargetRot), Time.deltaTime * 20);

        Vector2 fixedPosition = GameManager.instance.ClampVectorInDrawView(Controller.CursorPosition);
        Controller.CursorPosition = Vector2.Lerp(Controller.CursorPosition, fixedPosition, Time.deltaTime * 10);
        penTransform.position = Controller.CursorPosition;

        if (Input.GetKeyUp(Controller.key_Use))
        {
            ExitState();
        }

        drawPaper.PenPosition = Controller.CursorPosition;

        GameManager.instance.AddRightPlayerPoints(Time.deltaTime);
    }
}
