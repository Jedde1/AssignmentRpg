using UnityEngine;

public class Item 
{
    #region Variables
    //id of the item for programmer and devs
    private int _id;
    //Display name and Description for Players
    public string _name;
    public string _description;
    //Amount of items of that type...stackable
    private int _amount;
    //Buy sell vaue
    private int _value;
    //Basic Stats
    private int _damage;
    private int _armour;
    private int _heal;
    //Display Icon and Mesh
    private Texture2D _iconName;
    private GameObject _meshName;
    //Type of item... for item use
    private ItemTypes types;
    #endregion
    #region Proerties
    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public int Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public int Armour
    {
        get { return _armour; }
        set { _armour = value; }
    }
    public int Heal
    {
        get { return _heal; }
        set { _heal = value; }
    }
    public Texture2D IconName
    {
        get { return _iconName; }
        set { _iconName = value; }
    }
    public GameObject MeshName
    {
        get { return _meshName; }
        set { _meshName = value; }
    }
    public ItemTypes ItemTypes;
    #endregion
}
public enum ItemTypes
{
    Armour,
    Weapon,
    Potion,
    Money,
    Quest,
    Food,
    Ingredient,
    Craftable,
    Misc
}
