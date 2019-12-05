using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewInventory : MonoBehaviour
{
    private RectTransform inventoryRect;

    private float inventoryWidth, inventoryHeight;

    public int slots;
    public int rows;

    public float slotPaddingLeft, slotPaddingTop;

    public float slotSize;

    public GameObject slotPrefab;

    private List<GameObject> allSlots;

    private int emptySlot;
    // Start is called before the first frame update
    void Start()
    {
        CreateLayOut();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void CreateLayOut()
    {
        allSlots = new List<GameObject>();
        emptySlot = slots;
        //Controls the Width of the inventory based on how many slots
        inventoryWidth = (slots / rows) * (slotSize + slotPaddingLeft) + slotPaddingLeft;
        //Controls the Height of the inventory based on how many rows
        inventoryHeight = rows * (slotSize + slotPaddingTop) + slotPaddingTop;
        inventoryRect = GetComponent<RectTransform>();
        //Sets the size based on the position of the anchors
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventoryWidth);
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventoryHeight);
        //Instantates the slots sprites into the inventory
        int columns = slots / rows;
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                GameObject newSlot = (GameObject)Instantiate(slotPrefab);
                //Uses the rectTransform on the Slot Prefab
                RectTransform slotRect = newSlot.GetComponent<RectTransform>();

                newSlot.name = "Slot";

                newSlot.transform.SetParent(this.transform.parent);
                //Sets position of the slots
                slotRect.localPosition = inventoryRect.localPosition + new Vector3(slotPaddingLeft * (x + 1) + (slotSize * x), -slotPaddingTop * (y + 1) - (slotSize * y));
                //Sets the size based on the position of the anchors
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);

                allSlots.Add(newSlot);
            }
        }
    }
    public bool AddItem(RPGItem item)
    {
        if (item.maxSize == 1)
        {
            PlaceEmpty(item);
            return true;
        }
        return false;
    }
    private bool PlaceEmpty(RPGItem item)
    {
        if (emptySlot > 0)
        {
            foreach(GameObject slot in allSlots)
            {
                Slot temp = slot.GetComponent<Slot>();
                if (temp.isEmpty)
                {
                    temp.AddItem(item);
                    emptySlot--;
                    return true;
                }
            }
        }
        return false;
    }
}
