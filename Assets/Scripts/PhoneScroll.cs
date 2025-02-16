using Unity.VisualScripting;
using UnityEngine;

public class PhoneScroll : MonoBehaviour
{
	[SerializeField] MeshRenderer PhoneRenderer;
	Material phoneScreenMaterial;
	public float currentScrollAmount;
	public float currentScrollVelocity;
	public bool IsPhoneOn = true;
	bool wasPhoneOn = true;
	[SerializeField] float scrollForce = 1f;
	[SerializeField] float scrollDecay = 1f;
	[SerializeField] float scrollRandomnessScale = 0.2f;
	Vector4 tilingVector;

	void Start()
	{
		phoneScreenMaterial = PhoneRenderer.material;
	}

	[ContextMenu("Scroll memes")] public void ScrollMemes()
	{
		currentScrollVelocity = scrollForce * Random.Range(1f-scrollRandomnessScale, 1f+scrollRandomnessScale);
	}

	void Update()
	{
		if(IsPhoneOn != wasPhoneOn)
		{
			PhoneRenderer.gameObject.SetActive(IsPhoneOn);
			wasPhoneOn = IsPhoneOn;
		}

		tilingVector = new Vector4(1f, 0.2f, 0f, currentScrollAmount);

		if(currentScrollVelocity>0f)
		{
			currentScrollVelocity -= scrollDecay*Time.deltaTime;
			currentScrollAmount -= currentScrollVelocity;
		}

		phoneScreenMaterial.SetVector("_EmissionMap_ST", tilingVector);
		phoneScreenMaterial.SetVector("_MainTex_ST", tilingVector);
	}
	
}
