using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event
{
    public int _eventType;
    public int _eventContainer;
    public int _simObjectA = -1;
    public int _simObjectB = -1;
    public int _simObjectC = -1;
    public int _attributeIndex;
    public int _flagIndexA = -1; // flagList 참조 예정
    public int _flagIndexB = -1;
    public int? _intParameter;
    public float? _floatParameter;
    public float? _threshold;
    public int _fourKindsStandard = 0; // 0 : 미선택
    public int _fourKindsStandard2 = 0; // 0 : 미선택
    public bool _eventState = true; // 1회성 이벤트의 경우 스킵하기 위함
    public Vector3? _velocity = null;
    public float _lastActivatedTime = 0.0f; // 쿨타임용

    public float _attributeB; // 아직 안씀
}
