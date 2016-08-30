using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject mainCamera;

    public enum CurrentCharacter
    {
        eccCharacterOne,
        eccCharacterTwo,
        eccCharacterThree,
    }
    private CurrentCharacter currentCharacter = 0;


    // Use this for initialization
    void Start()
    {

    }

    void FixedUpdate()
    {
        SwitchUp();
        SwitchDown();

        mainCamera.transform.position = GameObject.FindGameObjectWithTag("Character" + ((int)currentCharacter + 1) + "Camera").transform.position;
        mainCamera.transform.rotation = GameObject.FindGameObjectWithTag("Character" + ((int)currentCharacter + 1) + "Camera").transform.rotation;

        
        if(currentCharacter == CurrentCharacter.eccCharacterThree)
        {
            GameObject.FindGameObjectWithTag("Character1").GetComponent<PlayerController>().enabled = false;
            GameObject.FindGameObjectWithTag("Character2").GetComponent<PlayerController>().enabled = false;
            GameObject.FindGameObjectWithTag("Character3").GetComponent<PlayerController>().enabled = true;
        }
        else if (currentCharacter == CurrentCharacter.eccCharacterTwo)
        {
            GameObject.FindGameObjectWithTag("Character1").GetComponent<PlayerController>().enabled = false;
            GameObject.FindGameObjectWithTag("Character2").GetComponent<PlayerController>().enabled = true;
            GameObject.FindGameObjectWithTag("Character3").GetComponent<PlayerController>().enabled = false;
        }
        else if(currentCharacter == CurrentCharacter.eccCharacterOne)
        {
            GameObject.FindGameObjectWithTag("Character1").GetComponent<PlayerController>().enabled = true;
            GameObject.FindGameObjectWithTag("Character2").GetComponent<PlayerController>().enabled = false;
            GameObject.FindGameObjectWithTag("Character3").GetComponent<PlayerController>().enabled = false;
        }
    }

    void SwitchUp()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentCharacter != CurrentCharacter.eccCharacterThree)
        {
            currentCharacter += 1;
            Debug.Log("Player " + currentCharacter);
        }
        else if (Input.GetKeyDown(KeyCode.E) && currentCharacter == CurrentCharacter.eccCharacterThree)
        {
            currentCharacter = CurrentCharacter.eccCharacterOne;
            Debug.Log("Player " + currentCharacter);
        }
    }

    void SwitchDown()
    {
        if (Input.GetKeyDown(KeyCode.Q) && currentCharacter != CurrentCharacter.eccCharacterOne)
        {
            currentCharacter -= 1;
            Debug.Log("Player " + currentCharacter);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && currentCharacter == CurrentCharacter.eccCharacterOne)
        {
            currentCharacter = CurrentCharacter.eccCharacterThree;
            Debug.Log("Player " + currentCharacter);
        }
    }
}
