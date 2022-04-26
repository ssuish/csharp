using System.Reflection;

namespace Grade_Calculator
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonToSignup_Click(object sender, EventArgs e)
        {
            FormSignup signup = new FormSignup();
            this.Hide();
            signup.Show();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Security aes = new Security();

                string runTimeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string dataDirectory = Path.Combine(runTimeDirectory, "Data");
                StreamReader reader = new StreamReader(Path.Combine(dataDirectory, "userData.txt"));

                try
                {
                    var userInfo = string.Empty;
                    do
                    {
                        userInfo = reader.ReadLine();
                    }
                    while (reader.Peek() != -1);

                    string[] infoArr = aes.Decrypt(userInfo).Split(',');
                    string loginUsername = textBoxLogUsername.Text;
                    string loginPwrd = textBoxLogPwrd.Text;

                    string cap = string.Empty;
                    string msg = string.Empty;

                    if (infoArr[0] == loginUsername && infoArr[1] == loginPwrd)
                    {
                        cap = "Login Successful";
                        msg = "Welcome to Grade Calculator!";
                        MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormMain mainMenu = new FormMain();
                        this.Hide();
                        mainMenu.Show();
                    }
                    else
                    {
                        cap = "Login Failed";
                        msg = "Empty or Invalid Password!";
                        MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("File is Empty!");
                }
                finally
                {
                    reader.Dispose();
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fatal error occured.\n" + ex);
            }
        }

        private void buttonDeleteAcc_Click(object sender, EventArgs e)
        {
            try
            {
                string runTimeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string dataDirectory = Path.Combine(runTimeDirectory, "Data");
                string cap = "Account Deletion";
                string msg = "For your security, you're not able to recover password.   " +
                    "\nDo you wish to continue?";
                DialogResult delAccount = MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (delAccount == DialogResult.OK)
                {
                    File.Delete(Path.Combine(dataDirectory, "userData.txt"));
                    cap = "Account Deleted";
                    msg = "Your account is now deleted. Please sign-in again. Thank you!";
                    MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fatal error occured.\n" + ex);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            string cap = "Project Specification";
            string msg = "This project will be part of my fully featured Grade Calculator App.\n\n" +
                "Current Specifications:\n" +
                "- Midterm Calculator \n- Log-in Page with Authentication \n- Multi-Document Interface \n" +
                "- Database (Currently via Text File) \n- Menustrip (File toolstrip) " +
                " \n\n Thank you for your consideration";
            MessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}