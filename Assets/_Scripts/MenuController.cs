/*
 *      Authors: Tony Bogun, Leonti Brechka, Baljinder Tanda, Hao Jiang
 *      Last Modified By: Leonti Brechka
 *      Date Modified: 2017-04-15
 *      Description: Controls all button click events and sound mode option
 *      Version: 3.0 
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Reference to scene management
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
    
{
    public Text SoundLabel;

    // Use this for initialization
    void Start()
    {
        if (SoundLabel)
        {
            if (AudioListener.volume != 0f)
            {
                SoundLabel.text = "Turn Sound Off";
            }
            else
            {
                SoundLabel.text = "Turn Sound On";
            }
        }    
    }

    // Update is called once per frame
    void Update()
    {

    }

    // StartButton event listener
    public void StartButton_Click()
    {
        SceneManager.LoadScene("Level1");
    }

    // InstructionsButton event listener
    public void InstructionsButton_Click()
    {
        SceneManager.LoadScene("Instructions");
    }

    // MainMenuButton evene listener
    public void MainMenuButton_Click()
    {
        SceneManager.LoadScene("Menu");
    }

    // OptionsButton evene listener
    public void OptionsButton_Click()
    {
        SceneManager.LoadScene("Options");
    }

    // Toggle sound option on or off
    public void ToggleSound_Click()
    {
        if (AudioListener.volume != 0f)
        {
            AudioListener.volume = 0f;
            SoundLabel.text = "Turn Sound On";
        }
        else
        {
            AudioListener.volume = 1f;
            SoundLabel.text = "Turn Sound Off";
        }    
    }
}
