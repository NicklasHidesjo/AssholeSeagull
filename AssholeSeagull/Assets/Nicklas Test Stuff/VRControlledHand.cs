using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
//using UnityEngine.InputSystem;

public class VRControlledHand : MonoBehaviour
{
	[SerializeField] float forceMultiplier;

	bool itemInHand;
	Vector3 throwForce;

	[SerializeField] InteractableItem interactable;

	[SerializeField] SteamVR_Input_Sources handType;
	[SerializeField] SteamVR_Action_Boolean grabAction;

	private void Update()
	{
		bool isPressed = grabAction.GetState(handType);

		if(isPressed)
		{
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

