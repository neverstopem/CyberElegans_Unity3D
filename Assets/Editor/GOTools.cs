using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GOTools
{
    [MenuItem("Tools/Count Children")]
    static void CountChildren()
    {
        if (Selection.activeTransform == null) return;
        int count = -1;     // do not count dad
     EachChildren(Selection.activeTransform, (tf) => { count++; });
        Debug.Log(Selection.activeTransform.name + " Children count:" + count);
    }

    static void EachChildren(Transform dad, Action<Transform> fn)
    {
        for (int i = 0; i < dad.childCount; i++)
            EachChildren(dad.GetChild(i), fn);
        fn(dad);
    }
}
