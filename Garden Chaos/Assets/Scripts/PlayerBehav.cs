using UnityEngine;
using UnityEngine.UI;

public class PlayerBehav : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float waterdropValue;
    [SerializeField] private float maxWater;
    [SerializeField] private ParticleSystem waterSplash;
    [SerializeField] private AudioSource raindropSound;
    [SerializeField] private AudioSource icestoneSound;
    [SerializeField] private int damageLevel;
    [SerializeField] private Sprite[] health;
    [SerializeField] private GameObject restartPanel;
    [SerializeField] private Button pauseMenuBtn;
    [SerializeField] private GameObject petal;
    [SerializeField] private Transform petalSpawn;
    [SerializeField] private GameObject groundLevel;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D pointLight;
    public CameraMovement cameraMovement;
    public float water;
    public Slider waterSlider;
    public int levelCounter;
    public bool resetLevel;
    public int reseted;

    [SerializeField] private Transform spawnPoint;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        maxWater = waterSlider.maxValue;
        damageLevel = 0;

    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("c"))
        {
            PlayerDead();
        }

        waterSlider.value = water;
        petalSpawn = transform;

        if (water >= 0)
        {
            water -= Time.deltaTime * 3;

        } else
        {
            water = 0;
        }

        if (water <= 5)
        {
            if (playerController.speed > playerController.minSpeed)
            {
                playerController.speed -= Time.deltaTime;
            }
        } else if (water >= 60)
        {
            if (playerController.speed < playerController.maxSpeed)
            {
                playerController.speed += Time.deltaTime;
            }
        }

        if (reseted >= 9)
        {
            resetLevel = false;
            reseted = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.tag == "Bug")
        {
            if(playerController.speed > 10)
            {
                playerController.speed -= 2;

            }
        }

        if (collision.collider.tag == "Ice")
        {
            damageLevel++;
            GetComponent<SpriteRenderer>().sprite = health[damageLevel];
            Instantiate(petal, petalSpawn.position, Quaternion.identity);

            icestoneSound.Play();

            if (damageLevel + 1 == health.Length)
            {
                PlayerDead();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "NextLevel")
        {
            cameraMovement.moveToTheNextPos = true;
            Destroy(groundLevel);
            PlayerStats.playerLevel = 1f;
            PlayerStats.playerPoints += 1;

        } else if (collision.tag == "NextLoopLevel")
        {

            transform.position = new Vector3(transform.position.x, spawnPoint.position.y, spawnPoint.position.z);

            if(pointLight.intensity > 0.2f)
            {
                pointLight.intensity -= 0.1f;
            }

            resetLevel = true;
            PlayerStats.playerLevel += 1f;
            PlayerStats.playerPoints += 1;

        }

        if (collision.tag == "Raindrop")
        {
            if (!waterSplash.isPlaying)
            {
                waterSplash.Play();
            }

            raindropSound.Play();

            PlayerStats.playerPoints += 1;

            if (water + waterdropValue > maxWater)
            {
                water = 100;
            }
            else
            {
                water += waterdropValue;

            }
        }
    }

    void PlayerDead()
    {
        if(PlayerStats.highScoreArrIndex < 4)
        {
            PlayerStats.scores[PlayerStats.highScoreArrIndex] = PlayerStats.playerPoints;
            PlayerStats.highScoreArrIndex++;

        } else
        {        
            int minPos = 0;

            for (int i = 1; i < PlayerStats.scores.Length; i++)
            {
                if(PlayerStats.scores[minPos] > PlayerStats.scores[i])
                {
                    minPos = i;

                }
            }
                if(PlayerStats.playerPoints > PlayerStats.scores[minPos])
            {
                PlayerStats.scores[minPos] = PlayerStats.playerPoints;

            }

            Debug.Log("Kicseréltem " + PlayerStats.scores[minPos] + "-et " + PlayerStats.playerPoints + "-ra");
        }

        PlayerStats.playerLevel = 0;
        PlayerStats.playerPoints = 0;
        Time.timeScale = 0;
        restartPanel.SetActive(true);
        pauseMenuBtn.interactable = false;
    }
}