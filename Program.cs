/*
Nathan Hillhouse
9/29/2025
Lab 5 - Mastermind
*/

Console.Clear();
Console.WriteLine(@"I have chosen 4 letters between 'a' and 'g' and have arranged them in a particular order.
Your job is to guess the letters and put them in the right order.");

int guessNumber = 0;
string? guess = "", word = "";
char[] wordlist = new char[4];
Random rand = new Random();

//Function to check if there are duplicates
static bool checkletters(int i, char letter, string word, Random rand)
{
    for (int x = word.Length - 1; x >= 0; x--)
    {
        if (letter == word[x])
        {
            return false;
        }
    }
    return true;

}

//get random word
for (int i = 3; i >= 0; i--)
{
    char letter = (char)rand.Next(97, 103); //Need to edit to have no repeats
    if (word.Length > 0)
    {
        bool success = checkletters(i, letter, word, rand);
        while (success == false)
        {
            letter = (char)rand.Next(97, 103);
            success = checkletters(i, letter, word, rand);
        }
    }
    wordlist[i] = letter;
    word += letter;

}


//Get guesses
while (guess != word)
{
    guessNumber++;
    Console.Write($"Guess #{guessNumber}: Please guess a sequence of 4 lowercase letters with no repeats.");
    guess = Console.ReadLine();
    while (guess == null || guess.Length != 4)
    {
        Console.Write($"Guess #{guessNumber}: Please guess a sequence of 4 lowercase letters with no repeats.");
        guess = Console.ReadLine();
    }

    int places = 0, correctPosition = 0;
    for (int item = word.Length - 1; item >= 0; item--)
    {

        if (word[item] == guess[item]) correctPosition++;
        for (int i = guess.Length - 1; i >= 0; i--) if (word[item] == guess[i]) places++;
    }
    places -= correctPosition;
    Console.WriteLine($" - {correctPosition} in the right positions");
    Console.WriteLine($" - {places} in the wrong positions");

}


Console.Write($"You did it! You guessed my secret ({word}) in {guessNumber} guesses.");