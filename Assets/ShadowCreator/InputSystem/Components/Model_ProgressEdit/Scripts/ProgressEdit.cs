﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using ShadowKit;
using System;
using SC.InputSystem;

public abstract class ProgressEdit : MonoBehaviour, ISCPointerDragHandler, ISCPointerDownHandler, ISCPointerUpHandler
{
    [HideInInspector]
    public GameObject scrollbar;
    [HideInInspector]
    public GameObject control;
    private float initX;
    private float initY;
    private float initZ;
    // Use this for initialization
    BoxCollider box;
    [HideInInspector]
    public float perValue;
    [HideInInspector]
    public bool isClick;
    Vector3[] v3;
    float toto;
    public Action<float> callBack;
    public Action<float> cEndBack;

    // 定义枚举
    [Serializable]
    public enum ProgressTypeEnum
    {
        [EnumAttirbute("X")]
        TypeX = 0,
        [EnumAttirbute("Y")]
        TypeY = 1,
        [EnumAttirbute("Z")]
        TypeZ = 2
    }
    // 定义枚举属性
    [EnumAttirbute("拖动方向")]
    public ProgressTypeEnum editType;
    // 定义枚举
    [Serializable]
    public enum ProgressEditEnum
    {
        [EnumAttirbute("无进度条")]
        NoScroll = 0,
        [EnumAttirbute("有进度条")]
        Scroll = 1,
        [EnumAttirbute("滚动")]
        Normal = 2
    }
    // 定义枚举属性
    [EnumAttirbute("类型")]
    public ProgressEditEnum editScroll;
    public virtual void Start()
    {
        box = this.GetComponent<BoxCollider>();
        switch (editScroll)
        {
            case ProgressEditEnum.Scroll:
                initX = scrollbar.transform.localScale.x;
                initY = scrollbar.transform.localScale.y;
                initZ = scrollbar.transform.localScale.z;
                break;
        }

        initPro();
    }

    public virtual void ChangeValue(float f)
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void GetSocller(Vector3 pv3)
    {

        Vector3[] v3 = GetBoxColliderVertexPositions(box);
        float temp = 0;
        float pv3temp = 0;
        float v3temp = 0;
        switch (editType)
        {
            case ProgressTypeEnum.TypeX:
                temp = Vector3.Distance(new Vector3(box.transform.InverseTransformPoint(pv3).x, 0, 0), new Vector3(box.transform.InverseTransformPoint(v3[1]).x, 0, 0));
                pv3temp = box.transform.InverseTransformPoint(pv3).x;
                v3temp = box.transform.InverseTransformPoint(v3[1]).x;
                break;
            case ProgressTypeEnum.TypeY:
                temp = Vector3.Distance(new Vector3(0, box.transform.InverseTransformPoint(pv3).y, 0), new Vector3(0, box.transform.InverseTransformPoint(v3[1]).y, 0));
                pv3temp = box.transform.InverseTransformPoint(pv3).y;
                v3temp = box.transform.InverseTransformPoint(v3[1]).y;
                break;
            case ProgressTypeEnum.TypeZ:
                temp = Vector3.Distance(new Vector3(0, 0, box.transform.InverseTransformPoint(pv3).z), new Vector3(0, 0, box.transform.InverseTransformPoint(v3[1]).z));
                pv3temp = box.transform.InverseTransformPoint(pv3).z;
                v3temp = box.transform.InverseTransformPoint(v3[1]).z;
                break;
        }

        perValue = temp / toto;
        //if (callBack != null)
        //{
        //    callBack(perValue);
        //}
        if (perValue > 1 && pv3temp > v3temp)
        {
            setValue(1);
        }
        else if (pv3temp < v3temp)
        {
            setValue(0);
        }
        else
        {
            setValue(perValue);
        }
    }

    public void initPro()
    {
        v3 = GetBoxColliderVertexPositions(box);

        toto = Vector3.Distance(box.transform.InverseTransformPoint(v3[0]), box.transform.InverseTransformPoint(v3[1]));
    }

