using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "db/game_db")]
public class game_db_sc : ScriptableObject
{
    public GameObject _hero;


    public List<GameObject> _loot_menu;


    //hero state
    public List<string> _equip;
    public List<string> _inv;

}
