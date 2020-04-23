using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        int result1, result2, result3;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startQuizz_Click(object sender, EventArgs e)
        {
            //
            elementOperation1.Text = randomizer.Next(10).ToString();
            elementOperation2.Text = randomizer.Next(10).ToString();
            elementOperation3.Text = randomizer.Next(10).ToString();
            elementOperation4.Text = randomizer.Next(10).ToString();
            elementOperation5.Text = randomizer.Next(10).ToString();
            elementOperation6.Text = randomizer.Next(10).ToString();
            result1 = Int32.Parse(elementOperation1.Text) + Int32.Parse(elementOperation2.Text);
            result2 = Int32.Parse(elementOperation3.Text) * Int32.Parse(elementOperation4.Text);
            result3 = Int32.Parse(elementOperation5.Text) - Int32.Parse(elementOperation6.Text);

            startQuizz.Enabled = false;
            startQuizz.Visible = false;
            endQuizz.Enabled = true;
            startQuizz.Visible = false;
            endQuizz.Visible = true;
            response1.Enabled = true;
            response2.Enabled = true;
            response3.Enabled = true;
        }

        // When user wish to end the quizz
        private void endQuizz_Click(object sender, EventArgs e)
        {
            // Collect response
            // Compare
            // Give the number of good response
            int response1Int, response2Int, response3Int;
            var isParsed = Int32.TryParse(response1.Text, out response1Int);
            var isParsed2 = Int32.TryParse(response2.Text, out response2Int);
            var isParsed3 = Int32.TryParse(response3.Text, out response3Int);
            if(response1Int == result1)
            {
                hiddenResponse1.Text = "Good";
            }
            else
            {
                hiddenResponse1.Text = $"Fail. Response {result1}";
            }
            if (response1Int == result1)
            {
                hiddenResponse1.Text = "Good";
            }
            else
            {
                hiddenResponse1.Text = "Fail";
            }
            if (response2Int == result2)
            {
                hiddenResponse2.Text = "Good";
            }
            else
            {
                hiddenResponse2.Text = $"Fail. Response {result1}";
            }
            if (response3Int == result3)
            {
                hiddenResponse3.Text = "Good";
            }
            else
            {
                hiddenResponse3.Text = $"Fail. Response {result3}";
            }
            hiddenResponse1.Visible = true;
            hiddenResponse2.Visible = true;
            hiddenResponse3.Visible = true;
            endQuizz.Visible = false;
            response1.Enabled = false;
            response2.Enabled = false;
            response3.Enabled = false;
        }
    }
}
