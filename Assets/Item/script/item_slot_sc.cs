using UnityEngine.UI;
using UnityEngine;

public class item_slot_sc : MonoBehaviour
{
    public inv_db_sc _inv_db;


    public GameObject _item;
    public item_sc _item_sc;
    public Image _big_art, _small_art;
    
    private void Start()
    {
        name = "item_slot";
        _item_sc = _item.GetComponent<item_sc>();
        Art_Load();
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

    public GameObject _item_inf_pn;
    public void Item_Slot_B()
    {
        gameObject.GetComponent<Animation>().Play("click");
        
        GameObject item_inf_pn = GameObject.Find("item_inf_pn");
        if (item_inf_pn != null)
        {
            Destroy(item_inf_pn);
        }
        item_inf_pn_sc item_inf_pn_sc = Instantiate(_item_inf_pn, _inv_db._ui_layer).GetComponent<item_inf_pn_sc>();
        item_inf_pn_sc._item = _item;
    }
}
