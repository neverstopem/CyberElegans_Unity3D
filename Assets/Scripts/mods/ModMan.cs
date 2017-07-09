using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModule {
    bool init();
    void start();
}


public class ModMan : IModule
{
    Dictionary<string, IModule> modDict = new Dictionary<string, IModule>();

    public bool init()
    {
        bool err = false;
        addModules();
        foreach (IModule mod in modDict.Values) err |= mod.init();
        return err;
    }

    public void start()
    {

    }


    // Private Functions
    void addModules()
    {
        //addMod(new KeysMan());
    }
    void addMod(IModule mod)
    {
        string name = mod.GetType().Name;
        modDict.Add(name, mod);
    }
}
