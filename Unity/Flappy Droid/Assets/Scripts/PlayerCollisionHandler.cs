using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{

    public TextMeshProUGUI restartHint;

    private void Start()
    {
        restartHint.alpha = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        restartHint.alpha = 1;
        Globals.playing = false;
    }
}
