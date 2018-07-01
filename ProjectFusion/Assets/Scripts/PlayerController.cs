using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Orientation
{
    up = 0,
    down = 1,
    right = 2,
    left = 3
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
//    private GameObject sounds;

    [SerializeField] private AnimatorOverrideController[] animatorControllers;
    
    
    private Element _element;
    private Animator _animator;
    private Rigidbody2D _rb2d;
    private CircleCollider2D _inductionRange;
    private ParticleSystem _inductionParticle;
    [SerializeField]  
    private ParticleSystem _linkParticle;

    [SerializeField] private float attackSpeed;
    private float time;

    [SerializeField] private GameObject[] projectiles;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
        _element = GetComponent<Element>();
        _inductionRange = GetComponent<CircleCollider2D>();
        _inductionParticle = transform.Find("InductionParticle").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        _animator.SetBool("isActive", (transform.parent != null));
    }

    void FixedUpdate()
    {
        InputHandler();
    }

    void InputHandler()
    {
        if (transform.root.name == "ActivePlayer")
        {
            float axisX = Input.GetAxis("Horizontal");
            float axisY = Input.GetAxis("Vertical");
            if (axisX != 0 || axisY != 0)
            {
                _animator.SetBool("isWalking", true);
                _animator.SetFloat("orientationX", axisX);
                _animator.SetFloat("orientationY", axisY);
                GetComponent<SpriteRenderer>().flipX = (axisX < 0) ? true : false;
            }
            else
                _animator.SetBool("isWalking", false);

            _animator.SetFloat("axisX", axisX);
            _animator.SetFloat("axisY", axisY);
            transform.Translate(Vector3.right * axisX * Time.deltaTime * speed);
            transform.Translate(Vector3.up * axisY * Time.deltaTime * speed);
//            if (Input.GetKeyDown(KeyCode.Space))
//            {
//                UseSpell();
//            }

            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                UseSpell(Orientation.up);
            } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
                UseSpell(Orientation.right);
            } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                UseSpell(Orientation.down);
            } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                UseSpell(Orientation.left);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && name == "PlayerFire")
            ChangeActivePlayer();
        else if (Input.GetKeyDown(KeyCode.Alpha2) && name == "PlayerEarth")
            ChangeActivePlayer();
        else if (Input.GetKeyDown(KeyCode.Alpha3) && name == "PlayerWater")
            ChangeActivePlayer();
        else if (Input.GetKeyDown(KeyCode.Alpha4) && name == "PlayerWind")
            ChangeActivePlayer();
    }

    private void ChangeActivePlayer()
    {
        if (GameObject.Find("ActivePlayer").transform.GetChild(0).parent)
        {
            GameObject.Find("ActivePlayer").transform.GetChild(0).parent = null;
            transform.parent = GameObject.Find("ActivePlayer").transform;
        }
        
        GameManager.Gm.UpdateElementsHUD();
    }

    private void UseSpell(Orientation orientation)
    {
        if (time < attackSpeed) return;
        time = 0;
        _inductionParticle.Play();
        _inductionRange.enabled = true;
        Collider2D[] results = new Collider2D[10];
        _inductionRange.OverlapCollider(new ContactFilter2D(), results);
        foreach (var col in results)
        {
            if (col && col.name != name && (col.gameObject.layer == 19 || col.gameObject.layer == 20
                    || col.gameObject.layer == 21 || col.gameObject.layer == 22))
            {
                Debug.Log(col.name);
                col.GetComponent<Element>().Induction(_element.GetCurrentElem());
                Vector3 target = col.transform.position;
                Vector3 dir = target - transform.position;
                ParticleSystem newParticle = Instantiate(_linkParticle, target, Quaternion.identity, col.transform);
                Color[] colors = {Color.green, Color.red, Color.blue, Color.yellow};
                var particleColor = newParticle.colorOverLifetime;
                var colorTarget = colors[(int)col.GetComponent<Element>().GetCurrentElem()];
                Gradient graddient = new Gradient();
                graddient.SetKeys(
                    new GradientColorKey[] {new GradientColorKey(colorTarget, 1.0f), new GradientColorKey(colors[(int)_element.GetCurrentElem()], 0.0f)},
                    new GradientAlphaKey[] {new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f)});
                particleColor.color = graddient;
            }
        }

        _inductionRange.enabled = false;
        GameObject newProj = Instantiate(projectiles[(int)_element.GetCurrentElem()], transform.position, Quaternion.identity);
        newProj.GetComponent<PlayerProjectile>().VelX = (orientation.Equals(Orientation.right)) ? 1 : (orientation.Equals(Orientation.left)) ? -1 : 0;
        newProj.GetComponent<PlayerProjectile>().VelY = (orientation.Equals(Orientation.up)) ? 1 : (orientation.Equals(Orientation.down)) ? -1 : 0;

        SoundManager.soundMan.PlaySound(2);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
//        if (other.CompareTag("Switch"))
//        {
//            if (Input.GetKeyDown(KeyCode.E))
//            {
//                Debug.Log("Test" + name);
//                other.GetComponent<Switch>().ActivateSwitch();
//            }
//        }
    }

    public void ChangeAnimatorController(ElementType elem)
    {
        _animator.runtimeAnimatorController = animatorControllers[(int) elem];
    }

    public void ChangeParticleColor(ElementType elem)
    {
        Color[] colors = {Color.green, Color.red, Color.blue, Color.yellow};
        var particleColor = _inductionParticle.colorOverLifetime;
        Gradient graddient = new Gradient();
        graddient.SetKeys(
            new GradientColorKey[] {new GradientColorKey(Color.white, 0.0f), new GradientColorKey(colors[(int)elem], 1.0f)},
            new GradientAlphaKey[] {new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.5f, 1.0f)});
        particleColor.color = graddient;
    }
}
