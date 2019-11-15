using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class PlayerHandler : MonoBehaviour
{
    [System.Serializable]
    public struct PlayerStats
    {
        public string name;
        public int value;
    };

    public Text text; 
    [Header("Value Variables")]
    public float curHealth;
    public float curStamina,curMana;
    public float maxHealth,maxStamina,maxMana,healRate;
    
    [SerializeField]
    public PlayerStats[] playerStats;

    [Header("Value Variables")]
    public Slider healthBar;
    public Slider manaBar,staminaBar;
    
    [Header("Damage Effect Variables")]
    public Image damageImage;
    public Image deathImage;
    public AudioClip deathClip;
    public float flashSpeed = 5;
    public Color flashColor = new Color(1, 0, 0, 0.2f);
    AudioSource playerAudio;
    public static bool isDead;
    bool damage;
    bool canHeal;
    float healTimer;

    [Header("Postion Variables")]
    public float posX;
    public float posY;
    public float posZ;
    [Header("Check Point")]
    public Transform curCheckPoint;

    [Header("Save")]
    public PlayerSaveAndLoad saveAndLoad;
    [Header("Custom")]
    public bool custom;
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex;
    public CharacterClass characterClass;
    public string characterName;
    public string firstCheckPointName = "First CheckPoint";
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!custom)
        {
            //Health
            if (healthBar.value != Mathf.Clamp01(curHealth / maxHealth))
            {
                curHealth = Mathf.Clamp(curHealth, 0, maxHealth);
                healthBar.value = Mathf.Clamp01(curHealth / maxHealth);
            }
            if (manaBar.value != Mathf.Clamp01(curMana / maxMana))
            {
                curMana = Mathf.Clamp(curMana, 0, maxMana);
                manaBar.value = Mathf.Clamp01(curMana / maxMana);
            }
            if (staminaBar.value != Mathf.Clamp01(curStamina / maxStamina))
            {
                curStamina = Mathf.Clamp(curStamina, 0, maxStamina);
                staminaBar.value = Mathf.Clamp01(curStamina / maxStamina);
            }

            if (curHealth <= 0 && !isDead)
            {
                Death();
            }
#if UNITY_EDITOR
            //Damage
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                damage = true;
                curHealth -= 50;
            }
#endif
            if (damage)
            {
                damageImage.color = flashColor;
                damage = false;

            }
            else
            {
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }
            if (!canHeal && curHealth < maxHealth && curHealth > 0)
            {
                healTimer += Time.deltaTime;
                if (healTimer >= 5)
                {
                    canHeal = true;
                }
            }
        }
    }
      
    private void LateUpdate()
    {
        if(curHealth < maxHealth && curHealth > 0 && canHeal)
        {
            HealOverTime();
        }
    }

    void Death()
    {
        //Set the death flag to this function isn't callsed again
        isDead = true;
        text.text = "";

        //Set the AudioSource to play the death clip
        playerAudio.clip = deathClip;
        playerAudio.Play();
        deathImage.gameObject.GetComponent<Animator>().SetTrigger("isDead");
        Invoke("DeathText", 2f);
        Invoke("ReviveText", 6f);

        Invoke("Revive", 9f);
    }
    void Revive()
    {
        isDead = false;
        text.text = "";
        curHealth = maxHealth;
        curMana = maxMana;
        curStamina = maxStamina;

        //More and to spawn location
        this.transform.position = curCheckPoint.position;
        this.transform.rotation = curCheckPoint.rotation;
        deathImage.gameObject.GetComponent<Animator>().SetTrigger("Revived");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            if (other.gameObject.CompareTag("CheckPoint"))
            {
                curCheckPoint = other.transform;
                healRate = 10;
                saveAndLoad.Save();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            healRate = 0;
        }
    }
    void DeathText()
    {
        text.text = "You Died";
    }
    void ReviveText()
    {
        text.text = "Haha You Suck!";
    }
    public void DamagePlayer(float damaged)
    {
        damage = true;
        curHealth -= damaged;
        canHeal = false;
        healTimer = 0;
    }
    public void HealOverTime()
    {
        curHealth += Time.deltaTime * (healRate+playerStats[2].value);
    }
}
