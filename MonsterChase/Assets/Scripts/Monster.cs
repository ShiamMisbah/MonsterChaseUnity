using UnityEngine;

public class Monster : MonoBehaviour
{

    [HideInInspector]
    public float speed;
    private Rigidbody2D mybody;
    private void Awake() {
        mybody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mybody.velocity = new Vector2(speed,  mybody.velocity.y);
    }
}
