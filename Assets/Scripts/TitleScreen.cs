using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
   public void OnButtonGameStart()
    {
        SceneManager.LoadScene("level1");
    }
}
