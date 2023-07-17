using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class item_inf_pn_sc : MonoBehaviour
{
    public inv_db_sc _inv_db;


    public game_sc _game_sc;


    public GameObject _item;
    public item_sc _item_sc;
    public Image _big_art, _small_art;

    public TextMeshProUGUI _item_name_txt, _item_type_txt, _inf_txt, _weight_txt;

    private void Start()
    {
        name = "item_inf_pn";

        _game_sc = GameObject.Find("game_sc").GetComponent<game_sc>();

        _item_sc = _item.GetComponent<item_sc>();

        Load();
    }


    public void Cls_B()
    {
        Destroy(gameObject);
    }

    public void Equip_B()
    {
        item_service_sc.Equip_Item(_item, _inv_db);
        _game_sc._inv_pn_sc.Inv_Load();
        Destroy(gameObject);
    }
    public void Remove_B()
    {
        item_service_sc.Remove_Item(_item, _inv_db);
        _game_sc._inv_pn_sc.Inv_Load();
        Destroy(gameObject);
    }

    public void Use_B()
    {

    }

    public void Take_B()
    {
        item_service_sc.Take_Item(_item, _inv_db);
        _game_sc._loot_pn_sc.Loot_Pn_Load();
        Destroy(gameObject);
    }
    public void Drop_B()
    {
        item_service_sc.Drop_Item(_item, _inv_db);
        _game_sc._inv_pn_sc.Inv_Load();
        Destroy(gameObject);
    }


    public GameObject cls_b, _use_b, _equip_b, _remove_b, _take_b, _drop_b;
    public TextMeshProUGUI _use_b_txt;
    void Load()
    {
        Load_Buttons();

        Art_Load();

        //txt
        _item_name_txt.text = _item_sc._name_txt;
        _item_type_txt.text = _item_sc._type_txt + "|" + _item_sc._subtype_txt;
        _weight_txt.text = "Вес: " + _item_sc._weight;
        if (_item_sc._type == "weapon")
        {
            Weapon_Load();
        }
    }
    void Load_Buttons()
    {
        if (_item_sc._is_drop == true)
        {
            _take_b.SetActive(true);
        }
        else if (_item_sc._is_drop == false)
        {
            if (_item_sc._type == "weapon")
            {
                if (_item_sc._subtype == "main_wp")
                {
                    if (_inv_db._main_wp == _item)
                    {
                        _remove_b.SetActive(true);
                    }
                    else if (_inv_db._main_wp != _item)
                    {
                        _equip_b.SetActive(true);
                        _drop_b.SetActive(true);
                    }
                    return;
                }
                if (_item_sc._subtype == "sub_wp")
                {
                    if (_inv_db._sub_wp == _item)
                    {
                        _remove_b.SetActive(true);
                    }
                    else if (_inv_db._sub_wp != _item)
                    {
                        _equip_b.SetActive(true);
                        _drop_b.SetActive(true);
                    }
                    return;
                }
                if (_item_sc._subtype == "melee_wp")
                {
                    if (_inv_db._melee_wp == _item)
                    {
                        _remove_b.SetActive(true);
                    }
                    else if (_inv_db._melee_wp != _item)
                    {
                        _equip_b.SetActive(true);
                        _drop_b.SetActive(true);
                    }
                    return;
                }
            }
        }
    }
    void Art_Load()
    {
        if (_item_sc._is_big_art == true)
        {
            _big_art.gameObject.SetActive(true);
            _big_art.sprite = _item_sc._art;
        }
        else if (_item_sc._is_big_art == false)
        {
            _small_art.gameObject.SetActive(true);
            _small_art.sprite = _item_sc._art;
        }
    }
    void Weapon_Load()
    {
        _inf_txt.text = "Боеприпас: " + _item_sc._bullet_name + "\n" +
            "Ёмкость: " + _item_sc._bullet_count + " | " + "Скорость Пули: " + _item_sc._bullet_speed + "\n" +
            "Темп огня: " + _item_sc._shot_speed + " | " + "Дальность: " + _item_sc._shot_range + "\n" +
            "Макс Разброс: " + _item_sc._miss_mx + " | " + "Мин Разброс: " + _item_sc._miss_mn + "\n" +
            "Сведение: " + _item_sc._miss_recover + " | " + "Ресурс: " + _item_sc._resource;
    }
}
