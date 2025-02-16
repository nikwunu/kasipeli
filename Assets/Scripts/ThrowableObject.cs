using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    public bool IsThrown { get; set; }
    public Vector2 Velocity => GetComponentInChildren<Rigidbody2D>().linearVelocity;
    public PlayerControllerBase ThrowerPlayer { get; set; } = null;

    private void Update()
    {
        if(Vector3.Distance(transform.position, GameManager.instance.transform.position) > 14)
        {
            Destroy(gameObject);
            GameManager.instance.SpawnNewObject();
        }
    }
}
