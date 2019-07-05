using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    private Animator animator;
    private float speed = 0.035f;
    private int life = 100;
    private int money = 100;
    public Text lifeText;
    public Text moneyText;
    public GameManager gameManager;
    void Start()
    {
        animator = GetComponent<Animator>();    
        lifeText.text = "♥ " + life;
        moneyText.text = "♥ " + money;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0) // gets forward
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + speed);
            animator.SetBool("move", true);
        }

        if (Input.GetAxis("Vertical") < 0) // gets forward
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - speed);
            animator.SetBool("move", true);
        }

        if (Input.GetAxis("Horizontal") > 0) // gets forward
        {
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed,gameObject.transform.position.y, gameObject.transform.position.z);
            animator.SetBool("move", true);
        }

        if (Input.GetAxis("Horizontal") < 0) // gets forward
        {
            gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - speed, gameObject.transform.position.y, gameObject.transform.position.z);
            
            animator.SetBool("move", true);
        }   
        
        if(Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("move", false);
        }

        UpdateLife();
        UpdateMoney();
        
        if(life <= 0)
        {
            gameManager.GameOver();
        }
    }

    private void UpdateLife()
    {
        lifeText.text = "♥ " + life;
    }

    private void UpdateMoney()
    {
        moneyText.text = "$ " + money;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FacturaFalopa")
        {
            this.money -= 10;
        }

        if(other.gameObject.tag == "Chorro")
        {
            this.life -= 10;

            if(this.life < 0)
                this.life = 0;

            other.GetComponent<ParticleSystem>().Emit(100);
        }

        var allAudioSources = FindObjectsOfType<AudioSource>().ToList();
        
        foreach(var a in allAudioSources)
        {
            a.Stop();
        }

        other.gameObject.GetComponent<AudioSource>().Play();
    }
}
