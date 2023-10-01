using System.Collections.Generic;
using System.Runtime.CompilerServices;

internal class Program
{

    /// <WARNING>
    /// I do not endorse illegal activity of any kind. I also do not wish to enable anyone to perform illegal activity. 
    ///     This tool is strictly for educational purposes. 
    ///         You assume ALL liability when using this tool for illegal activity, or when converting this tool into a cyber-weapon of ANY kind.
    /// 
    /// It is ILLEGAL to attempt to crack passwords that you do not own, as well as systems that you do not own.
    /// </WARNING>

    /// <SUMMARY>
    /// This app is not intended to be used as a real-world brute-force password cracker, or "hacking tool" of any kind!
    /// It's merely an educational tool, to help people understand that the entropy of a password increases with the size of the password, and how their passwords could be reverse-engineered - so that they are better able to defend themselves.
    /// In that vein, using more characters and symbols will create a stronger password - which requires more combinations and iterations to crack.
    ///     At some point, the password becomes almost impossible to crack using a tool like this (Because of current resource constraints), 
    ///         And it'd then require a "slower" approach, which sacrifices speed for memory/resources efficiency,
    ///             meaning that your password may STILL be vulnerable (Even if this tool can't crack it) over a longer period of time.
    ///
    ///                 
    /// This application may also benefit anyone looking for an example of: How to implement the mathematical "Power Set" algorithm - to get ALL possible combinations of a given series of characters/numbers/symbols, although it does slightly differ because of the use-case.
    ///     This also means that the tool is able to - theoretically - crack ANY "password" with 100% accuracy, because it gets ALL possible combinations, 
    ///         but the tool is bound by modern computing resource-constraints,
    ///             because the Power Set becomes exponentially massive as the length of the "password" increases - and computers have only finite memory to use.
    /// 
    ///     The app can definitely be improved and made to be more efficient, 
    ///         but it is PURPOSELY designed to be user-UNfriendly and developer-UNfriendly to increase the difficulty of turning it into a cyber-weapon.
    ///             I also wrote this over a weekend, and will likely improve it at some point in the future - but may not release the improved version to public, for obvious reasons.
    /// </SUMMARY>

    ///<HOW_THE_APP_WORKS>
    /// Basically:
    ///     When started, the app will specify some parameters for you to work within.
    ///     When you input a random "password", the app will generate a hash for the "password", and then try to reverse-engineer that hash (Which should be impossible, because of how hashing works)
    /// </HOW_THE_APP_WORKS>

    ///<USAGE_INSTRUCTIONS>
    /// You can change the characters that the app needs to iterate over by changing the values of the "chars" array
    /// You can change how many characters the "password" needs to be, by editing the value of"passLength"
    /// 
    /// Note that, because this app finds every possible combination for the given set - up to the number of passlength - the output data set will be exponentially massive with each value increment of 1 for the "passlength".
    ///     so basically, the complexity of this application is akin to n^n -> where n = the number of characters to use to generate the resultant data set ( "lengthOfCharsArr")
    ///     this means that a 6 char "password", using 91 characters - to reverse-engineer, could use upwards of 40GB of host RAM.
    ///         *** Please exercise extreme caution when changing the values of "chars[]" and "passlength" ***
    /// </USAGE_INSTRUCTIONS>
 
    ///<Additional_Info>
    /// Hackers/"Malicious Actors"/"Threat actors" may sometimes manage to compromise a database of stored password hashes
    ///     (This isn't uncommon - since most passwords aren't stored in "plain English", but rather stored as hashes [Which are meant to be impossible to reverse-engineer - because hashing is a one-wayfunction])
    ///     The attacker would then use a tool like this, a rainbow-table or some other hybrid-tool, to attempt to reverse engineer that hash.
    ///     They could also use cyber-weapons similar this, to automatically send hundreds-of-thousands of login-attempts to a server (With your username), to "guess" the password and gain access.
    ///         This is why "Lockout counts" (Although annoying) are so important! They would effectively prevent the hacker from logging into your account, by locking your account after a few failed login attempts
    ///             But these could also be exploited to cause Denial Of Service (DOS) attacks, to prevent you (The user) from using a specific service.
    /// </Additional_Info>





