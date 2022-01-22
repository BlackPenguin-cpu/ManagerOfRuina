using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUtil
{
	public static float valueForProb
	{
		get
		{
			return (float)UnityEngine.Random.Range(0, 1000000) / 10000f;
		}
	}

	public static float valueForRange
	{
		get
		{
			return UnityEngine.Random.value;
		}
	}

	public static int Range(int min, int max)
	{
		return UnityEngine.Random.Range(min, max + 1);
	}

	public static float RangeFloat(float min, float max)
	{
		return UnityEngine.Random.Range(min, max);
	}

	public static int SystemRange(int max)
	{
		return RandomUtil.randomValue.Next(max);
	}

	public static T SelectOne<T>(params T[] list)
	{
		return list[UnityEngine.Random.Range(0, list.Length)];
	}

	public static T SelectOne<T>(List<T> list)
	{
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public static T SelectOne<T>(T[] list, float[] probs)
	{
		if (list.Length != probs.Length)
		{
			Debug.LogError("Error : List's length must be equal to Probs's");
			return RandomUtil.SelectOne<T>(list);
		}
		float num = 0f;
		for (int i = 0; i < probs.Length; i++)
		{
			num += probs[i];
		}
		if (num <= 0f)
		{
			Debug.LogError("Error : Invalid Probs");
			return list[0];
		}
		float valueForProb = RandomUtil.valueForProb;
		int num2 = list.Length - 1;
		float num3 = 0f;
		for (int j = 0; j < list.Length - 1; j++)
		{
			num3 += probs[j] / num;
			if (valueForProb < num3)
			{
				num2 = j;
				break;
			}
		}
		return list[num2];
	}

	public static System.Random randomValue = new System.Random();
}
