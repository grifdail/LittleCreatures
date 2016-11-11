using UnityEngine;
using System.Collections;

public class GameFlow : MonoBehaviour {

    public Animator curtain;

    public GameObject decoPuppetCreation;
    public Interview interview;
    public GameObject decoPuppetToySequence;
    public float toySequenceDuration;
    public GameObject decoPuppetRecordSequence;
    public float recordSequenceDuration;
    public GameObject decoPuppetPlaySequence;
    public float playSequenceDuration;

    public InputRecoder recorder;

    private GameObject _sceneContent;


	IEnumerator Start()
    {
        
        yield return Flow();
    }

    IEnumerator Flow()
    {
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
        recorder.Record();
        yield return new WaitForSeconds(recordSequenceDuration);
        recorder.Stop();
        yield return PlayAnimation(curtain, "Closing", 3);
        Destroy(_sceneContent);
        _sceneContent = Instantiate(decoPuppetRecordSequence, Vector3.zero, Quaternion.identity) as GameObject;
        yield return PlayAnimation(curtain, "Opening", 4);
        recorder.Play();
        yield return new WaitForSeconds(playSequenceDuration);
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
}
