using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragSlot : MonoBehaviour
{
    static public DragSlot _instance;
    //public SimobjectSlot dragSlot;

    public Image _imageSimobject;
    public static GameObject _tmpEventData;
    public static int _draggingEventNum;
    
    void Start()
    {
        _instance = this;
    }

    public void DragSetImage(Image imageSimobject){
        _imageSimobject.sprite = imageSimobject.sprite;
        SetColor(1);
    }
    public void SetColor(float alpha){
        Color color = _imageSimobject.color;
        color.a = alpha;
        _imageSimobject.color = color;
    }
}
