using System.Text.RegularExpressions;  

namespace technical_assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create lists for email address, valid, and invalid addresses
            var emailAdd = new List<string>();
            var valid = new List<string>();
            var invalid = new List<string>();

            // Prompt user for File name
            Console.WriteLine("What is the name of the file you're looking for?: ");

            string fileName = Console.ReadLine();

            // File path string
            string filePath = @$"C:\Users\Savon Nur\Desktop\csv\{fileName}.csv";

            // Check if File exists
            if(File.Exists(filePath))
            {
              
              // Read the contents of the CSV file as individual lines
              string[] csvLines = System.IO.File.ReadAllLines(filePath);
              
              // For loop to iterate through each row
              for(int i = 1; i < csvLines.Length; i++){
                // Split each row into column data
                string[] rowData = csvLines[i].Split(',');

                // Add the email column data to the emailAdd list
                emailAdd.Add(rowData[2]);
              }

              // Iterate through email address list
              for(int j = 0; j < emailAdd.Count; j++)
              {
                string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

                // If email is valid, add it to valid list, else add it to invalid list
                if (Regex.IsMatch(emailAdd[j] , pattern))
                {    
                    valid.Add(emailAdd[j]);
                }
                else
                {
                  invalid.Add(emailAdd[j]);
                }
              }

              // Print valid email addresses
              Console.WriteLine("VALID EMAIL ADDRESSES");
              for(int x = 0; x < valid.Count; x++)
              {
                Console.WriteLine(valid[x]);
              }

              // Print invalid email addresses
              Console.WriteLine("\nINVALID EMAIL ADDRESSES");
              for(int y = 0; y < invalid.Count; y++)
              {
                Console.WriteLine(invalid[y]);
              }
              
            }
            else
            {
              // Return error is file does not exist
              Console.WriteLine("Error: File Does Not Exist!");
            }
            
            // Press key to end program
            Console.ReadKey();
        }
    }
}