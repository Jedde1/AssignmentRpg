using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keybinds : MonoBehaviour
{
    private Dictionary<string, KeyCode> Keys = new Dictionary<string, KeyCode>();

    public Text up, left, down, right, jump, interact;

    private GameObject currentKey;
    // Start is called before the first frame update
    void Start()
    {
        Keys.Add("Up", KeyCode.W);
        Keys.Add("Down", KeyCode.S);
        Keys.Add("Left", KeyCode.A);
        Keys.Add("Right", KeyCode.D);
        Keys.Add("Jump", KeyCode.Space);
        Keys.Add("Interact", KeyCode.E);

        up.text = Keys["Up"].ToString();
        up.text = Keys["Down"].ToString();
        up.text = Keys["Left"].ToString();
        up.text = Keys["Right"].ToString();
        up.text = Keys["Jump"].ToString();
        up.text = Keys["Interact"].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Keys["Up"]))
        {
            Debug.Log("MoveForward");
        }
        if (Input.GetKeyDown(Keys["Down"]))
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
        if (Input.GetKeyDown(Keys[""]))
        {
            Debug.Log("Picked up Cheese Wheel x10000");
        }
    }
}
