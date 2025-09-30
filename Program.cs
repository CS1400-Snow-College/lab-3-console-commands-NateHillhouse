/*
Nathan Hillhouse
9/29/2025
Lab 5 - Mastermind
*/

Console.Clear();
Console.WriteLine(@"I have chosen 4 letters between 'a' and 'g' and have arranged them in a particular order.
Your job is to guess the letters and put them in the right order.");

int guessNumber = 1;
string guess;
char[] word = new char[4];
Random rand = new Random();


//get random word
for (int i = 3; i >= 0; i--)
{
    word[i] = (char)rand.Next(97, 103);
    Console.Write(word[i]);
}

