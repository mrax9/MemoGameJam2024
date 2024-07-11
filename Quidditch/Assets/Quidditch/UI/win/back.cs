using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class back : MonoBehaviour
{
    public Button Button;
    public void SwitchScene()
    {
        SceneManager.LoadScene("UI_last");
    }
}