    //private static readonly char[] chars = new char[91]{'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','1','2','3','4','5','6','7','8','9','0','`','~','!','@','#','$','%','^','&','*','(',')','_','+','{','}',':','<','>','/','\\','\'','"','[',']',',','.',' ',';'};
    //private static readonly char[] chars = new char[15]{ 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o' };
    private static readonly char[] chars = new char[5] { 'a', 'b', 'c', 'd', 'e'};
    //private static readonly char[] chars = new char[3] { 'a', 'b', 'c' };
    private static int lengthOfCharsArr = chars.Length;
    private static int passLength = 6;
    private static List<List<List<string>>> ListOfListsOfLists_AllPossibleCombs_ForThisManyPasswordChars_forSingleCharacter = new List<List<List<string>>>();
    private static string userInputHash = "";
    private static string autoGeneratedInputThatGaveUsOurHash = "";
    private static void Main(string[] args)
    {
        //clear up all variables
        clearAllVariables();
        //save our user's input -> this will also gen an MD5 hash for their "password"
        loadUpUserInput();
        //controller method -> will handle creating all the power sets and comparing the hashes to user input "password" hash
        Controller();
        //write output to console
        writeOutPut();
        //clear up all variables
        clearAllVariables();
    }



















    private static void clearAllVariables()
    {
        //clear ListOfListsOfLists_AllPossibleCombs_ForThisManyPasswordChars_forSingleCharacter
        ListOfListsOfLists_AllPossibleCombs_ForThisManyPasswordChars_forSingleCharacter.Clear();
        ListOfListsOfLists_AllPossibleCombs_ForThisManyPasswordChars_forSingleCharacter.TrimExcess();
        //clear userInputHash 
        userInputHash = string.Empty;
        // clear autoGeneratedInputThatGaveUsOurHash 
        autoGeneratedInputThatGaveUsOurHash = string.Empty;
    }

    private static void loadUpUserInput()
    {
        string str= "";
        foreach (char c in chars)
        {
            str += c+", ";
        }
        Console.WriteLine("Password Length is currently set to: {0}\r\n*Please use a TOTAL of {0} chars for the password*\r\nThese are the characters that you can use to create a password:\r\n{1}", passLength, str);
        Console.WriteLine("Please enter a password:");

        string? s = Console.ReadLine();
        userInputHash = getMD5ForUserInput(s);
    }

    private static void writeOutPut()
    {
        Console.WriteLine("User password was: " + autoGeneratedInputThatGaveUsOurHash);
    }

    private static void Controller()
    {
        //load up all the required characters
        intialLoadupOfOurFistCharList();
        //test each combination
        dataAccessor();
    }

    /// <summary>
    /// Access the data in our global list of lists of lists
    /// </summary>
    private static void dataAccessor()
    {
        //this is to stop execution if we've got the answer we wanted to find (Default to true, to do exec until it finds answer)
        bool continueExecution = true; 
        //get a count of the elements in the global array
        int countOfGlobalListOfListsOfLists = ListOfListsOfLists_AllPossibleCombs_ForThisManyPasswordChars_forSingleCharacter.Count;
        //iterate over every List of lists in the global array
        for (int i = 0; i < countOfGlobalListOfListsOfLists; i++)
        {
            //stop exec if we already have an answer
            if(continueExecution)
            {
                //get the size of the lists in our inner List
                int countOfCurrentInnerListOfList = ListOfListsOfLists_AllPossibleCombs_ForThisManyPasswordChars_forSingleCharacter[i].Count;
                //iterate over every List in the list of lists
                for (int j = 0; j < countOfCurrentInnerListOfList; j++)
                {
                    //stop exec if we already have an answer
                    if (continueExecution)
                    {
                        //pass the list to the MD5 function
                        continueExecution = getMd5_StagingMethod(ListOfListsOfLists_AllPossibleCombs_ForThisManyPasswordChars_forSingleCharacter[i][j]);
                    }
                }
            }
        }
    }

    /// <summary>
    /// This method will call the md5 function, and iterate through all possible combs
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    private static bool getMd5_StagingMethod(List<string> list)
    {
        bool continueExecution = true;
        List<string> newList = new List<string>();

        //foreach element in the list
        foreach (string autoGeneratedListItem in list)
        {
            //we want to now add a new char to the end of the element array
            for (int j = 0; j < lengthOfCharsArr; j++)
            {
                //stop exec if we already have an answer
                if (continueExecution)
                {
                    //create a temp string
                    string s = "";
                    //convert each str to a char[]
                    char[] carr = autoGeneratedListItem.ToCharArray();
                    int lengOfTempArr = ((carr.Length)); // Min1, because it needs to be 0-based index

                    if(lengOfTempArr < passLength)
                    {
                        //add each element to the new string
                        for (int i = 0; i < lengOfTempArr; i++)
                        {
                            s += carr[i];
                        }
                        //add a new char to the string
                        s += chars[j];
                        //add our newly replaced character to the new list
                        newList.Add(s);
                    }
                }
            }
            if(newList.Count>0)
            {
                continueExecution = getMD5ForGeneratedInput(newList);
                newList.Clear();
                newList.TrimExcess();
            }
        }
        //if we still don't have an answer - likely because newList+newChar didn't equal passleng
        if (continueExecution)
        {
            continueExecution = getMD5ForGeneratedInput(list);
        }
        return continueExecution;
    }

