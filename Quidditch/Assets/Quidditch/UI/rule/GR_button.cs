using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GR_button : MonoBehaviour
{
    public Button GR_Button;
    public void SwitchScene2()
    {
        SceneManager.LoadScene("rule changdi");
    }
}
