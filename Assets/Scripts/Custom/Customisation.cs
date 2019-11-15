using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Customisation : MonoBehaviour
{
    public Renderer characterRenderer;
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex;
    public int skinMax, eyesMax, mouthMax, hairMax, clothesMax, armourMax;
    public string characterName = "Adventurer";
    public PlayerHandler player;
    public PlayerPrefSave saveNew;
    [System.Serializable]
    public struct Stats
    {
        public string statName;
        public int statValue;
        public int tempStat;
    }
    public Stats[] playerStats = new Stats[6];
    public CharacterClass characterClass;
    public Vector2 scr;
    public int selectedIndex;
    public int points = 10;

    void Start()
    {
        for (int i = 0; i < skinMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Skin_" +i.ToString()) as Texture2D;
            skin.Add(tempTexture);
        }
        for (int i = 0; i < eyesMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Eyes_" +i.ToString()) as Texture2D;
            eyes.Add(tempTexture);
        }
        for (int i = 0; i < mouthMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Mouth_" +i.ToString()) as Texture2D;
            mouth.Add(tempTexture);
        }
        for (int i = 0; i < hairMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Hair_" +i.ToString()) as Texture2D;
            hair.Add(tempTexture);
        }
        for (int i = 0; i < clothesMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Clothes_" +i.ToString()) as Texture2D;
            clothes.Add(tempTexture);
        }
        for (int i = 0; i < armourMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Armour_" +i.ToString()) as Texture2D;
            armour.Add(tempTexture);
        }
        SetTexture("Skin", 0);
        SetTexture("Eyes", 0);
        SetTexture("Mouth", 0);
        SetTexture("Hair", 0);
        SetTexture("Clothes", 0);
        SetTexture("Armour", 0);
    }

    public void Save()
    {
        // New Char Base Info
        player.maxHealth = 100;
        player.maxMana = 100;
        player.maxStamina = 100;

        player.curHealth = player.maxHealth;
        player.curMana = player.maxMana;
        player.curStamina = player.maxStamina;

        // New Char Stats
        player.skinIndex = skinIndex;
        player.eyesIndex = eyesIndex;
        player.mouthIndex = mouthIndex;
        player.hairIndex = hairIndex;
        player.clothesIndex = clothesIndex;
        player.armourIndex = armourIndex;

        player.characterClass = characterClass;
        player.characterName = characterName;
        for (int i = 0; i < playerStats.Length; i++)
        {
            player.stats[i].value = (playerStats[i].statValue + playerStats[i].tempStat);
        }
        saveNew.Save();
        SceneManager.LoadScene(2);
    }
    public void SetTexture(string type, int dir)
    {
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];
        switch(type)
        {
            case "Skin":
            index = skinIndex;
            max = skinMax;
            matIndex = 1;
            textures = skin.ToArray();
            break;
            case "Eyes":
            index = eyesIndex;
            max = eyesMax;
            matIndex = 2;
            textures = eyes.ToArray();
            break;
            case "Mouth":
            index = mouthIndex;
            max = mouthMax;
            matIndex = 3;
            textures = mouth.ToArray();
            break;
            case "Hair":
            index = hairIndex;
            max = hairMax;
            matIndex = 4;
            textures = hair.ToArray();
            break;
            case "Clothes":
            index = clothesIndex;
            max = clothesMax;
            matIndex = 5;
            textures = clothes.ToArray();
            break;
            case "Armour":
            index = armourIndex;
            max = armourMax;
            matIndex = 6;
            textures = armour.ToArray();
            break;
        }
        index += dir;
        if(index < 0)
        {
            index = max - 1;
        }
        if(index > max-1)
        {
            index = 0;
        }
        Material[] mat = characterRenderer.materials;
        mat[matIndex].mainTexture = textures[index];
        characterRenderer.materials = mat;

        switch(type)
        {
            case "Skin":
            skinIndex = index;
            break;
            case "Eyes":
            eyesIndex = index;
            break;
            case "Mouth":
            mouthIndex = index;
            break;
            case "Hair":
            hairIndex = index;
            break;
            case "Clothes":
            clothesIndex = index;
            break;
            case "Armour":
            armourIndex = index;
            break;
        }
    }
    void OnGUI()
    {
        scr = new Vector2 (Screen.width / 16, Screen.height / 9);
        DisplayCustom();
        DisplayStats();

        if(GUI.Button(new Rect(scr.x * 7.15f, scr.y * 0.5f, scr.x * 2, scr.y * 0.5f), "Save"))
        {
            Save();
        }
    }
    void DisplayCustom()
    {
        int i = 0;
        #region Skin
        if(GUI.Button(new Rect(scr.x * 0.25f, scr.y + i *(0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "<"))
        {
            SetTexture("Skin", -1);
        }

        GUI.Box(new Rect(scr.x * 0.75f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Skin");

        if(GUI.Button(new Rect(scr.x * 1.75f, scr.y + i *(0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), ">"))
        {
            SetTexture("Skin", 1);
        }
        i++;
        #endregion

        #region Eyes
        if(GUI.Button(new Rect(scr.x * 0.25f, scr.y + i *(0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "<"))
        {
            SetTexture("Eyes", -1);
        }

        GUI.Box(new Rect(scr.x * 0.75f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Eyes");

        if(GUI.Button(new Rect(scr.x * 1.75f, scr.y + i *(0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), ">"))
        {
            SetTexture("Eyes", 1);
        }
        i++;
        #endregion

        #region Mouth
        if(GUI.Button(new Rect(scr.x * 0.25f, scr.y + i *(0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "<"))
        {
            SetTexture("Mouth", -1);
        }

        GUI.Box(new Rect(scr.x * 0.75f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Mouth");

        if(GUI.Button(new Rect(scr.x * 1.75f, scr.y + i *(0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), ">"))
        {
            SetTexture("Mouth", 1);
        }
        i++;
        #endregion

        #region Hair
        if(GUI.Button(new Rect(scr.x * 0.25f, scr.y + i *(0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "<"))
        {
            SetTexture("Hair", -1);
        }

        GUI.Box(new Rect(scr.x * 0.75f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Hair");

        if(GUI.Button(new Rect(scr.x * 1.75f, scr.y + i *(0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), ">"))
        {
            SetTexture("Hair", 1);
        }
        i++;
        #endregion

        #region Clothes
        if(GUI.Button(new Rect(scr.x * 0.25f, scr.y + i *(0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "<"))
        {
            SetTexture("Clothes", -1);
        }

        GUI.Box(new Rect(scr.x * 0.75f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Clothes");

        if(GUI.Button(new Rect(scr.x * 1.75f, scr.y + i *(0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), ">"))
        {
            SetTexture("Clothes", 1);
        }
        i++;
        #endregion

        #region Armour
        if(GUI.Button(new Rect(scr.x * 0.25f, scr.y + i *(0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "<"))
        {
            SetTexture("Armour", -1);
        }

        GUI.Box(new Rect(scr.x * 0.75f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Armour");

        if(GUI.Button(new Rect(scr.x * 1.75f, scr.y + i *(0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), ">"))
        {
            SetTexture("Armour", 1);
        }
        i++;
        #endregion

        if(GUI.Button(new Rect(scr.x * 0.75f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Random"))
        {
            SetTexture("Skin",Random.Range(0, skinMax-1));
            SetTexture("Eyes",Random.Range(0, eyesMax-1));
            SetTexture("Mouth",Random.Range(0, mouthMax-1));
            SetTexture("Hair",Random.Range(0, hairMax-1));
            SetTexture("Clothes",Random.Range(0, clothesMax-1));
            SetTexture("Armour",Random.Range(0, armourMax-1));
        }
        i++;

        if(GUI.Button(new Rect(scr.x * 0.75f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), "Reset"))
        {
            SetTexture("Skin", -skinIndex);
            SetTexture("Eyes", -eyesIndex);
            SetTexture("Mouth", -mouthIndex);
            SetTexture("Hair", -hairIndex);
            SetTexture("Clothes", -clothesIndex);
            SetTexture("Armour", -armourIndex);
        }
        //            SetTexture("Skin",-skinIndex);
        //            SetTexture("Skin",100);
        //            SetTexture("Skin",skinMax);
        
    }
    void DisplayStats()
    {
        characterName = GUI.TextField(new Rect(scr.x * 6,scr.y * 7.5f,scr.x * 4,scr.y * 0.5f), characterName, 20);
        int i = 0;
        #region Class
        if(GUI.Button(new Rect(scr.x * 13.75f, scr.y + i *(0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "<"))
        {
            selectedIndex--;
            if(selectedIndex < 0)
            {
                selectedIndex = 11;
            }
            ChooseClass(selectedIndex);
        }

        GUI.Box(new Rect(scr.x * 14.25f, scr.y + i * (0.5f * scr.y), scr.x, scr.y * 0.5f), (characterClass.ToString()));

        if(GUI.Button(new Rect(scr.x * 15.25f, scr.y + i *(0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), ">"))
        {
            selectedIndex++;
            if(selectedIndex > 11)
            {
                selectedIndex = 0;
            }
            ChooseClass(selectedIndex);
        }
        i++;
        #endregion
        #region StatDistribution
        GUI.Box(new Rect(scr.x * 13.75f, scr.y + i * (0.5f * scr.y), scr.x * 2, scr.y * 0.5f), "Points: " + points);
        for(int s = 0; s < playerStats.Length; s++)
        {
            if(points > 0)
            {
                if(GUI.Button(new Rect(scr.x * 15.37f, 2 * scr.y + s *(0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "+"))
                {
                    points--;
                    playerStats[s].tempStat++;
                }
            }
            GUI.Box(new Rect(scr.x * 14.15f, 2 * scr.y + s *(0.5f * scr.y), scr.x * 1.2f, scr.y * 0.5f), playerStats[s].statName + ": " +(playerStats[s].statValue + playerStats[s].tempStat));
            if(points < 10 && playerStats[s].tempStat > 0)
            {
                if (GUI.Button(new Rect(scr.x * 13.65f, 2 * scr.y + s * (0.5f * scr.y), scr.x * 0.5f, scr.y * 0.5f), "-"))
                {
                    points++;
                    playerStats[s].tempStat--;
                }
            }
          
        }
    }
    #endregion
    
    void ChooseClass(int className)
    {
        switch(className)
        {
            case 0:
            playerStats[0].statValue = 15;
            playerStats[1].statValue = 10;
            playerStats[2].statValue = 10;
            playerStats[3].statValue = 10;
            playerStats[4].statValue = 10;
            playerStats[5].statValue = 5;
            characterClass = CharacterClass.Barbarian;
            break;
            case 1:
            playerStats[0].statValue = 5;
            playerStats[1].statValue = 10;
            playerStats[2].statValue = 15;
            playerStats[3].statValue = 9;
            playerStats[4].statValue = 4;
            playerStats[5].statValue = 5;
            characterClass = CharacterClass.Bard;
            break;
            case 2:
            playerStats[0].statValue = 17;
            playerStats[1].statValue = 10;
            playerStats[2].statValue = 10;
            playerStats[3].statValue = 7;
            playerStats[4].statValue = 5;
            playerStats[5].statValue = 5;
            characterClass = CharacterClass.Cleric;
            break;
            case 3:
            playerStats[0].statValue = 10;
            playerStats[1].statValue = 5;
            playerStats[2].statValue = 13;
            playerStats[3].statValue = 2;
            playerStats[4].statValue = 14;
            playerStats[5].statValue = 9;
            characterClass = CharacterClass.Druid;
            break;
            case 4:
            playerStats[0].statValue = 15;
            playerStats[1].statValue = 20;
            playerStats[2].statValue = 10;
            playerStats[3].statValue = 7;
            playerStats[4].statValue = 4;
            playerStats[5].statValue = 5;
            characterClass = CharacterClass.Fighter;
            break;
            case 5:
            playerStats[0].statValue = 4;
            playerStats[1].statValue = 7;
            playerStats[2].statValue = 2;
            playerStats[3].statValue = 10;
            playerStats[4].statValue = 8;
            playerStats[5].statValue = 5;
            characterClass = CharacterClass.Monk;
            break;
            case 6:
            playerStats[0].statValue = 2;
            playerStats[1].statValue = 8;
            playerStats[2].statValue = 15;
            playerStats[3].statValue = 7;
            playerStats[4].statValue = 10;
            playerStats[5].statValue = 5;
            characterClass = CharacterClass.Paladin;
            break;
            case 7:
            playerStats[0].statValue = 10;
            playerStats[1].statValue = 15;
            playerStats[2].statValue = 7;
            playerStats[3].statValue = 12;
            playerStats[4].statValue = 3;
            playerStats[5].statValue = 15;
            characterClass = CharacterClass.Ranger;
            break;
            case 8:
            playerStats[0].statValue = 2;
            playerStats[1].statValue = 8;
            playerStats[2].statValue = 15;
            playerStats[3].statValue = 15;
            playerStats[4].statValue = 6;
            playerStats[5].statValue = 5;
            characterClass = CharacterClass.Rogue;
            break;
            case 9:
            playerStats[0].statValue = 15;
            playerStats[1].statValue = 16;
            playerStats[2].statValue = 4;
            playerStats[3].statValue = 0;
            playerStats[4].statValue = 7;
            playerStats[5].statValue = 5;
            characterClass = CharacterClass.Sorcerer;
            break;
            case 10:
            playerStats[0].statValue = 7;
            playerStats[1].statValue = 7;
            playerStats[2].statValue = 10;
            playerStats[3].statValue = 25;
            playerStats[4].statValue = 3;
            playerStats[5].statValue = 2;
            characterClass = CharacterClass.Warlock;
            break;
            case 11:
            playerStats[0].statValue = 15;
            playerStats[1].statValue = 10;
            playerStats[2].statValue = 5;
            playerStats[3].statValue = 11;
            playerStats[4].statValue = 10;
            playerStats[5].statValue = 3;
            characterClass = CharacterClass.Wizard;
            break;
        }
    }
}
public enum CharacterClass
{
    Barbarian, 
    Bard, 
    Cleric, 
    Druid, 
    Fighter, 
    Monk, 
    Paladin, 
    Ranger, 
    Rogue, 
    Sorcerer, 
    Warlock,
    Wizard
}
