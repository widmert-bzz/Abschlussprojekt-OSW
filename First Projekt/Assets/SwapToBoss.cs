using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapToBoss : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("Bossfight");
    }

}
