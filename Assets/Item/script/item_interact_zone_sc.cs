using UnityEngine;

public class item_interact_zone_sc : MonoBehaviour
{
    public inv_db_sc _inv_db;
    public GameObject _item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interact_zone" && collision.transform.parent.tag == "Player" && _item.GetComponent<item_sc>()._is_drop == true)
        {
            _inv_db._loot.Add(_item);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Interact_zone" && collision.transform.parent.tag == "Player" && _item.GetComponent<item_sc>()._is_drop == true)
        {
            _inv_db._loot.Remove(_item);
        }
    }
}
