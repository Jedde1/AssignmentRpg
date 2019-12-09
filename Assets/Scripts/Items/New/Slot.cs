using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    private Stack<RPGItem> items;
    public Text stackText;
    public Sprite slotEmpty;
    public Sprite slotHighlight;

    public bool IsEmpty
    {
        get { return items.Count == 0; }
    }

    public bool IsAvailable
    {
        get { return CurrentItem.maxSize > items.Count; }
    }

    public RPGItem CurrentItem
    {
        get { return items.Peek(); }
    }

    public Stack<RPGItem> Items { get => items; set => items = value; }

    // Start is called before the first frame update
    void Start()
    {
        items = new Stack<RPGItem>();
        RectTransform slotRect = GetComponent<RectTransform>();
        RectTransform textRect = stackText.GetComponent<RectTransform>();
        int textScaleFactor = (int)(slotRect.sizeDelta.x * 0.6);
        stackText.resizeTextMaxSize = textScaleFactor;
        stackText.resizeTextMinSize = textScaleFactor;
        textRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotRect.sizeDelta.y);
        textRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotRect.sizeDelta.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddItem(RPGItem item)
    {
        items.Push(item);
        if (items.Count > 1)
        {
            stackText.text = items.Count.ToString();
        }

        ChangeSprite(item.spriteNeutral, item.spriteHighlighted);
    }

    public void AddItems(Stack<RPGItem> items)
    {
        this.items = new Stack<RPGItem>(items);
        stackText.text = items.Count > 1 ? items.Count.ToString() : string.Empty;
        ChangeSprite(CurrentItem.spriteNeutral, CurrentItem.spriteHighlighted);
    }
    private void ChangeSprite(Sprite neutral, Sprite highlight)
    {
        GetComponent<Image>().sprite = neutral;
        SpriteState st = new SpriteState();
        st.highlightedSprite = highlight;
        st.pressedSprite = neutral;
        GetComponent<Button>().spriteState = st;
    }
    public void UseItem()
    {
        if (!IsEmpty)
        {
            items.Pop().Use();

            //if an item is used either reduce the count or change to empty
            stackText.text = items.Count > 1 ? items.Count.ToString() : string.Empty;

            //if the slot is empty use empty slot sprite
            if (IsEmpty)
            {
                ChangeSprite(slotEmpty, slotHighlight);
                NewInventory.EmptySlots++;
            }
        }
    }

    public void ClearSlot()
    {
        items.Clear();
        ChangeSprite(slotEmpty, slotHighlight);
        stackText.text = string.Empty;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            UseItem();
        }
    }
}
