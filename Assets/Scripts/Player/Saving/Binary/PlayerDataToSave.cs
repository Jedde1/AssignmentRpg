[System.Serializable]
public class PlayerDataToSave 
{
    //Data....Get from Game
    public string playerName;
    public int level;
    public string checkPoint;
    public float maxHealth, maxMana, maxStamina;
    public float curHealth, curMana, curStamina;
    public float pX, pY, pZ;
    public float rX, rY, rZ, rW;
    
    public static int saveSlot;
    public int[] stats = new int[6];
    public int classIndex;
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex;
    public PlayerDataToSave(PlayerHandler player)
    {
        playerName = player.characterName;
        level = 0;
        if (player.curCheckPoint != null)
        {
            checkPoint = player.curCheckPoint.name;

            pX = player.transform.position.x;
            pY = player.transform.position.y;
            pZ = player.transform.position.z;

            rX = player.transform.rotation.x;
            rY = player.transform.rotation.y;
            rZ = player.transform.rotation.z;
            rW = player.transform.rotation.w;
        }
        else
        {
            checkPoint = player.firstCheckPointName;
            pX = 0;
            pY = 0;
            pZ = 0;
        }
        

        maxHealth = player.maxHealth;
        maxMana = player.maxMana;
        maxStamina = player.maxStamina;

        curHealth = player.curHealth;
        curMana = player.curMana;
        curStamina = player.curStamina;

        for (int i = 0; i < 6; i++)
        {
            stats[i] = player.playerStats[i].value;
        }
        skinIndex = player.skinIndex;
        hairIndex = player.hairIndex;
        mouthIndex = player.mouthIndex;
        eyesIndex = player.eyesIndex;
        clothesIndex = player.clothesIndex;
        armourIndex = player.armourIndex;

        classIndex = (int)player.characterClass;
    }
}
