using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GUIStyle crosshair;

    // Update is called once per frame
    void OnGUI()
    {
        Vector2 scr = new Vector2(Screen.width / 16, Screen.height / 9);

        GUI.Box(new Rect(7.875f * scr.x, 4.375f * scr.y, 0.25f * scr.x, 0.25f * scr.y), "", crosshair);
    }
}
