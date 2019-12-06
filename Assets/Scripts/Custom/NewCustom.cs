using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCustom : MonoBehaviour
{
    public GameObject[] skins;
    public int currentSkin;

    private void Update()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            if (i == currentSkin)
            {
                skins[i].SetActive(true);
            }
            else
            {
                skins[i].SetActive(false);
            }
        }
    }
    public void SwitchSkins()
    {
        if (currentSkin == skins.Length - 1)
        {
            currentSkin = 0;
        }
        else
        {
            currentSkin++;
        }
    }
}
