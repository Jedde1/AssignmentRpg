using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    
    public bool showShop;
    public int[] itemsToSpawn;
    public List<Item> shopInv = new List<Item>();
    public Item selectedShopItem;

    private void Start()
    {
        itemsToSpawn = new int[Random.Range(1, 11)];
        for (int i = 0; i < itemsToSpawn.Length; i++)
        {
            itemsToSpawn[i] = Random.Range(0, 999);
            shopInv.Add(ItemData.CreateItem(itemsToSpawn[i]));
        }
    }

    private void OnGUI()
    {
        if (showShop)
        {
            Vector2 scr = new Vector2(Screen.width / 16, Screen.height / 9);
            GUI.Box(new Rect(scr.x * 6.5f, scr.y * .25f, scr.x * 3, scr.y * .25f), "$" + LinearInventory.money);
            for (int i = 0; i < shopInv.Count; i++)
            {
                if (GUI.Button(new Rect(12.75f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), shopInv[i].Name))
                {
                    selectedShopItem = shopInv[i];
                }
                
            }
            if (selectedShopItem == null)
            {
                return;
            }
            else
            {
                //Display item box with value +25%
                GUI.Box(new Rect(scr.x * 9.65f, scr.y * 1.5f, scr.x * 3, scr.y * 3), selectedShopItem.IconName);
                GUI.Box(new Rect(scr.x * 9.65f, scr.y * 0.5f, scr.x * 3, scr.y * .25f), selectedShopItem.Name);
                GUI.Box(new Rect(scr.x * 9.65f, scr.y * 1, scr.x * 3, scr.y * .25f), selectedShopItem.Description);
                GUI.Box(new Rect(scr.x * 9.65f, scr.y * 5, scr.x * 3, scr.y * .25f), "$"+ (int)(selectedShopItem.Value+selectedShopItem.Value *0.25f));
                //if inv.money >= value + 25%
                if (LinearInventory.money >= (selectedShopItem.Value + (int)selectedShopItem.Value * 0.25f))
                {
                    if (GUI.Button(new Rect(12.5f * scr.x, 6.5f * scr.y, 1.5f * scr.x, 0.25f * scr.y), "Buy"))
                    {
                        LinearInventory.inv.Add(ItemData.CreateItem(selectedShopItem.ID));
                        shopInv.Remove(selectedShopItem);
                        //inv.money -= value+25%
                        LinearInventory.money -= (int)(selectedShopItem.Value + selectedShopItem.Value * 0.25f);
                        selectedShopItem = null;
                    }
                }
                
            }
        }
    }
}

