using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Stack<RPGItem> items;
    public Text stackText;
    public Sprite slotEmpty;
    public Sprite slotHighlight;

    public bool isEmpty
    {
        get { return items.Count == 0; }
    }
    // Start is called before the first frame update
    void Start()
    {
        items = new Stack<RPGItem>();
        RectTransform slotRect = GetComponent<RectTransform>();
        RectTransform textRect = GetComponent<RectTransform>();
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

        ChangeSprite(RPGItem.spriteNeutral, RPGItem.spriteHighlighted);
    }
    private void ChangeSprite(Sprite neutral, Sprite highlight)
    {
        GetComponent<Image>().sprite = neutral;
        SpriteState st = new SpriteState();
        st.highlightedSprite = highlight;
        st.pressedSprite = neutral;
        GetComponent<Button>().spriteState = st;
    }
}
