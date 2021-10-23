using Db4objects.Db4o;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace Lap5Cosodulieu
{
    public partial class Form1 : Form
    {
        
        private object pilotdb1;
        IObjectContainer db = null;
        IObjectSet result = null;
        public Form1()
        {
            InitializeComponent();
       
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            Employee template = new Employee();
            result = db.QueryByExample(template);
            dtgvShow.DataSource = result;
        }

        private void dtgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = Db4oEmbedded.OpenFile("pilotdb1.yap");
            loadData();

        }
        private void loadData()
        {
            Dependent template = new Dependent();
            result = db.QueryByExample(template);
            dtgvShow.DataSource = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Dependent template = new Dependent();
            result = db.QueryByExample(template);
            dtgvShow.DataSource = result;
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Database.CreateEmployees(db, "C:\\Users\\PC\\source\\repos\\Lap5Cosodulieu\\Lap5Cosodulieu\\bin\\Debug\\employee.txt");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Database.CreateDependents(db, "C:\\Users\\PC\\source\\repos\\Lap5Cosodulieu\\Lap5Cosodulieu\\bin\\Debug\\Dependents.txt");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IList<Dependent> a = db.Query(delegate (Dependent b)
            {
                return true;
            });
            string d = "";
            for (int i = 0; i < a.Count; i++){
                Dependent c = (Dependent)a[i];
                Employee f = c.DependentOf;
                if (f!= null)
                {
                    d += c.DependentOf.Ssn;
                d += ":";
                }

            }
            MessageBox.Show(d);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
