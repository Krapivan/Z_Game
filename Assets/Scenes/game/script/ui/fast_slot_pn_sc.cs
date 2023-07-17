using UnityEngine;
using UnityEngine.UI;

public class fast_slot_pn_sc : MonoBehaviour
{
    public inv_db_sc _inv_db;


    public GameObject _fast_slot_1_b, _fast_slot_2_b, _fast_slot_3_b, _fast_slot_4_b;
    public Image _fast_slot_1_art, _fast_slot_2_art, _fast_slot_3_art, _fast_slot_4_art;


    public void Fast_Slot_Load()
    {
        Fast_Slot_Visual();
        Fast_Slot_Art_Load();
    }
    void Fast_Slot_Visual()
    {
        _fast_slot_1_b.gameObject.SetActive(false);
        _fast_slot_2_b.gameObject.SetActive(false);
        _fast_slot_3_b.gameObject.SetActive(false);
        _fast_slot_4_b.gameObject.SetActive(false);
        int pocket_count = _inv_db._pocket.Count;
        switch (pocket_count)
        {
            case 1: _fast_slot_1_b.SetActive(true); break;
            case 2: _fast_slot_1_b.SetActive(true); _fast_slot_2_b.SetActive(true); break;
            case 3: _fast_slot_1_b.SetActive(true); _fast_slot_2_b.SetActive(true); _fast_slot_3_b.SetActive(true); break;
            case 4: _fast_slot_1_b.SetActive(true); _fast_slot_2_b.SetActive(true); _fast_slot_3_b.SetActive(true); _fast_slot_4_b.SetActive(true); break;
        }
    }
    void Fast_Slot_Art_Load()
    {
        _fast_slot_1_art.gameObject.SetActive(false);
        _fast_slot_2_art.gameObject.SetActive(false);
        _fast_slot_3_art.gameObject.SetActive(false);
        _fast_slot_4_art.gameObject.SetActive(false);
        switch (_inv_db._pocket.Count)
        {
            case 1:
                _fast_slot_1_art.sprite = _inv_db._pocket[0].GetComponent<item_sc>()._art;
                _fast_slot_1_art.gameObject.SetActive(true);
                break;
            case 2:
                _fast_slot_1_art.sprite = _inv_db._pocket[0].GetComponent<item_sc>()._art;
                _fast_slot_2_art.sprite = _inv_db._pocket[0].GetComponent<item_sc>()._art;
                _fast_slot_1_art.gameObject.SetActive(true);
                _fast_slot_2_art.gameObject.SetActive(true);
                break;
            case 3:
                _fast_slot_1_art.sprite = _inv_db._pocket[0].GetComponent<item_sc>()._art;
                _fast_slot_2_art.sprite = _inv_db._pocket[0].GetComponent<item_sc>()._art;
                _fast_slot_3_art.sprite = _inv_db._pocket[0].GetComponent<item_sc>()._art;
                _fast_slot_1_art.gameObject.SetActive(true);
                _fast_slot_2_art.gameObject.SetActive(true);
                _fast_slot_3_art.gameObject.SetActive(true);
                break;
            case 4:
                _fast_slot_1_art.sprite = _inv_db._pocket[0].GetComponent<item_sc>()._art;
                _fast_slot_2_art.sprite = _inv_db._pocket[0].GetComponent<item_sc>()._art;
                _fast_slot_3_art.sprite = _inv_db._pocket[0].GetComponent<item_sc>()._art;
                _fast_slot_4_art.sprite = _inv_db._pocket[0].GetComponent<item_sc>()._art;
                _fast_slot_1_art.gameObject.SetActive(true);
                _fast_slot_2_art.gameObject.SetActive(true);
                _fast_slot_3_art.gameObject.SetActive(true);
                _fast_slot_4_art.gameObject.SetActive(true);
                break;
        }
    }
}
