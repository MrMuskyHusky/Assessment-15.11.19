using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public enum AIState
    {
        Patrol,
        Seek,
        Attack,
        Die
    }
    public AIState state;
    public float curHealth, maxHealth, moveSpeed, attackRange, attackSpeed, sightRange, baseDamage;
    public int curWaypoint, difficulty;
    public bool isDead;

    [Space(5), Header("Base References")]
    public GameObject self;
    public Transform player;
    public Transform waypointParent;
    protected Transform[] waypoints;
    public NavMeshAgent agent;
    public GameObject healthCanvas;
    public Image healthBar;
    public Animator anim;

    public void Start()
    {
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        agent = self.GetComponent<NavMeshAgent>();
        curWaypoint = 1;
        agent.speed = moveSpeed;
        anim = self.GetComponent<Animator>();
        Patrol();
    }
    private void Update()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
        anim.SetBool("Attack", false);

        Patrol();
        Seek();
        Attack();
        Die();
    }

    void LateUpdate()
    {
        if (healthBar.fillAmount < 1 && healthBar.fillAmount > 0)
        {
            healthCanvas.SetActive(true);
            healthCanvas.transform.LookAt(Camera.main.transform);
            healthCanvas.transform.Rotate(0, 180, 0);
        }
        else if (healthCanvas.activeSelf == true)
        {
            healthCanvas.SetActive(false);
        }
    }

    public void Patrol()
    {
        // DO NOT CONTINUE IF NO WAYPOINTS
        if (waypoints.Length == 0 || Vector3.Distance(player.position, self.transform.position) <= sightRange)
        {
            return;
        }
        anim.SetBool("Walk", true);
        // Follow waypoints
        // Set agent to target
        agent.destination = waypoints[curWaypoint].position;
        // Are we at the waypoint?
        if (self.transform.position.x.Equals(agent.destination.x) && self.transform.position.z == agent.destination.z)
        {
            if (curWaypoint < waypoints.Length - 1)
            {
                // If so go to next waypoint
                curWaypoint++;
            }
            else
            {
                // If at the end of patrol go to start
                curWaypoint = 1;
            }
        }
        // If so go to next waypoint
    }
    public void Seek()
    {

        if (Vector3.Distance(player.position, self.transform.position) > sightRange || Vector3.Distance(player.position, self.transform.position) < attackRange)
        {
            // Stop seeking
            return;
        }
        state = AIState.Seek;
        anim.SetBool("Run", true);
        // If player in sight range and not attack range then chase
        agent.destination = player.position;
    }
    public virtual void Attack()
    {
        if (Vector3.Distance(player.position, self.transform.position) > attackRange || curHealth < 0 || player.GetComponent<PlayerHandler>().curHealth < 0)
        {
            return;
        }
        state = AIState.Attack;
        anim.SetBool("Attack", true);

        Debug.Log("Attack");
        // If player in attack range then attack
    }
    public void Die()
    {
        // If we are alive
        if (curHealth > 0)
        {
            // Don't run this
            return;
        }
        // else we are dead so run this
        state = AIState.Die;
        if(!isDead)
        anim.SetTrigger("Die");
        isDead = true;
        agent.destination = self.transform.position;
        // Drop Loot
    }
}
