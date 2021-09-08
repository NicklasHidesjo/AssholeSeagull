using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRControlledHand : MonoBehaviour
{
	[SerializeField] float forceMultiplier;

	bool itemInHand;
	Vector3 throwForce;

	[SerializeField] InteractableItem Interactable;

	public void Gripped(InputAction.CallbackContext context)
	{
		if (itemInHand)
		{
			Interactable.DropItem(throwForce * forceMultiplier);
			Interactable = null;
			itemInHand = false;
		}
		else if (Interactable != null)
		{
			Interactable.PickUp(gameObject);
			itemInHand = true;
		}
	}


	private void OnTriggerEnter(Collider other)
	{
		if (itemInHand)
		{ return; }
		if (other.gameObject.GetComponent<InteractableItem>() != null)
		{
			Interactable = other.gameObject.GetComponent<InteractableItem>();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (itemInHand)
		{ return; }
		if (other.gameObject.GetComponent<InteractableItem>() != null)
		{
			Interactable = null;
		}
	}
}
