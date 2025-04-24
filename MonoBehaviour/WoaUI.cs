using UnityEngine;
using System;

public class WoaUI : MonoBehaviour
{
    private bool showWindow = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F3))
        {
            showWindow = !showWindow;
        }
    }
    void OnGUI()
    {
        if(!showWindow) return;
        PlayerController player = FindAnyObjectByType<PlayerController>();
        GUI.Box(new Rect(20, 20,200, 120), "Woa UI");
        if(player != null)
            GUI.Label(new Rect(40, 30, 200, 20), $"is Moving {player.moving}");
        if(GUI.Button(new Rect(40, 60, 160, 30), "Test"))
        {
            Debug.Log("Button Clicked");
        }
        if(GUI.Button(new Rect(40, 95, 160, 20), "Exit"))
        {
            showWindow = false;
        }
    }
}