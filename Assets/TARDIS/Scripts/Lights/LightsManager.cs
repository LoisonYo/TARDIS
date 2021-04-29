using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{
    private TardisSingleton singleton;
    private Light wallRoundYellowLights;
    private RotatingLight topLights;
    private RotatingLight topRealLights;
    private Light catwalkLights;
    private Light bottomWallBlueLight;
    private Light topWallBlueLight;
    private Light topWallOrangeLight;

    // Start is called before the first frame update
    void Start()
    {
        singleton = TardisSingleton.GetInstance();
        wallRoundYellowLights = new Light("WallDecorationYellowLight");
        topLights = new RotatingLight("MainLight", true);
        topRealLights = new RotatingLight("Light");
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
                bottomWallBlueLight.TurnAllOn();
                topWallBlueLight.TurnAllOn();
                break;

            case TardisState.Starting_2:
                catwalkLights.TurnAllOn();
                topWallOrangeLight.TurnAllOn();
                break;

            case TardisState.Starting_3:
                topLights.TurnAllOn();
                topRealLights.TurnAllOn();
                break;

            case TardisState.Starting_4:
                wallRoundYellowLights.TurnAllOn();
                break;

            case TardisState.TakeOff_1:
            case TardisState.Flying:
                topRealLights.Rotate(Time.deltaTime);
                topLights.Rotate(Time.deltaTime);
                break;
        }
    }
}
