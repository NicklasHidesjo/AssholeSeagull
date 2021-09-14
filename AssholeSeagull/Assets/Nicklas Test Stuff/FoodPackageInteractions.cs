using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	[RequireComponent(typeof(Interactable))]
	public class FoodPackageInteractions : MonoBehaviour
	{
		[SerializeField] FoodPackage package;

		public UnityEvent onHandHoverBegin;
		public UnityEvent onHandHoverEnd;
		public UnityEvent onAttachedToHand;
		public UnityEvent onDetachedFromHand;
		private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);

		public SteamVR_Action_Boolean trigger;

		bool hovering;

		//-------------------------------------------------
		private void OnHandHoverBegin()
		{
			Debug.Log("Hand Hovering");
			hovering = true;
			onHandHoverBegin.Invoke();
		}


		//-------------------------------------------------
		private void OnHandHoverEnd()
		{
			hovering = false;
			onHandHoverEnd.Invoke();
		}

		private void Update()
		{
			if(hovering)
			{
				Debug.Log("Hovering");
				if(trigger.active)
				{
					Debug.Log("triggering");
				}
			}
		}

		//-------------------------------------------------
		private void OnAttachedToHand(Hand hand)
		{
			onAttachedToHand.Invoke();
			Debug.Log("Hand touched");

			GameObject gameObject = package.SpawnFoodItem();
			GrabTypes startingGrabType = hand.GetGrabStarting();
			hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
		}

		private void OnDetachedFromHand(Hand hand)
		{
			onDetachedFromHand.Invoke();
		}
	}
}

