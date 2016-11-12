using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameFlow : MonoBehaviour {

    public Animator curtain;

    public GameObject[] puppetBodies;
    public Vector3 puppetLocation = Vector3.zero;

    public float titleScreenDuration = 5f;
    public GameObject decoPuppetCreation;
    public Interview interview;
    public GameObject decoPuppetToySequence;
    public float toySequenceDuration;
    public GameObject decoPuppetRecordSequence;
    public float recordSequenceDuration;
    public GameObject decoPuppetPlaySequence;
    public float playSequenceDuration;



    public InputRecoder recorder;
    private GameObject _activePuppet;
    private InputRecoder _activeRecorder;
    private GameObject _sceneContent;

    public float ghostScale = 0.2f;
    private List<GameObject> _ghosts;
    public int maxGhostCount = 5;
    private int _ghostCount = 0;
    public Vector3 ghostPositionStart = Vector3.zero;
    public Vector3 ghostPositionEnd = Vector3.zero;

    IEnumerator Start()
    {
        _ghosts = new List<GameObject>();
        while (true)
        {
            yield return Flow();
        }
    }

    IEnumerator Flow()
    {
        
        CreateCreature();
        // Interview
        _sceneContent = Instantiate(decoPuppetCreation, Vector3.zero, Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(titleScreenDuration);
        yield return PlayAnimation(curtain, "open", 4);
        yield return WaitForEndOfInterview();

        // Toy
        yield return Curtain(decoPuppetPlaySequence);
        yield return new WaitForSeconds(toySequenceDuration);
        // Record
        yield return Curtain(decoPuppetRecordSequence);
        _activeRecorder.Record();
        yield return new WaitForSeconds(recordSequenceDuration);
        _activeRecorder.Stop();
        // Play
        yield return Curtain(decoPuppetCreation);
        _activeRecorder.Play();
        yield return new WaitForSeconds(playSequenceDuration);
        //EndGame
        yield return PlayAnimation(curtain, "close", 3);
        CreateGhost();
        Destroy(_sceneContent);
    }

    IEnumerator Curtain(GameObject deco)
    {
        _activeRecorder.Force(Vector2.zero);
        yield return PlayAnimation(curtain, "open", 3);
        Destroy(_sceneContent);
        _sceneContent = Instantiate(deco, Vector3.zero, Quaternion.identity) as GameObject;
        yield return PlayAnimation(curtain, "close", 4);
        _activeRecorder.Stop();
    }

    IEnumerator PlayAnimation(Animator animator, string anim, float time)
    {
        animator.Play(anim);
        yield return new WaitForSeconds(time);
    }

    IEnumerator WaitForEndOfInterview()
    {
        while (!interview.isCompleted())
        {
            yield return null;
        }
    }

    void CreateCreature()
    {
        GameObject prefab = puppetBodies[Random.Range(0, puppetBodies.Length)];
        GameObject go = Instantiate(prefab, puppetLocation, Quaternion.identity) as GameObject ;
        Transform body = go.transform.GetChild(1).GetChild(0);

        interview.m_PuppetController = go.GetComponentInChildren<PuppetController>();
        interview.m_BodyTransform = body;
        interview.Reset();

        _activePuppet = go;
        _activeRecorder = go.GetComponentInChildren<InputRecoder>();

    }

    void CreateGhost()
    {
        Transform t = _activePuppet.transform;
        t.localScale = Vector3.one * ghostScale;
        if(_ghostCount>=maxGhostCount)
        {
            Destroy(_ghosts[_ghostCount % maxGhostCount]);
            _ghosts[_ghostCount % maxGhostCount] = _activePuppet;
        } else
        {
            _ghosts.Add(_activePuppet);
        }
        _activePuppet.GetComponentInChildren<PuppetController>().playSound = false;
        Vector3 position = Vector3.Lerp(ghostPositionStart, ghostPositionEnd, (float)(_ghostCount % maxGhostCount) / (maxGhostCount - 1));
        _activeRecorder.PlayLoop();
        _ghostCount++;
        t.position = position;
        foreach (AudioSource audio in _activePuppet.GetComponentsInChildren<AudioSource>())
        {
            audio.Stop();
        }
    }
}
