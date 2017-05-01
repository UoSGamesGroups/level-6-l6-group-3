using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerSts : MonoBehaviour {


    public float current_player_hp = 1000;
	
	
	MonoBehaviour[] playerComponents;
    [SerializeField] float hunger;
    private float max_player_hp;

    //GUI
	[SerializeField] private pngFadeIn _pngFadeIn;
    private GameObject mcHpBar;
    private GameObject mcHpText;

    //Bonuses
    BonusController bonus;


    private void Awake()
    {
        mcHpBar = GameObject.FindGameObjectWithTag("mcHp");
        mcHpText= GameObject.FindGameObjectWithTag("mcHpText");
        bonus = GetComponent<BonusController>();
    }

    void Start()
    {
        max_player_hp = current_player_hp;
    }

    void Update()
    {
        if(bonus != null)
        {
            if(bonus.BonusHp > 0f)
            {
                max_player_hp = max_player_hp + bonus.BonusHp;
                bonus.BonusHp =0f;
            }
        }
        HpDecreas();
        GUI();
        Dead();
    }

    void HpDecreas()
    {
        if(bonus != null)
            current_player_hp -= Time.deltaTime * (hunger + bonus.BonusLwrHealthDrop);
        current_player_hp = Mathf.Clamp(current_player_hp, 0, max_player_hp);
    }

	void Dead()
	{
		if(current_player_hp<=0)
		{
			playerComponents=GetComponents<MonoBehaviour>();
			foreach(MonoBehaviour mb in playerComponents)
			{
				mb.enabled = false;
			}
			
			GetComponent<CapsuleCollider>().enabled = true;
			GetComponent<Rigidbody>().constraints=0;
			_pngFadeIn.gameObject.SetActive(true);
			StartCoroutine(ChangeScene());
		}
	}
	
    void GUI()
    {
        if(mcHpBar!=null)
            mcHpBar.transform.localScale = new Vector3(current_player_hp / max_player_hp, 1f, 1f);
        if(mcHpText!=null)
            mcHpText.GetComponent<TextMesh>().text = current_player_hp.ToString("N1") + "/" + max_player_hp.ToString("N1");

    }
	
	IEnumerator ChangeScene()
	{
		yield return new WaitForSeconds(3.5f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}


}
