namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Button[,] buttons = new Button[10,10];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    buttons[i, j] = new Button()
                    {
                        Name = $"{i}{j}",
                        Text = $"",
                        Size = new System.Drawing.Size(40, 40),
                        Margin = new System.Windows.Forms.Padding(0, 0, 0, 0),
                        Tag = new ButtonState(i, j, random.Next(0, 10) < 1),
                        TabStop = true,
                    };
                    buttons[i, j].Click += buttons_Click;
                    tableLayoutPanel1.Controls.Add(buttons[i, j], j, i);
                }
            }
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ButtonState state = (ButtonState)button.Tag;
           
            if (state.IsBomb)
            {
                button.Text = "*";
            }
            else
            {
                int countBomb = CheckBomb(state);
                button.Text = countBomb.ToString();
                button.Enabled = false;
                if (countBomb == 0)
                {
                    OpenArroundZeroButtons(state);
                }
                
            }

        }

        private void OpenArroundZeroButtons(ButtonState state)
        {
            for (int i = state.I - 1; i <= state.I + 1; i++)
            {
                for (int j = state.J - 1; j <= state.J + 1; j++)
                {
                    if (i > -1 && j > -1 && i < 10 && j < 10)
                    {
                        if (buttons[i, j].Enabled == true)
                        {
                            buttons_Click(buttons[i, j], null);
                        }
                    }
                }
            }
        }

        private int CheckBomb(ButtonState state)
        {
            int countBomb = 0;
            for (int i = state.I-1; i <= state.I + 1; i++)
            {
                for (int j = state.J-1; j <= state.J+1; j++)
                {
                    if (i > -1 && j > -1 && i < 10 && j < 10)
                    {
                        ButtonState checkedState = (ButtonState)buttons[i, j].Tag;
                        if (checkedState.IsBomb)
                        {
                            countBomb++;
                        }
                    }
                }
            }
            return countBomb;
        }
    }
}
