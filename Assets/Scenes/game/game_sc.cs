using Unity.VisualScripting;
using UnityEngine;

public class game_sc : MonoBehaviour
{
    public game_db_sc _game_db;


    public GameObject _hero;


    private void FixedUpdate()
    {

    }


    public GameObject _inv_equip_pn, _inv_equip_pn_op_b, _inv_slot;
    public Transform _inv_cont;
    public void Inv_Equip_B()
    {
        if (_inv_equip_pn.activeSelf == false)
        {
            _inv_equip_pn.SetActive(true);
            _inv_equip_pn_op_b.SetActive(false);
            Inv_Load();
        }
        else if (_inv_equip_pn.activeSelf == true)
        {
            _inv_equip_pn.SetActive(false);
            _inv_equip_pn_op_b.SetActive(true);
        }
    }
    void Inv_Load()
    {
        Inv_Clear();
        for (int i = 0; i < _game_db._inv.Count; i++)
        {
            Instantiate(_inv_slot, _inv_cont);
        }
    }
    void Inv_Clear()
    {
        for (int i = 0; i < _inv_cont.childCount; i++)
        {
            Destroy(_inv_cont.GetChild(i).gameObject);
        }
    }
}
