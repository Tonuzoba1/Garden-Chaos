using UnityEngine;

public class GroundBehav : MonoBehaviour
{
    [SerializeField] private float strength;
    [SerializeField] private bool standOn;
    [SerializeField] GameTiming gameTiming;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private BoxCollider2D bc;
    [SerializeField] private SpriteRenderer selfSr;
    [SerializeField] private float a;
    [SerializeField] private float g;
    [SerializeField] private float resetStrength;
    [SerializeField] private float resetA;
    [SerializeField] private float resetg;
    [SerializeField] private bool tileDead;
    [SerializeField] private bool resetPlanned;
    [SerializeField] private PlayerBehav playerBehav;

    void Awake()
    {
        selfSr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();

        tileDead = false;

        a = 0;
        g = 0.6415094f;

        resetStrength = strength;
        resetA = a;
    }

   public void Update()
    {

        if (gameTiming.gameStart && standOn)
        {
            a += (Time.deltaTime * 0.3f);
            strength -= Time.deltaTime * 2;
            sr.color = new Color(0.5775858f, 0.6415094f, 0.09380562f, a);

            g -= (Time.deltaTime * 0.1f);
            selfSr.color = new Color(0.5775858f, g, 0.09380562f, 1);
        }

        if(gameTiming.gameStart && strength <= 0 && !tileDead)
        {
            tileDead = true;
            selfSr.enabled = !selfSr.enabled;
            sr.enabled = !sr.enabled;
            bc.enabled = !bc.enabled;
        }
        ResetLevel();
    }

    void ResetLevel()
    {
      
        if (playerBehav.resetLevel)
        {
            if (tileDead)
            {
                selfSr.enabled = !selfSr.enabled;
                sr.enabled = !sr.enabled;
                bc.enabled = !bc.enabled;

                tileDead = false;
            }

            a = 0;
            g = 0.6415094f;
            strength = resetStrength;

            sr.color = new Color(1, 1, 1, a);
            selfSr.color = new Color(1, g, 0, 1);

        }
        playerBehav.reseted++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            standOn = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            standOn = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        standOn = false;
    }
}
