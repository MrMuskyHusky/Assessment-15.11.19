using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int itemId)
    {
        string name = "";
        string description = "";
        int amount = 0;
        int value = 0;
        int damage = 0;
        int armour = 0;
        int heal = 0;
        string iconName = "";
        string meshName = "";
        ItemTypes type = ItemTypes.Misc;

        switch (itemId)
        {
            #region Armour 0-99
            case 0:
                name = "Armor Chest";
                description = "Special Armor for protection for your chest";
                amount = 1;
                value = 120;
                damage = 0;
                armour = 1;
                heal = 0;
                iconName = "Armor_1";
                meshName = "Armor_1";
                type = ItemTypes.Armour;
                break;
            case 1:
                name = "Armor Boots";
                description = "Special Armor for protection for your feet";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 1;
                heal = 0;
                iconName = "Armor_2";
                meshName = "Armor_2";
                type = ItemTypes.Armour;
                break;
            case 2:
                name = "Armor Pants";
                description = "Special Armor for protection for your groian";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 1;
                heal = 0;
                iconName = "Armor_3";
                meshName = "Armor_3";
                type = ItemTypes.Armour;
                break;
            case 3:
                name = "Armor Helmet";
                description = "Special Armor for protection for your Head";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 1;
                heal = 0;
                iconName = "Helmet_1";
                meshName = "Armour/Helmet";
                type = ItemTypes.Armour;
                break;
            #endregion
            #region Weapon 100 - 199
            case 100:
                name = "Axe";
                description = "";
                amount = 1;
                value = 10;
                damage = 15;
                armour = 0;
                heal = 0;
                iconName = "Axe_1";
                meshName = "Axe_1";
                type = ItemTypes.Weapon;
                break;
            case 101:
                name = "Sword";
                description = "";
                amount = 1;
                value = 10;
                damage = 10;
                armour = 0;
                heal = 0;
                iconName = "Sword_2";
                meshName = "Sword_2";
                type = ItemTypes.Weapon;
                break;
            case 102:
                name = "Special Axe";
                description = "";
                amount = 1;
                value = 10;
                damage = 20;
                armour = 0;
                heal = 0;
                iconName = "Axe_3";
                meshName = "Axe_3";
                type = ItemTypes.Weapon;
                break;
            case 103:
                name = "Mini Axe";
                description = "";
                amount = 1;
                value = 10;
                damage = 20;
                armour = 0;
                heal = 0;
                iconName = "Axe_2";
                meshName = "Weapon/Axe";
                type = ItemTypes.Weapon;
                break;
            #endregion
            #region Potion 200 - 299
            case 200:
                name = "Health Potion";
                description = "Regain health back to 100%";
                amount = 1;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 100;
                iconName = "Health Potion";
                meshName = "Health Potion";
                type = ItemTypes.Potion;
                break;
            case 201:
                name = "Damage Potion";
                description = "Increase your damage to your opponent";
                amount = 1;
                value = 0;
                damage = 50;
                armour = 0;
                heal = 0;
                iconName = "Damage Potion";
                meshName = "Damage Potion";
                type = ItemTypes.Potion;
                break;
            case 202:
                name = "Resistance Potion";
                description = "Decrease the damage from your opponent";
                amount = 1;
                value = 0;
                damage = 0;
                armour = 100;
                heal = 0;
                iconName = "Resistance Potion";
                meshName = "Resistance Potion";
                type = ItemTypes.Potion;
                break;
            #endregion
            #region Food 300 - 399
            case 300:
                name = "Apple";
                description = "Munchies and Crunchies";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 0;
                heal = 2;
                iconName = "Food/Apple";
                meshName = "Food/Apple";
                type = ItemTypes.Food;
                break;
            case 301:
                name = "Meat";
                description = "Mmmmmmm Yummy";
                amount = 1;
                value = 5;
                damage = 0;
                armour = 0;
                heal = 5;
                iconName = "Food/Meat";
                meshName = "Food/Meat";
                type = ItemTypes.Food;
                break;
            case 302:
                name = "Sandwich";
                description = "Home made Sandwich";
                amount = 1;
                value = 5;
                damage = 0;
                armour = 0;
                heal = 5;
                iconName = "Food/Sandwich";
                meshName = "Food/Sandwich";
                type = ItemTypes.Food;
                break;
            #endregion
            #region Ingredient 400 - 499
            case 400:
                name = "Luck Leaf";
                description = "Gives you an rare craftable Ingredient";
                amount = 1;
                value = 5;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Luck Leaf";
                meshName = "Luck Leaf";
                type = ItemTypes.Ingredient;
                break;
            case 401:
                name = "Leaf";
                description = "";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Leaf";
                meshName = "Leaf";
                type = ItemTypes.Ingredient;
                break;
            case 402:
                name = "Blue Mushroom";
                description = "";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Blue Mushroom";
                meshName = "Blue Mushroom";
                type = ItemTypes.Ingredient;
                break;
            #endregion
            #region Craftable 500 - 599
            case 500:
                name = "Blue Stone";
                description = "";
                amount = 1;
                value = 3;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Blue Stone";
                meshName = "Blue Stone";
                type = ItemTypes.Craftable;
                break;
            case 501:
                name = "Black Stone";
                description = "";
                amount = 1;
                value = 3;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Black Stone";
                meshName = "Black Stone";
                type = ItemTypes.Craftable;
                break;
            case 502:
                name = "Red Aura Stone";
                description = "";
                amount = 1;
                value = 3;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Red Aura Stone";
                meshName = "Red Aura Stone";
                type = ItemTypes.Craftable;
                break;
            #endregion
            #region Quest 600 - 699
            case 600:
                name = "Helmet";
                description = "";
                amount = 1;
                value = 5;
                damage = 0;
                armour = 50;
                heal = 0;
                iconName = "Helmet";
                meshName = "Helmet";
                type = ItemTypes.Quest;
                break;
            case 601:
                name = "Cloak";
                description = "";
                amount = 1;
                value = 5;
                damage = 0;
                armour = 10;
                heal = 0;
                iconName = "Cloak";
                meshName = "Cloak";
                type = ItemTypes.Quest;
                break;
            case 602:
                name = "Glove";
                description = "";
                amount = 1;
                value = 5;
                damage = 0;
                armour = 15;
                heal = 0;
                iconName = "Glove";
                meshName = "Glove";
                type = ItemTypes.Quest;
                break;
            #endregion
            #region Misc 700 - 799
            case 700:
                name = "";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Misc;
                break;
            case 701:
                name = "";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Misc;
                break;
            case 999:
                name = "Gold";
                description = "";
                amount = 01;
                value = 01;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Money;
                break;
            #endregion
            default:
                itemId = 0;
                name = "";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Misc;
                break;
        }
        Item temp = new Item
        {
            ID = itemId,
            Name = name,
            Description = description,
            Value = value,
            Amount = amount,
            Damage = damage,
            Armour = armour,
            Heal = heal,
            IconName = Resources.Load("Icons/" + iconName) as Texture2D,
            MeshName = Resources.Load("Prefabs/"+ meshName) as GameObject,
            ItemType = type
        };
        return temp;
    }
}
