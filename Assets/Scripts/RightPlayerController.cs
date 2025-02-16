using UnityEngine;

public class RightPlayerController : PlayerControllerBase
{
    public Transform penTransform;

    private void Update()
    {
        UpdatePlayer();
        if (Input.GetKeyDown(key_Use) && Vector2.Distance(CursorPosition, penTransform.position) < 1.5f)
        {
            SetState<DrawPlayerState>();
        }
    }
}
