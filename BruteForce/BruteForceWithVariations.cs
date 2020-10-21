public class BruteForceWithVariations
{
    private void buttonRun_Click(object sender, EventArgs e)
    {
        //bruteForce1();
        bruteForce2();
    }

    private void bruteForce1()
    {
        int count = 0;
        var digits = new char[10];
        for (char i = '0'; i <= '9'; i++)
        {
            digits[count] = i;
            count++;
        }
        count = 0;
        var chars = new char[26];
        for (char i = 'a'; i <= 'z'; i++)
        {
            chars[count] = i;
            count++;
        }

        var allElements = digits.Concat(chars).ToArray();
        string all = "";
        foreach (var n in allElements)
        {
            all += n.ToString();
        }


        for (int i = 1; ; i++)
        {
            var pass = new int[i];


            do
            {
                var passChars = pass
                    .Select(s => allElements[s])
                    .ToArray();

                SendTextAndClick(new String(passChars));
            }
            while (Next(36, pass));
        }
    }

    #region test1
    private void printNCharPwd(string prefix, int num, char[] allElements)
    {
        counter++;

        if (num == 0)
        {
            SendTextAndClick(prefix);
            passed[counter] = prefix;

            return;
        }
        for (int i = 0; i < allElements.Length; i++)
        {
            if (prefix.Length == 0)
            {
                if (!passed.Contains(prefix + allElements[i]))
                {
                    passed[counter] = prefix + allElements[i];
                }

                printNCharPwd(prefix + allElements[i], num - 1, allElements);

            }
            else
            {
                if (passed.Contains(prefix[prefix.Length - 1].ToString() + allElements[i]))
                {
                    int n = Array.IndexOf(passed, prefix[prefix.Length - 1].ToString() + allElements[i]);
                    SendTextAndClick(passed[n]);
                }
                else
                {
                    passed[counter - 1] = prefix[prefix.Length - 1].ToString() + allElements[i];
                    SendTextAndClick(passed[counter - 1]);
                }

                printNCharPwd(prefix[prefix.Length - 1].ToString() + allElements[i], num - 1, allElements);

            }
        }
    }
    #endregion

    public static string[] passed = new string[36 * 36 * 36];
    public static Dictionary<string, string> map = new Dictionary<string, string>();
    public static Dictionary<string, string> temp = new Dictionary<string, string>();
    public int counter = 0;
    private void bruteForce2()
    {
        int count = 0;
        var digits = new char[10];
        for (char i = '0'; i <= '9'; i++)
        {
            digits[count] = i;
            count++;
        }
        count = 0;
        var chars = new char[26];
        for (char i = 'a'; i <= 'z'; i++)
        {
            chars[count] = i;
            count++;
        }

        var allElements = digits.Concat(chars).ToArray();

        for (int i = 1; ; i++)
        {
            var pass = new int[i];

            if (i > 2)
            {
                for (int k = 0; k < passed.Length; k++)
                {
                    for (int j = 0; j < allElements.Length; j++)
                    {
                        string str = allElements[j] + passed[k];
                        SendTextAndClick(str);
                    }
                }
                continue;
            }

            do
            {
                var passChars = pass
                    .Select(s => allElements[s])
                    .ToArray();

                SendTextAndClick(new String(passChars));
                passed[counter] = new String(passChars);
                counter++;
                //map.Add(new String(passChars), "");
            }
            while (Next(36, pass));
        }
        #region test
        /*for (int i = 1; ; i++)
        {
            char[] charse = new char[i];
            counter = 0;
        */
        //printNCharPwd("", charse.Length, allElements);
        //printRess(charse, allElements);
        /* int initialSize = 0;
         if (i == 1)
         {
             for (int j = 0; j < allElements.Length; j++)
             {
                 SendTextAndClick(allElements[j].ToString());
                 passed[j] = allElements[j].ToString();
             }
         }
         else
         {
             for (int j = 0; j < allElements.Length; j++)
             {
                 for (int k = 0 + initialSize; k < 36; k++)
                 {
                     string txt = allElements[j].ToString() + passed[k];
                     SendTextAndClick(txt);
                     passed[k + 36] = txt;
                 }
             }
             initialSize += 36;
         }
     }
     */


        /* for (int i = 1; ; i++)
         {
             var pass = new int[i];

             do
             {
                 if (map.LongCount() != 0)
                 {
                     string key = "";
                     for (int j = 1; j < pass.Length; j++)
                     {
                         key += pass[j].ToString() + " ";
                     }
                     if (map.ContainsKey(key))
                     {
                         SendTextAndClick(map[pass[0].ToString() + " "] + map[key]);
                         continue;
                     }
                 }

                 var passChars = pass
                     .Select(s => allElements[s])
                     .ToArray();

                 string key1 = "";
                 string value = "";

                 for (int j = 0; j < pass.Length; j++)
                 {
                     key1 += pass[j].ToString() + " ";
                     value += passChars[j];
                 }
                  map.Add(key1, value);

                 SendTextAndClick(new String(passChars));
             }
             while (Next(36, pass));
         }
        */
        #endregion
    }

    public static bool Next(int n, int[] vals)
    {
        var k = vals.Length;

        vals[k - 1]++;
        for (int i = k - 1; i > 0; i--)
        {
            if (vals[i] >= n)
            {
                vals[i] = 0;
                vals[i - 1]++;
            }
        }

        return vals[0] < n;
    }
}
