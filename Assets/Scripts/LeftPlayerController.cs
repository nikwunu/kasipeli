using UnityEngine;

public class LeftPlayerController : PlayerControllerBase
{
    public Transform phoneTransform;

    private void Update()
    {
        UpdatePlayer();
        if (Input.GetKeyDown(key_Use) && Vector2.Distance(CursorPosition, phoneTransform.position) < 1.5f)
        {
            SetState<PhonePlayerState>();
        }
    }
}
