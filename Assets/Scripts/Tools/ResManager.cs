using System.Linq;
using System.Collections.Generic;
using UnityEngine;


public class CRenderObject : MonoBehaviour
{
    public virtual void Init(object[] args) { }
    public virtual void Setup(Color c, float w = -1) { }
    public virtual void Draw(params Vector3[] args) { }
    public virtual void Hide() { }
}


public class ResManager
{
    public static GameObject root;
    public static Dictionary<EWormParts, Transform> dads = new Dictionary<EWormParts, Transform>();

    public static CRenderObject CreateObject(params object[] args)
    {
        EWormParts type = (EWormParts)args[0];
        string path = getPrefabPath(type);
        if (string.IsNullOrEmpty(path)) return null;

        Object prefab = Resources.Load(path);
        GameObject go = (GameObject)GameObject.Instantiate(prefab);
        if (go == null) return null;

        List<object> list = args.ToList();
        list.RemoveRange(0, 1);
        object[] restArgs = list.ToArray();

        Transform dad = WorldMan.Inst.GetParent(type);
        string name = string.Format("{0} {1}", type, dad.childCount);
        go.transform.SetParent(dad);
        go.name = name;
        go.SetActive(false);
        CRenderObject obj = go.GetComponent<CRenderObject>();
        obj.Init(restArgs);
        return obj;
    }

    public static T CreateObjectFromPrefab<T>(string path, Transform parent)
    {
        Object prefab = Resources.Load(path);
        GameObject go = (GameObject)GameObject.Instantiate(prefab);
        go.transform.SetParent(parent);
        return go.GetComponent<T>();
    }

    public static string getPrefabPath(EWormParts type)
    {
        switch (type) {
            case EWormParts.point:
            case EWormParts.neuron: return "Prefabs/Sphere";
            case EWormParts.axon:
            case EWormParts.spring: return "Prefabs/Line";
            case EWormParts.muscle: return "Prefabs/Cone";
        }
        return null;
    }
}
