/* author: em
 *  email: neverstopem@gmail.com
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMan : MonoBehaviour
{
    static UIMan mInst;
    public static UIMan Inst { get { return mInst; } }

    List<Text> titles;
    List<Text> values;

    void Awake()
    {
        GameObject go = GameObject.Find("Canvas/dbgInfo/titles");
        titles = getCompsInChildren<Text>(go.transform);

        go = GameObject.Find("Canvas/dbgInfo/values");
        values = getCompsInChildren<Text>(go.transform);

        mInst = this;
    }

    public void SetText(int line, object title, object value)
    {
        if (line < 0 || line >= titles.Count) return;
        if (title != null) titles[line].text = title.ToString();
        if (value != null) values[line].text = value.ToString();
    }

    List<T> getCompsInChildren<T>(Transform parent)
    {
        List<T> list = new List<T>();
        for (int i = 0; i < parent.childCount; i++) {
            Transform tf = parent.GetChild(i);
            T t = tf.GetComponent<T>();
            if (t == null) continue;
            list.Add(t);
        }
        return list;
    }

    GameObject findOrCreate(string path, bool setParent = true)
    {
        GameObject go = null, prev = null;
        string[] objs = path.Split('/');

        string existPath = "";
        foreach (string name in objs) {
            existPath += name + '/';
            go = GameObject.Find(existPath);
            if (go == null) {
                go = new GameObject(name);
                if (setParent && prev) go.transform.SetParent(prev.transform);
                go.transform.position.Set(0, 0, 0);
                go.transform.localPosition = new Vector3(0, 0, 0);
            }
            prev = go;
        }
        return go;
    }

}
