using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Normally Genral Game Settings Eg: Sound
public class PlayerPrefsSave : MonoBehaviour
{
    public PlayerHandler player;
    public float x, y, z;
    public float rotX, rotY, rotZ, rotW;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Loaded"))
        {
            PlayerPrefs.DeleteAll();
            FirstLoad();
            PlayerPrefs.SetInt("Loaded", 0);
            Save();
            //Save Binay Data
        }
        else
        {
            //Load Binary 
            Load();
        }
    }
    void FirstLoad()
    {

    }
    public void Save()
    {
        //Health, Mana, Stamina
        //PlayerPrefs save Float with Key CurHealth and the players curremt health value
        PlayerPrefs.SetFloat("CurHealth", player.curHealth);
        PlayerPrefs.SetFloat("CurMana", player.curMana);
        PlayerPrefs.SetFloat("CurStamina", player.curStamina);
        //Postion
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
        //Rotation
        PlayerPrefs.SetFloat("RotX", player.transform.rotation.x);
        PlayerPrefs.SetFloat("RotX", player.transform.rotation.y);
        PlayerPrefs.SetFloat("RotX", player.transform.rotation.z);
        PlayerPrefs.SetFloat("RotX", player.transform.rotation.w);
    }
   
    // Update is called once per frame
    public void Load()
    {
        //Health, Mana, Stamina
        //Players current health is set to PlayerPrefs Saved float called CurHealth, else set it to MaxHealth
        player.curHealth = PlayerPrefs.GetFloat("CurHealth", player.maxHealth);
        player.curMana = PlayerPrefs.GetFloat("CurMana", player.curMana);
        player.curStamina = PlayerPrefs.GetFloat("CurStamina", player.curStamina);
        //Postion

       // x = PlayerPrefs.GetFloat("PlayerX", 1);
       // y = PlayerPrefs.GetFloat("PlayerY", 1);
       // z = PlayerPrefs.GetFloat("PlayerZ", 1);

        player.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX", 1), PlayerPrefs.GetFloat("playerY", 1), PlayerPrefs.GetFloat("PlayerZ", 1));
        player.transform.rotation = new Quaternion(PlayerPrefs.GetFloat("PlayerRotX", 0), PlayerPrefs.GetFloat("PlayerRotY", 0), PlayerPrefs.GetFloat("PlayerRotZ", 0), PlayerPrefs.GetFloat("PlayerRotW", 0));
        //Rotation
    }
}
    
 
