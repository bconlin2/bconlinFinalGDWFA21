using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCollision : MonoBehaviour
{
    #region REFERENCES
    [SerializeField]
    internal PlayerController playerController;

    
    #endregion

    #region PROPERTIES
    internal MeshRenderer meshRenderer;
    #endregion

    void Awake()
    {
        playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // defeat
        if (other.gameObject.tag == "Bad")
        {
            // disable player visibility
            meshRenderer.enabled = false;
            SoundManager.PlaySFX("sizzle");
            playerController.defeat = true;
        }

        // progress
        if(other.gameObject.tag == "Good")
        {
            if (other.gameObject.activeSelf)
            {
                other.gameObject.SetActive(false);
                SoundManager.PlaySFX("horn");
                playerController.gameController.progress++;
            }
        }
    }

    void ScaleUp(float target, float rate)
    {
        Vector3 currScale = transform.localScale;
        Vector3 targetScale = new Vector3(target, target, target);
        
        // only scaling uniform
        if(currScale.x < targetScale.x)
        {
          currScale += new Vector3(rate, rate, rate);
          transform.localScale = currScale;
        }
    }

    void ScaleDown(float target, float rate)
    {
        Vector3 currScale = transform.localScale;
        Vector3 targetScale = new Vector3(target, target, target);

        // only scaling uniform
        while(currScale.x > targetScale.x)
        {
           
            currScale -= new Vector3(rate, rate, rate)*Time.deltaTime*0.002f;
            if(currScale.x < 0)
             {
                currScale = Vector3.zero;
             }
             transform.localScale = currScale;
        }

    }
}
