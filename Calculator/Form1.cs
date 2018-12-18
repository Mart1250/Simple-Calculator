using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            outputT.AppendText("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            outputT.AppendText("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            outputT.AppendText("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            outputT.AppendText("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            outputT.AppendText("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            outputT.AppendText("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            outputT.AppendText("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            outputT.AppendText("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            outputT.AppendText("9");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            outputT.AppendText("0");
        }

        private void addB_Click(object sender, EventArgs e)
        {
            outputT.AppendText("+");
        }

        private void substractB_Click(object sender, EventArgs e)
        {
            outputT.AppendText("-");
        }

        private void multiplyB_Click(object sender, EventArgs e)
        {
            outputT.AppendText("*");
        }

        private void divideB_Click(object sender, EventArgs e)
        {

            outputT.AppendText("/");

        }

        private void backB_Click(object sender, EventArgs e)
        {
            string input = outputT.Text;
            char[] buffer = input.ToCharArray();
            char[] resultbuffer = { };
            string result;

            if (buffer.Length > 0)
            {
                resultbuffer = new char[buffer.Length - 1];
            }

            if (buffer != null && buffer.Length > 0)
            {

                for (int i = 0; i < (buffer.Length - 1); i++)
                {
                    resultbuffer[i] = buffer[i];
                }

                result = new string(resultbuffer);

                outputT.Text = result;
            }


        }

        private void processB_Click(object sender, EventArgs e)
        {

            string input = outputT.Text;
            char[] buffer = input.ToArray();
            char[] resultbuffer = { };
            int? result = null;
            int? tempresult = null;
            string stringresult;
            char lastoperator = ' ';
            char lastoperatorbefore = ' ';
            UInt32 currentchar;

            foreach (char @char in buffer)
            {

                if (UInt32.TryParse(@char.ToString(), out currentchar))
                {

                    //MessageBox.Show("currentchar: " + currentchar + "lastoperator: " + lastoperator);

                    if (lastoperator != ' ')
                    {

                        tempresult = Convert.ToInt32(string.Format("{0}{1}", tempresult, currentchar));

                    }
                    else
                    {

                        result = Convert.ToInt32(string.Format("{0}{1}", result, currentchar));
                        //MessageBox.Show("switch: " + result);

                    }

                }
                else
                {

                    if (tempresult != null)
                    {
                        switch (lastoperatorbefore)
                        {
                            case '+':
                                result = result + tempresult;
                                //MessageBox.Show("else" + result);
                                tempresult = null;
                                break;
                            case '-':
                                result = result - tempresult;
                                tempresult = null;
                                break;
                            case '*':
                                result = result * tempresult;
                                tempresult = null;
                                break;
                            case '/':
                                result = result / tempresult;
                                tempresult = null;
                                break;
                            default:
                                break;
                        }
                    }

                    switch (@char)
                    {
                        case '+':
                            tempresult = null;
                            lastoperator = '+';
                            lastoperatorbefore = '+';
                            break;
                        case '-':
                            tempresult = null;
                            lastoperator = '-';
                            lastoperatorbefore = '-';
                            break;
                        case '*':
                            tempresult = null;
                            lastoperator = '*';
                            lastoperatorbefore = '*';
                            break;
                        case '/':
                            tempresult = null;
                            lastoperator = '/';
                            lastoperatorbefore = '/';
                            break;

                        default:
                            break;
                    }

                }

            }


            if (tempresult != null)
            {
                switch (lastoperatorbefore)
                {
                    case '+':
                        result = result + tempresult;
                        //MessageBox.Show("else" + result);
                        tempresult = null;
                        break;
                    case '-':
                        result = result - tempresult;
                        tempresult = null;
                        break;
                    case '*':
                        result = result * tempresult;
                        tempresult = null;
                        break;
                    case '/':
                        result = result / tempresult;
                        tempresult = null;
                        break;
                    default:
                        break;
                }
            }


            stringresult = result.ToString();

            outputT.Text = stringresult;

            /*int i;
            int j;
            int a = 0;
            int q = 0;
            int num;
            int almostend = 0; //bijna het einde van programma variable.
            string conversionnum;

            string output = outputT.Text;
            char[] outputinchars = new char[150];
            outputinchars = output.ToArray();
            char[] tempchars = new char[150];
            List<KeyValuePair<int, char>> numparts = new List<KeyValuePair<int, char>>();
            //Dictionary<int, char> numparts = new Dictionary<int, char>();
            int lastoploc = 0; //-1 omdat er in de for lastoploc + 1 wordt gebruikt; Je begint met tellen na het operator teken.


            for (i = 0; i < outputT.TextLength; ++i)
            {
                
                //q++;
                    MessageBox.Show("" + i);
                switch (outputinchars[i])
                {


                    case '+':

                        //tempchars = new char[i - lastoploc]; //even checken of dit binnen de range valt.

                        for (j = (lastoploc); j < i; ++j) //aflopen tot de operator +;
                        {


                            tempchars[a++] = outputinchars[j];
                            MessageBox.Show("dsdfs");

                            if ((i-1) == outputT.TextLength)
                            {
                                //tempchars = new char[(i+1) - lastoploc]; //even checken of dit binnen de range valt.
                                MessageBox.Show("test");
                                for (j = (lastoploc); j < i; j++) //aflopen tot de operator +;
                                {


                                    tempchars[a++] = outputinchars[j];
                                    MessageBox.Show("aaaa");

                                    if (j == i)
                                    {
                                        conversionnum = null;
                                        conversionnum = new string(tempchars);
                                        int.TryParse(conversionnum, out num);

                                        numparts.Add(new KeyValuePair<int, char>(num, ' '));
                                        //numparts.Add(num, '+');


                                        MessageBox.Show("" + numparts[a]);
                                        j = 0;
                                        a = 0;
                                        num = 0;
                                        lastoploc = i+1;
                                        //tempchars = new char[0];
                                        conversionnum = null;



                                        Array.Clear(tempchars, 0, tempchars.Length);

                                    }

                                }
                            }else if (j == i) //i-1 omdat i de operator zelf is.
                            {
                                conversionnum = new string(tempchars);
                                int.TryParse(conversionnum, out num);

                                numparts.Add(new KeyValuePair<int, char>(num, '+'));
                                //numparts.Add(num, '+');

                                j = 0;
                                a = 0;
                                num = 0;
                                lastoploc = i+1;
                                //tempchars = new char[0];
                                conversionnum = null;
                                MessageBox.Show("" + numparts[0]);

                                MessageBox.Show("j == i");

                                Array.Clear(tempchars, 0, tempchars.Length);

                            }

                        }

                        break;

                }
            

        }*/




        }

    }

}






/*


            string input = outputT.Text;
            char[] buffer = input.ToArray();
            char[] resultbuffer = { };
            int ? result = null;
            int ? tempresult = null;
            string stringresult;
            char lastoperator = ' ';
            char lastoperatorbefore = ' ';
            UInt32 currentchar;

            foreach (char @char in buffer)
            {

                if (UInt32.TryParse(@char.ToString(), out currentchar))
                {

                    MessageBox.Show("currentchar: " + currentchar + "lastoperator: " + lastoperator);

                    if (lastoperator != ' ')
                    {

                        tempresult = Convert.ToInt32(string.Format("{0}{1}", tempresult, currentchar));

                    }
                    else
                    {

                        result = Convert.ToInt32(string.Format("{0}{1}", result, currentchar));
                        MessageBox.Show("switch: " + result);

                    }

                }
                else
                {

                    if(tempresult != null)
                    {
                        switch (lastoperatorbefore)
                        {
                            case '+':
                                result = result + tempresult;
                                MessageBox.Show("else" + result);
                                tempresult = null;
                                break;
                            case '-':
                                result = result - tempresult;
                                tempresult = null;
                                break;
                            case '*':
                                result = result * tempresult;
                                tempresult = null;
                                break;
                            case '/':
                                result = result / tempresult;
                                tempresult = null;
                                break;
                            default:
                                break;
                        }
                    }

                    switch (@char)
                    {
                        case '+':
                            tempresult = null;
                            lastoperator = '+';
                            lastoperatorbefore = '+';
                            break;
                        case '-':
                            tempresult = null;
                            lastoperator = '-';
                            lastoperatorbefore = '-';
                            break;
                        case '*':
                            tempresult = null;
                            lastoperator = '*';
                            lastoperatorbefore = '*';
                            break;
                        case '/':
                            tempresult = null;
                            lastoperator = '/';
                            lastoperatorbefore = '/';
                            break;

                        default:
                            break;
                    }

                }

            }


            if (tempresult != null)
            {
                switch (lastoperatorbefore)
                {
                    case '+':
                        result = result + tempresult;
                        MessageBox.Show("else" + result);
                        tempresult = null;
                        break;
                    case '-':
                        result = result - tempresult;
                        tempresult = null;
                        break;
                    case '*':
                        result = result * tempresult;
                        tempresult = null;
                        break;
                    case '/':
                        result = result / tempresult;
                        tempresult = null;
                        break;
                    default:
                        break;
                }
            }


            stringresult = result.ToString();

            outputT.Text = stringresult;



 
*/

/*switch (lastoperator)
{
    case '+':

        tempresult = Convert.ToInt32(string.Format("{0}{1}", tempresult, currentchar));

        //result = result + (int)currentchar;
        MessageBox.Show("+" + tempresult);
        //lastoperator = ' ';
        break;
    case '-':

        tempresult = Convert.ToInt32(string.Format("{0}{1}", tempresult, currentchar));
        MessageBox.Show("before: -" + result);
        result = result - (int)currentchar;
        MessageBox.Show("" + result);
        lastoperator = ' ';

        break;
    case '*':

        tempresult = Convert.ToInt32(string.Format("{0}{1}", tempresult, currentchar));

        result = (int)(result * currentchar);
        //MessageBox.Show("*" + result);
        lastoperator = ' ';

        break;
    case '/':

        tempresult = Convert.ToInt32(string.Format("{0}{1}", tempresult, currentchar));

        result = (int)(result / currentchar);
        //MessageBox.Show("/" + result);
        lastoperator = ' ';

        break;

        default:
            result = Convert.ToInt32(string.Format("{0}{1}", result, currentchar));
            lastoperator = ' ';
            MessageBox.Show("switch: " + result);
            break;
}*/
