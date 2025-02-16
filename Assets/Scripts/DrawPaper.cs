using System.Collections;
using UnityEngine;

public class DrawPaper : MonoBehaviour
{
	[SerializeField] MeshRenderer lomakePohja;
	[SerializeField] Transform drawStroke;
	public Vector3 PenPosition;
	public bool PenActive = false;
	bool penWasActive;
	/* public bool PaperToBeCleared;
	bool wasPaperCleared; */
	
	void Start()
	{
		StartCoroutine(ClearPaper());
	}

	[ContextMenu("Clear the paper")] public IEnumerator ClearPaper()
	{
		lomakePohja.enabled = true;
		yield return null;
		lomakePohja.enabled = false;
	}

	void Update()
	{
		drawStroke.position = PenPosition;

		if(PenActive != penWasActive)
		{
			drawStroke.gameObject.SetActive(PenActive);
			penWasActive = PenActive;

		}

		/* if(wasPaperCleared)
		{
			lomakePohja.enabled = false;
			wasPaperCleared = false;
		} */
	}
}
