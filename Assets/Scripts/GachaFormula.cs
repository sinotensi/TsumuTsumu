using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GachaFormula : MonoBehaviour {
	private static int[] normalRange = new int[]{ 0, 900 };
	private static int[] rareRange = new int[]{ 901, 990 };
	private static int[] superRareRange = new int[]{ 991, 1000 };
	
	public static void Initialize () {

	}

	public static int NormalFormaule () {
		int range = Random.Range( 0, 1001 );

		return NormalRangeCheck( range );
	}

	public static int SuperFormaule () {
		int range = Random.Range( 0, 1001 );
		
		return SuperRangeCheck( range );
	}

	public static int NormalRangeCheck ( int range ) {
		if( range >= normalRange[0] && range <= normalRange[1] )
		{
			NormalPet();
			return 1;
		}
//		else if( range >= rareRange[0] && range <= rareRange[1] )
//		{
//			RarePet();
//			return 2;
//		}
//		else if( range >= superRareRange[0] && range <= superRareRange[1] )
//		{
//			SuperRarePet();
//			return 3;
//		}

		return 1;
	}

	public static int SuperRangeCheck ( int range ) {
		if( range >= superRareRange[0] && range <= superRareRange[1] )
		{
			NormalPet();
			return 1;
		}
		else if( range >= normalRange[0] && range <= normalRange[1] )
		{
			RarePet();
			return 2;
		}
		else if( range >= rareRange[0] && range <= rareRange[1] )
		{
			SuperRarePet();
			return 3;
		}
		
		return 2;
	}

	public static void NormalPet () {
		string uid = string.Format( "{0:00000}", Random.Range( 1, 4 ) );
		uid = uid.Insert( 0, "u" );
		Debug.Log( uid );
		GetPetView.petUID = uid;
		//Debug.Log( Random.Range( 0, 17 ) );
	}

	public static void RarePet () {
		Debug.Log( Random.Range( 17, 24 ) );
	}

	public static void SuperRarePet () {
		Debug.Log( Random.Range( 24, 29 ) );
	}
}
