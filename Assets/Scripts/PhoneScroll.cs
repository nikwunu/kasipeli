using Unity.VisualScripting;
using UnityEngine;

public class PhoneScroll : MonoBehaviour
{
	[SerializeField] Material PhoneScreenMaterial;
	public float currentScrollAmount;
	public float currentScrollVelocity;
	[SerializeField] float scrollForce = 1f;
	[SerializeField] float scrollDecay = 1f;
	Vector2 tilingVector;

	[ContextMenu("Scroll memes")] public void ScrollMemes()
	{
		currentScrollVelocity = scrollForce;
	}

	void Update()
	{
		tilingVector = new Vector2(0f, currentScrollAmount);

		if(currentScrollVelocity>0f)
		{
			currentScrollVelocity -= scrollDecay*Time.deltaTime;
			currentScrollAmount -= currentScrollVelocity;
		}
	}
	
}
