using UnityEngine;
using UnityEngine.UI;

public class inv_pn_sc : MonoBehaviour
{
    public inv_db_sc _inv_db;

    public GameObject _item_inf_pn;


    public GameObject _item_slot;
    public Transform _inv_cont;
    public Image _helmet_art, _mask_art, _armor_art, _costume_art, _tool_art, _vest_art, _pouch_art, _bag_art, _pocket_1_art, _pocket_2_art, _pocket_3_art, _pocket_4_art, _main_wp_art, _sub_wp_art, _melee_wp_art;
    public Image _helmet_b, _mask_b, _armor_b, _costume_b, _tool_b, _vest_b, _pouch_b, _bag_b, _pocket_1_b, _pocket_2_b, _pocket_3_b, _pocket_4_b, _main_wp_b, _sub_wp_b, _melee_wp_b;
    public void Inv_Load()
    {
        Inv_Clear();

        //equip
        {
            //helmet
            if (_inv_db._helmet != null)
            {
                _helmet_art.gameObject.SetActive(true);
                _helmet_art.sprite = _inv_db._helmet.GetComponent<item_sc>()._art;
            }
            else 
            {
                _helmet_art.gameObject.SetActive(false);
            }
            //mask
            if (_inv_db._mask != null)
            {
                _mask_art.gameObject.SetActive(true);
                _mask_art.sprite = _inv_db._mask.GetComponent<item_sc>()._art;
            }
            else
            {
                _mask_art.gameObject.SetActive(false);
            }
            //armor
            if (_inv_db._armor != null)
            {
                _armor_art.gameObject.SetActive(true);
                _armor_art.sprite = _inv_db._armor.GetComponent<item_sc>()._art;
            }
            else
            {
                _armor_art.gameObject.SetActive(false);
            }
            //costume
            if (_inv_db._costume != null)
            {
                _costume_art.gameObject.SetActive(true);
                _costume_art.sprite = _inv_db._costume.GetComponent<item_sc>()._art;
            }
            else
            {
                _costume_art.gameObject.SetActive(false);
            }
            //tool
            if (_inv_db._tool != null)
            {
                _tool_art.gameObject.SetActive(true);
                _tool_art.sprite = _inv_db._tool.GetComponent<item_sc>()._art;
            }
            else
            {
                _tool_art.gameObject.SetActive(false);
            }
            //vest
            if (_inv_db._vest != null)
            {
                _tool_art.gameObject.SetActive(true);
                _vest_art.sprite = _inv_db._vest.GetComponent<item_sc>()._art;
            }
            else
            {
                _tool_art.gameObject.SetActive(false);
            }
            //pouch
            if (_inv_db._pouch != null)
            {
                _pouch_art.gameObject.SetActive(true);
                _pouch_art.sprite = _inv_db._pouch.GetComponent<item_sc>()._art;
            }
            else
            {
                _pouch_art.gameObject.SetActive(false);
            }
            //bag
            if (_inv_db._bag != null)
            {
                _bag_art.gameObject.SetActive(true);
                _bag_art.sprite = _inv_db._bag.GetComponent<item_sc>()._art;
            }
            else
            {
                _bag_art.gameObject.SetActive(false);
            }
            //pockets
            if (_inv_db._pocket.Count >= 1)
            {
                _pocket_1_art.gameObject.SetActive(true);
                _pocket_1_art.sprite = _inv_db._pocket[0].GetComponent<item_sc>()._art;
            }
            else
            {
                _pocket_1_art.gameObject.SetActive(false);
            }

            if (_inv_db._pocket.Count >= 2)
            {
                _pocket_2_art.gameObject.SetActive(true);
                _pocket_2_art.sprite = _inv_db._pocket[1].GetComponent<item_sc>()._art;
            }
            else
            {
                _pocket_2_art.gameObject.SetActive(false);
            }

            if (_inv_db._pocket.Count >= 3)
            {
                _pocket_3_art.gameObject.SetActive(true);
                _pocket_3_art.sprite = _inv_db._pocket[2].GetComponent<item_sc>()._art;
            }
            else
            {
                _pocket_3_art.gameObject.SetActive(false);
            }

            if (_inv_db._pocket.Count >= 4)
            {
                _pocket_4_art.gameObject.SetActive(true);
                _pocket_4_art.sprite = _inv_db._pocket[3].GetComponent<item_sc>()._art;
            }
            else
            {
                _pocket_4_art.gameObject.SetActive(false);
            }
            //weapons
            if (_inv_db._main_wp != null)
            {
                _main_wp_art.gameObject.SetActive(true);
                _main_wp_art.sprite = _inv_db._main_wp.GetComponent<item_sc>()._art;
            }
            else 
            {
                _main_wp_art.gameObject.SetActive(false);
            }

            if (_inv_db._sub_wp != null)
            {
                _sub_wp_art.gameObject.SetActive(true);
                _sub_wp_art.sprite = _inv_db._sub_wp.GetComponent<item_sc>()._art;
            }
            else
            {
                _sub_wp_art.gameObject.SetActive(false);
            }

            if (_inv_db._melee_wp != null)
            {
                _melee_wp_art.gameObject.SetActive(true);
                _melee_wp_art.sprite = _inv_db._melee_wp.GetComponent<item_sc>()._art;
            }
            else
            {
                _melee_wp_art.gameObject.SetActive(false);
            }
        }

        //inv
        for (int i = 0; i < _inv_db._inv.Count; i++)
        {
            Instantiate(_item_slot, _inv_cont).GetComponent<item_slot_sc>()._item = _inv_db._inv[i];
        }
    }
    void Inv_Clear()
    {
        for (int i = 0; i < _inv_cont.childCount; i++)
        {
            Destroy(_inv_cont.GetChild(i).gameObject);
        }
    }


