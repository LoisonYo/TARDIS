using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TardisEventManager : MonoBehaviour
{
    private TardisSingleton singleton;

    // Start is called before the first frame update
    void Start()
    {
        singleton = TardisSingleton.GetInstance();

        StartCoroutine(TardisMainCouroutine());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(singleton.state);
        if(singleton.state == TardisState.Stop || Input.GetKey("escape"))
            Application.Quit();
    }

    IEnumerator TardisMainCouroutine()
    {
        yield return new WaitForSeconds(7);
        singleton.state = TardisState.Starting_1;

        yield return new WaitForSeconds(1);
        singleton.state = TardisState.Starting_2;

        yield return new WaitForSeconds(1);
        singleton.state = TardisState.Starting_3;

        yield return new WaitForSeconds(1);
        singleton.state = TardisState.Starting_4;

        yield return new WaitForSeconds(1);
        singleton.state = TardisState.Started;

        yield return new WaitForSeconds(1);
        singleton.state = TardisState.Started;

        yield return new WaitForSeconds(10);
        singleton.state = TardisState.TakeOff_1;

        yield return new WaitForSeconds(3);
        singleton.state = TardisState.Flying;
        yield return new WaitForSeconds(35);
        singleton.state = TardisState.Stop;
    }
}
