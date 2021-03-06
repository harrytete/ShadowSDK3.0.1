﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(ProgressEdit),true)] //关联之前的脚本
public class EditorProgress : Editor
{


    private SerializedObject obj; //序列化


    private SerializedProperty scrollbar, editManagerType, control; //定义变量


    void OnEnable()
    {
        obj = new SerializedObject(target);

        editManagerType = obj.FindProperty("editScroll");
        scrollbar = obj.FindProperty("scrollbar");
        control = obj.FindProperty("control");

    }


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        obj.Update();


    //    EditorGUILayout.PropertyField(editManagerType);


        if (editManagerType.enumValueIndex == 0)
        {
            EditorGUILayout.PropertyField(control);
        }
        else if (editManagerType.enumValueIndex == 1)
        {
            EditorGUILayout.PropertyField(scrollbar);
            EditorGUILayout.PropertyField(control);
        }
        else if (editManagerType.enumValueIndex == 2)
        {
        }


        obj.ApplyModifiedProperties();

    }


}