    public virtual void setValue(float bfb)
    {
        if (bfb >= 0 && bfb <= 1)
        {
            if (callBack != null && isClick)
            {
                callBack(bfb);
            }
            perValue = bfb;
            Vector3 position;
            switch (editScroll)
            {
                case ProgressEditEnum.Scroll:
                    switch (editType)
                    {
                        case ProgressTypeEnum.TypeX:
                            control.transform.localPosition = new Vector3(toto * bfb - toto * 0.5f, 0, 0);
                            position = -new Vector3(1, 0, 0) * (toto * 0.5f - toto * bfb * 0.5f);// left justified;
                            scrollbar.transform.localPosition = position;
                            scrollbar.transform.localScale = new Vector3(initX * bfb, initY, initZ);
                            break;
                        case ProgressTypeEnum.TypeY:
                            control.transform.localPosition = new Vector3(0, toto * bfb - toto * 0.5f, 0);
                            position = -new Vector3(0, 1, 0) * (toto * 0.5f - toto * bfb * 0.5f); // left justified;
                            scrollbar.transform.localPosition = position;
                            scrollbar.transform.localScale = new Vector3(initX, initY * bfb, initZ);
                            break;
                        case ProgressTypeEnum.TypeZ:
                            control.transform.localPosition = new Vector3(0, 0, toto * bfb - toto * 0.5f);
                            position = -new Vector3(0, 0, 1) * (toto * 0.5f - toto * bfb * 0.5f); // left justified;
                            scrollbar.transform.localPosition = position;
                            scrollbar.transform.localScale = new Vector3(initX, initY, initZ * bfb);
                            break;
                    }
                    break;
                case ProgressEditEnum.NoScroll:
                    switch (editType)
                    {
                        case ProgressTypeEnum.TypeX:
                            control.transform.localPosition = new Vector3(toto * bfb - toto * 0.5f, 0, 0);
                            break;
                        case ProgressTypeEnum.TypeY:
                            control.transform.localPosition = new Vector3(0, toto * bfb - toto * 0.5f, 0);
                            break;
                        case ProgressTypeEnum.TypeZ:
                            control.transform.localPosition = new Vector3(0, 0, toto * bfb - toto * 0.5f);
                            break;
                    }
                    break;
            }


        }
    }

    Vector3[] GetBoxColliderVertexPositions(BoxCollider boxcollider)
    {
        var vertices = new Vector3[2];
        switch (editType)
        {
            case ProgressTypeEnum.TypeX:
                //下面4个点
                vertices[0] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(boxcollider.size.x, boxcollider.size.y, boxcollider.size.z) * 0.5f);
                //上面4个点
                vertices[1] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(-boxcollider.size.x, boxcollider.size.y, boxcollider.size.z) * 0.5f);
                break;
            case ProgressTypeEnum.TypeY:
                //下面4个点
                vertices[0] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(boxcollider.size.x, boxcollider.size.y, boxcollider.size.z) * 0.5f);
                //上面4个点
                vertices[1] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(boxcollider.size.x, -boxcollider.size.y, boxcollider.size.z) * 0.5f);
                break;
            case ProgressTypeEnum.TypeZ:
                //下面4个点
                vertices[0] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(boxcollider.size.x, boxcollider.size.y, boxcollider.size.z) * 0.5f);
                //上面4个点
                vertices[1] = boxcollider.transform.TransformPoint(boxcollider.center + new Vector3(boxcollider.size.x, boxcollider.size.y, -boxcollider.size.z) * 0.5f);
                break;
        }
        return vertices;
    }
    public void enterbox()
    {
        isClick = true;
    }
    public void exitbox()
    {
        ChangeValue(perValue);
        if (cEndBack != null)
        {

            cEndBack(perValue);
        }
        isClick = false;
    }


    public virtual void OnSCPointerDrag(InputDevicePartBase part, SCPointEventData eventData)
    {
        //eventData.hitAnchorPointer.transform.position = eventData.currentHitPoint;
        //GetSocller(eventData.currentHitPoint);

        if (eventData.target != null)
        {
            eventData.hitAnchorPointer.transform.position = eventData.currentHitPoint;
            GetSocller(eventData.currentHitPoint);
        }
        else if (eventData.target == null)
        {
            eventData.hitAnchorPointer.transform.position = eventData.hitPointer.transform.position;
            GetSocller(eventData.hitPointer.transform.position);
        }

    }

    public virtual void OnSCPointerDown(InputDevicePartBase part, SCPointEventData eventData)
    {
        GetSocller(eventData.currentHitPoint);
        enterbox();
    }

    public virtual void OnSCPointerUp(InputDevicePartBase part, SCPointEventData eventData)
    {
        exitbox();
    }
}
