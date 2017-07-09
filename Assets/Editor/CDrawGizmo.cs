using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CDrawGizmo : MonoBehaviour
{

    public float jump = 0.1f;
    public string startName = "Cube";

    List<GameObject> mList = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < 100; i++) {
            string objName = string.Format("{0} ({1})", startName, i);
            GameObject go = GameObject.Find(objName);
            if (go == null)
                break;
            mList.Add(go);
        }
    }

    public void OnDrawGizmos()
    {
        float color = 0;

        for (int i = 0; i < mList.Count; i++) {
            float r = 0, g = 0, b = 0;
            int to = i + 1;
            if (to == mList.Count)
                to = 0;

            color = jump * i;
            if (color < 1)
                r = color;
            if (color > 1 && color < 2)
                g = color - 1;
            if (color > 2 && color < 3)
                b = color - 2;
            Gizmos.color = new Color(r, g, b);
            Gizmos.DrawLine(mList[i].transform.position, mList[to].transform.position);
        }

        //Gizmos.DrawLine(transform.position, 0.3f);

        //Handles.color = Color.blue;
        //Handles.ArrowCap(0, transform.position, transform.rotation, transform.localScale.z);
        //Handles.Disc(transform.rotation, transform.position, Vector3.up, transform.localScale.z * 0.5f, false, 1);

    }

    public void OnDrawGizmosSelected()
    {
        //Handles.color = new Color(1f, 0f, 0f, 0.2f);
        //Handles.DrawSolidDisc(transform.position, Vector3.up, transform.localScale.z * 0.5f);
    }
}
