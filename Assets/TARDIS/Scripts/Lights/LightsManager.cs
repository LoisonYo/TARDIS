using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{
    private TardisSingleton singleton;
    private Light wallRoundYellowLights;
    private Light topLights;
    private Light topRealLights;
    private Light catwalkLights;
    private Light bottomWallBlueLight;
    private Light topWallBlueLight;
    private Light topWallOrangeLight;

    // Start is called before the first frame update
    void Start()
    {
        singleton = TardisSingleton.GetInstance();
        wallRoundYellowLights = new Light("WallDecorationYellowLight");
        topLights = new Light("MainLight", true);
        topRealLights = new Light("Light");
        catwalkLights = new Light("CatwalkLight");
        bottomWallBlueLight = new Light("LongBlueLight");
        topWallBlueLight = new Light("WallDecorationBlueLight");
        topWallOrangeLight = new Light("WallDecorationOrangeLight");
    }

    // Update is called once per frame
    void Update()
    {
        switch(singleton.state)
        {
            case TardisState.Starting_1:
                bottomWallBlueLight.TurnOn();
                topWallBlueLight.TurnOn();
                break;

            case TardisState.Starting_2:
                catwalkLights.TurnOn();
                topWallOrangeLight.TurnOn();
                break;

            case TardisState.Starting_3:
                topLights.TurnOn();
                topRealLights.TurnOn();
                break;

            case TardisState.Starting_4:
                wallRoundYellowLights.TurnOn();
                break;
        }
    }
}
