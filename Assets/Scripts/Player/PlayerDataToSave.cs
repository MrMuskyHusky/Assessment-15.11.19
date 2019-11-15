[System.Serializable]
// Serialization is the automatic process of transforming data structures or object states into a format thtat Unity can store and reconstruct later.

// Serialization is the process of converting an object into a stream of bytes to store the object or transmit it to memory, a database, or a file. Its main purpose is to save the state of an object in order to be able to recreate it when needed. The reverse process is called deserialization

// The serialization system is written in C++
public class PlayerDataToSave
{
    // Data...Get from game
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
        if(player.curCheckPoint != null)
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
            stats[i] = player.stats[i].value;
        }

        skinIndex = player.skinIndex;
        eyesIndex = player.eyesIndex;
        mouthIndex = player.mouthIndex;
        hairIndex = player.hairIndex;
        clothesIndex = player.clothesIndex;
        armourIndex = player.armourIndex;

        classIndex = (int)player.characterClass;
    }
}
