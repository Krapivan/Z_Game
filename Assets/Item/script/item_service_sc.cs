using UnityEngine;

public static class item_service_sc
{
    public static void Equip_Item(GameObject _item, inv_db_sc _inv_db)
    {
        item_sc _item_sc = _item.GetComponent<item_sc>();

        if (_item_sc._type == "weapon")
        {
            if (_item_sc._subtype == "main_wp")
            {
                if (_inv_db._main_wp == null)
                {
                    _inv_db._inv.Remove(_item);
                    _inv_db._main_wp = _item;
                }
                else if (_inv_db._main_wp != null)
                {
                    _inv_db._inv.Add(_inv_db._main_wp);
                    _inv_db._inv.Remove(_item);
                    _inv_db._main_wp = _item;
                }
            }
            else if (_item_sc._subtype == "sub_wp")
            {
                if (_inv_db._sub_wp == null)
                {
                    _inv_db._sub_wp = _item;
                    _inv_db._inv.Remove(_item);
                }
                else if (_inv_db._sub_wp != null)
                {
                    _inv_db._inv.Add(_inv_db._sub_wp);
                    _inv_db._sub_wp = _item;
                    _inv_db._inv.Remove(_item);
                }
            }
            else if (_item_sc._subtype == "melee_wp")
            {
                if (_inv_db._melee_wp == null)
                {
                    _inv_db._melee_wp = _item;
                    _inv_db._inv.Remove(_item);
                }
                else if (_inv_db._melee_wp != null)
                {
                    _inv_db._inv.Add(_inv_db._melee_wp);
                    _inv_db._inv.Remove(_item);
                    _inv_db._melee_wp = _item;
                }
            }
        }
    }
    public static void Remove_Item(GameObject _item, inv_db_sc _inv_db)
    {
        item_sc _item_sc = _item.GetComponent<item_sc>();

        if (_item_sc._type == "clothes")
        {
            if (_item_sc._subtype == "helmet")
            {
                _inv_db._inv.Add(_item);
                _inv_db._helmet = null;
            }

            if (_item_sc._subtype == "mask")
            {
                _inv_db._inv.Add(_item);
                _inv_db._mask = null;
            }

            if (_item_sc._subtype == "armor")
            {
                _inv_db._inv.Add(_item);
                _inv_db._armor = null;
            }

            if (_item_sc._subtype == "costume")
            {
                _inv_db._inv.Add(_item);
                _inv_db._costume = null;
            }

            if (_item_sc._subtype == "tool")
            {
                _inv_db._inv.Add(_item);
                _inv_db._tool = null;
            }
        }
        else if (_item_sc._type == "weapon")
        {
            if (_inv_db._main_wp == _item)
            {
                _inv_db._inv.Add(_inv_db._main_wp);
                _inv_db._main_wp = null;
            }
            else if (_inv_db._sub_wp == _item)
            {
                _inv_db._inv.Add(_inv_db._sub_wp);
                _inv_db._sub_wp = null;
            }
            else if (_inv_db._melee_wp == _item)
            {
                _inv_db._inv.Add(_inv_db._melee_wp);
                _inv_db._melee_wp = null;
            }
        }
    }

    public static void Take_Item(GameObject _item, inv_db_sc _inv_db)
    {
        item_sc _item_sc = _item.GetComponent<item_sc>();

        if (_item_sc._weight + _inv_db._weight_now <= _inv_db._weight_mx)
        {
            _item_sc._is_drop = false;
            _inv_db._inv.Add(_item);
            _item.transform.SetParent(_inv_db._inv_layer);
            _item_sc.transform.localPosition = Vector3.zero;

            _inv_db._loot.Remove(_item);
        }
    }
    public static void Drop_Item(GameObject _item, inv_db_sc _inv_db)
    {
        item_sc _item_sc = _item.GetComponent<item_sc>();

        _item_sc._is_drop = true;
        _inv_db._inv.Remove(_item);
        _item.transform.SetParent(_inv_db._game_layer);
        _item_sc.transform.localPosition = _inv_db._hero.transform.localPosition;
    }


    public static GameObject Find_Slot(Transform field, GameObject item)
    {
        GameObject slot = null;

        for (int i = 0; i < field.childCount; i++)
        {
            if (field.GetChild(i).GetComponent<item_slot_sc>()._item == item)
            {
                slot = field.GetChild(i).gameObject;
                return slot;
            }
        }

        return slot;
    }
}
