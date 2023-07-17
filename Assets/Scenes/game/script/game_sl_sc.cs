using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class game_sl_sc : MonoBehaviour
{
    public inv_db_sc _inv_db;
    public item_db_sc _item_db;

    public void Inv_Db_Load()
    {
        Inv_Json inv_json = new();
        inv_json = JsonUtility.FromJson<Inv_Json>(File.ReadAllText(Application.streamingAssetsPath + "/inv_json.json"));
        Inv_Db_Up(inv_json);
    }
    public void Inv_Db_Save()
    {
        Inv_Json inv_json = Inv_Db_Down();
        string json = JsonUtility.ToJson(inv_json);
        File.WriteAllText(Application.streamingAssetsPath + "/inv_json.json", json);
    }
    void Inv_Db_Up(Inv_Json inv_json)
    {
        int id = 0;
        GameObject _item;

        for (int i = 0; i < inv_json._inv_item.Count; i++)
        {
            id = _item_db._item_name.IndexOf(inv_json._inv_item[i]._name) + 1;

            _item = Instantiate(_item_db._item[id - 1], _inv_db._inv_layer);

            switch (inv_json._inv_item[i]._from)
            {
                case "helmet": _inv_db._helmet = _item; break;
                case "mask": _inv_db._mask = _item; break;
                case "armor": _inv_db._armor = _item; break;
                case "costume": _inv_db._costume = _item; break;

                case "tool": _inv_db._tool = _item; break;
                case "vest": _inv_db._vest = _item; break;
                case "pouch": _inv_db._pouch = _item; break;
                case "bag": _inv_db._bag = _item; break;

                case "pocket": _inv_db._pocket.Add(_item); break;

                case "main_wp": _inv_db._main_wp = _item; break;
                case "pistol": _inv_db._sub_wp = _item; break;
                case "melee": _inv_db._melee_wp = _item; break;

                case "inv": _inv_db._inv.Add(_item); break;
            }

            _inv_db._weight_mx = inv_json._weight_mx;
            _inv_db._weight_now = inv_json._weight_now;
        }

    }
    Inv_Json Inv_Db_Down()
    {
        Inv_Json inv_json = new();

        GameObject _item;
        Item item;
        //helmet
        _item = _inv_db._helmet;
        if (_item != null)
        {
            item = new()
            {
                _name = _item.GetComponent<item_sc>()._name,
                _from = "helmet",
            };
            inv_json._inv_item.Add(item);
        }
        //mask
        _item = _inv_db._mask;
        if (_item != null)
        {
            item = new()
            {
                _name = _item.GetComponent<item_sc>()._name,
                _from = "mask",
            };
            inv_json._inv_item.Add(item);
        }
        //armor
        _item = _inv_db._armor;
        if (_item != null)
        {
            item = new()
            {
                _name = _item.GetComponent<item_sc>()._name,
                _from = "armor",
            };
            inv_json._inv_item.Add(item);
        }
        //costume
        _item = _inv_db._costume;
        if (_item != null)
        {
            item = new()
            {
                _name = _item.GetComponent<item_sc>()._name,
                _from = "costume",
            };
            inv_json._inv_item.Add(item);
        }
        //tool
        _item = _inv_db._tool;
        if (_item != null)
        {
            item = new()
            {
                _name = _item.GetComponent<item_sc>()._name,
                _from = "tool",
            };
            inv_json._inv_item.Add(item);
        }
        //vest
        _item = _inv_db._vest;
        if (_item != null)
        {
            item = new()
            {
                _name = _item.GetComponent<item_sc>()._name,
                _from = "vest",
            };
            inv_json._inv_item.Add(item);
        }
        //pouch
        _item = _inv_db._pouch;
        if (_item != null)
        {
            item = new()
            {
                _name = _item.GetComponent<item_sc>()._name,
                _from = "pouch",
            };
            inv_json._inv_item.Add(item);
        }
        //bag
        _item = _inv_db._bag;
        if (_item != null)
        {
            item = new()
            {
                _name = _item.GetComponent<item_sc>()._name,
                _from = "bag",
            };
            inv_json._inv_item.Add(item);
        }
        //pocket
        for (int i = 0; i < _inv_db._pocket.Count; i++)
        {
            _item = _inv_db._pocket[0];
            item = new()
            {
                _name = _item.GetComponent<item_sc>()._name,
                _from = "pocket",
            };
            inv_json._inv_item.Add(item);
        }
        //main wp
        _item = _inv_db._main_wp;
        if (_item != null)
        {
            item = new()
            {
                _name = _item.GetComponent<item_sc>()._name,
                _from = "main_wp",
            };
            inv_json._inv_item.Add(item);
        }
        //pistol
        _item = _inv_db._sub_wp;
        if (_item != null)
        {
            item = new()
            {
                _name = _item.GetComponent<item_sc>()._name,
                _from = "pistol",
            };
            inv_json._inv_item.Add(item);
        }
        //melee
        _item = _inv_db._melee_wp;
        if (_item != null)
        {
            item = new()
            {
                _name = _item.GetComponent<item_sc>()._name,
                _from = "melee",
            };
            inv_json._inv_item.Add(item);
        }
        //inv
        for (int i = 0; i < _inv_db._inv.Count; i++)
        {
            _item = _inv_db._inv[0];
            item = new()
            {
                _name = _item.GetComponent<item_sc>()._name,
                _from = "inv",
            };
            inv_json._inv_item.Add(item);
        }
        //weight
        inv_json._weight_mx = _inv_db._weight_mx;
        inv_json._weight_now = _inv_db._weight_now;

        return inv_json;
    }



    public void Inv_Null()
    {
        //general
        _inv_db._hero = null;
        _inv_db._chosen_wp = null;

        _inv_db._loot.Clear();

        //layers
        _inv_db._ui_layer = null;
        _inv_db._inv_layer = null;
        _inv_db._game_layer = null;

        //slot
        _inv_db._helmet = null;
        _inv_db._mask = null;
        _inv_db._armor = null;
        _inv_db._costume = null;

        _inv_db._tool = null;
        _inv_db._vest = null;
        _inv_db._pouch = null;
        _inv_db._bag = null;

        _inv_db._pocket.Clear();

        _inv_db._main_wp = null;
        _inv_db._sub_wp = null;
        _inv_db._melee_wp = null;

        _inv_db._inv.Clear();

        _inv_db._weight_mx = 100;
        _inv_db._weight_now = 0;
    }
}

[System.Serializable]
public class Inv_Json
{
    public List<Item> _inv_item = new();
    public float _weight_mx;
    public float _weight_now;
}
[System.Serializable]
public class Item
{
    public string _name;
    public string _from;
}
