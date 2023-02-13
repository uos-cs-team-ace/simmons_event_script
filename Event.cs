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
    public int _flagIndexA = -1; // flagList ���� ����
    public int _flagIndexB = -1;
    public int? _intParameter;
    public float? _floatParameter;
    public float? _threshold;
    public int _fourKindsStandard = 0; // 0 : �̼���
    public int _fourKindsStandard2 = 0; // 0 : �̼���
    public bool _eventState = true; // 1ȸ�� �̺�Ʈ�� ��� ��ŵ�ϱ� ����
    public Vector3? _velocity = null;
    public float _lastActivatedTime = 0.0f; // ��Ÿ�ӿ�

    public float _attributeB; // ���� �Ⱦ�
}
