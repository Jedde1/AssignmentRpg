using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCustomisation : MonoBehaviour
{

    public static Renderer character;
    public PlayerHandler player;
    private void Awake()
    {
        character = GameObject.FindGameObjectWithTag("Renderer").GetComponent<SkinnedMeshRenderer>();
    }
    public static void SetTexture(string type, int index)
    {
        Texture2D texture = null;
        int materialIndex = 0;
        switch (type)
        {
            case "Skin":
                texture = Resources.Load("Character/Skin_" + index.ToString()) as Texture2D;
                materialIndex = 1;
                break;
            case "Eyes":
                texture = Resources.Load("Character/Eyes_" + index.ToString()) as Texture2D;
                materialIndex = 2;
                break;
            case "Mouth":
                texture = Resources.Load("Character/Mouth_" + index.ToString()) as Texture2D;
                materialIndex = 3;
                break;
            case "Hair":
                texture = Resources.Load("Character/Hair_" + index.ToString()) as Texture2D;
                materialIndex = 4;
                break;
            case "Clothes":
                texture = Resources.Load("Character/Clothes_" + index.ToString()) as Texture2D;
                materialIndex = 5;
                break;
            case "Armour":
                texture = Resources.Load("Character/Armour_" + index.ToString()) as Texture2D;
                materialIndex = 6;
                break;
                
        }
        Material[] mats = character.materials;
        mats[materialIndex].mainTexture = texture;
        character.materials = mats;
    }
}

