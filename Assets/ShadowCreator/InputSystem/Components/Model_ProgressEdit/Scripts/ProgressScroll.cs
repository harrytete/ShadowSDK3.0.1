﻿using System.Collections;
using System.Collections.Generic;
using SC.InputSystem;
using UnityEngine;

public class ProgressScroll : ProgressEdit
{
    public MeshRenderer mr;
    private float initValue;
    Vector2 initv2;
    public override void Start()
    {
        base.Start();
        initv2 = mr.material.GetTextureOffset("_MainTex");
    }
    public override void OnSCPointerDown(InputDevicePartBase part, SCPointEventData eventData)
    {
        base.OnSCPointerDown(part, eventData);
        initValue = perValue;
    }

    public override void OnSCPointerUp(InputDevicePartBase part, SCPointEventData eventData)
    {
        base.OnSCPointerUp(part, eventData);
        initv2 = mr.material.GetTextureOffset("_MainTex");
    }

    public override void OnSCPointerDrag(InputDevicePartBase part, SCPointEventData eventData)
    {
        base.OnSCPointerDrag(part, eventData);
    }

    public override void setValue(float f)
    {

        base.setValue(f);
        f = (f - initValue)/2;
        float vf = 0;
        if((initv2.y - f)>0.85f)
        {
            vf = 0.85f;
        }
        else if((initv2.y - f) < 0f)
        {
            vf = 0f;

        }
        else
        {
            vf = initv2.y - f;
        }

        mr.material.SetTextureOffset("_MainTex", new Vector2(0, vf));
    }
}
