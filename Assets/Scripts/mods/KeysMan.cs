using System;
using System.Collections.Generic;
using UnityEngine;

public class KeysMan
{
    struct KeyEvent
    {
        public KeyEvent(bool o, object fn, string type, object[] arg)
        {
            once = o; func = fn; fnType = type; args = arg;
        }
        public bool once;
        string fnType;
        object func;
        object[] args;
        public void Exec()
        {
            switch (fnType) {
                case "": ((Action)func)(); break;
                case "i": ((Action<int>)func)((int)args[0]); break;
            }
        }
    }

    static Dictionary<KeyCode, List<KeyEvent>> keysMap = new Dictionary<KeyCode, List<KeyEvent>>();

    public static void AddKeyEvent(KeyCode key, Action fn, bool once = true, object[] args = null)
    {
        if (!keysMap.ContainsKey(key)) keysMap.Add(key, new List<KeyEvent>());
        keysMap[key].Add(new KeyEvent(once, fn, "", args));
    }
    public static void AddKeyEvent(KeyCode key, Action<int> fn, bool once = true, object[] args = null)
    {
        if (!keysMap.ContainsKey(key)) keysMap.Add(key, new List<KeyEvent>());
        keysMap[key].Add(new KeyEvent(once, fn, "i", args));
    }

    public static void update()
    {
        List<KeyEvent> evts = null;
        foreach (KeyValuePair<KeyCode, List<KeyEvent>> kv in keysMap) {
            bool down = Input.GetKey(kv.Key);
            bool press = Input.GetKeyDown(kv.Key);

            foreach (KeyEvent evt in kv.Value) {
                if (evt.once && !press)
                    continue;
                if (!down)
                    continue;
                if (evts == null) evts = new List<KeyEvent>();
                evts.Add(evt);
                //Debug.Log(kv.Key + " pressed");
            }
        }
        if (evts == null) return;
        foreach (KeyEvent evt in evts)
            evt.Exec();
    }
}
