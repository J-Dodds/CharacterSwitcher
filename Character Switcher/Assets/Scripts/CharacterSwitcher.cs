using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterSwitcher : MonoBehaviour
{
    //The main camera in the game
    public GameObject mainCamera;
    
    //The list for each script on a character that you want to activate/deactivate
    public List<MonoBehaviour> characterOneScripts;
    public List<MonoBehaviour> characterTwoScripts;
    public List<MonoBehaviour> characterThreeScripts;

    //State machine representing every potential character that will be switched to
    public enum CurrentCharacter
    {
        eccCharacterOne,
        eccCharacterTwo,
        eccCharacterThree,
    }
    private CurrentCharacter currentCharacter = 0;

    void Update()
    {
        SwitchUp();
        SwitchDown();
        ActivatingScripts();

        //Sets camera position to a pre designated position and rotation using a tagged object
        mainCamera.transform.position = GameObject.FindGameObjectWithTag("Character" + ((int)currentCharacter + 1) + "Camera").transform.position;
        mainCamera.transform.rotation = GameObject.FindGameObjectWithTag("Character" + ((int)currentCharacter + 1) + "Camera").transform.rotation;

    }

    //On pressing E, character will switch in an ascending order, or resetting to the first character if the last character is active
    void SwitchUp()
    {                                                          //Will need to be changed to the LAST character you want to switch to
        if (Input.GetKeyDown(KeyCode.E) && currentCharacter != CurrentCharacter.eccCharacterThree)
        {
            currentCharacter += 1;
            Debug.Log("Player " + currentCharacter);
        }                                                           //Will need to be changed to the LAST character you want to switch to
        else if (Input.GetKeyDown(KeyCode.E) && currentCharacter == CurrentCharacter.eccCharacterThree)
        {
                               //Will need to be chnaged to the FIRST character you want to switch to
            currentCharacter = CurrentCharacter.eccCharacterOne;
            Debug.Log("Player " + currentCharacter);
        }
    }

    //On pressing Q, character will switch in decending order, or resetting to the last character if the first character is active
    void SwitchDown()
    {
                                                               //Will need to be chnaged to the FIRST character you want to switch to
        if (Input.GetKeyDown(KeyCode.Q) && currentCharacter != CurrentCharacter.eccCharacterOne)
        {
            currentCharacter -= 1;
            Debug.Log("Player " + currentCharacter);
        }
                                                                    //Will need to be chnaged to the FIRST character you want to switch to
        else if (Input.GetKeyDown(KeyCode.Q) && currentCharacter == CurrentCharacter.eccCharacterOne)
        {
                               //Will need to be changed to the LAST character you want to switch to
            currentCharacter = CurrentCharacter.eccCharacterThree;
            Debug.Log("Player " + currentCharacter);
        }
    }

    //When the character is switched, handles activatibg and deactivating any scripts that are in the list of scripts. A new for each will need to be created for each new list of scripts
    void ActivatingScripts()
    {
        //If the third character is the current character, activate the character 3 scripts and deactivate the others
        if (currentCharacter == CurrentCharacter.eccCharacterThree)
        {
            foreach (MonoBehaviour script in characterThreeScripts)
            {
                script.enabled = true;
            }

            foreach (MonoBehaviour script in characterTwoScripts)
            {
                script.enabled = false;
            }

            foreach (MonoBehaviour script in characterOneScripts)
            {
                script.enabled = false;
            }
        }
        //If the second character is the current character, activate the character 2 scripts and deactivate the others
        else if (currentCharacter == CurrentCharacter.eccCharacterTwo)
        {
            foreach (MonoBehaviour script in characterThreeScripts)
            {
                script.enabled = false;
            }

            foreach (MonoBehaviour script in characterTwoScripts)
            {
                script.enabled = true;
            }

            foreach (MonoBehaviour script in characterOneScripts)
            {
                script.enabled = false;
            }
        }
        //If the one character is the current character, activate the character 1 scripts and deactivate the others
        else if (currentCharacter == CurrentCharacter.eccCharacterOne)
        {
            foreach (MonoBehaviour script in characterThreeScripts)
            {
                script.enabled = false;
            }

            foreach (MonoBehaviour script in characterTwoScripts)
            {
                script.enabled = false;
            }

            foreach (MonoBehaviour script in characterOneScripts)
            {
                script.enabled = true;
            }
        }
    }
}
