using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Leap;

public class Valores : MonoBehaviour {

	Controller LeapController;
	private string dia = DateTime.Now.ToShortDateString();
	private string hora = DateTime.Now.ToShortTimeString();
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
	private SaveData data;
	private List<Dados> valores;

	// Use this for initialization
	void Start () {
		LeapController = new Controller ();
		data = new SaveData("Dados");
		valores = new List<Dados>();
	}

	// Update is called once per frame
	void Update () {

		Frame frame = LeapController.Frame (); // controller is a Controller object
		if (frame.Hands.Count > 0) {
			List<Hand> hands = frame.Hands;
			Hand firstHand = hands [0];
			List<Finger> fingers = firstHand.Fingers;
			Finger thumbFinger = fingers [0];
			Finger indexFinger = fingers [1];
			Finger middleFinger = fingers [2];
			Finger ringFinger = fingers [3];
			Finger pinkyFinger = fingers [4];

			handname.text = firstHand.IsLeft ? "Mão esquerda" : "Mão direita";
			posx.text = "x: " + firstHand.PalmPosition.x.ToString ("f0");
			posy.text = "y: " + firstHand.PalmPosition.y.ToString ("f0");
			posz.text = "z: " + firstHand.PalmPosition.z.ToString ("f0");
			velx.text = "x: " + firstHand.PalmVelocity.x.ToString ("f0");
			vely.text = "y: " + firstHand.PalmVelocity.y.ToString ("f0");
			velz.text = "z: " + firstHand.PalmVelocity.z.ToString ("f0");
			angx.text = "x: " + firstHand.PalmNormal.x.ToString ("f2");
			angy.text = "y: " + firstHand.PalmNormal.y.ToString ("f2");
			angz.text = "z: " + firstHand.PalmNormal.z.ToString ("f2");
			pitch.text = "Pitch: " + firstHand.Direction.Pitch.ToString ("f2");
			yaw.text = "Yaw: " + firstHand.Direction.Yaw.ToString ("f2");
			roll.text = "Roll: " + firstHand.Direction.Roll.ToString ("f2");

			if (firstHand.GrabStrength == 0)
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

			Dados dado = new Dados();

			dado.estado = grabstate.text;
			dado.posicaoMao = new Vector3 (firstHand.PalmPosition.x, firstHand.PalmPosition.y, firstHand.PalmPosition.z);
			dado.velocidadeMao = new Vector3(firstHand.PalmVelocity.x, firstHand.PalmVelocity.y, firstHand.PalmVelocity.z);
			dado.direcaoMao = new Vector3(firstHand.Direction.Pitch, firstHand.Direction.Yaw, firstHand.Direction.Roll);
			dado.anguloMao = new Vector3(firstHand.PalmNormal.x, firstHand.PalmNormal.y, firstHand.PalmNormal.z);
			dado.posicaoPolegar = new Vector3 (thumbFinger.TipPosition.x, thumbFinger.TipPosition.y, thumbFinger.TipPosition.z);
			dado.posicaoIndicador = new Vector3 (indexFinger.TipPosition.x, indexFinger.TipPosition.y, indexFinger.TipPosition.z);
			dado.posicaoMedio = new Vector3 (middleFinger.TipPosition.x, middleFinger.TipPosition.z);
			dado.posicaoAnelar = new Vector3 (ringFinger.TipPosition.x, ringFinger.TipPosition.y, ringFinger.TipPosition.z);
			dado.posicaoMinimo = new Vector3 (pinkyFinger.TipPosition.x, pinkyFinger.TipPosition.y, pinkyFinger.TipPosition.z);
			dado.velocidadePolegar = new Vector3 (thumbFinger.TipVelocity.x, thumbFinger.TipVelocity.y, thumbFinger.TipVelocity.z);
			dado.velocidadeIndicador = new Vector3 (indexFinger.TipVelocity.x, indexFinger.TipVelocity.y, indexFinger.TipVelocity.z);
			dado.velocidadeMedio = new Vector3 (middleFinger.TipVelocity.x, middleFinger.TipVelocity.y, middleFinger.TipVelocity.z);
			dado.velocidadeAnelar = new Vector3 (ringFinger.TipVelocity.x, ringFinger.TipVelocity.y, ringFinger.TipVelocity.z);
			dado.velocidadeMinimo = new Vector3 (pinkyFinger.TipVelocity.x, pinkyFinger.TipVelocity.y, pinkyFinger.TipVelocity.z);
			dado.direcaoPolegar = new Vector3 (thumbFinger.Direction.x, thumbFinger.Direction.y, thumbFinger.Direction.z);
			dado.direcaoIndicador = new Vector3 (indexFinger.Direction.x, indexFinger.Direction.y, indexFinger.Direction.z);
			dado.direcaoMedio = new Vector3 (middleFinger.Direction.x, middleFinger.Direction.y, middleFinger.Direction.z);
			dado.direcaoAnelar = new Vector3 (ringFinger.Direction.x, ringFinger.Direction.y, ringFinger.Direction.z);
			dado.direcaoMinimo = new Vector3 (pinkyFinger.Direction.x, pinkyFinger.Direction.y, pinkyFinger.Direction.z);

			valores.Add(dado);

			data ["Data"] = dia + " " + hora;
			data ["Mão"] = handname.text;
			data ["Dados da mão"] = valores;

			data.Save();
		}
	}
}
