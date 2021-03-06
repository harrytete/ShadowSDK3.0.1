﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressVolume : ProgressEdit
{
    public TextMesh text;
    public AudioSource audio;
    public override void Start()
    {
        base.Start();
        setValue(audio.volume);
    }

    public override void setValue(float f)
    {
        audio.volume = f;
        string aa = (f * 100).ToString("F0");
        text.text = "音量大小：" + aa;
        base.setValue(f);
    }
}
