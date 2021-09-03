using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
	GameObject pickedUpBy;
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
			transform.position = pickedUpBy.transform.position + offset;
			transform.rotation = Quaternion.Euler(rotation);
		}
	}

}
