using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TextHider : MonoBehaviour
{
    [SerializeField] private float timerDuration = 3f;
    public void OnEnable()
    {
        StartCoroutine(Timer());
    }
    private IEnumerator Timer(){
        yield return new WaitForSeconds(timerDuration);
        this.gameObject.SetActive(false);
    }
    
}
