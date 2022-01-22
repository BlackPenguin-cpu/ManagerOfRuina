using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class EventX : MonoBehaviour
{
	public void ButtonClick()
	{
		Singleton<EventManager>.Instance.eventbg.gameObject.SetActive(false);
	}
}
