using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Bounds playAreaBounds;
    public Bounds drawAreaBounds;
    public Bounds phoneAreaBounds;
    public float stunVelocityTreshold;
    public float pointLimit;
    public float leftPlayerPointMultiplier;
    public float rightPlayerPointMultiplier;
    public float LeftPlayerPoints {  get; private set; }
    public float RightPlayerPoints {  get; private set; }

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

    public Vector3 ClampVectorInDrawView(Vector2 vector)
    {
        vector.x = Mathf.Clamp(vector.x, drawAreaBounds.min.x, drawAreaBounds.max.x);
        vector.y = Mathf.Clamp(vector.y, drawAreaBounds.min.y, drawAreaBounds.max.y);
        return vector;
    }

    public Vector3 ClampVectorInPhoneView(Vector2 vector)
    {
        vector.x = Mathf.Clamp(vector.x, phoneAreaBounds.min.x, drawAreaBounds.max.x);
        vector.y = Mathf.Clamp(vector.y, phoneAreaBounds.min.y, drawAreaBounds.max.y);
        return vector;
    }

    public void AddLeftPlayerPoints(float amount)
    {
        LeftPlayerPoints += amount * leftPlayerPointMultiplier;
    }

    public void AddRightPlayerPoints(float amount)
    {
        RightPlayerPoints += amount * rightPlayerPointMultiplier;
    }
}
