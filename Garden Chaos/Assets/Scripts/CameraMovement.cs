using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform nextCameraPos;
    [SerializeField] private GameObject caveLight;
    [SerializeField] private AudioSource slowTrack;
    [SerializeField] private AudioSource fastTrack;
    [SerializeField] private bool musicChanged;
    public bool moveToTheNextPos;

    void Update()
    {
        if(PlayerStats.playerLevel > 0 && !musicChanged)
        {
            SwitchMusic();
        }

        if (moveToTheNextPos)
        {
            transform.position = new Vector3(nextCameraPos.position.x, nextCameraPos.position.y, nextCameraPos.position.z);
            caveLight.SetActive(true);
        }
    }

    void SwitchMusic()
    {
        if (slowTrack.isPlaying)
        {
            slowTrack.Stop();
        }

        if (!fastTrack.isPlaying)
        {
            fastTrack.Play();
        }
    }
}