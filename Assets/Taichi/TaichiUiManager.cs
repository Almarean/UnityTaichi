using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaichiUiManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Taichi");
    }
}
