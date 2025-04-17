using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float levelLoadeDelay = 2f;
    [SerializeField] private AudioClip successAudio;
    [SerializeField] private AudioClip crashedAudio;
    [SerializeField] private ParticleSystem successParticles;
    [SerializeField] private ParticleSystem crashedParticles;

    private AudioSource audioSource;
    private Movement getMovement;

    private bool isControllable = true;
    private bool iscollidable = true;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        getMovement = GetComponent<Movement>();
    }

    private void Update()
    {
        RespondToDebugKeys();

    }

    void RespondToDebugKeys()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadNextLevel();
        }
        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            iscollidable = !iscollidable;
            crashedParticles.Play();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isControllable || !iscollidable){return;}
        
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Everything lookin gud");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("Not exists");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successAudio);
        successParticles.Play();
        getMovement.enabled = false;
        Invoke("LoadNextLevel", levelLoadeDelay);
    }
    void StartCrashSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crashedAudio);
        crashedParticles.Play();
        getMovement.enabled = false;
        Invoke("ReloadLevel", levelLoadeDelay);
    }
    
    void SceneFunc(int lvlholder, bool NextLvl)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + lvlholder);
        if (NextLvl == true )
        {
            int nextScene = currentScene + 1;

            if (nextScene == SceneManager.sceneCountInBuildSettings)
            {
                nextScene = 0;
            }
            SceneManager.LoadScene(nextScene);
        }
    }
        
    void LoadNextLevel()
    {
        SceneFunc(1, true);
    }
        
    void ReloadLevel()
    {
        SceneFunc(0,false);
    }
}
