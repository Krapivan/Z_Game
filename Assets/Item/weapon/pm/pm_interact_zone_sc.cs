using UnityEngine;

public class pm_interact_zone_sc : MonoBehaviour
{
    public game_db_sc _game_db;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interact_zone" && collision.transform.parent.tag == "Player")
        {
            _game_db._loot_menu.Add(transform.parent.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Interact_zone" && collision.transform.parent.tag == "Player")
        {
            _game_db._loot_menu.Remove(transform.parent.gameObject);
        }
    }
}
