using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

[RequireComponent(typeof(NavMeshAgent))]
public class GalneonMonoBehaviour : MonoBehaviour
{
    private StateMachine stateMachine = new StateMachine();
    public GalneonCharacter character;
    public GameObject hud;
    private Vector3 mousePos;
    private Camera mainCamera;
    private Rigidbody2D rb;
    private float force;
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    public float maxHp;
    public float currentHp;

    void Awake() {
        this.maxHp = character.hp;
        this.currentHp = character.hp;

    }

    void Start()
    {

        //Observação: falta o ability power e o ability raste
        GameObject.Find("TextArmor").GetComponent<TextMeshProUGUI>().text = character.armor.ToString();
        GameObject.Find("TextAttackDamage").GetComponent<TextMeshProUGUI>().text = character.attackdamage.ToString();
        GameObject.Find("TextAttackSpeed").GetComponent<TextMeshProUGUI>().text = character.attackspeed.ToString();
        GameObject.Find("TextCrit").GetComponent<TextMeshProUGUI>().text = character.crit.ToString();
        GameObject.Find("TextSpellblock").GetComponent<TextMeshProUGUI>().text = character.spellblock.ToString();
        GameObject.Find("TextMoveSpeed").GetComponent<TextMeshProUGUI>().text = character.movespeed.ToString();
        /*force = character.force;

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);*/
    }


    private void Update()
    {
        this.stateMachine.ExecuteStateUpdate();
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            //lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                this.stateMachine.ChangeState(new GoTo(this.gameObject, hit.point, this.navMeshAgent.transform.position, this.navMeshAgent, this.TriggerGoTo));
            }
            //this.stateMachine.ChangeState(new GoTo(this.gameObject, lastClickedPos, this.navMeshAgent, this.TriggerGoTo));
        }
    }

    public void TriggerGoTo(GoToResults goToResults)
    {
        var gotoLocalization = goToResults.initialLocalization;
        Debug.Log("TRIGGER GO TO");
        //this.stateMachine.ChangeState(new BackTo(this.gameObject, gotoLocalization, this.navMeshAgent, this.TriggerBackTo));
    }
    public int DoDamage()
    {
        return character.basicAttack.attack;
    }

    public void TakeDamage(float amount) {
        this.currentHp -= amount;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bullet")
        {
            Debug.Log("COLIDIU");
            this.TakeDamage(other.gameObject.GetComponent<BasicAttack3DMonoBehaviour>().DoDamage());
            

            Destroy(other.gameObject);
            if(this.currentHp <= 0f){
                this.gameObject.SetActive(false);
            }
        }
    }
}
