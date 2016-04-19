using UnityEngine;
using System.Collections;

public class StartButtonAnimation : MonoBehaviour {

 protected Animator animator;
 
    void Awake ()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    
    void OnEnable () 
    {
        Debug.Log("I'm Wide Awake !");
        
        if(animator)
        {
            Debug.Log("And So Are You !");
            animator.SetBool("Awake", true );
        }       
    }
    
    void OnDisable () 
    {
		if(animator && gameObject.activeInHierarchy)
        {
            animator.SetBool("Awake", false );
        }       
    }      
}
