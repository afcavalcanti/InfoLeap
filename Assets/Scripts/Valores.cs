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
	public Text posd1;
	public Text posd2;
	public Text posd3;
	public Text posd4;
	public Text posd5;
	public Text velx;
	public Text vely;
	public Text velz;
	public Text veld1;
	public Text veld2;
	public Text veld3;
	public Text veld4;
	public Text veld5;
	public Text angx;
	public Text angy;
	public Text angz;
	public Text pitch;
	public Text yaw;
	public Text roll;
	public Text dird1;
	public Text dird2;
	public Text dird3;
	public Text dird4;
	public Text dird5;
	public Text handname;
	public Text grabstate;
	public Text polegar;
	public Text indicador;
	public Text medio;
	public Text anelar;
	public Text minimo;

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

		posd1.text = "x: " + thumbFinger.TipPosition.x.ToString ("f2") + " y: " + thumbFinger.TipPosition.y.ToString ("f2") + " z: " + thumbFinger.TipPosition.z.ToString ("f2");
		posd2.text = "x: " + indexFinger.TipPosition.x.ToString ("f2") + " y: " + indexFinger.TipPosition.y.ToString ("f2") + " z: " + indexFinger.TipPosition.z.ToString ("f2");
		posd3.text = "x: " + middleFinger.TipPosition.x.ToString ("f2") + " y: " + middleFinger.TipPosition.y.ToString ("f2") + " z: " + middleFinger.TipPosition.z.ToString ("f2");
		posd4.text = "x: " + ringFinger.TipPosition.x.ToString ("f2") + " y: " + ringFinger.TipPosition.y.ToString ("f2") + " z: " + ringFinger.TipPosition.z.ToString ("f2");
		posd5.text = "x: " + pinkyFinger.TipPosition.x.ToString ("f2") + " y: " + pinkyFinger.TipPosition.y.ToString ("f2") + " z: " + pinkyFinger.TipPosition.z.ToString ("f2");
		veld1.text = "x: " + thumbFinger.TipVelocity.x.ToString ("f2") + " y: " + thumbFinger.TipVelocity.y.ToString ("f2") + " z: " + thumbFinger.TipVelocity.z.ToString ("f2");
		veld2.text = "x: " + indexFinger.TipVelocity.x.ToString ("f2") + " y: " + indexFinger.TipVelocity.y.ToString ("f2") + " z: " + indexFinger.TipVelocity.z.ToString ("f2");
		veld3.text = "x: " + middleFinger.TipVelocity.x.ToString ("f2") + " y: " + middleFinger.TipVelocity.y.ToString ("f2") + " z: " + middleFinger.TipVelocity.z.ToString ("f2");
		veld4.text = "x: " + ringFinger.TipVelocity.x.ToString ("f2") + " y: " + ringFinger.TipVelocity.y.ToString ("f2") + " z: " + ringFinger.TipVelocity.z.ToString ("f2");
		veld5.text = "x: " + pinkyFinger.TipVelocity.x.ToString ("f2") + " y: " + pinkyFinger.TipVelocity.y.ToString ("f2") + " z: " + pinkyFinger.TipVelocity.z.ToString ("f2");
		dird1.text = "x: " + thumbFinger.Direction.x.ToString ("f2") + " y: " + thumbFinger.Direction.y.ToString ("f2") + " z: " + thumbFinger.Direction.z.ToString ("f2");
		dird2.text = "x: " + indexFinger.Direction.x.ToString ("f2") + " y: " + indexFinger.Direction.y.ToString ("f2") + " z: " + indexFinger.Direction.z.ToString ("f2");
		dird3.text = "x: " + middleFinger.Direction.x.ToString ("f2") + " y: " + middleFinger.Direction.y.ToString ("f2") + " z: " + middleFinger.Direction.z.ToString ("f2");
		dird4.text = "x: " + ringFinger.Direction.x.ToString ("f2") + " y: " + ringFinger.Direction.y.ToString ("f2") + " z: " + ringFinger.Direction.z.ToString ("f2");
		dird5.text = "x: " + pinkyFinger.Direction.x.ToString ("f2") + " y: " + pinkyFinger.Direction.y.ToString ("f2") + " z: " + pinkyFinger.Direction.z.ToString ("f2");
		
		data ["Mão"] = handname.text;
		data ["Estado"] = grabstate.text;
		data ["Posição (mm)"] = new Vector3 (hand.PalmPosition.x, hand.PalmPosition.y, hand.PalmPosition.z);
		data ["Velocidade (mm/s)"] = new Vector3(hand.PalmVelocity.x, hand.PalmVelocity.y, hand.PalmVelocity.z);
		data ["Ângulo (rad)"] = new Vector3(hand.PalmNormal.x, hand.PalmNormal.y, hand.PalmNormal.z);
		data ["Direção (Pitch, Yaw, Roll)"] = new Vector3(hand.Direction.Pitch, hand.Direction.Yaw, hand.Direction.Roll);
		data ["polegar"] = polegar.text;
		data ["Posição do polegar (mm)"] = new Vector3 (thumbFinger.TipPosition.x, thumbFinger.TipPosition.y, thumbFinger.TipPosition.z);
		data ["Velocidade do polegar (mm/s)"] = new Vector3(thumbFinger.TipVelocity.x, thumbFinger.TipVelocity.y, thumbFinger.TipVelocity.z);
		data ["Direção do polegar"] = new Vector3(thumbFinger.Direction.x, thumbFinger.Direction.y, thumbFinger.Direction.z);
		data ["indicador"] = indicador.text;
		data ["Posição do indicador (mm)"] = new Vector3 (indexFinger.TipPosition.x, indexFinger.TipPosition.y, indexFinger.TipPosition.z);
		data ["Velocidade do indicador (mm/s)"] = new Vector3(indexFinger.TipVelocity.x, indexFinger.TipVelocity.y, indexFinger.TipVelocity.z);
		data ["Direção do indicador"] = new Vector3(indexFinger.Direction.x, indexFinger.Direction.y, indexFinger.Direction.z);
		data ["médio"] = medio.text;
		data ["Posição do médio (mm)"] = new Vector3 (middleFinger.TipPosition.x, middleFinger.TipPosition.y, middleFinger.TipPosition.z);
		data ["Velocidade do médio (mm/s)"] = new Vector3(middleFinger.TipVelocity.x, middleFinger.TipVelocity.y, middleFinger.TipVelocity.z);
		data ["Direção do médio"] = new Vector3(middleFinger.Direction.x, middleFinger.Direction.y, middleFinger.Direction.z);
		data ["anelar"] = anelar.text;
		data ["Posição do anelar (mm)"] = new Vector3 (ringFinger.TipPosition.x, ringFinger.TipPosition.y, ringFinger.TipPosition.z);
		data ["Velocidade do anelar (mm/s)"] = new Vector3(ringFinger.TipVelocity.x, ringFinger.TipVelocity.y, ringFinger.TipVelocity.z);
		data ["Direção do anelar"] = new Vector3(ringFinger.Direction.x, ringFinger.Direction.y, ringFinger.Direction.z);
		data ["mínimo"] = minimo.text;
		data ["Posição do mínimo(mm)"] = new Vector3 (pinkyFinger.TipPosition.x, pinkyFinger.TipPosition.y, pinkyFinger.TipPosition.z);
		data ["Velocidade do mínimo (mm/s)"] = new Vector3(pinkyFinger.TipVelocity.x, pinkyFinger.TipVelocity.y, pinkyFinger.TipVelocity.z);
		data ["Direção do mínimo"] = new Vector3(pinkyFinger.Direction.x, pinkyFinger.Direction.y, pinkyFinger.Direction.z);

		data.Save();
	}
}
