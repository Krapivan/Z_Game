using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "db/item_db")]
public class item_db_sc : ScriptableObject
{
    public List<string> _item_name;
    public List<GameObject> _item;
}
