
using UnityEngine;

public class PlayerSoundEffect : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] Player player;
    [SerializeField] Weapon weapon;

    [SerializeField] AudioClip playerAttack;
    [SerializeField] AudioClip playerReload;
    [SerializeField] AudioClip playerDash;
     [SerializeField] AudioClip playerSkill;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        weapon.onShoot += PlayShootSound;
        weapon.onReloadStart += PlayReloadSound;
        player.onDash += PlayDashSound;

        player.onPlayerSkill1+=PlaySkillSound;
        player.onPlayerSkill2+=PlaySkillSound;
    }

    private void OnDisable()
    {
        weapon.onShoot -= PlayShootSound;
        weapon.onReloadStart -= PlayReloadSound;
        player.onDash -= PlayDashSound;

        player.onPlayerSkill1-=PlaySkillSound;
        player.onPlayerSkill2-=PlaySkillSound;
    }

    private void PlaySkillSound()
    {
        audioSource.clip = playerSkill;
        audioSource.Play();
    }

    private void PlayDashSound()
    {
        audioSource.clip = playerDash;
        audioSource.Play();
    }

    private void PlayReloadSound()
    {
        audioSource.clip = playerReload;
        audioSource.Play();
    }

    private void PlayShootSound()
    {
        audioSource.clip = playerAttack;
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.Play();
    }
}
