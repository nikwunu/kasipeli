using UnityEngine;

public abstract class PlayerStateBase : MonoBehaviour
{
    public PlayerControllerBase Controller { get; private set; }

    public void Init(PlayerControllerBase playerController)
    {
        Controller = playerController;
    }

    public abstract void UpdateState();

    public abstract void OnEnter();

    public abstract void OnExit();
}
