using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Leap;

public class Valores : MonoBehaviour {

	public string fileName;
	private SaveData data;

	Controller LeapController;
	public Text posx;
	public Text posy;
	public Text posz;
	public Text velx;
	public Text vely;
	public Text velz;
	public Text angx;
	public Text angy;
	public Text angz;
	public Text pitch;
	public Text yaw;
	public Text roll;
	public Slider grabgraf;
	public Slider pinchgraf;

	// Use this for initialization
	void Start () {
		LeapController = new Controller ();
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = LeapController.Frame ();
		Hand hand = null;
		for (int i = 0; i < frame.Hands.Count; i++) {
			hand = frame.Hands [i];
		}

		posx.text = "x: " + hand.PalmPosition.x.ToString ("f0");
		posy.text = "y: " + hand.PalmPosition.y.ToString ("f0");
		posz.text = "z: " + hand.PalmPosition.z.ToString ("f0");
		velx.text = "x: " + hand.PalmVelocity.x.ToString ("f0");
		vely.text = "y: " + hand.PalmVelocity.y.ToString ("f0");
		velz.text = "z: " + hand.PalmVelocity.z.ToString ("f0");
		angx.text = "x: " + hand.PalmNormal.x.ToString ("f2");
		angy.text = "y: " + hand.PalmNormal.y.ToString ("f2");
		angz.text = "z: " + hand.PalmNormal.z.ToString ("f2");
		pitch.text = "Pitch: " + hand.Direction.Pitch.ToString ("f2");
		yaw.text = "Yaw: " + hand.Direction.Yaw.ToString ("f2");
		roll.text = "Roll: " + hand.Direction.Roll.ToString ("f2");
		grabgraf.value = hand.GrabStrength;
		pinchgraf.value = hand.PinchStrength;

		data = new SaveData(fileName);
		data["Posição (mm)"] = new Vector3(hand.PalmPosition.x, hand.PalmPosition.y, hand.PalmPosition.z);
		data["Velocidade (mm/s)"] = new Vector3(hand.PalmVelocity.x, hand.PalmVelocity.y, hand.PalmVelocity.z);
		data["Ângulo (rad)"] = new Vector3(hand.PalmNormal.x, hand.PalmNormal.y, hand.PalmNormal.z);
		data["Direção (Pitch, Yaw, Roll)"] = new Vector3(hand.Direction.Pitch, hand.Direction.Yaw, hand.Direction.Roll);
		data["Força"] = grabgraf.value;
		data["Força"] = pinchgraf.value;

		data.Save();

	}
}
