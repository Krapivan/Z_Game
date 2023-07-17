using UnityEngine;

public class choose_wp_b_sc : MonoBehaviour
{
    public inv_db_sc _inv_db;


    public GameObject _choose_main_wp_b, _choose_pistol_b, _choose_melee_b;


    private void FixedUpdate()
    {
        Choose_Wp_B_Load();
    }

    void Choose_Wp_B_Load()
    {
        if (_inv_db._main_wp != null)
        {
            _choose_main_wp_b.SetActive(true);
        }
        else
        {
            _choose_main_wp_b.SetActive(false);
        }

        if (_inv_db._sub_wp != null)
        {
            _choose_pistol_b.SetActive(true);
        }
        else
        {
            _choose_pistol_b.SetActive(false);
        }

        if (_inv_db._melee_wp != null)
        {
            _choose_melee_b.SetActive(true);
        }
        else
        {
            _choose_melee_b.SetActive(false);
        }
    }
    public void Choose_Wp_B(int slot_num)
    {
        GameObject weapon = null;
        hero_sc hero_sc = _inv_db._hero.GetComponent<hero_sc>();

        switch (slot_num)
        {
            case 1:
                weapon = _inv_db._main_wp;
                break;
            case 2:
                weapon = _inv_db._sub_wp;
                break;
            case 3:
                weapon = _inv_db._melee_wp;
                break;
        }

        hero_sc.Equip_Remove_Weapon(weapon);
    }
}
