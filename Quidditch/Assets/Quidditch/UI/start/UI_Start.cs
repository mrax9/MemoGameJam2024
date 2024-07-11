using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Start : MonoBehaviour
{
    public Button Button;
    public void SwitchScene()
    {
        SceneManager.LoadScene("game_rule1");
    }
}
                                     