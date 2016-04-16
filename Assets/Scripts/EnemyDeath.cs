using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

    private bool isDying;
    private Color color;
    private Transform transform;
    private Renderer renderer;
    
    public Material deathMaterial;
    private int tick = 0;
    public AudioClip deathSound;
    private AudioSource audioSource;
    
    void Start() {
        renderer = GetComponent<Renderer>();
        transform = gameObject.transform;
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update() {
        if(isDying) {
            Color color = renderer.material.GetColor("_TintColor");
            
            if(color.a <= 0) {
                isDying = false;
                color.a = 0;
                
                FinallyDestroy();
                
                return;
            }
            
            switch (tick)
            {
                case 0:
                    gameObject.transform.position = transform.TransformPoint(0.1f,0,0);
                    break;
                    
                case 1:
                    gameObject.transform.position = transform.TransformPoint(0,0.1f,0);
                    break;
                    
                case 2:
                    gameObject.transform.position = transform.TransformPoint(-0.1f,0,0);
                    break;
                    
                case 3:
                    gameObject.transform.position = transform.TransformPoint(0,-0.1f,0);
                    break;
                    
                default:
                    tick = -1;
                    break;
            }
            
            tick++;
            
            color.a -= Time.deltaTime * 0.5f;
        
            renderer.material.SetColor("_TintColor",color);
        }
    }

	public IEnumerator Dying () {
        if (!isDying) {
            renderer.material = deathMaterial;
            audioSource.PlayOneShot(deathSound,1.0f);
            isDying = true;
        }
            
        yield return "Dying";
    }
    
    private void FinallyDestroy() {
        Destroy(gameObject);
    }
}
