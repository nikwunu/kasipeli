using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    public bool IsThrown { get; set; }
    public Vector2 Velocity => GetComponentInChildren<Rigidbody2D>().linearVelocity;
    public PlayerControllerBase ThrowerPlayer = null;
}
