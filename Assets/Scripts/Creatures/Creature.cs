
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public Nest nest;
    [SerializeField] private float maxNestDistance=15f;
    [SerializeField] private float cooldownActions=5f;
    [Header("Agressive")]
    [SerializeField] private bool agressive;
    [SerializeField] private string[] targetTags={"Player"};
    [SerializeField] private float detectionRadius=5f;
    private bool acting=true;

    private Actions action = Actions.Idle;
    private bool returning = false;

    private enum Actions
    {
       Idle,
       Moving,
       Spining,
       Chasing
    }
    
    private Movement movement;
    private Spin spin;
    private Damage damage;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        spin = GetComponent<Spin>();
        damage = GetComponentInChildren<Damage>();
    }
    private void Start()
    {
        StartCoroutine(RunStatesCoroutine());
        if (agressive)
        {
            damage.enabled=true;
        }
    }
    private void Update()
    {
        float nestDistance = Vector2.Distance(transform.position, nest.transform.position);
        if (nestDistance>=maxNestDistance && !returning)
        {
            action=Actions.Moving;
            MoveRandom();
            StartCoroutine(ReturnHomeCoroutine(3f));
            return;
        }

        if (!agressive) return;
        Chase();
    }

    private void MoveRandom()
    {
        Vector2 nestPosition = nest.transform.position;
        Vector2 randomOffset = UnityEngine.Random.insideUnitCircle * maxNestDistance/2;
        Vector2 positionToGo = nestPosition + randomOffset;
        movement.MoveTo(positionToGo);
    }
    private void StartSpin()
    {
        StartCoroutine(SpinCoroutine(5));
    }
    private IEnumerator SpinCoroutine(float seconds)
    {
        spin.SetSpin(true);
        yield return new WaitForSeconds(seconds);
        spin.SetSpin(false);
    }

    private IEnumerator RunStatesCoroutine()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(0f,2f));
        while (acting)
        {
            if (returning)
            {
                yield return null;
                continue;
            }
            if (action==Actions.Chasing)
            {
                yield return null;
                continue;
            }

            yield return new WaitForSeconds(cooldownActions);
            action = RandomAction(new Actions[]{Actions.Chasing,Actions.Idle});
            switch (action)
            {
                case Actions.Moving:
                    MoveRandom();
                break;
                case Actions.Spining:
                    StartSpin();
                break;
            }
        }

    }

    private Actions RandomAction(Actions[] exclude =null)
    {
        List<Actions> values = new List<Actions>((Actions[])Enum.GetValues(typeof(Actions)));
        if (exclude!=null)
        {
            foreach (Actions action in exclude)
                values.Remove(action);
        }
        return values[UnityEngine.Random.Range(0,values.Count)];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            action = Actions.Moving;
            MoveRandom();
        }
    }

    private IEnumerator ReturnHomeCoroutine(float returnSeconds)
    {
        returning=true;
        yield return new WaitForSeconds(returnSeconds);
        returning=false;
    }

    private (Transform nearest,float nearestDistance) FindNearestTarget()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius*2);
        
        Transform nearest = null;
        float nearestDistance = Mathf.Infinity;
        
        foreach (Collider2D hit in hits)
        {
            if (!IsValidTarget(hit,targetTags)) continue;
            
            float distance = Vector2.Distance(transform.position, hit.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearest = hit.transform;
            }
        }
        
        return (nearest,nearestDistance); // null se não achou ninguém
    }

    private bool IsValidTarget(Collider2D collider,string[] targetTags)
    {
        foreach (string tag in targetTags)
        {
            if (collider.CompareTag(tag)) return true;
        }
        return false;
    }

    private void Chase()
    {
        if (returning) return;
        
        (Transform target,float targetDistance) = FindNearestTarget();
        if (target==null) return;

        if (targetDistance<=detectionRadius)
        {
            action=Actions.Chasing;
            movement.MoveTo(target.position);  
        } else
        {
            action = Actions.Idle;
        }

    }

}
