namespace ExtractTheVowels;

public partial class MainPage : ContentPage { 

    //default array of vowels
	char[] arrayOfVowels = new char[] { 'a', 'e', 'i', 'o', 'u'};

    public MainPage()
	{
		InitializeComponent();
	}

	private void onExtractBtnClicked(object sender, EventArgs e)
	{
        //stores data entered by the user
		var userInput = entry.Text;

        //stores list of extracted vowel characters
        var extractedVowelList = new List<char>();

        //validates if the user input is empty or not
        if (userInput == null || userInput == "")
        {
            errorMsg.Text = "Word field cannot be empty.";
            errorMsg.IsVisible = true;
            resultMsg.IsVisible = false;
        }
        //validated whether user has given two or more words
        else if (userInput.Trim().Contains(" ")) {
            errorMsg.Text = "Please enter only one word.";
            errorMsg.IsVisible = true;
            resultMsg.IsVisible = false;
        }
        //main logic
        else {
            //loop for characters inside of the word
            foreach (char i in userInput) {
            //loop for arrayOfVowels
                foreach (char letter in arrayOfVowels)
                {
                    //compares the character of user input with a vowel array
                    if (i == letter)
                    {
                        extractedVowelList.Add(i);
                        break; //vowel array loop breaks if the letter matches
                    }
                }
            }

            //to display the extracted vowel letters if they have any
            if (extractedVowelList.Count != 0)
            {
                var result = "The vowel letters in the word are: \n";

                foreach (char i in extractedVowelList)
                {
                    result += $"{i} ";
                }
                //provides the result message
                resultMsg.Text = result;
                resultMsg.IsVisible = true;
            }
            else {
                //displays if the word has no vowel letters
                resultMsg.Text = "There are no vowel letters in the word.";
                resultMsg.IsVisible = true;
            }
        }

        SemanticScreenReader.Announce(Extractbtn.Text);
	}
}


