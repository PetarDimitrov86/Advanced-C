using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
class OlympicsAreComming
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string whiteSpacePattern = @"\s{2,}";
        Regex whiteSpaceReplace = new Regex(whiteSpacePattern);
        Dictionary<string, Dictionary<string, int>> countryWins = new Dictionary<string, Dictionary<string, int>>();
        while (input != "report")
        {
            string removedExtraSpaces = whiteSpaceReplace.Replace(input, " ");
            string[] playerCountrySplit = removedExtraSpaces.Split('|');
            string player = playerCountrySplit[0].Trim();
            string country = playerCountrySplit[1].Trim();
            if (!countryWins.ContainsKey(country))
            {
                countryWins.Add(country, new Dictionary<string, int>());
            }
            if (!countryWins[country].ContainsKey(player))
            {
                countryWins[country].Add(player, 0);
            }
            countryWins[country][player]++;
            input = Console.ReadLine();
        }
        var sorted = countryWins.OrderByDescending(x => x.Value.Values.Sum());
        foreach (var item in sorted)
        {
            Console.WriteLine("{0} ({1} participants): {2} wins", item.Key, item.Value.Count, item.Value.Values.Sum());
        }
    }
}