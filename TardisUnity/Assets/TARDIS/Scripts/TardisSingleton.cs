using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TardisSingleton
{
    private static TardisSingleton instance;

    public TardisState state;

    public static TardisSingleton GetInstance()
    {
        if (instance == null)
            instance = new TardisSingleton();
        return instance;
    }

    private TardisSingleton()
    {
        state = TardisState.Shutdown;
    }
}
