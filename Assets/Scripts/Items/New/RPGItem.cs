using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {Mana, Health};
public class RPGItem : MonoBehaviour
{
    public ItemType type;
    public Sprite spriteNeutral;
    public Sprite spriteHighlighted;

    public int maxSize;

    public void Use()
    {
        switch (type)
        {
            case ItemType.Mana:
                Debug.Log("Mana Come back");
                break;
            case ItemType.Health:
                Debug.Log("Health Come Back");
                break;
        }
    }
}
