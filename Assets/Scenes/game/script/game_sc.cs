using UnityEngine;
using UnityEngine.UI;

public class game_sc : MonoBehaviour
{
    public inv_db_sc _inv_db;
    public item_db_sc _item_db;


    public game_sl_sc _game_sl;
    public inv_pn_sc _inv_pn_sc;
    public loot_pn_sc _loot_pn_sc;
    public fast_slot_pn_sc _fast_slot_pn_sc;


    public GameObject _hero;


    private void Start()
    {
        Inv_Db_Load();
        Start_Metod();
    }

    void Start_Metod()
    {
        _fast_slot_pn_sc.Fast_Slot_Load();
    }

    void Inv_Db_Load()
    {
        _game_sl.Inv_Null();

        _inv_db._hero = GameObject.Find("hero");

        //layers
        _inv_db._ui_layer = GameObject.Find("ui_layer").transform;
        _inv_db._inv_layer = GameObject.Find("inv_layer").transform;
        _inv_db._game_layer = GameObject.Find("game_layer").transform;
    }



    public GameObject _inv_pn, _inv_op_b;
    public void Inv_Pn_Op_B()
    {
        if (_inv_pn.activeSelf == false)
        {
            _inv_pn.SetActive(true);
            _inv_op_b.SetActive(false);
            _inv_pn_sc.Inv_Load();
        }
        else if (_inv_pn.activeSelf == true)
        {
            _inv_pn.SetActive(false);
            _inv_op_b.SetActive(true);
        }
    }


    public GameObject _loot_pn, _loot_op_b;
    public void Loot_Pn_Op_B()
    {
        if (_loot_pn.activeSelf == false)
        {
            _loot_pn.SetActive(true);
            _loot_op_b.SetActive(false);
            _loot_pn_sc.Loot_Pn_Load();
        }
        else if (_loot_pn.activeSelf == true)
        {
            _loot_pn.SetActive(false);
            _loot_op_b.SetActive(true);
        }
    }


    public GameObject _spawn_obj;
    public Transform _spawn_tr;
    public void Spawn_Item(Transform field, string sad)
    {

    }
    public void Spawn_B()
    {
        GameObject obj = Instantiate(_spawn_obj, _spawn_tr);
        obj.GetComponent<item_sc>()._is_drop = true;
    }
    public void Save_B()
    {
        _game_sl.Inv_Db_Save();
    }
    public void Load_B()
    {
        _game_sl.Inv_Db_Load();
    }
}
