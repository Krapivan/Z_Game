using UnityEngine;

public class hero_sc : MonoBehaviour
{
    public inv_db_sc _inv_db;


    public Rigidbody2D _rb;
    public GameObject _body_layer, _arm_layer, _leg_layer;
    public GameObject _arm_1, _arm_2;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
        Arm_2_Follow();
    }


    public Animator _body_an, _arm_an, _leg_an;
    void Bool_Animator_Changer(string parametr, bool value, string layer)
    {
        if (layer == "all")
        {
            _body_an.SetBool(parametr, value);
            _arm_an.SetBool(parametr, value);
            _leg_an.SetBool(parametr, value);
        }
        else if (layer == "body")
        {
            _body_an.SetBool(parametr, value);
        }
        else if (layer == "arm")
        {
            _arm_an.SetBool(parametr, value);
        }
        else if (layer == "leg")
        {
            _leg_an.SetBool(parametr, value);
        }
    }
    void Int_Animator_Changer(string parametr, int value, string layer)
    {
        if (layer == "all")
        {
            _body_an.SetInteger(parametr, value);
            _arm_an.SetInteger(parametr, value);
            _leg_an.SetInteger(parametr, value);
        }
        else if (layer == "body")
        {
            _body_an.SetInteger(parametr, value);
        }
        else if (layer == "arm")
        {
            _arm_an.SetInteger(parametr, value);
        }
        else if (layer == "leg")
        {
            _leg_an.SetInteger(parametr, value);
        }
    }

    //Move = = = = =
    public Vector3 _move_v;
    public bool _is_move;
    public float _move_spd;
    public float _run_spd;
    [SerializeField] float spd;
    void Move()
    {
        //flip
        if (_move_v.x < 0)
        {
            Flip(false);
        }
        else if (_move_v.x > 0)
        {
            Flip(true);
        }

        //move an
        if (_move_v != new Vector3(0,0,0))
        {
            Bool_Animator_Changer("move", true, "all");
        }
        else
        {
            Bool_Animator_Changer("move", false, "all");
        }

        //spd
        if (Input.GetKey(KeyCode.LeftShift) == true)
        {
            _body_an.SetBool("run", true);
            spd = _run_spd;
        }
        else 
        {
            _body_an.SetBool("run", false);
            spd = _move_spd; 
        }

        _rb.velocity = _move_v.normalized * spd;
    }
    public void Flip(bool flip)
    {
        if (flip == true)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (flip == false)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }


    //Weapon = = = = =
    public Vector3 arm_2_follow_target;
    public void Equip_Remove_Weapon(GameObject weapon)
    {
        if (_inv_db._chosen_wp != null)
        {
            if (_inv_db._chosen_wp != weapon)
            {
                Remove_Weapon();
                Equip_Weapon(weapon);
            }
            else if (_inv_db._chosen_wp == weapon)
            {
                Remove_Weapon();
            }
        }
        else if (_inv_db._chosen_wp == null)
        {
            Equip_Weapon(weapon);
        }
    }
    void Equip_Weapon(GameObject weapon)
    {
        item_sc item_sc = weapon.GetComponent<item_sc>();
        _inv_db._chosen_wp = weapon;
        weapon.transform.SetParent(_arm_1.transform);
        item_sc.In_Arm();
        arm_2_follow_target = item_sc._arm_2_follow_target;
        switch (item_sc._subtype)
        {
            case "main_wp": Int_Animator_Changer("equip_wp", 1, "arm"); break;
            case "sub_wp": Int_Animator_Changer("equip_wp", 2, "arm"); break;
            case "melee_wp": Int_Animator_Changer("equip_wp", 3, "arm"); break;
        }
    }
    void Remove_Weapon()
    {
        GameObject weapon = _inv_db._chosen_wp;
        weapon.transform.SetParent(_inv_db._inv_layer);
        weapon.transform.localPosition = Vector3.zero;
        _inv_db._chosen_wp = null;
        arm_2_follow_target = Vector3.zero;
        Int_Animator_Changer("equip_wp", 0, "arm");
    }
    void Arm_2_Follow()
    {
        if (_inv_db._chosen_wp != null && _arm_an.enabled == false)
        {
            _arm_2.transform.localPosition = Vector3.MoveTowards(_arm_2.transform.localPosition, arm_2_follow_target, 0.1f);
        }
    }
}
