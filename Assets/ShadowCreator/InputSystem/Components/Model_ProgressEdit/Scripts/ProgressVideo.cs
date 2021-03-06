﻿using System.Collections;
using System.Collections.Generic;
using SC.InputSystem;
using UnityEngine;
using UnityEngine.Video;

public class ProgressVideo : ProgressEdit
{
    public VideoPlayer vp;

    public void Update()
    {
        if(!isClick&& vp!=null&& !isDelay)
        {
            float f = float.Parse(vp.frame.ToString()) / float.Parse(vp.frameCount.ToString());
            setValue(f);
        }
    }
    private bool isDelay;
    public override void ChangeValue(float f)
    {
        isDelay = true;
        vp.frame = long.Parse((f * vp.frameCount).ToString("0."));
        vp.Play();
        Invoke("isEnd",1f);
        base.ChangeValue(f);
    }
    void isEnd()
    {
        isDelay = false;
    }
}
