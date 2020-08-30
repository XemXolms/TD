using System.Collections;
using UnityEngine;

public class PlayerStats: MonoBehaviour
{
	public static int Lives;
	public int startLives = 20;

	public static int Money;
	public int startMoney = 400;

	void Start()
	{
		Money = startMoney;
		Lives = startLives;
	}
}
