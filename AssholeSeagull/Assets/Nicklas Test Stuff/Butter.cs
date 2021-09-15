using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butter : MonoBehaviour
{
	[SerializeField] float butteringDone;
	[SerializeField] float butterSpeed;
	[SerializeField] List<float> butterStageInitiation;

    [SerializeField] Mesh[] butterStages;

    MeshFilter meshFilter;
	MeshCollider meshtrigger;
	[SerializeField] MeshCollider meshCollider;

    [SerializeField] Rigidbody knife;


    void Start()
    {
		meshtrigger = GetComponent<MeshCollider>();
        meshFilter = GetComponent<MeshFilter>();
    }

	private void Update()
	{
		if(knife == null) { return; }

		butteringDone += Mathf.Abs(knife.velocity.x * Time.deltaTime * butterSpeed);
		butteringDone += Mathf.Abs(knife.velocity.y * Time.deltaTime * butterSpeed);
		butteringDone += Mathf.Abs(knife.velocity.z * Time.deltaTime * butterSpeed);

		if (butteringDone > butterStageInitiation[1])
		{
			meshCollider.sharedMesh = butterStages[1];
			meshtrigger.sharedMesh = butterStages[1];
			meshFilter.mesh = butterStages[1];
		}
		else if(butteringDone > butterStageInitiation[0])
		{
			meshCollider.sharedMesh = butterStages[0];
			meshtrigger.sharedMesh = butterStages[0];
			meshFilter.mesh = butterStages[0];
		}
	}


	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.GetComponent<ButterBlade>())
		{
			knife = other.gameObject.GetComponentInParent<Rigidbody>();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.gameObject.GetComponent<ButterBlade>())
		{
			knife = null;
		}
	}
}