    public void Inv_Pn_Slot(string slot_name)
    {
        GameObject item = null;
        if (slot_name == "helmet")
        {
            if (_inv_db._helmet != null)
            {
                //_melee_wp_b.GetComponent<Animation>().Play("click");
                item = _inv_db._helmet;
            }
        }
        else if (slot_name == "mask")
        {
            if (_inv_db._mask != null)
            {
                //_melee_wp_b.GetComponent<Animation>().Play("click");
                item = _inv_db._mask;
            }
        }
        else if (slot_name == "armor")
        {
            if (_inv_db._armor != null)
            {
                //_melee_wp_b.GetComponent<Animation>().Play("click");
                item = _inv_db._armor;
            }
        }
        else if (slot_name == "costume")
        {
            if (_inv_db._costume != null)
            {
                //_melee_wp_b.GetComponent<Animation>().Play("click");
                item = _inv_db._costume;
            }
        }
        else if (slot_name == "tool")
        {
            if (_inv_db._tool != null)
            {
                //_melee_wp_b.GetComponent<Animation>().Play("click");
                item = _inv_db._tool;
            }
        }
        else if (slot_name == "vest")
        {
            if (_inv_db._vest != null)
            {
                //_melee_wp_b.GetComponent<Animation>().Play("click");
                item = _inv_db._vest;
            }
        }
        else if (slot_name == "pouch")
        {
            if (_inv_db._pouch != null)
            {
                //_melee_wp_b.GetComponent<Animation>().Play("click");
                item = _inv_db._pouch;
            }
        }
        else if (slot_name == "bag")
        {
            if (_inv_db._bag != null)
            {
                //_melee_wp_b.GetComponent<Animation>().Play("click");
                item = _inv_db._bag;
            }
        }
        else if (slot_name == "pocket_1")
        {
            if (_inv_db._pocket.Count >= 1)
            {
                //_melee_wp_b.GetComponent<Animation>().Play("click");
                item = _inv_db._pocket[0];
            }
        }
        else if (slot_name == "pocket_2")
        {
            if (_inv_db._pocket.Count >= 2)
            {
                //_melee_wp_b.GetComponent<Animation>().Play("click");
                item = _inv_db._pocket[1];
            }
        }
        else if (slot_name == "pocket_3")
        {
            if (_inv_db._pocket.Count >= 3)
            {
                //_melee_wp_b.GetComponent<Animation>().Play("click");
                item = _inv_db._pocket[2];
            }
        }
        else if (slot_name == "pocket_4")
        {
            if (_inv_db._pocket.Count >= 4)
            {
                //_melee_wp_b.GetComponent<Animation>().Play("click");
                item = _inv_db._pocket[3];
            }
        }
        else if (slot_name == "main_wp")
        {
            if (_inv_db._main_wp != null)
            {
                //_main_wp_b.GetComponent<Animation>().Play("click");
                item = _inv_db._main_wp;
            }
        }
        else if (slot_name == "sub_wp")
        {
            if (_inv_db._sub_wp != null)
            {
                //_sub_wp_b.GetComponent<Animation>().Play("click");
                item = _inv_db._sub_wp;
            }
        }
        else if (slot_name == "melee_wp")
        {
            if (_inv_db._melee_wp != null)
            {
                //_melee_wp_b.GetComponent<Animation>().Play("click");
                item = _inv_db._melee_wp;
            }
        }

        if (item != null)
        {
            item_inf_pn_sc item_inf_pn_sc = Instantiate(_item_inf_pn, _inv_db._ui_layer).GetComponent<item_inf_pn_sc>();
            item_inf_pn_sc._item = item;
        }
    }
}
