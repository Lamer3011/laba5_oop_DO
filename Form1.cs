using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace laba5_oop
{
    public partial class Form1 : Form
    {
        List<Thread> myThreadsList = new List<Thread>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread currentThread = Thread.CurrentThread;
            this.Text = "Form" + currentThread.ManagedThreadId.ToString();
            currentThread.Name = this.Text;
            Name.Text = currentThread.Name;
            Alive.Text = currentThread.IsAlive.ToString();
            Id.Text = currentThread.ManagedThreadId.ToString();
            Priority.Text = currentThread.Priority.ToString();
            State.Text = currentThread.ThreadState.ToString();
        }

        void show_new_Form()
        {
            Application.Run(new Form1());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread myThread = new Thread(show_new_Form);
            myThread.Start();

            for (int i = 0; i < 5; i++)
            {
                label2.Text = ("Головний потік: " + i);
                Thread.Sleep(200);
            }

            myThreadsList.Add(myThread);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (myThreadsList.Count == 0)
            {
                return;
            }
            Thread myThread = myThreadsList.Last();
            myThread.Abort();
            myThreadsList.Remove(myThread);
        }
    }
}

