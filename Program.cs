// ask for input
Console.WriteLine("Enter 1 to create movie file.");
Console.WriteLine("Enter 2 to parse movies.");
Console.WriteLine("Enter 3 to search movies.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();
DateTime today = DateTime.Now;


if (resp == "1")
{
    // gets the index of our new entry by referring to the last index
    string newEntry = Int32.Parse(File.ReadLines("movies.csv").Last().Split(",")[0]) + 1 + ",";
    
    // creates movie based on user input -- does not allow duplicate titles
    while(true){
        Console.Write("What is the title of your movie?\n > ");
        string titleEntry = Console.ReadLine();

        Console.Write("What year did your movie come out?\n > ");
        titleEntry += " (" + Console.ReadLine() + ")";
    
        if(titleEntry.Contains(",")) {titleEntry = ('"' + titleEntry + '"');}

        Console.WriteLine(titleEntry);

        if(System.IO.File.ReadAllText("movies.csv").Contains(titleEntry)){
            Console.WriteLine("This movie is already in the collection, please try again.\n");
        }
        else{
            newEntry += titleEntry + ","; 
            int count = 0;
            while(true){
                Console.Write("Please enter either a genre or 0 to quit:\n > "); string userInput = Console.ReadLine();
                if(userInput == "0" && count == 0) newEntry += "(no genres listed)";
                else if(userInput == "0") {
                    newEntry = newEntry.Remove(newEntry.Length - 1, 1); 
                    break;
                }
                else{
                    ++count;
                    newEntry += userInput + "|";
                }
            }
            break;
        }
    }
        
    // create file
    Console.Write("Entry created: " + newEntry);
    using (StreamWriter sw = File.AppendText("movies.csv")){
        sw.WriteLine(newEntry);
    };

}
else if (resp == "2")
{
    // 1. Program takes in all information from file
    string txtReadOut = new StreamReader("movies.csv").ReadToEnd();;
    // 2. Program strips all information down to lines, skipping the final blank one
    List<string> lines = new List<string>(txtReadOut.Split("\n").SkipLast(1));

    foreach(string line in lines){
        if(line.Contains('"')) continue;
        Console.WriteLine(line.Split(",")[1]);
    }
}

else if (resp == "3")
{
    Console.Write("What would you like to search? > "); string entry = Console.ReadLine();

    
}