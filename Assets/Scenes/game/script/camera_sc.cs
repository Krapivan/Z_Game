using UnityEngine;

public class camera_sc : MonoBehaviour
{
    public GameObject _hero;
    private void FixedUpdate()
    {
        transform.position = new Vector3(_hero.transform.position.x, _hero.transform.position.y, transform.position.z);
    }
}
