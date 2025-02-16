using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public ThrowableObject[] throwablePrefabs;
    public GameObject winEffectLeft;
    public GameObject winEffectRight;

    private bool ended = false;
    public float LeftPlayerPoints { get; private set; }
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
        if (ended) return;

        LeftPlayerPoints += amount * leftPlayerPointMultiplier;
        CheckEndCondition();
    }

    public void AddRightPlayerPoints(float amount)
    {
        if (ended) return;

        RightPlayerPoints += amount * rightPlayerPointMultiplier;
        CheckEndCondition();
    }

    private IEnumerator EndGameEnumerator()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");
    }

    private void CheckEndCondition()
    {
        if (LeftPlayerPoints >= pointLimit)
        {
            winEffectLeft.gameObject.SetActive(true);
            ended = true;
            StartCoroutine(EndGameEnumerator());
        }
        else if (RightPlayerPoints >= pointLimit)
        {
            winEffectRight.gameObject.SetActive(true);
            ended = true;
            StartCoroutine(EndGameEnumerator());
        }

    }

    public void SpawnNewObject()
    {
        ThrowableObject obj = Instantiate(throwablePrefabs[Random.Range(0, throwablePrefabs.Length)]
            ,Vector3.up * 7 + Vector3.right * Random.Range(-1f, 1f), Quaternion.identity);
    }
}
