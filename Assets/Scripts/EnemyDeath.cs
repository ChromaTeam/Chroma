using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

    private bool isDying;
    private Color color;
    private Transform enemyTransform;
    private Renderer enemyRenderer;
    
    public Material deathMaterial;
    private int tick = 0;
    public AudioClip deathSound;
    private AudioSource audioSource;
    
    void Start() {
		enemyRenderer = GetComponent<SpriteRenderer>();
		enemyTransform = gameObject.transform;
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update() {
        if(isDying) {
			Color color = enemyRenderer.material.GetColor("_TintColor");
            
            if(color.a <= 0) {
                isDying = false;
                color.a = 0;
                
                FinallyDestroy();
                
                return;
            }
            
            switch (tick)
            {
                case 0:
                    gameObject.transform.position = enemyTransform.TransformPoint(0.1f,0,0);
                break;
                    
                case 1:
					gameObject.transform.position = enemyTransform.TransformPoint(0,0.1f,0);
                break;
                    
                case 2:
					gameObject.transform.position = enemyTransform.TransformPoint(-0.1f,0,0);
                break;
                    
                case 3:
					gameObject.transform.position = enemyTransform.TransformPoint(0,-0.1f,0);
                break;
                    
                default:
                    tick = -1;
                    break;
            }
            
            tick++;
            
            color.a -= Time.deltaTime * 0.5f;
        
			enemyRenderer.material.SetColor("_TintColor",color);
        }
    }

	public IEnumerator Dying () {
        if (!isDying) {
			enemyRenderer.material = deathMaterial;
            audioSource.PlayOneShot(deathSound,1.0f);
            isDying = true;
        }
            
        yield return "Dying";
    }
    
    private void FinallyDestroy() {
        Destroy(gameObject);
    }
}
