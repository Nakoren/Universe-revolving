using System;
using UnityEngine;

public class EnemySoundEffect : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] Enemy enemy;


    [SerializeField] AudioClip enemyAttack;
    [SerializeField] AudioClip enemyGetDamage;
    [SerializeField] AudioClip enemyDead;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        enemy.onEnemyGetDamage+=PlayGetDamageSound;
        enemy.onEnemyDeath+=PlayDeathSound;
        enemy.onEnemyAttack+=PlayAttackSound;
    }
    private void OnDisable()
    {
        enemy.onEnemyGetDamage-=PlayGetDamageSound;
        enemy.onEnemyDeath-=PlayDeathSound;
        enemy.onEnemyAttack-=PlayAttackSound;
    }

    private void PlayAttackSound(Enemy enemy)
    {
        audioSource.clip = enemyAttack;
        audioSource.Play();
    }

    private void PlayDeathSound(Enemy enemy)
    {
        audioSource.clip = enemyDead;
        audioSource.Play();
    }

    private void PlayGetDamageSound(Enemy enemy)
    {
        audioSource.clip = enemyGetDamage;
        audioSource.Play();
    }

    
}
