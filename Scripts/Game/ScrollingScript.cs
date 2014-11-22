using UnityEngine;
using System.Collections;

public class ScrollingScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    _sprite = GetComponent<SpriteRenderer>().sprite;
	    _size =gameObject.transform.localScale.x*_sprite.bounds.size.x/2;
	    _instance = true;
	}

    private float _size;
    private Sprite _sprite;
    public int Speed = 10;
    [SerializeField] private GameObject _prefab;
    private bool _instance;

    void Movement()
    {
        Vector3 movement = new Vector3(-Speed, 0, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }

    void SpriteSpawn()
    {
        if ((transform.position.x + _size <  Camera.main.orthographicSize * Camera.main.aspect + Camera.main.transform.position.x) && _instance)
        {
           var prefab = Instantiate(_prefab) as GameObject;
           prefab.transform.Translate(_size*2,0,0);
            _instance = false;
        }
    }

    void DestroyBackGroung()
    {
        if(transform.position.x < -2*_size)
            Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {

        Movement();
        SpriteSpawn();
        DestroyBackGroung();
	}
}
