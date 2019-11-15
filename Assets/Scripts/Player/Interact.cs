using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Ray interactionRay;
            interactionRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hitInfo;
            if (Physics.Raycast(interactionRay, out hitInfo, 10))
            {
                switch (hitInfo.collider.tag)
                {
                    case "NPC":
                        Dialogue dlg = hitInfo.transform.GetComponent<Dialogue>();
                        if(dlg != null)
                        {
                            dlg.showDlg = true;

                            Time.timeScale = 0;

                            Cursor.visible = true;

                            Cursor.lockState = CursorLockMode.None;
                        }
                        Debug.Log("Talk to NPC is Triggered");
                        break;
                    case "Item":
                        Debug.Log("Pick up Item");
                        ItemHandler handler = hitInfo.transform.GetComponent<ItemHandler>();
                        if(handler != null)
                        {
                            handler.Oncollection();
                        }
                        break;
                    case "Treasure":
                        Debug.Log("Surprise Mimic Attack");
                        Chest chest = hitInfo.transform.GetComponent<Chest>();
                        if (chest != null)
                        {
                            chest.showChest = true;
                            LinearInventory.showInv = true;
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;
                            Time.timeScale = 0;
                        }
                            break;
                    case "Shop":
                        Shop shop = hitInfo.transform.GetComponent<Shop>();
                        if (shop != null)
                        {
                            shop.showShop = true;
                            LinearInventory.showInv = true;
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;
                            Time.timeScale = 0;
                        }
                        Debug.Log("See Something You Like?");
                        break;

                }
                /*
                if (hitInfo.collider.CompareTag("NPC"))
                {
                    Debug.Log("Talk to NPC is Triggered");
                }
                if (hitInfo.collider.tag == "Item")
                {
                    Debug.Log("Pick up Item");
                }
                */
            }

        }
    }
}
