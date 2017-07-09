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
                Debug.Log(kv.Key + " pressed");
            }
        }
        if (evts == null) return;
        foreach (KeyEvent evt in evts)
            evt.Exec();

#if false
      if(g_keys->keyDown[VK_F5]) {
        g_keys->keyDown[VK_F5] = false;
        mode = !mode;
      }

      if(g_keys->keyDown[VK_F6]) {
        g_keys->keyDown[VK_F6] = false;
        mode2 = !mode2;
        f6 = false;
      }

      if(g_keys->keyDown[VK_F7]) {
        g_keys->keyDown[VK_F7] = false;
        mode3 = !mode3;
        mode4 = false;
        f6 = false;
      }

      if(g_keys->keyDown[VK_F8]) {
        g_keys->keyDown[VK_F8] = false;
        mode4 = !mode4;
        mode3 = false;
        f6 = false;
      }

      if(g_keys->keyDown[VK_F2]) {
        g_keys->keyDown[VK_F2] = false;
        f9 = !f9;
      }

      if(g_keys->keyDown[VK_F3]) {
        g_keys->keyDown[VK_F3] = false;
        f10 = !f10;
      }

      if(g_keys->keyDown[VK_F4]) {
        g_keys->keyDown[VK_F4] = false;
        f11 = !f11;
      }

      /////// KEY A //////////////
      if(g_keys->keyDown[65]) {
        if(key_a_prev)
        , key_a = true;

        key_a_prev = true;
      } else {
        if(!key_a_prev)
        , key_a = false;

        key_a_prev = false;
      }

      /////// KEY R //////////////
      if(g_keys->keyDown[82]) {
        if(key_r_prev)
        , key_r = true;

        key_r_prev = true;
      } else {
        if(!key_r_prev)
        , key_r = false;

        key_r_prev = false;
      }

      if(key_r) {
        worm->rotateWormAroundAnterPosterAxis(1.f);

        f6 = false;
      }

      //语疣怆屙桢 镱玷鲨扈 礤轲铐钼	

      //X
      if(f6) {
        /*
        for(int ind = 0; ind<100;ind++)
        {
        , if (g_keys->keyDown [ind])
        , {
              break;
        , }
        }
        */


      //
      }

#endif

    }
}
