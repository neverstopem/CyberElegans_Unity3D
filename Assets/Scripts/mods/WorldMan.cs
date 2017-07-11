/* author: em
 *  email: neverstopem@gmail.com
 */

using System.Collections.Generic;
using UnityEngine;

public class WorldMan : MonoBehaviour {

    static WorldMan mInstance;
    public static WorldMan Inst { get { return mInstance; } }

    Dictionary<EWormParts, Transform> parts = new Dictionary<EWormParts, Transform>();
    Transform worm;

    void Awake()
    {
        worm = new GameObject().transform;
        worm.SetParent(transform);
        worm.name = "worm";

        mInstance = this;
    }

    public Transform GetParent(EWormParts type)
    {
        if (!parts.ContainsKey(type)) {
            Transform dad = transform.Find(type.ToString());
            if (!dad) {
                dad = new GameObject().transform;
                dad.SetParent(worm);
                dad.name = type.ToString();
            }
            parts.Add(type, dad);
        }
        return parts[type];
    }
}
