using UnityEngine;
using TMPro;

public class UIManagerTMP : MonoBehaviour
{
    public TMP_Text leftPlayerPointsTMP;
    public TMP_Text rightPlayerPointsTMP;

    private void Update()
    {
        if (leftPlayerPointsTMP != null) { 
            float leftPlayerPercentage = (GameManager.instance.LeftPlayerPoints / GameManager.instance.pointLimit) * 100;
            leftPlayerPointsTMP.text = $"Left Player Points: {leftPlayerPercentage:F2}%";
        }

        if (rightPlayerPointsTMP != null)
        {
            float rightPlayerPercentage = (GameManager.instance.RightPlayerPoints / GameManager.instance.pointLimit) * 100;
            rightPlayerPointsTMP.text = $"Right Player Points: {rightPlayerPercentage:F2}%";
        }
     }
}
