using UnityEngine;

public class HandVisualRotation : MonoBehaviour
{
	[SerializeField] Vector3 targetShoulder;
	/* void Start()
	{
		
	} */

	void Update()
	{
		transform.LookAt(targetShoulder, Vector3.back);
	}

	void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(targetShoulder, 1f);
    }
}
