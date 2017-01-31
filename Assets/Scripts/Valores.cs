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
	public Text handname;
	public Text grabstate;
	public Text polegar;
	public Text indicador;
	public Text medio;
	public Text anelar;
	public Text minimo;
	public Text velpolegar;

	// Use this for initialization
	void Start () {
		LeapController = new Controller ();
		data = new SaveData(fileName);
	}
	
	// Update is called once per frame
	void Update () {

		Frame frame = LeapController.Frame ();
		Hand hand = null;
		for (int i = 0; i < frame.Hands.Count; i++) {
			hand = frame.Hands [i];
		}
		Finger thumbFinger = null;
		Finger indexFinger = null;
		Finger middleFinger = null;
		Finger ringFinger = null;
		Finger pinkyFinger = null;
		for (int i = 0; i < hand.Fingers.Count; i++) {
			thumbFinger = hand.Fingers [0];
			indexFinger = hand.Fingers [1];
			middleFinger = hand.Fingers [2];
			ringFinger = hand.Fingers [3];
			pinkyFinger = hand.Fingers [4];
		}

		handname.text = hand.IsLeft ? "Mão esquerda" : "Mão direita";
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

		if(hand.GrabStrength==0)
			grabstate.text = "Aberta";
		else
			grabstate.text = "Fechada";
		
		polegar.text = thumbFinger.IsExtended ? "Estendido" : "Contraido";
		indicador.text = indexFinger.IsExtended ? "Estendido" : "Contraido";
		medio.text = middleFinger.IsExtended ? "Estendido" : "Contraido";
		anelar.text = ringFinger.IsExtended ? "Estendido" : "Contraido";
		minimo.text = pinkyFinger.IsExtended ? "Estendido" : "Contraido";

		data ["Mão"] = handname.text;
		data ["Estado"] = grabstate.text;
		data ["Posição (mm)"] = new Vector3 (hand.PalmPosition.x, hand.PalmPosition.y, hand.PalmPosition.z);
		data ["Velocidade (mm/s)"] = new Vector3(hand.PalmVelocity.x, hand.PalmVelocity.y, hand.PalmVelocity.z);
		data ["Ângulo (rad)"] = new Vector3(hand.PalmNormal.x, hand.PalmNormal.y, hand.PalmNormal.z);
		data ["Direção (Pitch, Yaw, Roll)"] = new Vector3(hand.Direction.Pitch, hand.Direction.Yaw, hand.Direction.Roll);
		data ["Polegar"] = polegar.text;
		data ["indicador"] = indicador.text;
		data ["medio"] = medio.text;
		data ["anelar"] = anelar.text;
		data ["minimo"] = minimo.text;

		data.Save();
	}
}
