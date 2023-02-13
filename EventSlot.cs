using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EventSlot : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler
{
    public GameObject _eventBlockPrefeb;
    public int _eventType;

    public void OnBeginDrag(PointerEventData eventData)
    {
        DragSlot._tmpEventData = _eventBlockPrefeb;
        DragSlot._draggingEventNum = this._eventType;
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        DragSlot._tmpEventData = null;
    }
}
