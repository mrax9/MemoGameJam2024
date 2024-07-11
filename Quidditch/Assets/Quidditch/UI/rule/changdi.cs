using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changdi : MonoBehaviour
{
    public Button Button;
    public void SwitchScene3()
    {
        SceneManager.LoadScene("Lottery page");
    }
}
