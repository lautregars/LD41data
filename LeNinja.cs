using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class LeNinja : MonoBehaviour {
	public float NinjaLife = 100f ;
	public float NinjaLifeMax = 100f;
	public bool VueFps = false;
	public bool FpsCamBool;
	public float aled = 0 ;
	public bool PlaCamBool;
	public CameraFacingBillboard billboard;
	public Camera FPSCAM;
	public Camera PLACAM;
	Collider2D NinjaCollider;
	private IEnumerator coroutine;
	private IEnumerator coroutineanimhurt;
	private IEnumerator coroutineanimhurthead;
	public PostProcessingProfile AaaFPS ;
	public ColorGradingModel.Settings colorSettings;
	public VignetteModel.Settings vignSettings;
	public MotionBlurModel.Settings BlurSettings;
	float Satu = 1 ;
	float dmgmask = 0;
	bool tetedegattest = false;
	public SpriteRenderer Visual;
	public Animator myanimator;
	Animator animator;
	public Image tete;
	public Image healthBar;
	public Image ChangeViewCd;
	public float View = 10f;
	public float RunTime = 0.0f;
	public Sprite hurtHead;
	public Sprite midLifeHead;
	public Sprite LowLifeHead;
	public Sprite NormalHead;
	public GameObject WinPanel;
	public UnityEngine.UI.Text TextRunTime;
	public UnityEngine.UI.Text TextRunTimeWin;
	public AudioSource Jump1;
	public AudioSource Jump2;
	public AudioSource Dash;
	public AudioSource ChangeCamera;
	public AudioSource Hit1;
	public AudioSource Hit2;
	public AudioSource Hit3;
	public AudioSource Run;
	public AudioSource Victory;
	public AudioSource GameOver;
	public AudioSource ChangeViewReady;
	public AudioSource Heartbeat;
	public AudioSource HeavyBreathing;
	public AudioSource Zik;
	public AudioSource VictoryCrowd;
	public AudioSource ExplosionSound;
	// Use this for initialization
	void Start () {
		AudioSource audio = GetComponent<AudioSource> ();

		TextRunTime = GameObject.Find ("TextRunTime").GetComponent<UnityEngine.UI.Text> ();
		FpsCamBool = false;
		PlaCamBool = true;

		AaaFPS.colorGrading.enabled = true;
		AaaFPS.colorGrading.settings = colorSettings;
		NinjaCollider = gameObject.GetComponent<Collider2D>();
		PLACAM.enabled = true;
		FPSCAM.enabled = false;
		Satu = 1;
		AaaFPS.vignette.enabled = true;
		AaaFPS.vignette.settings = vignSettings;
		vignSettings.opacity = 0;
		Zik.PlayDelayed (0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Keypad0)) {
			Run.Stop ();
			float aupif = Random.Range (1, 2);
			if (aupif <= 1)
				Jump1.Play ();

			if (aupif >= 2)
				Jump2.Play ();
				


		}





		if (WinPanel.activeSelf == false) {
			RunTime += Time.fixedUnscaledDeltaTime;
	

		}
		TextRunTime.text = RunTime.ToString ("F1");
		TextRunTimeWin.text = RunTime.ToString ("F1");
		healthBar.fillAmount = NinjaLife / NinjaLifeMax;
		ChangeViewCd.fillAmount = View / 150;
		colorSettings.basic.saturation = Satu;
		GameObject g = GameObject.Find ("Ninja");
		PlatformerMotor2D pmotor = g.GetComponent<PlatformerMotor2D> ();
		vignSettings.opacity = dmgmask;
		AaaFPS.vignette.settings = vignSettings;

		if (PLACAM.enabled == true && FPSCAM.enabled == false) {
			PlaCamBool = true;
			FpsCamBool = false;
			Debug.Log ("Platform");
			aled = 0;
		}
		if (FPSCAM.enabled == true && PLACAM.enabled == false) {
			Debug.Log ("Fps");
			aled = 1;
			PlaCamBool = false;
			FpsCamBool = true;

		}

		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
		}



		if (pmotor.DashBool == true) {
			if (!Dash.isPlaying) {
				Dash.Play ();

			}
			gameObject.layer = 9;
			AaaFPS.motionBlur.enabled = true;
			AaaFPS.motionBlur.settings = BlurSettings;
			float FXDashBlur = 180;
			float FXDashBlurImg = 0.2f;
			BlurSettings.shutterAngle= FXDashBlur;
			BlurSettings.frameBlending = FXDashBlurImg; 

		}

		if (pmotor.DashBool == false) {
			Dash.Stop();
			gameObject.layer = 8;
			float FXDashBlur = 270;
			float FXDashBlurImg = 0;
		}
		if (Input.GetKeyDown (KeyCode.C) == true || Input.GetKeyDown (KeyCode.RightControl) == true ) {
			ChangeCamera.Play ();
			InvertCam ();
		}

		if (PlaCamBool == true && FpsCamBool == false) {
			View -= Time.deltaTime * 10;
		}

		if (View <= 0.5f) {
			View = 0.5f;
			PlaCamBool = false;
			FpsCamBool = true;
			InvertCam ();
		}

		if (PlaCamBool == false && FpsCamBool == true) {
			View += Time.deltaTime * 10;
		}

		if (View >= 150) {
			View = 150;
		}
		if (View <= 149 && View >= 148) {
			ChangeViewReady.Play ();
		}

		if (NinjaLife > NinjaLifeMax) {

			NinjaLife = 100;

		}

		if (NinjaLife > 50) {
			if (tetedegattest == false) {
				tete.sprite = NormalHead;

			}
			AaaFPS.colorGrading.enabled = false;
			HeavyBreathing.Stop ();
			Heartbeat.Stop ();
			AaaFPS.chromaticAberration.enabled = false;
		

		}
		if (NinjaLife <= 50) {
			if (tetedegattest == false) {
				tete.sprite = midLifeHead;

			}
			AaaFPS.colorGrading.enabled = true;
			AaaFPS.chromaticAberration.enabled = true;
			if (!HeavyBreathing.isPlaying) {
				HeavyBreathing.Play ();
			}

			AaaFPS.colorGrading.settings = colorSettings;
			Satu = 0.8f;
			colorSettings.basic.temperature = 35;

		}
		if (NinjaLife <= 30) {
			if (tetedegattest == false) {
				tete.sprite = LowLifeHead;

			}
			AaaFPS.chromaticAberration.enabled = true;
			AaaFPS.colorGrading.enabled = true;
			if (!Heartbeat.isPlaying) {
				Heartbeat.Play ();
			}

			AaaFPS.colorGrading.settings = colorSettings;
			Satu = 0.5f;
			colorSettings.basic.temperature = 50;
		}
		if (NinjaLife <= 0 ) {
			
			AaaFPS.vignette.enabled = true;
			AaaFPS.vignette.settings = vignSettings;
			CameraShake FpsShake = FPSCAM.GetComponent<CameraShake> ();
			FpsShake.shakeDuration = 0.2f;
			FpsShake.shakeAmount = 1f;
			HeavyBreathing.Stop ();
			Heartbeat.Stop ();
			SceneManager.LoadScene ("GAmeOverScene");


		}

	}


	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Ronce")) {
			Debug.Log ("Aiou");
			float aupif = Random.Range (1, 3);
			if (aupif == 1)
				Hit1.Play ();

			if (aupif == 2)
				Hit2.Play ();

			if (aupif >= 3)
				Hit3.Play ();
			
			NinjaLife = NinjaLife - 5;
			AaaFPS.vignette.enabled = true;
			AaaFPS.vignette.settings = vignSettings;
			myanimator.SetBool ("Harm",true);
			GameObject BarreDeVie = GameObject.Find("BarreDeVie");

			CameraShake bardevishake = BarreDeVie.GetComponent<CameraShake> ();
			bardevishake.shakeDuration = 0.4f;
			CameraShake FpsShake = FPSCAM.GetComponent<CameraShake> ();
			FpsShake.shakeDuration = 0.2f;
			coroutine = DmgMaskAppears (0);
			StartCoroutine (coroutine);
			coroutineanimhurt = Deganim (0);
			StartCoroutine (coroutineanimhurt);
			coroutineanimhurthead = Degatete (0);
			StartCoroutine (coroutineanimhurthead);

		}
		if (col.gameObject.CompareTag("Victoire")){
			Zik.Stop ();
			GameOver.Stop ();
			Heartbeat.Stop ();
			HeavyBreathing.Stop ();
			Victory.Play ();
			VictoryCrowd.Play ();
			transform.DetachChildren();
			Destroy (gameObject);
			WinPanel.SetActive (true);

			RunTime = RunTime;


		}
		if (col.gameObject.CompareTag ("EnemyBullet")) {
			float aupif = Random.Range (1, 3);
			if (aupif == 1)
				ExplosionSound.Play ();
				Hit1.Play ();
			

			if (aupif == 2)
				ExplosionSound.Play ();
				Hit2.Play ();

			if (aupif >= 3)
				ExplosionSound.Play ();
				Hit3.Play ();


			NinjaLife = NinjaLife - 20;
			AaaFPS.vignette.enabled = true;
			AaaFPS.vignette.settings = vignSettings;
			myanimator.SetBool ("Harm",true);
			GameObject BarreDeVie = GameObject.Find("BarreDeVie");

			CameraShake bardevishake = BarreDeVie.GetComponent<CameraShake> ();
			bardevishake.shakeAmount = 13;
			bardevishake.shakeDuration = 0.5f;

			CameraShake FpsShake = FPSCAM.GetComponent<CameraShake> ();
			FpsShake.shakeDuration = 0.3f;
			coroutine = DmgMaskAppears (0);
			StartCoroutine (coroutine);
			coroutineanimhurt = Deganim (0);
			StartCoroutine (coroutineanimhurt);
			coroutineanimhurthead = Degatete (0);
			StartCoroutine (coroutineanimhurthead);

		}
		if (col.gameObject.CompareTag ("Vide")) {
			Debug.Log ("HitVide");
		/*	AaaFPS.vignette.enabled = true;
			AaaFPS.vignette.settings = vignSettings;
			myanimator.SetBool ("Harm",true);
			GameObject BarreDeVie = GameObject.Find("BarreDeVie");

			CameraShake bardevishake = BarreDeVie.GetComponent<CameraShake> ();
			bardevishake.shakeAmount = 13;
			bardevishake.shakeDuration = 0.5f;

			CameraShake FpsShake = FPSCAM.GetComponent<CameraShake> ();
			FpsShake.shakeDuration = 0.3f;
			coroutine = DmgMaskAppears (0);
			StartCoroutine (coroutine);
			coroutineanimhurt = Deganim (0);
			StartCoroutine (coroutineanimhurt);
			coroutineanimhurthead = Degatete (0);
			StartCoroutine (coroutineanimhurthead);
	*/
			NinjaLife = NinjaLife - 300;
		}
		if (col.gameObject.CompareTag ("Life")) {
			NinjaLife = NinjaLife + 25;
			Destroy (col.gameObject);

		}


	}

	private IEnumerator DmgMaskAppears(float FadeTime){

		dmgmask = 1;
		while (dmgmask > 0 && NinjaLife >= 20) {
			Debug.Log ("Ca disparait");
			yield return new WaitForSeconds(0.05f);
			dmgmask= dmgmask - 0.01f;
		
		}	


	}

	private IEnumerator Deganim(float FadeTime){
		
		yield return new WaitForSeconds (1f);
		myanimator.SetBool ("Harm",false);

	}

	private IEnumerator Degatete(float FadeTime){
		Debug.Log ("TeteDamaged");
		tete.sprite = hurtHead;
		tetedegattest = true;

		yield return new WaitForSeconds (0.5f);
		tetedegattest = false;

	}

	void InvertCam() {

		FPSCAM.enabled = !FPSCAM.enabled;
		PLACAM.enabled = !PLACAM.enabled;

	}


}
