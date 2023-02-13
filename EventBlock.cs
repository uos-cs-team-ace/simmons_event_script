using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class EventBlock : MonoBehaviour
{
    public GameObject _blockPrefab;
    public Event _e;

    public TMPro.TMP_Dropdown _dropdownObjectA;
    public TMPro.TMP_Dropdown _dropdownObjectB;
    public TMPro.TMP_Dropdown _dropdownObjectC;
    public TMPro.TMP_Dropdown _dropdownAttributeIndex;
    public TMPro.TMP_Dropdown _dropdownStandards;
    public TMPro.TMP_Dropdown _dropdownFlagA;
    public TMPro.TMP_Dropdown _dropdownFlagB;
    public TMPro.TMP_Dropdown _dropdownStandards2;

    public TMP_InputField _thresholdInputField;
    public TMP_InputField _floatInputField;
    public TMP_InputField _intInputField;

    public Transform _vectorInput;
    public void ModifyEvent()
    {
        //Debug.Log("Debug: EventBlock.ModifyEvent()");
        if(_e == null)
        {
            Debug.Log("Error: EventBlock.ModifyEvent() - No Event");
            return;
        }
        // ----- dropdowns -----

        if(_dropdownObjectA != null)
        {
            _e._simObjectA = _dropdownObjectA.value - 1;
        }
        if(_dropdownObjectB != null)
        {
            _e._simObjectB = _dropdownObjectB.value - 1;
        }
        if(_dropdownObjectC != null)
        {
            _e._simObjectC = _dropdownObjectC.value - 1;
        }
        if(_dropdownAttributeIndex != null)
        {
            _e._attributeIndex = _dropdownAttributeIndex.value - 1;
        }
        if(_dropdownStandards != null)
        {
            _e._fourKindsStandard = _dropdownStandards.value;
        }
        if(_dropdownFlagA != null)
        {
            _e._flagIndexA = _dropdownFlagA.value - 1;
        }
        if(_dropdownFlagB != null)
        {
            _e._flagIndexB = _dropdownFlagB.value - 1;
        }
        if (_dropdownStandards2 != null)
        {
            _e._fourKindsStandard2 = _dropdownStandards2.value;
        }

        // ----- inputfields -----

        if (_thresholdInputField != null)
        {
            float tmp;
            if(float.TryParse(_thresholdInputField.text, out tmp))
            {
                //Debug.Log("Set threshold data: " + _e._threshold);
                _e._threshold = tmp;
            }
            else
            {
                _e._threshold = null;
            }
        }
        if (_floatInputField != null)
        {
            float tmp;
            if(float.TryParse(_floatInputField.text, out tmp))
            {
                _e._floatParameter = tmp;
                //Debug.Log("Set float data: " + _e._floatParameter);
            }
            else
            {
                _e._floatParameter = null;
                //Debug.Log("null");
            }
        }
        if(_intInputField != null)
        {
            int tmp;
            if(int.TryParse(_intInputField.text, out tmp))
            {
                _e._intParameter = tmp;
                //Debug.Log("Set int data: " + _e._intParameter);
            }
            else
            {
                _e._intParameter = null;
            }
        }

        // ----- vector inputfields -----

        if(_vectorInput != null)
        {
            float tmpX;
            float tmpZ;

            if(float.TryParse(_vectorInput.Find("InputFieldX").GetComponent<TMP_InputField>().text, out tmpX) && float.TryParse(_vectorInput.Find("InputFieldZ").GetComponent<TMP_InputField>().text, out tmpZ))
            {
                _e._velocity = new Vector3(tmpX, 0.0f, tmpZ);
            }
            else
            {
                _e._velocity = null;
            }

        }

        if(_e == null)
        {
            Debug.Log("Error: EventBlock.ModifyEvent() - no evnet in block");
        }
        else
        {
            transform.GetComponentInParent<SimObjectEditor>().ModifyEvent(_e);
            NotifyValidity(transform.GetComponentInParent<SimObjectEditor>().CheckValid(_e));
        }

        return;
    }

    public void NotifyValidity(bool validity)
    {
        transform.Find("Notify Icon").gameObject.SetActive(!validity);
    }

    public void ModifyAttributeDropdown()
    {
        transform.GetComponentInParent<SimObjectEditor>().RenewAttributeEventDropDown();
        return;
    }

    public void EditDropdown(Transform simObjectTab)
    {
        //Debug.Log("Debug: EventBlock.EditDropdown()");
        int countSlot = simObjectTab.GetComponent<SimObjectTab>()._countSlot;
        int flagCount = FlagObjectSlot.GetCount();
        int logCount = LogManager._logKey.Count;

        //Debug.Log("Debug: EventBlock.EditDropdown() - flagCount: " + flagCount);

        List<string> optionList = new List<string>();
        optionList.Add("- Select Object");

        List<string> flagOptionList = new List<string>();
        flagOptionList.Add("- Select MapObject");

        List<string> logOptionList = new List<string>();
        logOptionList.Add("- Select Log");


        for (int i = 0; i < countSlot; i++)
        {
            string name = simObjectTab.GetChild(i).GetComponent<SimObjectSlot>().ReturnName();
            optionList.Add(name);
        }

        for (int i = 0; i < flagCount; i++)
        {
            flagOptionList.Add("Flag-" + i.ToString());
        }

        for (int i = 0; i < logCount; i++)
        {
            logOptionList.Add(LogManager._logKey[i]);
        }

        if (_dropdownObjectA != null)
        {
            _dropdownObjectA.ClearOptions();
            _dropdownObjectA.AddOptions(optionList);
            _dropdownObjectA.value = _e._simObjectA + 1;
        }
        if (_dropdownObjectB != null)
        {
            _dropdownObjectB.ClearOptions();
            _dropdownObjectB.AddOptions(optionList);
            _dropdownObjectB.value = _e._simObjectB + 1;
        }

        if (_dropdownObjectC != null)
        {
            _dropdownObjectC.ClearOptions();
            if(45 < _e._eventType && _e._eventType < 49)
            {
                _dropdownObjectC.AddOptions(logOptionList);
            }
            else
            {
                _dropdownObjectC.AddOptions(optionList);
            }
            _dropdownObjectC.value = _e._simObjectC + 1;
        }

        if(_dropdownFlagA != null)
        {
            _dropdownFlagA.ClearOptions();
            _dropdownFlagA.AddOptions(flagOptionList);
            _dropdownFlagA.value = _e._flagIndexA + 1;
        }
        if (_dropdownFlagB != null)
        {
            _dropdownFlagB.ClearOptions();
            _dropdownFlagB.AddOptions(flagOptionList);
            _dropdownFlagB.value = _e._flagIndexB + 1;
        }

        return;
    }

    public void EditAttributeDropdown(Transform simObjectTab)
    {
        if (_dropdownAttributeIndex != null && _dropdownObjectA.value != 0) // AttributeDropdown�� �����Ǿ� ������ A._attribute�� �����ϱ� ������ 
        {
            SimObjectSlot slotScript = simObjectTab.GetChild(_dropdownObjectA.value - 1).GetComponent<SimObjectSlot>();
            int attributeLength = slotScript.ReturnAttributeLength();
            List<string> attributeList = new List<string>();
            attributeList.Add("- Select Attribute");

            for (int i = 0; i < attributeLength; i++)
            {
                //Debug.Log("Attribute Option Add : " + slotScript.ReturnKeyAttribute(i));
                attributeList.Add(slotScript.ReturnKeyAttribute(i));
            }

            _dropdownAttributeIndex.ClearOptions();
            _dropdownAttributeIndex.AddOptions(attributeList);
            if(_e._attributeIndex >= attributeLength)
            {
                _dropdownAttributeIndex.value = -1;
            }
            else
            {
                _dropdownAttributeIndex.value = _e._attributeIndex + 1;
            }
        }
        else if (_dropdownAttributeIndex != null && _dropdownObjectA.value == 0)
        {
            List<string> attributeList = new List<string>();
            attributeList.Add("* Select Object *");
            _dropdownAttributeIndex.ClearOptions();
            _dropdownAttributeIndex.AddOptions(attributeList);
        }
    }

    public void DeleteBlockEvent()
    {
        transform.GetComponentInParent<SimObjectEditor>().DeleteEvent(_e,this.gameObject);
    }

    public void ModifyEventInput(List<string> attribute)
    {
        int length = attribute.Count;
        int index = 0;

        if(_dropdownObjectA != null)
        {
            int value = 0;
            if(int.TryParse(attribute[index], out value))
            {
                _dropdownObjectA.value = value;
            }
            index++;
        }
        if(_dropdownObjectB != null)
        {
            int value = 0;
            if(int.TryParse(attribute[index], out value))
            {
                _dropdownObjectB.value = value;
            }
            index++;
        }
        if(_dropdownObjectC != null)
        {
            int value = 0;
            if(int.TryParse(attribute[index], out value))
            {
                _dropdownObjectC.value = value;
            }
            index++;
        }
        if(_dropdownAttributeIndex != null)
        {
            int value = 0;
            if(int.TryParse(attribute[index], out value))
            {
                _dropdownAttributeIndex.value = value;
            }
            index++;
        }
        if(_dropdownStandards != null)
        {
            int value = 0;
            if(int.TryParse(attribute[index], out value))
            {
                _dropdownStandards.value = value;
            }
            index++;
        }
        if(_dropdownFlagA != null)
        {
            int value = 0;
            if(int.TryParse(attribute[index], out value))
            {
                _dropdownFlagA.value = value;
            }
            index++;
        }
        if(_dropdownFlagB != null)
        {
            int value = 0;
            if(int.TryParse(attribute[index], out value))
            {
                _dropdownFlagB.value = value;
            }
            index++;
        }
        if(_dropdownStandards2 != null)
        {
            int value = 0;
            if(int.TryParse(attribute[index], out value))
            {
                _dropdownStandards2.value = value;
            }
            index++;
        }
        if(_thresholdInputField != null)
        {
            _thresholdInputField.text = attribute[index];
            index++;
        }
        if(_floatInputField != null)
        {
            float value = 0.0f;
            if(float.TryParse(attribute[index], out value))
            {
                _floatInputField.text = value.ToString();
            }
            index++;
        }
        if(_intInputField != null)
        {
            int value = 0;
            if(int.TryParse(attribute[index], out value))
            {
                _intInputField.text = value.ToString();
            }
            index++;
        }
    }

    public EventInformation ReturnEventInformation()
    {
        EventInformation info = new EventInformation();
        List<string> list = new List<string>();
        int attributeLength = 0;

        info.eventblocknumber = _e._eventType;

        if(_dropdownObjectA != null)
        {
            attributeLength++;
            list.Add(_dropdownObjectA.value.ToString());
        }
        if(_dropdownObjectB != null)
        {
            attributeLength++;
            list.Add(_dropdownObjectB.value.ToString());
        }
        if(_dropdownObjectC != null)
        {
            attributeLength++;
            list.Add(_dropdownObjectC.value.ToString());
        }
        if(_dropdownAttributeIndex != null)
        {
            attributeLength++;
            list.Add(_dropdownAttributeIndex.value.ToString());
        }
        if(_dropdownStandards != null)
        {
            attributeLength++;
            list.Add(_dropdownStandards.value.ToString());
        }
        if(_dropdownFlagA != null)
        {
            attributeLength++;
            list.Add(_dropdownFlagA.value.ToString());
        }
        if(_dropdownFlagB != null)
        {
            attributeLength++;
            list.Add(_dropdownFlagB.value.ToString());
        }
        if(_dropdownStandards2 != null)
        {
            attributeLength++;
            list.Add(_dropdownStandards2.value.ToString());
        }
        if(_thresholdInputField != null)
        {
            attributeLength++;
            if(_thresholdInputField.text == null)
            {
                list.Add("");
            }
            else
            {
                list.Add(_thresholdInputField.text);
            }
        }
        if(_floatInputField != null)
        {
            attributeLength++;
            if(_floatInputField.text == null)
            {
                list.Add("");
            }
            else
            {
                list.Add(_floatInputField.text);
            }
        }
        if(_intInputField != null)
        {
            attributeLength++;
            if(_intInputField.text == null)
            {
                list.Add("");
            }
            else
            {
                list.Add(_intInputField.text);
            }
        }
        info.attribute = new string[attributeLength];
        for(int i = 0 ;i < attributeLength;i++)
        {
            info.attribute[i] = list[i];
        }

        return info;
    }

    private void OnDestroy()
    {
        if(transform.GetComponentInParent<SimObjectEditor>() != null)
        {
            transform.GetComponentInParent<SimObjectEditor>().DeleteEvent(_e, this.gameObject);
        }
    }
}
