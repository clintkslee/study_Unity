using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySample : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject; //대상이 될 오브젝트 지정

    private void Awake()
    {
        //플레이어 오브젝트의 PlayerController 컴포넌트 삭제      
        //Destroy(playerObject.GetComponent<PlayerController>());

        //실제 개발 시에는 컴포넌트 삭제보다는 컴포넌트 비활성화를 권장 
        //playerObject.GetComponent<PlayerController>().enabled = false;

        // 플레이어 오브젝트 삭제
        //Destroy(playerObject);

        //Destroy(GameObject, time); 게임 오브젝트를 time 시간만큼 흐른 후 삭제 (time은 실수 초)
        //2초 후 플레이어 오브젝트 삭제
        //Destroy(playerObject, 2.0f);
    }
}
