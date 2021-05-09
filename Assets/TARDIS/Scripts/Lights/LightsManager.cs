using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{
    private TardisSingleton singleton;
    private TardisLight wallRoundYellowLights;
    private TardisLight orangeEngineLights;
    private TardisLight rotorWhiteLights;
    private RotatingLight topLights;
    private RealRotatingLight topRealLights;
    private TardisLight catwalkLights;
    private TardisLight bottomWallBlueLight;
    private TardisLight topWallBlueLight;
    private TardisLight topWallOrangeLight;

    // Start is called before the first frame update
    void Start()
    {
        singleton = TardisSingleton.GetInstance();
        rotorWhiteLights = new TardisLight("TimeRotorWhiteLight");
        orangeEngineLights = new TardisLight("EngineLight");
        wallRoundYellowLights = new TardisLight("WallDecorationYellowLight");
        topLights = new RotatingLight("MainLight", true);
        topRealLights = new RealRotatingLight("Light");
        catwalkLights = new TardisLight("CatwalkLight");
        bottomWallBlueLight = new TardisLight("LongBlueLight");
        topWallBlueLight = new TardisLight("WallDecorationBlueLight");
        topWallOrangeLight = new TardisLight("WallDecorationOrangeLight");
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
                orangeEngineLights.TurnAllOn();
                break;

            case TardisState.Starting_3:
                topLights.TurnAllOn();
                topRealLights.TurnAllOn();
                rotorWhiteLights.TurnAllOn();
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
