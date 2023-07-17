using UnityEngine;

public class loot_pn_sc : MonoBehaviour
{
    public inv_db_sc _inv_db;


    public Transform _loot_cont;
    public GameObject _item_slot;


    public void Loot_Pn_Load()
    {
        Loot_Pn_Clear();
        for (int i = 0; i < _inv_db._loot.Count; i++)
        {
            Instantiate(_item_slot, _loot_cont).GetComponent<item_slot_sc>()._item = _inv_db._loot[i];
        }
    }
    void Loot_Pn_Clear()
    {
        for (int i = 0; i < _loot_cont.childCount; i++)
        {
            Destroy(_loot_cont.GetChild(i).gameObject);
        }
    }
}
