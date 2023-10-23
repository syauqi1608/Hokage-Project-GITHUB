using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public Sprite iconUI;

    public Sprite imgUI;
    public string itemName;
    public string itemDesc;
}
