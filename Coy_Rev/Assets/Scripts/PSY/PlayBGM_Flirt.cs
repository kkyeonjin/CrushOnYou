using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBGM_Flirt : MonoBehaviour
{
    private AudioSource Audio;
    public static PlayBGM_Flirt FlirtBGM;
    [SerializeField] private AudioClip[] clip;

    void Awake(){
        
        if(FlirtBGM == null) FlirtBGM = this;

        else if (FlirtBGM != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        Audio = GetComponent<AudioSource>();
        
    }

    void Update(){

        int turn = DataController.Instance.gameData.turn;

        if(SceneManager.GetActiveScene().name == "PlaceScene_PSY" || SceneManager.GetActiveScene().name == "TalkScene0_PSY" || SceneManager.GetActiveScene().name == "TalkScene1_PSY"){
           //아무것도.. 
        }
        else{ //현재 씬이 장소 선택씬이나 대화씬이 아니면 브금 중지
            Debug.Log("파괴");
            Destroy(gameObject);
        }
        if(Audio.isPlaying){ //현재 브금이 플레이중인데 턴수에 맞지 않는 브금이면 브금 변경
            if(turn >= 5 && turn <10 && Audio.clip != clip[1]){
                PlayBgm();
            }
            else if(turn >= 10 && Audio.clip != clip[2]){
                PlayBgm();
            }
        }
        else PlayBgm(); //브금 안나오고 있으면 브금 재생


    }

    public void PlayBgm(){ //턴수에 맞는 브금 재생

        if(DataController.Instance.gameData.turn < 5){
            Audio.clip = clip[0];
            Audio.Play();
        }
        else if(DataController.Instance.gameData.turn < 10){
            Audio.clip = clip[1];
            Audio.Play();
        }
        else{
            Audio.clip = clip[2];
            Audio.Play();
        }
    }

}
