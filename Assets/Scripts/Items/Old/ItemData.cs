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
                name = "IronChest";
                description = "Basic Iron Amrour";
                amount = 1;
                value = 50;
                damage = 0;
                armour = 10;
                heal = 0;
                iconName = "Armour/IronChest";
                meshName = "Armour/IronChest";
                type = ItemTypes.Armour;
                break;

            case 1:
                name = "IronLeg";
                description = "Basic Iron Amrour";
                amount = 1;
                value = 40;
                damage = 0;
                armour = 10;
                heal = 0;
                iconName = "Armour/IronLeg";
                meshName = "Armour/IronLeg";
                type = ItemTypes.Armour;
                break;
            case 2:
                name = "IronBoot";
                description = "Basic Iron Amrour";
                amount = 1;
                value = 25;
                damage = 0;
                armour = 5;
                heal = 0;
                iconName = "Armour/IronBoot";
                meshName = "Armour/IronBoot";
                type = ItemTypes.Armour;
                break;

            case 3:
                name = "IronHelmet";
                description = "Basic Iron Helmet";
                amount = 1;
                value = 25;
                damage = 0;
                armour = 5;
                heal = 0;
                iconName = "Armour/IronHelmet";
                meshName = "Armour/IronHelmet";
                type = ItemTypes.Armour;
                break;
            #endregion
            #region Weapon 100-199
            case 100:
                name = "Sword_1";
                description = "Basic Sword Given from time in Military";
                amount = 1;
                value = 25;
                damage = 10;
                armour = 0;
                heal = 0;
                iconName = "Weapon/Sword_1";
                meshName = "Weapon/Sword_1";
                type = ItemTypes.Weapon;
                break;
            case 101:
                name = "Mace_1";
                description = "Basic Mace Given from time in Military";
                amount = 1;
                value = 25;
                damage = 10;
                armour = 0;
                heal = 0;
                iconName = "Weapon/Mace_1";
                meshName = "Weapon/Mace_1";
                type = ItemTypes.Weapon;
                break;
            case 102:
                name = "Axe_1";
                description = "Basic Axe given from time in Military";
                amount = 1;
                value = 25;
                damage = 10;
                armour = 0;
                heal = 0;
                iconName = "Weapon/Axe_1";
                meshName = "Weapon/Axe_1";
                type = ItemTypes.Weapon;
                break;
            #endregion
            #region Potion 200-299
            case 200:
                name = "HealthPot";
                description = "Your Basic Pocket Cleric";
                amount = 1;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 100;
                iconName = "Potion/HealthPot";
                meshName = "Potion/HealthPot";
                type = ItemTypes.Potion;
                break;

            case 201:
                name = "ManaPot";
                description = "Restores Mana";
                amount = 1;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Potion/ManaPot";
                meshName = "Potion/ManaPot";
                type = ItemTypes.Potion;
                break;

            case 202:
                name = "StamPot";
                description = "Restores Stamina";
                amount = 1;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 100;
                iconName = "Potion/StamPot";
                meshName = "Potion/StamPot";
                type = ItemTypes.Potion;
                break;
            #endregion
            #region Food 300-399
            case 300:
                name = "Apple";
                description = "Munches and Crunches";
                amount = 1;
                value = 2;
                damage = 0;
                armour = 0;
                heal = 10;
                iconName = "Food/Apple";
                meshName = "Food/Apple";
                type = ItemTypes.Food;
                break;
            case 301:
                name = "Meat";
                description = "The only reason your not a Vegan";
                amount = 1;
                value = 5;
                damage = 0;
                armour = 0;
                heal = 50;
                iconName = "Food/Meat";
                meshName = "Food/Meat";
                type = ItemTypes.Food;
                break;
            #endregion
            #region Ingredient 400-499
            case 400:
                name = "Acorn";
                description = "Plant to Grow Deku Tree";
                amount = 1;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Ingredient/Acorn";
                meshName = "Ingredient/Acorn";
                type = ItemTypes.Ingredient;
                break;

            case 401:
                name = "Chilli";
                description = "Much Spicy";
                amount = 1;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Ingredient/Chilli";
                meshName = "Ingredient/Chilli";
                type = ItemTypes.Ingredient;
                break;

            case 402:
                name = "Clover";
                description = "Good luck charm. Better then a Black Clover";
                amount = 1;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Ingredient/Clover";
                meshName = "Ingredient/Clover";
                type = ItemTypes.Ingredient;
                break;
            #endregion
            #region Craftable 500-599
            case 500:
                name = "Ingot";
                description = "Made of Iron. To make Iron Items";
                amount = 1;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Craftable/Ingot";
                meshName = "Craftable/Ingot";
                type = ItemTypes.Craftable;
                break;

            case 501:
                name = "Gem_1";
                description = "A Gem... It Glows";
                amount = 1;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Craftable/Gem_1";
                meshName = "Craftable/Gem_1";
                type = ItemTypes.Craftable;
                break;

            case 502:
                name = "Gem_2";
                description = "A Gem... It Glows";
                amount = 1;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Craftable/Gem_2";
                meshName = "Craftable/Gem_2";
                type = ItemTypes.Craftable;
                break;
            #endregion
            #region Quest 600-699
            case 600:
                name = "Globe";
                description = "A simple Globe holding all Elemental power... If Broken The World will end";
                amount = 1;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Quest/Globe";
                meshName = "Quest/Globe";
                type = ItemTypes.Quest;
                break;
            #endregion
            #region Misc 700-799
            case 700:
                name = "Dead_Chilli";
                description = "It's dead no good for Eating... Better sell it";
                amount = 1;
                value = 1;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "Misc/Dead_Chilli";
                meshName = "Misc/Dead_Chilli";
                type = ItemTypes.Misc;
                break;
            #endregion
            default:
                itemId = 300;
                name = "Apple";
                description = "Munches and Crunches";
                amount = 1;
                value = 2;
                damage = 0;
                armour = 0;
                heal = 10;
                iconName = "Food/Apple";
                meshName = "Food/Apple";
                type = ItemTypes.Food;
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
            IconName = Resources.Load("Icons/"+ iconName) as Texture2D,
            MeshName = Resources.Load("Prefabs/"+ meshName)as GameObject,
            ItemTypes = type
        };
        return temp;
    }

    
}
