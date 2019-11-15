using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool showChest;
    public int[] itemsToSpawn;
    public List<Item> chestInv = new List<Item>();
    public Item selectedChestItem;

    private void Start()
    {
        itemsToSpawn = new int[Random.Range(1, 11)];
        for (int i = 0; i < itemsToSpawn.Length; i++)
        {
            itemsToSpawn[i] = Random.Range(0, 999);
            chestInv.Add(ItemData.CreateItem(itemsToSpawn[i]));
        }
    }

    private void OnGUI()
    {
        if (showChest)
        {
            Vector2 scr = new Vector2(Screen.width / 16, Screen.height / 9);
            for (int i = 0; i < chestInv.Count; i++)
            {
                if (GUI.Button(new Rect(12.75f * scr.x, 0.25f * scr.y +i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), chestInv[i].Name))
                {
                    selectedChestItem = chestInv[i];
                }
                if (selectedChestItem == null)
                {
                    return;
                }
                else
                {
                    if(GUI.Button(new Rect(12.5f * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Take"))
                    {
                        LinearInventory.inv.Add(ItemData.CreateItem(selectedChestItem.ID));
                        chestInv.Remove(selectedChestItem);
                        selectedChestItem = null;
                    }
                }
            }
        }
    }
}
