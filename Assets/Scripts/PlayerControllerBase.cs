using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;

public class PlayerControllerBase : MonoBehaviour
{
    public KeyCode key_Up;
    public KeyCode key_Down;
    public KeyCode key_Left;
    public KeyCode key_Right;
    public KeyCode key_Use;

    public Transform playerHandTransform;

    public float movementSpeed;

    private PlayerStateBase[] playerStates;
    public ThrowableObject CurrentlyHoveredObject { get; private set; }

    public PlayerStateBase CurrentState { get; private set; }
    public float MovementMultiplier { get; private set; } = 1f;
    public Vector2 CursorPosition { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }

    private void Awake()
    {
        playerStates = GetComponentsInChildren<PlayerStateBase>(true);
        for (int i = 0; i < playerStates.Length; i++)
        {
            playerStates[i].Init(this);
        }
        SetState<DefaultPlayerState>();
    }

    private void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.UpdateState();
        }

        if (Input.GetKeyDown(key_Use) && CurrentlyHoveredObject != null)
        {
            SetState<MoveItemPlayerState>();
        }

        HandleCursorMovement();

        playerHandTransform.position = CursorPosition;
    }

    private void HandleCursorMovement()
    {
        Vector2 movementVector = Vector2.zero;
        movementVector.y = (Input.GetKey(key_Up) ? 1 : 0) - (Input.GetKey(key_Down) ? 1 : 0);
        movementVector.x = (Input.GetKey(key_Right) ? 1 : 0) - (Input.GetKey(key_Left) ? 1 : 0);
        Vector2 newPosition = movementVector * Time.deltaTime * movementSpeed * MovementMultiplier;
        CursorPosition = GameManager.instance.ClampVectorInPlayView(CursorPosition + newPosition);
        CurrentVelocity = movementVector;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ThrowableObject obj))
        {
            CurrentlyHoveredObject = obj;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == CurrentlyHoveredObject.gameObject)
        {
            CurrentlyHoveredObject = null;
        }
    }

    public void SetState<T>() where T : PlayerStateBase
    {
        CurrentState?.OnExit();
        for (int i = 0; i < playerStates.Length; i++)
        {
            if (playerStates[i] is T)
            {
                playerStates[i].OnEnter();
                CurrentState = playerStates[i];
                break;
            }

            if (i == playerStates.Length - 1)
            {
                Debug.LogError("Could not find state " + typeof(T));
            }
        }

    }
}
