using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trajectory : MonoBehaviour
{
    private Scene _simulationScene;
    private PhysicsScene2D _physicsScene;

    [SerializeField] private Transform _obstaclesParent;

    // Start is called before the first frame update
    void Start()
    {
        CreatePhysicsScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SimluateTrajector(KnifeSpawner spawner, Vector2 shotPoint, Vector2 velocity)
    {
        var ghostObj = Instantiate(spawner, shotPoint, Quaternion.identity);
        ghostObj.GetComponent<Renderer>().enabled = false;
        SceneManager.MoveGameObjectToScene(ghostObj.gameObject, _simulationScene);

        ghostObj.Throw();
    }

    void CreatePhysicsScene()
    {
        _simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics2D));
        _physicsScene = _simulationScene.GetPhysicsScene2D();

        foreach (Transform obj in _obstaclesParent){
            var ghostObj = Instantiate(obj.gameObject, obj.transform.position, obj.transform.rotation);
            ghostObj.GetComponent<Renderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(ghostObj, _simulationScene);
        }

    }
}
