using System.Collections;
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

    private static int emptySlots;

    public static bool showInv;

    public static int EmptySlots { get => emptySlots; set => emptySlots = value; }

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

        //Hover Object follows mouse on screen
        if (hoverObject != null)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out position);
            hoverObject.transform.position = canvas.transform.TransformPoint(position);
            position.Set(position.x, position.y - hoverYOffset);
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

    hoverYOffset = slotSize * 0.01f;

    emptySlots = slots;
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

public bool PlaceEmpty(RPGItem item)
{
    if (emptySlots > 0)
    {
        foreach (GameObject slot in allSlots)
        {
            Slot temp = slot.GetComponent<Slot>();
            if (temp.isEmpty)
            {
                temp.AddItem(item);
                emptySlots--;
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
        if (!clicked.GetComponent<Slot>().isEmpty)
        {
            from = clicked.GetComponent<Slot>();
            from.GetComponent<Image>().color = Color.gray;

            hoverObject = (GameObject)Instantiate(iconPrefab);
            hoverObject.GetComponent<Image>().sprite = clicked.GetComponent<Image>().sprite;
            hoverObject.name = "Hover";

            RectTransform hoverTransform = hoverObject.GetComponent<RectTransform>();
            RectTransform clickedTransform = clicked.GetComponent<RectTransform>();

            hoverTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, clickedTransform.sizeDelta.x);
            hoverTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, clickedTransform.sizeDelta.y);

            //Makes HoverObject a child of the Canvas
            hoverObject.transform.SetParent(GameObject.Find("Canvas").transform, true);
            hoverObject.transform.localScale = from.gameObject.transform.localScale;
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
