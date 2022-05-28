using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cerberus : MonoBehaviour
{

    Animator anim;
    public Transform originalPos, restPos;
    public GameObject headCollider;
    public bool isResting;
    bool onceR, onceNR;

    int actions;
    bool actionsDone = true;
    int actionsLeft;
    public float timeBetweenAction;
    bool onceA;

    public bool inBiteRange;
    public int biteDamage = 20;

    public int health = 10000;

    public GameObject fireTarg;
    public bool isFiring;
    public GameObject projectile;
    GameObject localProjectile;

    public Transform[] enemies;
    public Transform particlesSpawn;
    public Transform spawnLoc;

    public bool isActive;

    public AudioSource bark, bark1, bark2, gruñido, biteSS, spell;

    public GameObject canvas;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        transform.position = originalPos.position;
        headCollider.SetActive(false);
        actionsLeft = 1;
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            canvas.SetActive(true);
        }


        if (actionsDone && isActive)
        {
            actions = Random.Range(0, 10);
            actionsLeft = Random.Range(3, 7);
            actionsDone = false;
        }


        if(actionsLeft > 0 && isActive)
        {
            if(actions == 0 || actions == 1 || actions == 2 || actions == 3)
            {
                if (!onceA)
                {
                    onceA = true;
                    anim.SetTrigger("biting");
                    StartCoroutine(timeBeforeAction());
                    bark.Play();
                }
            }
            if (actions == 4 || actions == 5 || actions == 6)
            {
                if (!onceA)
                {
                    onceA = true;
                    anim.SetTrigger("Fire");
                    StartCoroutine(timeBeforeAction());
                    bark1.Play();
                }
            }
            if (actions == 7 || actions == 8)
            {
                if (!onceA)
                {
                    onceA = true;
                    anim.SetTrigger("summon");
                    StartCoroutine(timeBeforeAction());
                    bark2.Play();
                }
            }
            if (actions == 9)
            {
                if (!onceA)
                {
                    onceA = true;
                    StartCoroutine(timeBeforeAction());
                    //gruñido.Play();
                }
            }
        }


        if(actionsLeft == 0)
        {
            isResting = true;
        }

        Debug.Log(actionsLeft);

        if (isResting)
        {
            if (!onceR)
            {
                
                onceR = true;
                onceNR = false;
                anim.SetBool("resting", true);
                transform.position = restPos.position;
                headCollider.SetActive(true);
                StartCoroutine(timeBeforeStopResting());
            }
        }
        else
        {

            if (!onceNR)
            {
                onceNR = true;
                anim.SetBool("resting", false);
                transform.position = originalPos.position;
                headCollider.SetActive(false);
            }


        }




        if (isFiring)
        {
            localProjectile.transform.Translate(Vector3.down * Time.deltaTime * 30);
        }



        if(isActive && GameObject.Find("Player").GetComponent<stats>().health <= 0)
        {
            if(GameObject.Find("BossStart") != null)
            {
                var scene = SceneManager.LoadSceneAsync(1);
                
            }
            else
            {
                SceneManager.LoadScene(1);
            }

            
        }

        if(health <= 0)
        {
            SceneManager.LoadScene(1);
        }


        if(GameObject.Find("Player").GetComponent<stats>().health <= 0)
        {

            StartCoroutine(waitForRestart());

        }



    }


    IEnumerator timeBeforeAction()
    {
        yield return new WaitForSeconds(timeBetweenAction);
        actionsLeft -= 1;
        actions = Random.Range(0, 10);
        onceA = false;
    }

    IEnumerator timeBeforeStopResting()
    {
        yield return new WaitForSeconds(timeBetweenAction + 8);
        onceR = false;
        isResting = false;
        actionsDone = true;
    }


    public void bite()
    {
        if (inBiteRange)
        {
            GameObject.Find("Player").GetComponent<stats>().health -= biteDamage;
        }
    }


    public void fire()
    {
        Vector3 pos = GameObject.Find("fireTarget").transform.position;
        Vector3 pos2 = pos + new Vector3(0, 20, 0);
        GameObject fireTP = Instantiate(fireTarg, pos, Quaternion.identity);
        localProjectile = Instantiate(projectile, pos2, Quaternion.identity);
        StartCoroutine(waitForInpact());
    }


    IEnumerator waitForInpact()
    {
        yield return new WaitForSeconds(.2f);
        isFiring = true;
        
    }


    public void spawnE()
    {
        Instantiate(particlesSpawn, spawnLoc.transform.position, spawnLoc.rotation);
        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnLoc.transform.position, spawnLoc.rotation);
    }

    public void fixB()
    {
        Debug.Log("lol");
    }


    public void gruñir()
    {
        if (isActive)
        {
            gruñido.Play();
        }
    }

    IEnumerator waitForRestart()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }


    public void biteSSS()
    {
        biteSS.Play();
    }

    public void spellS()
    {
        spell.Play();
    }

}