    /// <summary>
    /// calculate an MD5 for every given input, then compare the md5 to the MD5 we calculated on input
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    private static bool getMD5ForGeneratedInput(List<string> list)
    {
        string strInputThatMatchedTheHash = "";
        //for every item in the list
        foreach (string autoGeneratedListItem in list)
        {
            //only do stuff if our input is empty. No point asking a question if we already have an answer.
            if (strInputThatMatchedTheHash.Equals(""))
            {
                string hashForThisInputStr = "";
                //generate a new md5
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    //create a byte[] from the string in our list
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(autoGeneratedListItem);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);
                    //convert the hash to string
                    hashForThisInputStr = Convert.ToHexString(hashBytes); // .NET 5 and up. In .net 4 and lower, we need to do this manually (no method to do it for us)
                }
                //do the check after our md5 object is destroyed - to not keep it in memory unnecessarily
                //if the hash matches to what the user inputted, set our input to the string we've found to match the hash
                if (CompareHashes(hashForThisInputStr))
                {
                    strInputThatMatchedTheHash = autoGeneratedListItem;
                }
            }
        }
        //save the input that gave us the hash we wanted
        autoGeneratedInputThatGaveUsOurHash = strInputThatMatchedTheHash;
        //if we have an answer, we want to stop execution.
        return (strInputThatMatchedTheHash.Equals(""));
    }

    //simply get a hash for the combo a user has inputted
    private static string getMD5ForUserInput(string s)
    {
        string st = "";
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            //create a byte[] from the string in our list
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(s);
            //create a new byte[] that consists of the md5 hash of our input
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            //convert the hash to string
            st = Convert.ToHexString(hashBytes); // .NET 5 and up. In .net 4 and lower, we need to do this manually (no method to do it for us)
        }
        return st;
    }

    private static bool CompareHashes(string hashInput)
    {
        return (userInputHash.Equals(hashInput));
    }

    /// <summary>
    /// get the first char combination - saved to a list
    /// (later, we'll make this check if any of the hashes match to the hash of user)
    /// </summary>
    private static void intialLoadupOfOurFistCharList() 
    {
        //we only want to do this if the req no. of password chars is 1 or higher
        if (passLength >= 1)
        {
            //create a list to hold our data
            List<string> baseStringList_InitialChars = new List<string>();
            // for every char in the chars[]
            for (int i = 0; i < lengthOfCharsArr; i++)
            {
                //create a temp string to hold our character
                string s = "";
                s += chars[i];
                //add our string (of a single char) to the list
                baseStringList_InitialChars.Add(s);
            }

            // we only want to get all power sets if the password length is greater than 1 (-> else: we only generate and compare 1 char)
            if (passLength > 1)
            {
                int count = baseStringList_InitialChars.Count;
                secondLoadupAttempt(baseStringList_InitialChars, count, passLength - 1);
            }
            else if (passLength == 1)
            {
                //here, we want to compare the hash of single char to the input hash.. (since, at this point, we only have a single char)
                //Note: I could break this out into a separate method, but the storage implications of repeatedly copying and creating Lists<> could be too high (and we're already doing this quite a lot in the other methods..)
                    //because of the (unfortunately) badly optimized power set algorithm (Which nobody taught me to do in code, and I didn't have examples to follow along with), and current computing limitations, we should save space where we can -> this is one of those opportunities :)
                foreach (string s in baseStringList_InitialChars)
                {
                    //execute only if we don't already have an answer
                    if(autoGeneratedInputThatGaveUsOurHash.Equals(""))
                    {
                        //reuse the same method we had earlier to get a hash for a single string (This method will prod a hash for a single char)
                        if (CompareHashes(getMD5ForUserInput(s)))
                        {
                            autoGeneratedInputThatGaveUsOurHash = s;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// load up the second char in the password. 
    /// Functionally, this is slightly different to the recursive method (recurseAddBaseStringVariationsToLists) that gets all remaining chars
    ///     reason for this, is simply because the initial List (of a single char) requires only iteration over that list,
    ///        but, as the size of the power set grows, we need to iterate over multiple sets
    ///             this warrants a new method
    /// </summary>
    /// <param name="previousList"></param>
    /// <param name="countOfPreviousList"></param>
    /// <param name="noOfIterationsLeft"></param>
    private static void secondLoadupAttempt(List<string> previousList, int countOfPreviousList, int noOfIterationsLeft)
    {
        //we only want to iterate over chars and do stuff, if we need to (-> if there's another letter for us to try to get)
        if(noOfIterationsLeft >= 1)
        {
            //this list is going to store all combinations for all elements in the previous list (Remember, we need to now add every character to the end of each element to get all poss combs)
            List<List<string>> listOfAllPossibleCombs = new List<List<string>>();
            //for each element in the previous list -> we now need to add a set of chars to the end of each one
            for (int i = 0; i < countOfPreviousList; i++)
            {
                //get each item in the previous list
                string str = previousList[i];
                //create a list to hold all the new possible combs - for each item in previous list
                List<string> strList = new List<string>();
                //iterate - for each item, for lengthOfCharsArr - to add all possible combs to the end of it
                for (int j = 0; j < lengthOfCharsArr; j++)
                {
                    //for "str" - which was the previousElem - we want to add all possible combs
                    //for this purpose, leave str unchanged (so we can use it again)
                    //create a new string with the new char appended to the end
                    string copyOfStr = str;
                    //simply append the new char to the end..
                    copyOfStr += chars[j];
                    //save the new string (or char[] - if you want to think about it like that) to the list for this set
                    strList.Add(copyOfStr);
                }
                //once we've got a list of all new possible combs for THIS specific "row"/set in the previous list, add it to the new list
                listOfAllPossibleCombs.Add(strList);
            }
            //decrease the noOfIterationsLeft, because we don't want to go to next phase, if we already have the max chars
            noOfIterationsLeft--;

            //if noOfIterationsLeft is still > 1 (-> we still have some characters to get), get the remaining chars
            if (noOfIterationsLeft >= 1)
            {
                //calculate the no of elements of the current list
                int countOfCurrList = listOfAllPossibleCombs.Count;
                //call the recursive method to continue with the rest of the numbers, until there's no letters left to get
                recurseAddBaseStringVariationsToLists(listOfAllPossibleCombs, countOfCurrList, noOfIterationsLeft);
            }
            //else, we just save what we currently have
            else if (noOfIterationsLeft == 0)
            {
                ListOfListsOfLists_AllPossibleCombs_ForThisManyPasswordChars_forSingleCharacter.Add(listOfAllPossibleCombs);
            }
        }
    }
    /// <summary>
    /// Recursively load up all the remaining chars in the password
    /// </summary>
    /// <param name="ListOfList_previousCombinationsList"></param>
    /// <param name="countOfPreviousList"></param>
    /// <param name="noOfIterationsLeft"></param>
    private static void recurseAddBaseStringVariationsToLists(List<List<string>> ListOfList_previousCombinationsList, int countOfPreviousList, int noOfIterationsLeft)
    {
        if (noOfIterationsLeft >= 1)
        {
            //this list is going to store all combinations for all elements in the previous list (Remember, we need to now add every character to the end of each element to get all poss combs)
            List<List<string>> listOfAllPossibleCombs = new List<List<string>>();
            //for each element in the previous list -> Which was a List, itself
            for (int i = 0; i < countOfPreviousList; i++)
            {
                //calculate the size of the previous list's i-th element, so that we can iterate over all items in THAT list
                int countOfPreviousList_InnerList = ListOfList_previousCombinationsList[i].Count;
                //iterate over every element in that list
                for (int m = 0; m < countOfPreviousList_InnerList; m++)
                {
                    //get each item in the previous list's inner list
                    string str = ListOfList_previousCombinationsList[i][m];
                    //create a list to hold all the new possible combs - for each item in previous list
                    List<string> strList = new List<string>();
                    //iterate - for each item, for lengthOfCharsArr - to add all possible combs to the end of it
                    for (int j = 0; j < lengthOfCharsArr; j++)
                    {
                        //for "str" - which was the previousElem - we want to add all possible combs
                        //for this purpose, leave str unchanged (so we can use it again)
                        //create a new string with the new char appended to the end
                        string copyOfStr = str;
                        //simply append the new char to the end..
                        copyOfStr += chars[j];
                        //save the new string (or char[] - if you want to think about it like that) to the list for this set
                        strList.Add(copyOfStr);
                    }
                    //once we've got a list of all new possible combs for THIS specific "row"/set in the previous list, add it to the new list
                    listOfAllPossibleCombs.Add(strList);
                }
            }
            //decrease the noOfIterationsLeft, because we don't want to go to next phase, if we already have the max chars
            noOfIterationsLeft--;

            //if noOfIterationsLeft is still > 1 (IF we still have some characters to get), get the remaining chars
            if (noOfIterationsLeft >= 1)
            {
                //get the no of elements of the current list
                int countOfCurrList = listOfAllPossibleCombs.Count;
                //call the recursive method to continue with the rest of the numbers
                recurseAddBaseStringVariationsToLists(listOfAllPossibleCombs, countOfCurrList, noOfIterationsLeft);
            }

            //only on the LAST run/iteration, we want to save the data to a global variable, so that we can access it from other parts of our program
            if(noOfIterationsLeft == 0)
            {
                //add the current list to uor global list of lists of lists..
                ListOfListsOfLists_AllPossibleCombs_ForThisManyPasswordChars_forSingleCharacter.Add(listOfAllPossibleCombs);
            }
        }
    }
}