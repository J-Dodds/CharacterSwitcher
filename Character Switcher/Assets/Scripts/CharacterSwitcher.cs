using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterSwitcher : MonoBehaviour
{   
    //The main camera in the game
    public GameObject mainCamera;

    //List of sets of character information from the above CharacetrToggleData class
    public List<CharacterToggleData> characterDatas;

    //Index of currently selected character
    public int selectedCharacterIndex;

    public float cameraPositionDisplacementPercentagePerSecond = 0.99f;
    public float cameraRotationDisplacementPercentagePerSecond = 0.99f;

    void Start()
    {
        for (int i = 0; i < characterDatas.Count; i++)
        {
            characterDatas[i].SwitchTo(i == selectedCharacterIndex);
        }
    }

    void Update()
    {
        //On input 1, handle switching up the index of CharacterDatas
        if (Input.GetKeyDown(KeyCode.E))
        {
            HandleSwitching(1);
        }
        //On input 2, handle switching down the index of CharacterDatas
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            HandleSwitching(-1);
        }

        //Moves camera to the camera attach point of the currently selected character
        if (characterDatas[selectedCharacterIndex].cameraAttachPoint != null)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, characterDatas[selectedCharacterIndex].cameraAttachPoint.transform.position, cameraPositionDisplacementPercentagePerSecond * Time.deltaTime);
            mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, characterDatas[selectedCharacterIndex].cameraAttachPoint.transform.rotation, cameraRotationDisplacementPercentagePerSecond * Time.deltaTime);
        }
        else
        {
            Debug.Log("No camera attach point on game object!");
        }
    }

    //Deactivates current object, moves by the offset in the array, and activates the new current object. Wraps arounds the ends of the array
    void HandleSwitching(int offset)
    {
        SetActiveCurrentCharacter(false);
        selectedCharacterIndex += offset;
        selectedCharacterIndex += characterDatas.Count;
        selectedCharacterIndex %= characterDatas.Count;
        SetActiveCurrentCharacter(true);
    }

    //Handles the activation/deactivation based on the state bool
    void SetActiveCurrentCharacter(bool state)
    {
        characterDatas[selectedCharacterIndex].SwitchTo(state);
    }  
}
