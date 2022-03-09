	public class Program
{
	public static void Main()
	{
		//i get data under name "data" from file
		string[] lines = File.ReadAllLines(@"data.txt");
		
        
		var array = SetArray(lines);
		
		var max = MeaMax(lines, array);
		
		Console.WriteLine("The maximum sum of the data is -> {0}",max[0, 0]);
		//I am printing a formatted string. {0} means adding the first parameter following the format string.
		
	}

//function that we convert the data to an array
	private static int[,] SetArray(string[] lines)
	{
		int[,] array = new int[lines.Length, lines.Length + 1];
		
		for (int row = 0; row < lines.Length; row++)
		{
			var rope = lines[row].Trim().Split(' ');
            //we separate from both " " and "\n"
			
			for (int column = 0; column < rope.Length; column++)
			{
				int number;
				int.TryParse(rope[column], out number);
                //converting the string x to an integer value and assigning the data I obtained to the variable "number"
				array[row, column] = number;
                //i thought it would make my job easier to define a 2D array
			}
		}
		return array;
	}


//function that we set prime numbers
	private static bool IsPrime(int number)
	{
		//if the number is 1 then return false directly
		if (number == 1) return false;
        //if the number is 2, return directly. because 2 is the smallest prime number.
		if (number == 2) return true;
        //negative numbers cannot have prime properties.
		if(number < 0)return false;

        //operations continue between the remaining numbers.
		for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
        //we don't need to go all the way to the number itself while in the for loop. 
        //if we go to the square root of the number and we can't find a result, this number is already a prime number.
		{
			if (number % i == 0) return false;
		}
		
        
		return true;
		
	}


//function that we throw prime numbers
	private static int[,] GetPrime(string[] lines, int[,] array)
	{
		for (int i = 0; i < lines.Length; i++)
		{
			for (int j = 0; j < lines.Length; j++)
			{
				if (IsPrime(array[i, j]))
					array[i, j] = 0;
                    //it returns the whole array and sends each element to the "isPrime" function
                    //if the value is a prime number I pass the number 0 on it
			}
		}
		return array;
	}

//function that we find the largest number
	private static int[,] MeaMax(string[] lines, int[,] array)
	{
		var filteredArray = GetPrime(lines, array);
		
		for (int i = lines.Length - 2; i >= 0; i--)
		{
			for (int j = 0; j < lines.Length; j++)
			{
                //i defined the number on which standing.
				var old = filteredArray[i, j];
				var leftNode = filteredArray[i + 1, j];
                //i increased the value of i by 1 for the left path
				var rightNode = filteredArray[i + 1, j + 1];
                //i increased both i and j values by 1 for the right path

                //Is our number not both prime and the numbers to its right or left are greater than 0?
				if ((old > 0 && leftNode > 0) || (old > 0 && rightNode > 0))
				{
                    //then send it to function .Max to find which one is bigger.
					array[i, j] = old + Math.Max(leftNode, rightNode);
				}
			}
		}
		return array;
	}
	
}