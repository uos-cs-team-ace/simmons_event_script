using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class EventHandler : MonoBehaviour, IDropHandler
{
    public Transform _editor;
    

    public void OnDrop(PointerEventData eventData)
    {
        if (DragSlot._tmpEventData != null)
        {
            _editor.GetComponent<SimObjectEditor>().AddEvent(DragSlot._draggingEventNum, DragSlot._tmpEventData);
        }
    }
}