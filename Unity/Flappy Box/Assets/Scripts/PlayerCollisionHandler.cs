using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollisionHandler : MonoBehaviour
{

    public Text restartHint;

    private void Start()
    {
        restartHint.color = Color.clear;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        restartHint.color = Color.white;
        Globals.playing = false;
    }
}
