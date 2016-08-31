using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterToggleData:MonoBehaviour
{
    public List<MonoBehaviour> characterScripts;
    public List<GameObject> activeWhenActive, activeWhenDeactivated;
    public GameObject rootObject, cameraAttachPoint;

    //Activates scripts attached to current character, also sneds message to (currently non existant) OnActivation and OnDeactivation functions that dont need to exist
    public void SwitchTo(bool state)
    {
        for (int i = 0; i < characterScripts.Count; i++)
        {
            characterScripts[i].enabled = state;
        }

        for (int i = 0; i < activeWhenActive.Count; i++)
        {
            activeWhenActive[i].SetActive(state);
        }

        for (int i = 0; i < activeWhenDeactivated.Count; i++)
        {
            activeWhenDeactivated[i].SetActive(!state);
        }

        rootObject.SendMessage(state ? "OnActivation" : "OnDeactivation", SendMessageOptions.DontRequireReceiver);
    }
}