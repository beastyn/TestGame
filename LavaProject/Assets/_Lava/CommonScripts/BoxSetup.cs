using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//генерим коробку для игры
public class BoxSetup : MonoBehaviour {

    [SerializeField] Camera mainCamera;
    [SerializeField] Transform player;
    [SerializeField] Material boxMaterialHorizontal;
    [SerializeField] Material boxMaterialVertical;
    GameObject topBoxWall;
    GameObject bottomBoxWall;
    GameObject leftBoxWall;
    GameObject rightBoxWall;


    void Start () {
        
        // обозначаем размеры экрана в мировых единицах
        Vector3 horizontalWallWidthPoint = new Vector3(Screen.width * 2f, 0f, 0f);
        Vector3 horizontalWallCenterYPoint = new Vector3(0f, Screen.height, 0f);
        Vector3 verticalWallHeightPoint = new Vector3(0f,Screen.height * 2f, 0f);
        Vector3 verticalWallCenterYPoint = new Vector3(Screen.width, 0f, 0f);

        //генерим кубики
        topBoxWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        topBoxWall.transform.position = new Vector3(0f, mainCamera.ScreenToWorldPoint(horizontalWallCenterYPoint).y + 0.5f, 0f);
        topBoxWall.transform.localScale = new Vector3(mainCamera.ScreenToWorldPoint(horizontalWallWidthPoint).x, 1f, 1f);
        topBoxWall.transform.parent = this.transform;
        Renderer rendTop = topBoxWall.GetComponent<Renderer>();
        rendTop.material = boxMaterialHorizontal;

        bottomBoxWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bottomBoxWall.transform.position = new Vector3(0f, mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y + 1f, 0f);
        bottomBoxWall.transform.localScale = new Vector3(mainCamera.ScreenToWorldPoint(horizontalWallWidthPoint).x, 2f, 1f);
        bottomBoxWall.transform.parent = this.transform;
        bottomBoxWall.transform.parent = this.transform;
        Renderer rendBot = bottomBoxWall.GetComponent<Renderer>();
        rendBot.material = boxMaterialHorizontal;

        leftBoxWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftBoxWall.transform.position = new Vector3(mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x, 0f, 0f);
        leftBoxWall.transform.localScale = new Vector3(1f, mainCamera.ScreenToWorldPoint(verticalWallHeightPoint).y, 1f);
        leftBoxWall.transform.parent = this.transform;
        leftBoxWall.transform.parent = this.transform;
        Renderer rendLeft = leftBoxWall.GetComponent<Renderer>();
        rendLeft.material = boxMaterialVertical;

        rightBoxWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightBoxWall.transform.position = new Vector3(mainCamera.ScreenToWorldPoint(verticalWallCenterYPoint).x, 0f, 0f);
        rightBoxWall.transform.localScale = new Vector3(1f, mainCamera.ScreenToWorldPoint(verticalWallHeightPoint).y, 1f);
        rightBoxWall.transform.parent = this.transform;
        rightBoxWall.transform.parent = this.transform;
        Renderer rendRight = rightBoxWall.GetComponent<Renderer>();
        rendRight.material = boxMaterialVertical;


        //Помещаем игрока в уентре на нижнем кубе.
        player.position = new Vector3 (0f, bottomBoxWall.transform.position.y + 1.25f, 0f);
        
        //TODO mske it flexible in editor
        
    }
	
}
