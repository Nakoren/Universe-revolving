using System;
using UnityEngine;
using System.Collections;

public class HP_Recover_Effect : MonoBehaviour
{
    private ParticleSystem m_particleSystem;
    [SerializeField] private Health m_health;
    private void Awake()
    {
        m_particleSystem = GetComponent<ParticleSystem>();
        m_particleSystem.Stop();
    }

    private void OnEnable()
    {
        m_health.onAgentRestoreHealth+=OnHP_ParticleSystem;
    }

      private void OnDisable()
    {
        m_health.onAgentRestoreHealth -= OnHP_ParticleSystem;
    }

    private void OnHP_ParticleSystem()
    {
        m_particleSystem.Play();
        StartCoroutine(StopParticleAfterDelay(1f)); 
    }

    private IEnumerator StopParticleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        m_particleSystem.Stop();
    }

  

}
