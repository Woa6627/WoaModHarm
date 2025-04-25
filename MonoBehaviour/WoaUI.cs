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
            GUI.Label(new Rect(50, 30, 200, 20), $"is Moving {player.moving}");
        string speed = GUI.TextArea(new Rect(40, 10, 200, 20),"Speed", 20, GUIStyle.none);
        if(GUI.Button(new Rect(40, 60, 160, 30), "Test"))
        {
            if(player) player.SprintSpeed = float.Parse(speed);
        }
        if(GUI.Button(new Rect(40, 95, 160, 20), "Exit"))
        {
            showWindow = false;
        }
    }
}