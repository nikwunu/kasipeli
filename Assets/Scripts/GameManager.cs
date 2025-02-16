using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Bounds playAreaBounds;
    public float stunVelocityTreshold;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }


    public Vector2 ClampVectorInPlayView(Vector2 vector)
    {
        vector.x = Mathf.Clamp(vector.x, playAreaBounds.min.x, playAreaBounds.max.x);
        vector.y = Mathf.Clamp(vector.y, playAreaBounds.min.y, playAreaBounds.max.y);
        return vector;
    }
}
