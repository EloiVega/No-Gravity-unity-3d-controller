using UnityEngine;

[ExecuteInEditMode]
public class AirBorneManagement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float JumpHeight;

    public enum State { OnGround, InAir };
    public static State state = State.OnGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray Down = new Ray(transform.position, -Vector3.up);
        RaycastHit HitInfo;

        if (Physics.Raycast(Down, out HitInfo, 1f))
        {
            Debug.DrawLine(Down.origin, HitInfo.point, Color.green);
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            state = State.OnGround;
        }
        else if(Physics.Raycast(Down, out HitInfo, 1.5f)){
            Debug.DrawLine(Down.origin, HitInfo.point, Color.yellow);
            //rb.velocity = new Vector3(rb.velocity.x/2, rb.velocity.y, rb.velocity.z/2);
            state = State.InAir;
        }
        else
        {
            Debug.DrawLine(Down.origin, Down.origin + Down.direction * 1.5f, Color.red);
            rb.AddForce(0, -JumpHeight/5 * Time.deltaTime, 0);
            state = State.InAir;
        }

        if(Physics.Raycast(Down, out HitInfo, 1.5f))if (Input.GetKey(KeyCode.Space)) { rb.AddForce(0,  JumpHeight * Time.deltaTime, 0); }
    }
}
