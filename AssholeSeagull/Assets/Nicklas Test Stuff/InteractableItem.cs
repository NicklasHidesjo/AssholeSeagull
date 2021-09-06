using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
	[SerializeField] float followSpeed; 

	public Vector3 Velocity => body.velocity;

	GameObject pickedUpBy;

	public GameObject PickeUpBy => pickedUpBy;

	Rigidbody body;

	Vector3 offset;
	Vector3 rotation;

	private void Start()
	{
		body = GetComponent<Rigidbody>();
	}

	public void PickUp(GameObject picker)
	{
		pickedUpBy = picker;
		offset = transform.position - picker.transform.position;
		rotation = transform.eulerAngles;
	}
	public void DropItem(Vector3 force)
	{
		pickedUpBy = null;
		body.AddForce(force, ForceMode.Impulse);
	}

	public void Rotate(Vector3 handRotation)
	{
		rotation += handRotation;
	}

	private void Update()
	{
		if(pickedUpBy != null)
		{
			Vector3 targetPos = Vector3.MoveTowards(transform.position,pickedUpBy.transform.position + offset, followSpeed * Time.deltaTime);

			body.AddForce(targetPos - transform.position, ForceMode.Impulse);

			transform.rotation = Quaternion.Euler(rotation);
		}
	}
}
