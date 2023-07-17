using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "db/weapon_db")]
public class weapon_db_sc : ScriptableObject
{
    public List<string> _wp_name;
    public List<Sprite> _wp_art;
    public List<bool> _wp_is_big_art;
    public List<string> _ammo_name;
    public List<int> _ammo_count;
    public List<float> _ammo_speed;
    public List<float> _shot_speed;
    public List<float> _shot_range;
    public List<float> _miss_mx;
    public List<float> _miss_mn;
    public List<float> _miss_recover;
    public List<int> _wp_resource;
    public List<float> _wp_weight;
}
