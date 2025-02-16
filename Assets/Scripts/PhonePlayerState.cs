using UnityEngine;

public class PhonePlayerState : PlayerStateBase
{
    public PhoneScroll phoneScroll;
    private bool isActive = false;
    private Vector3 phoneStartPosition;

    private void Start()
    {
        phoneStartPosition = phoneScroll.transform.position;
        phoneScroll.IsPhoneOn = false;
    }

    private void Update()
    {
        if (!isActive)
        {
            phoneScroll.transform.position = Vector3.Lerp(phoneScroll.transform.position,
                phoneStartPosition, 10 * Time.deltaTime);

            phoneScroll.transform.GetChild(0).transform.localPosition =
                Vector3.Lerp(phoneScroll.transform.GetChild(0).transform.localPosition,
                Vector3.zero, Time.deltaTime * 20);
        }
    }

    public override void OnEnter()
    {
        isActive = true;
        phoneScroll.IsPhoneOn = true;
        Controller.MovementMultiplier = 0;
    }

    public override void OnExit()
    {
        isActive = false;
        phoneScroll.IsPhoneOn = false;
        Controller.MovementMultiplier = 1;
    }

    public override void UpdateState()
    {
        Vector2 fixedPosition = GameManager.instance.ClampVectorInPhoneView(Controller.CursorPosition);
        Controller.CursorPosition = Vector2.Lerp(Controller.CursorPosition, fixedPosition, Time.deltaTime * 10);
        phoneScroll.transform.position = Controller.CursorPosition;
        phoneScroll.transform.GetChild(0).transform.localPosition =
            Vector3.Lerp(phoneScroll.transform.GetChild(0).transform.localPosition,
            -2f * Vector3.forward, Time.deltaTime * 20);

        if (Input.GetKeyDown(Controller.key_Down))
        {
            phoneScroll.ScrollMemes();
        }

        if (Input.GetKeyUp(Controller.key_Use))
        {
            ExitState();
        }

        GameManager.instance.AddLeftPlayerPoints(Time.deltaTime);
    }
}
