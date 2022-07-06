
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour{
    private Vector2 _direction = Vector2.right;
    private List<Transform> segments = new List<Transform>();
    public Transform SegmentPrefab;
    public int initialsize = 3;
    public int score;
    public LoadNextSceneScript nextScene;
    public Score hscore;
    public Text sctext;

    private void Start(){
        sctext.text = score.ToString();
        Reset();
    }
    private void Update(){
        //Input keys to control snake
        if (Input.GetKeyDown(KeyCode.W)){
            _direction = Vector2.up;
        }else if (Input.GetKeyDown(KeyCode.S)){
            _direction = Vector2.down;
        }else if (Input.GetKeyDown(KeyCode.A)){
            _direction = Vector2.left;
        }else if (Input.GetKeyDown(KeyCode.D)){
            _direction = Vector2.right;
        }
    }
    private void FixedUpdate(){
        for(int i = segments.Count - 1; i > 0; i--){//initializes the position of tail of the snake
            segments[i].position = segments[i - 1].position;//the tail will move to the position of the next segment
        }
        
        //continously updates the position of the snake at fixed times after the tail moves
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
           Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
            );
    }

    private void Grow(){
        //Grow function will create an snake segment and set the new spawn position just behind the snake
        Transform segment=Instantiate(this.SegmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
       score++;
    }

    private void Reset(){
        //segments are destroyed and are cleared
        for (int i = 1; i < segments.Count; i++){
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(this.transform);
        //segments are added in the beginning of a game
        for (int i = 1; i < this.initialsize; i++){
            segments.Add(Instantiate(this.SegmentPrefab));
        }
        //resets snake position to zero
        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Food"){
            Grow();
            
        }
        else if (collision.tag == "Obstacle"){
            nextScene.LoadNextScene(Score.sto);
        }
    }
}


