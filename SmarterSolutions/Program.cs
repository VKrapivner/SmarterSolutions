class GlasPyramid
{
    static void Main()
    {
        while (true)
        {
            try
            {
                Console.Write("Vänligen ange önskad Rad: ");
                int r = int.Parse(Console.ReadLine());  
                Console.Write("Vänligen ange vilket Glas:  ");
                int g = int.Parse(Console.ReadLine());  

                double[][] pyramid = new double[r][];

                for (int i = 0; i < r; i++)
                {
                    pyramid[i] = new double[i + 1];
                }

                pyramid[0][0] = -10.0; 

                for (int row = 0; row < r; row++)
                {
                    for (int pos = 0; pos <= row; pos++)
                    {
                        if (pyramid[row][pos] < 0)
                        {
                            double overflowTime = -pyramid[row][pos];
                            if (row + 1 < r)
                            {
                                double flowTime = overflowTime + 10; 
                                int nextRow = row + 1;
                                if (pos <= nextRow)
                                {
                                    pyramid[nextRow][pos] = AddWater(pyramid[nextRow][pos], flowTime);
                                }
                                if (pos + 1 <= nextRow)
                                {
                                    pyramid[nextRow][pos + 1] = AddWater(pyramid[nextRow][pos + 1], flowTime);
                                }
                            }
                        }
                    }
                }

                double result = -pyramid[r - 1][g - 1];
                Console.WriteLine($"Det tar {result:0.000} sekunder.");
                Console.WriteLine("Vill du försöka igen? (y/n): ");
                string responce = Console.ReadLine();
                if(responce != "y")
                {
                    break;
                }
                 
            }
            catch
            {
                Console.WriteLine("Input var inkorrekt, det glaset eller den raden finns inte. Vänligen försök igen.");
            }
        }
    }

    static double AddWater(double currentValue, double addedTime)
    {
        if (currentValue == 0)
        {
            return -addedTime;
        }
        else
        {
            double currentTime = -currentValue;
            return -(currentTime + (addedTime - currentTime) / 2.0);
        }
    }
}
