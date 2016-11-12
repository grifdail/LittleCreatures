using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameFlow : MonoBehaviour {

    public Animator curtain;

    public GameObject[] puppetBodies;
    public Vector3 puppetLocation = Vector3.zero;

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
        yield return PlayAnimation(curtain, "Opening", 4);
        _sceneContent = Instantiate(decoPuppetCreation, Vector3.zero, Quaternion.identity) as GameObject;
        yield return WaitForEndOfInterview();
        yield return PlayAnimation(curtain, "Closing", 3);
        Destroy(_sceneContent);
        _sceneContent = Instantiate(decoPuppetToySequence, Vector3.zero, Quaternion.identity) as GameObject;
        yield return PlayAnimation(curtain, "Opening", 4);
        yield return new WaitForSeconds(toySequenceDuration);
        yield return PlayAnimation(curtain, "Closing", 3);
        Destroy(_sceneContent);
        _sceneContent = Instantiate(decoPuppetRecordSequence, Vector3.zero, Quaternion.identity) as GameObject;
        yield return PlayAnimation(curtain, "Opening", 4);
        _activeRecorder.Record();
        yield return new WaitForSeconds(recordSequenceDuration);
        _activeRecorder.Stop();
        yield return PlayAnimation(curtain, "Closing", 3);
        Destroy(_sceneContent);
        _sceneContent = Instantiate(decoPuppetRecordSequence, Vector3.zero, Quaternion.identity) as GameObject;
        yield return PlayAnimation(curtain, "Opening", 4);
        _activeRecorder.Play();
        yield return new WaitForSeconds(playSequenceDuration);
        yield return PlayAnimation(curtain, "Closing", 3);
        backUpPuppet();
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
        Transform controller = go.transform.GetChild(0);
        Transform body = go.transform.GetChild(1).GetChild(0);
        Transform recorder = go.transform.GetChild(2);

        interview.m_PuppetController = controller.GetComponent<PuppetController>();
        interview.m_BodyTransform = body;
        interview.Reset();

        _activePuppet = go;
        _activeRecorder = recorder.GetComponent<InputRecoder>();

    }

    void backUpPuppet()
    {
        Transform t = _activePuppet.transform;
        t.localScale = Vector3.one * ghostScale;
        if(_ghostCount>=maxGhostCount)
        {
            Debug.Log("taaaaaaaest"+ _ghostCount);
            Destroy(_ghosts[_ghostCount % maxGhostCount]);
            _ghosts[_ghostCount % maxGhostCount] = _activePuppet;
        } else
        {
            Debug.Log("test");
            _ghosts.Add(_activePuppet);
        }
        Vector3 position = Vector3.Lerp(ghostPositionStart, ghostPositionEnd, (float)(_ghostCount % maxGhostCount) / maxGhostCount);
        _activeRecorder.PlayLoop();
        _ghostCount++;
        t.position = position;
    }
}
