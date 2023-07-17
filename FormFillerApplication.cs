using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace FormFillerApp
{
    public partial class FormFillerApplication : Form
    {
        public FormFillerApplication()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserInput.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
        }
        /*Here are some commonly used regex metacharacters and their meanings:

        . (dot): Matches any single character except a newline.
        *: Matches zero or more occurrences of the preceding element.
        +: Matches one or more occurrences of the preceding element.
        ?: Matches zero or one occurrence of the preceding element.
        []: Matches any single character within the brackets.
        ^: Matches the start of a string.
        $: Matches the end of a string.
        \d: Matches any digit character (0-9).
        \w: Matches any word character (a-z, A-Z, 0-9, and underscore).
        \s: Matches any whitespace character (space, tab, newline, etc.).
        \b: Matches a word boundary.
        */

        /* How regular expressions work
        The block of code below extracts the name, address, and email from the userInput string using regular expressions.
        
        - The name is extracted using the regex pattern @"Name:\s*([\w\s]+?)(?=\r?\nAddress:|$)".
        - The pattern matches the text "Name:" followed by any number of word characters and whitespace characters.
        - The captured name is stored in the 'name' variable, and leading/trailing whitespace is trimmed.
        
        - The address is extracted using the regex pattern @"Address:\s*([\s\S]+?)(?:\r?\n(?:Email:|$))".
        - The pattern matches the text "Address:" followed by any number of characters (including newlines).
        - The captured address is stored in the 'address' variable, and leading/trailing whitespace is trimmed.
        
        - The email is extracted using the regex pattern @"Email:\s*([a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+)".
        - The pattern matches the text "Email:" followed by a valid email address pattern.
        - The captured email is stored in the 'email' variable.
          
        "Leading/trailing whitespace is trimmed" refers to the removal of any whitespace characters (such as spaces, tabs, or newlines) at the beginning or end of a string.
        */
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string userInput = txtUserInput.Text;

            // Extract name from userInput

            string namePattern = @"Name:\s*([\w\s]+?)(?=\r?\nAddress:|$)";
            Match nameMatch = Regex.Match(userInput, namePattern);
            string name = nameMatch.Success ? nameMatch.Groups[1].Value.Trim() : "";

            // Extract address from userInput

            string addressPattern = @"Address:\s*([\s\S]+?)(?:\r?\n(?:Email:|$))";
            Match addressMatch = Regex.Match(userInput, addressPattern);
            string address = addressMatch.Success ? addressMatch.Groups[1].Value.Trim() : "";

            // Extract email from userInput

            string emailPattern = @"Email:\s*([a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+)";
            Match emailMatch = Regex.Match(userInput, emailPattern);
            string email = emailMatch.Success ? emailMatch.Groups[1].Value : "";

            // Display error message if any field is empty

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all the fields.", "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Fill the form fields
            txtName.Text = name;
            txtAddress.Text = address;
            txtEmail.Text = email;

            MessageBox.Show("Form filled successfully!");

        }

    }
}
