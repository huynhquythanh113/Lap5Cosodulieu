using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap5Cosodulieu
{
    public class Database
    {
        public static string DbFileName { get; set; }
        public static IObjectContainer DB => Db4oEmbedded.OpenFile(DbFileName);
        public static void CloseDB(IObjectContainer db) { db.Close(); }

        public static void CreateEmployees(IObjectContainer db, string fileName)
        {
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                StreamReader fin = new StreamReader(fs);
                int nEmps = int.Parse(fin.ReadLine());
                for (int i = 0; i < nEmps; i++)
                {
                    string line = fin.ReadLine();
                    if (line != null)
                    {
                        string[] fields = line.Split(':');
                        string fname = fields[0];
                        char minit = fields[1][0];
                        string lname = fields[2];
                        int ssn = int.Parse(fields[3]);
                        string bdate = fields[4];
                        string address = fields[5];
                        char sex = fields[6][0];
                        float salary = float.Parse(fields[7]);
                        Employee e = new Employee
                        {
                            Ssn = ssn,
                            FName = fname,
                            MInit = minit,
                            LName = lname,
                            Address = address,
                            BirthDate = bdate,
                            Salary = salary,
                            Sex = sex
                        };
                        db.Store(e);
                    }
                }
                fin.Close();
                fs.Close();
            }
        } 
            public static void CreateDependents(IObjectContainer db1, string fileName1)
            {
             
            
            if (File.Exists(fileName1))
                {
              
                FileStream fs = new FileStream(fileName1, FileMode.Open);
                    StreamReader fin = new StreamReader(fs);
                    int nEmps = int.Parse(fin.ReadLine());
                    for (int i = 0; i < nEmps; i++)
                    {
                  
                    string line = fin.ReadLine();
                        if (line != null)
                        {
                            string[] fields = line.Split(',');
                       int sn = int.Parse(fields[0]);
                            string name = fields[1];
                            char sex = fields[2][0];
                            string bdate = fields[3];
                            string rela = fields[4];
                       
                        IList<Employee> a = db1.Query(delegate (Employee b)
                        {
                            return b.Ssn==sn;
                        });
                        Employee dependentof = null;
                        if (a != null && a.Count != 0) {
                              dependentof = (Employee)a[0]; }
                        Dependent e = new Dependent
                            {
                            DependentOf = dependentof,
                            Name = name,
                            Sex = sex,
                            BirthDate = bdate,
                            Relationship = rela
                            };
                            db1.Store(e);
                        }
                    }
                    fin.Close();
                    fs.Close();
                }
            }
        }
    }
