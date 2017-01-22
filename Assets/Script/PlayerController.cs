using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public GameObject myCam;

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public cam[] Cam;
    public AudioClip impact;
    public GameObject ai;

    private Vector3 moveDirection = Vector3.zero;
    void Awake()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
        GetComponent<Rigidbody>().useGravity = false;
    }


    void Update(){
        Cursor.visible = false;
        Screen.lockCursor = true;
        if (!isLocalPlayer){
			return;
		}
		print(Network.player.ToString());

        foreach (cam item in Cam)
        {
            item.enabled = true;
        }

        myCam.GetComponent<Camera>().enabled=true;

        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    
        if (Input.GetMouseButtonDown(0)){
			CmdFire();
		}
	}

    [Command]
	void CmdFire(){
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 20;	
		NetworkServer.Spawn(bullet);
		Destroy(bullet, 5.0f);
        GetComponent<AudioSource>().PlayOneShot(impact, 0.7F);
    }
	
	public override void OnStartLocalPlayer (){
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "eye" || other.tag == "Bullet") {
            transform.position = new Vector3(0, 30, 0);
        }
    }
}