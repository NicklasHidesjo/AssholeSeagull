using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VRControlledHand : MonoBehaviour
{
	[SerializeField] float forceMultiplier;

	bool itemInHand;
	Vector3 throwForce;

	[SerializeField] InteractableItem interactable;

	[SerializeField] InputActionReference grabInteraction;

	XRController hand;

	private void Start()
	{
		grabInteraction.action.performed += Gripped;
		hand = GetComponentInParent<XRController>();
	}

	private void Update()
	{

	}

	private void Gripped(InputAction.CallbackContext context)
	{
		Debug.Log("I am retarded");
		if (itemInHand)
		{
			interactable.DropItem(throwForce * forceMultiplier);
			interactable = null;
			itemInHand = false;
		}
		else if (interactable != null)
		{
			interactable.PickUp(gameObject);
			itemInHand = true;
		}
	}


	private void OnTriggerEnter(Collider other)
	{
		if (itemInHand)
		{ return; }
		if (other.gameObject.GetComponent<InteractableItem>() != null)
		{
			interactable = other.gameObject.GetComponent<InteractableItem>();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (itemInHand)
		{ return; }
		if (other.gameObject.GetComponent<InteractableItem>() != null)
		{
			interactable = null;
		}
	}
}

