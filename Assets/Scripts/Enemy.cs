using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f; 

    private Rigidbody rb;
    private GameObject player;

    private bool isStunned = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if (isStunned)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        Vector3 dir = (player.transform.position - transform.position).normalized;

        rb.AddForce(dir * speed, ForceMode.Acceleration); 
    }

    public void SetStunned(bool stunned)
    {
        isStunned = stunned;

   
        Debug.Log(name + " stunned: " + stunned);
    }
    void Update()
    {
        // ถ้าตกต่ำเกิน → ลบทิ้ง
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}