using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControlledHand : MonoBehaviour
{
    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;

	[SerializeField] float scrollSpeed;

	[SerializeField] float handSpeed;
	[SerializeField] float rotationSpeed;

	[SerializeField] float forceMultiplier;

    float handHeight = 0f;

	[SerializeField] InteractableItem Interactable;

	bool itemInHand;
	Vector3 throwForce;
	Rigidbody body;
	
	void Start()
    {
		body = GetComponent<Rigidbody>();
        handHeight = 3f;
    }

    void Update()
	{
		MoveMouse();
		ChangeMouseHeight();
		RotateMouse();

		if (Interactable == null) { return; }

		if (Input.GetButtonDown("pickUp"))
		{
			if (itemInHand)
			{
				Interactable.DropItem(throwForce * forceMultiplier);
				Interactable = null;
				itemInHand = false;
				return;
			}

			Interactable.PickUp(gameObject);
			itemInHand = true;
		}

		if (!itemInHand) { return; }

		RotateItemInHand();

	}

	private void MoveMouse()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		Vector3 camPos = ray.origin;
		Vector3 mouseDir = ray.direction;

		float t = (handHeight - camPos.y) / mouseDir.y;

		Vector3 intersPos = camPos + t * mouseDir;
		Vector3 targetPos = Vector3.MoveTowards(transform.position, intersPos, handSpeed * Time.deltaTime);

		body.AddForce(targetPos - transform.position, ForceMode.Impulse);

		throwForce = intersPos - transform.position;
	}
	private void RotateMouse()
	{
		transform.rotation = Quaternion.Euler(Vector3.zero);
	}
	private void ChangeMouseHeight()
	{
		handHeight += -Input.GetAxisRaw("Mouse ScrollWheel") * Time.deltaTime * scrollSpeed;
		handHeight = Mathf.Clamp(handHeight, minHeight, maxHeight);
	}

	private void RotateItemInHand()
	{
		Vector3 rotation = Vector3.zero;

		rotation.x += Input.GetAxis("Rotation(X)") * Time.deltaTime * rotationSpeed;
		rotation.y += Input.GetAxis("Rotation(Y)") * Time.deltaTime * rotationSpeed;
		rotation.z += Input.GetAxis("Rotation(Z)") * Time.deltaTime * rotationSpeed;

		Interactable.Rotate(rotation);
	}


	private void OnTriggerEnter(Collider other)
	{
		if (itemInHand) { return; }
		if (other.gameObject.GetComponent<InteractableItem>() != null)
		{
			Interactable = other.gameObject.GetComponent<InteractableItem>();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (itemInHand) { return; }
		if (other.gameObject.GetComponent<InteractableItem>() != null)
		{
			Interactable = null;
		}
	}

}
