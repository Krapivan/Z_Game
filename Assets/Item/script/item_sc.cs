using UnityEngine;

public class item_sc : MonoBehaviour
{
    public inv_db_sc _inv_db;


    //general har
    public string _name_txt, _type_txt, _subtype_txt;
    public string _name, _type, _subtype;

    public Vector3 _in_arm_position;
    public Vector3 _in_arm_rotation;
    public Vector3 _arm_2_follow_target;

    public Sprite _art;
    public bool _is_big_art;
    public bool _is_drop;

    //weapon har = = = = =
    public bool _is_range;
    //range har
    public string _attack_an_name;
    public GameObject _bullet;
    public Transform _bullet_spawn_point;
    public string _bullet_name;
    public int _bullet_count, _bullet_per_shot;
    public float _bullet_speed;
    public float _shot_speed, _shot_range;
    public float _miss_mx, _miss_mn, _miss_recover;
    public int _resource;
    public float _weight;


    public void In_Arm()
    {
        transform.localPosition = _in_arm_position;
        transform.localRotation = Quaternion.Euler(_in_arm_rotation);
    }

    

    public void Attack(float ang)
    {
        if (_is_range == true)
        {
            Range_Attack(ang);
        }
    }
    void Range_Attack(float ang)
    {
        GetComponent<Animation>().Play(_attack_an_name);
        Instantiate(_bullet, _bullet_spawn_point.position, Quaternion.Euler(0, 0, ang)).GetComponent<bullet_sc>().Get_Setting(_shot_range, _bullet_speed);
    }
}
