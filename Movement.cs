using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float rotationspeed;

    float rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKey(KeyCode.D))
        {

            rotation -= speed * Time.deltaTime;
            rotation = Mathf.Clamp(rotation, -37, 37);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 0f, rotation), speed * Time.deltaTime);


            if (AirBorneManagement.state == AirBorneManagement.State.OnGround) GetComponent<Rigidbody>().AddForce((speed / 4) * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rotation += speed * Time.deltaTime;
            rotation = Mathf.Clamp(rotation, -37, 37);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 0f, rotation), speed * Time.deltaTime);

            if (AirBorneManagement.state == AirBorneManagement.State.OnGround) GetComponent<Rigidbody>().AddForce((-speed / 4) * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
        }
        else
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 0f, 0f), rotationspeed * Time.deltaTime);
            rotation = 0f;
        }
    }
}
