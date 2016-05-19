using System;
using System.Collections.Generic;
using System.Linq;
class HandsOfCards
{
    static void Main(string[] args)
    {
        Dictionary<string, HashSet<string>> dictList = new Dictionary<string, HashSet<string>>();
        HashSet<string> playerCards = new HashSet<string>();
        string input = Console.ReadLine();
        while (input != "JOKER")
        {
            string[] command = input.Split(':');
            string name = command[0];
            string cardsCommand = command[1];
            string[] cards = cardsCommand.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < cards.Length; i++)
            {
                string currentCard = cards[i];          
                currentCard = currentCard.Replace("0", "");
                if (!dictList.ContainsKey(name))
                    dictList[name] = new HashSet<string>();
                playerCards.Add(currentCard);
            }
            foreach (var item in playerCards)
                dictList[name].Add(item);
            playerCards.Clear();
            input = Console.ReadLine();
        }
        foreach (var kvp in dictList)
        {
            long score = 0;
            for (int i = 0; i < kvp.Value.Count; i++)
            {
                score = 0;
                foreach (var item in kvp.Value)
                {
                    char card = item[0];
                    char type = item[1];
                    score += CardValue(card, type);
                }
            }
            Console.WriteLine("{0}: {1}", kvp.Key, score);
        }
    }
    public static int CardValue(char card, char type)
    {
        int cardValue = 0;
        int typeValue = 0;
        int result = 1;
        switch (card)
        {
            case '2':
                cardValue = 2;
                break;
            case '3':
                cardValue = 3;
                break;
            case '4':
                cardValue = 4;
                break;
            case '5':
                cardValue = 5;
                break;
            case '6':
                cardValue = 6;
                break;
            case '7':
                cardValue = 7;
                break;
            case '8':
                cardValue = 8;
                break;
            case '9':
                cardValue = 9;
                break;
            case '1':
                cardValue = 10;
                break;
            case 'J':
                cardValue = 11;
                break;
            case 'Q':
                cardValue = 12;
                break;
            case 'K':
                cardValue = 13;
                break;
            case 'A':
                cardValue = 14;
                break;
        }
        switch (type)
        {
            case 'S':
                typeValue = 4;
                break;
            case 'H':
                typeValue = 3;
                break;
            case 'D':
                typeValue = 2;
                break;
            case 'C':
                typeValue = 1;
                break;                
        }
        result = typeValue * cardValue;
        return result;
    }
}