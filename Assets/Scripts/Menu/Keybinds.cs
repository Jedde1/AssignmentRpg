using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keybinds : MonoBehaviour
{
    public Dictionary<string, KeyCode> Keys = new Dictionary<string, KeyCode>();

    public Text up, left, down, right, jump, interact;

    private GameObject currentKey;

    private Color32 normal = new Color(39, 171, 249, 255);
    private Color32 selected = new Color32(239, 116, 36, 255);
    // Start is called before the first frame update
    void Start()
    {
        Keys.Add("Forward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W")));
        Keys.Add("Backward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S")));
        Keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        Keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        Keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));
        Keys.Add("Interact", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Interact", "E")));

        up.text = Keys["Forward"].ToString();
        down.text = Keys["Backward"].ToString();
        left.text = Keys["Left"].ToString();
        right.text = Keys["Right"].ToString();
        jump.text = Keys["Jump"].ToString();
        interact.text = Keys["Interact"].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Keys["Forward"]))
        {
            Debug.Log("MoveForward");
        }
        if (Input.GetKeyDown(Keys["Backward"]))
        {
            Debug.Log("MoveBackwards");
        }
        if (Input.GetKeyDown(Keys["Left"]))
        {
            Debug.Log("MoveLeft");
        }
        if (Input.GetKeyDown(Keys["Right"]))
        {
            Debug.Log("MoveRight");
        }
        if (Input.GetKeyDown(Keys["Jump"]))
        {
            Debug.Log("Double Jump");
        }
        if (Input.GetKeyDown(Keys["Interact"]))
        {
            Debug.Log("Picked up Cheese Wheel x10000");
        }
    }
    private void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                Keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }
    public void changeKey(GameObject clicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }

        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
    }

    


    /*
    public KeyCode tempKey, forward, backward, left, right, jump;
    public Text forwardButton, backwardButton, leftButton, rightButton, jumpButton;
    private void Start()
    {
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W"));
        forwardButton.text = forward.ToString();
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S"));
        forwardButton.text = forward.ToString();
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D"));
        forwardButton.text = forward.ToString();
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A"));
        forwardButton.text = forward.ToString();
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space"));
        jumpButton.text = jump.ToString();
    }
    public void Forward()
    {
        if (backward != KeyCode.None)
        {
            tempKey = forward;
            forward = KeyCode.None;
        }
        forwardButton.text = forward.ToString();

    }
    private void OnGUI()
    {
        Event e = Event.current;
        if (forward == KeyCode.None)
        {
            if (e.keyCode != backward)
            {
                forward = e.keyCode;
                tempKey = KeyCode.None;
                forwardButton.text = forward.ToString();
            }
            else
            {
                forward = tempKey;
                forwardButton.text = forward.ToString();
            }

        }
    }
    */
}
