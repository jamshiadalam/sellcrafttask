using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    
    public Animator player;
    public ParticleSystem muzzle;
    public AudioSource shootSound;
    bool isRuning = false;
    public GameObject Pistol;
    bool isActionArea = false;
    public Text msgText;
    public Text toggleText;
    public static bool onAction = false;
    float distance;
    GameObject arrow;
    public TextMesh dist;
    public GameObject target;
    public static bool onShoot = false;
    public static bool isMouseAim = false;
    public Transform spawnPoint;
    public GameObject bullet;

    void Start () {
        arrow = GameObject.Find("Arrow");
    }
	
	void Update () {

        if(!isActionArea)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                player.SetTrigger("Run");
                isRuning = true;

            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                player.SetTrigger("Stop");
                isRuning = false;
            }

            if (isRuning)
            {
                transform.Translate(0, 0, 0.1f);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Pistol.SetActive(true);
                onAction = true;
                msgText.text = "Click Right Mouse Button to Aim";
                
                target.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                isMouseAim = !isMouseAim;

                if(!isMouseAim)
                    toggleText.text = "Press V for Mouse Aim Mode";
                else
                    toggleText.text = "Press V for Auto Aim Mode";
            }
        }

        if(onAction)
        {
            if (Input.GetMouseButtonDown(1))
            {
                player.SetTrigger("Aim");
                msgText.text = "Click Left Mouse Button to Shoot";
                onShoot = true;
                toggleText.text = "Press V to Toggle Aim Mode";
            }

            if (Input.GetMouseButtonDown(0))
            {
                if(onShoot)
                {
                    player.Play("Shoot");
                    muzzle.Play();
                    shootSound.PlayDelayed(0.1f);
                    Invoke("Fire", 0.1f);
                }
            }

        }

        if (dist.gameObject != null)
        {
            distance = Vector3.Distance(gameObject.transform.position, arrow.transform.position);
            dist.text = Mathf.FloorToInt(distance).ToString() + " m";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isRuning = false;
        player.SetTrigger("Stop");
        isActionArea = true;
        other.gameObject.SetActive(false);
        arrow.SetActive(false);
        msgText.text = "Press E to Equip Pistol";
        dist.gameObject.SetActive(false);
    }

    void Fire()
    {
        GameObject bulletClone = (GameObject)Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        bulletClone.GetComponent<Rigidbody>().velocity = spawnPoint.gameObject.transform.forward * 10;
        Destroy(bulletClone, 2.0f);
    }
}
