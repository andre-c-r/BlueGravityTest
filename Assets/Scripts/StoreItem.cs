using UnityEngine;

[CreateAssetMenu (fileName = "StoreItem", menuName = "ScriptableObjects/StoreItem", order = 0)]
public class StoreItem : ScriptableObject
{
    public string itemName;
    public int itemPrice;
    public Sprite ItemIcon;
}
