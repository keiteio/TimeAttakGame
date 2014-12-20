using System;

public class Randomizer
{
	static Randomizer instance;
	
	public static Randomizer Instance{
		get{
			if(instance == null){
				instance = new Randomizer();
			}
			return instance;
		}
	}
	
	Random random;
	
	private Randomizer(){
		random = new Random();
	}
	
	public int Next(){
		return random.Next();
	}
	
	public double NextDouble(){
		return random.NextDouble();
	}
	
	public float NextFloat(){
		return (float)(random.NextDouble());
	}
}