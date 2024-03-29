﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewInventory : MonoBehaviour
{
    private RectTransform inventoryRect;

    private float inventoryWidth, inventoryHeight;

    public int slots;
    public int rows;

    public float slotPaddingLeft, slotPaddingTop;

    public float slotSize;

    public GameObject slotPrefab;

    private static Slot from, to;

    private List<GameObject> allSlots;

    public GameObject iconPrefab;

    private static GameObject hoverObject;

    private static int emptySlot;

    public static bool showInv;
    public static int EmptySlots { get => emptySlot; set => emptySlot = value; }

    public Canvas canvas;

    private float hoverYOffset;

    public EventSystem eventSystem;

    public RPGItem selectedItem;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateLayOut();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!eventSystem.IsPointerOverGameObject(-1) && from != null)
            {
                from.GetComponent<Image>().color = Color.white;
                from.ClearSlot();
                Destroy(GameObject.Find("Hover"));
                to = null;
                from = null;
                hoverObject = null;
            }
        }
        if (Input.GetButtonDown("Inventory") && !PauseMenu.isPaused)
        {
            showInv = !showInv;
            if (showInv)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                selectedItem = null;
            }
        }

    }

    void CreateLayOut()
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
        else
        {
            foreach (GameObject slot in allSlots)
            {
                Slot temp = slot.GetComponent<Slot>();

                if (!temp.IsEmpty)
                {
                    if(temp.CurrentItem.type == item.type && temp.IsAvailable)
                    {
                        temp.AddItem(item);
                        return true;
                    }
                }
            }
            if(emptySlot > 0)
            {
                PlaceEmpty(item);
            }
        }
        return false;
    }
    public bool PlaceEmpty(RPGItem item)
    {
        if (emptySlot > 0)
        {
            foreach (GameObject slot in allSlots)
            {
                Slot temp = slot.GetComponent<Slot>();
                if (temp.IsEmpty)
                {
                    temp.AddItem(item);
                    emptySlot--;
                    return true;
                }
            }
        }
        return false;

    }
    public void MoveItem(GameObject clicked)
    {
        if (from == null)
        {
            if (!clicked.GetComponent<Slot>().IsEmpty)
            {
                from = clicked.GetComponent<Slot>();
                from.GetComponent<Image>().color = Color.gray;               
            }
        }
        else if (to == null)
        {
            to = clicked.GetComponent<Slot>();
            Destroy(GameObject.Find("Hover"));
        }
        if (to != null && from != null)
        {
            Stack<RPGItem> tempTo = new Stack<RPGItem>(to.Items);
            to.AddItems(from.Items);
            if (tempTo.Count == 0)
            {
                from.ClearSlot();
            }
            else
            {
                from.AddItems(tempTo);
            }

            from.GetComponent<Image>().color = Color.white;
            to = null;
            from = null;
            hoverObject = null;
        }
    }
}

