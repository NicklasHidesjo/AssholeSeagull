using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butter : MonoBehaviour
{
	[SerializeField] float butteringDone;
	[SerializeField] List<float> butterStageInitiation;

    [SerializeField] Mesh[] butterStages;

	[SerializeField] Vector3[] butterStagePositions;

    MeshFilter meshFilter;
	[SerializeField] MeshCollider meshCollider;

    [SerializeField] ButterVelocity knife;


    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

	private void Update()
	{
		if(knife == null) { return; }

		Debug.Log("Buttering");
		
		butteringDone += knife.Velocity;

		if (butteringDone > butterStageInitiation[1])
		{
			meshCollider.sharedMesh = butterStages[1];
			meshFilter.mesh = butterStages[1];
			transform.position = butterStagePositions[1];
		}
		else if(butteringDone > butterStageInitiation[0])
		{
			meshCollider.sharedMesh = butterStages[0];
			meshFilter.mesh = butterStages[0];
			transform.position = butterStagePositions[2];
		}
	}


	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.GetComponent<ButterBlade>())
		{
			knife = other.GetComponentInChildren<ButterVelocity>();
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
