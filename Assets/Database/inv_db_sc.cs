using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "db/inv_db")]
public class inv_db_sc : ScriptableObject
{
    //general
    public GameObject _hero;
    public GameObject _chosen_wp;

    public List<GameObject> _loot;

    //layers
    public Transform _ui_layer;
    public Transform _inv_layer;
    public Transform _game_layer;

    //inv
    public GameObject _helmet;
    public GameObject _mask;
    public GameObject _armor;
    public GameObject _costume;

    public GameObject _tool;
    public GameObject _vest;
    public GameObject _pouch;
    public GameObject _bag;

    public List<GameObject> _pocket;

    public GameObject _main_wp;
    public GameObject _sub_wp;
    public GameObject _melee_wp;

    public List<GameObject> _inv;

    public float _weight_mx;
    public float _weight_now;
}
