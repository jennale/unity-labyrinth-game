using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InformationScreenController : MonoBehaviour {

    void Start()
    {
        //Add button listener
        Button infoButton = GameObject.Find("InfoButton").GetComponent<Button>();
        infoButton.onClick.AddListener(ToggleInfo);

        Button backButton = GameObject.Find("BackButtonInfo").GetComponent<Button>();
        backButton.onClick.AddListener(ToggleInfo);

        gameObject.SetActive(false);
    }

    /// <summary>
    /// Load the main labyrinth game scene.
    /// </summary>
    void ToggleInfo()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

}
