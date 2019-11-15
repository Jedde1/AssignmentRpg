using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOption : MonoBehaviour
{
    public string[] text;
    public int index, option;
    public bool showDlg;
    private void OnGUI()
    {
        if (showDlg)
        {
            Vector2 scr = new Vector2(Screen.width / 16, Screen.height / 9);

            GUI.Box(new Rect(0,scr.y*6,Screen.width,scr.y*3), text[index]);
            if (!(index >= text.Length - 1 || index == option))
            {
                if (GUI.Button(new Rect(scr.x * 14.75f, scr.y * 8.25f, scr.x, scr.y / 2), "Next"))
                {
                    index++;
                }
            }
            else if(index == option)
            {
                if (GUI.Button(new Rect(scr.x * 14.75f, scr.y * 8.25f, scr.x, scr.y / 2), "Decline"))
                {
                    index = text.Length - 1;
                }
                if (GUI.Button(new Rect(scr.x * 13.5f, scr.y * 8.25f, scr.x, scr.y / 2), "Accept"))
                {
                    index++;
                }
            }
            else
            {
                if (GUI.Button(new Rect(scr.x * 14.75f, scr.y * 8.25f, scr.x, scr.y / 2), "Finish"))
                {
                    index = 0;
                    showDlg = false;
                }
            }
            
        }
    }
}
