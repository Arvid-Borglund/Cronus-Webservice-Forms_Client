using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CronusFormsClient
{
    public partial class CronusForm : Form
    {
        public CronusForm()
        {
            InitializeComponent();
            RunCronusApp();
        }
        CronusWebService proxy = new CronusWebService();

        private async Task<string> WaitForInput()
        {
            var tcs = new TaskCompletionSource<string>();

            EventHandler onClick = null;
            onClick = (s, e) =>
            {
                string input = txtBoxInput.Text.Trim();
                txtBoxInput.Clear();
                txtBoxInput.Focus();
                tcs.SetResult(input);
                btnSubmit.Click -= onClick;
            };

            btnSubmit.Click += onClick;

            return await tcs.Task;
        }


        private void TxtBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit.PerformClick();
            }
        }


        private void BtnSubmit_Click(object sender, EventArgs e)
        {

        }


        private void DisplayOutput(string output)
        {
            txtBoxData.AppendText(output);
            txtBoxData.SelectionStart = txtBoxData.Text.Length;
            txtBoxData.ScrollToCaret();
        }

        private async Task RunCronusApp()
        {
            DisplayOutput("Welcome to the Cronus CRUD employee application!" + Environment.NewLine);
            DisplayOutput(Environment.NewLine);

            bool quit = false;
            
            while (!quit)
            {
                DisplayOutput("Select an option" + Environment.NewLine);
                DisplayOutput("1. Create an employee" + Environment.NewLine);
                DisplayOutput("2. Read an employee" + Environment.NewLine);
                DisplayOutput("3. Update an employee" + Environment.NewLine);
                DisplayOutput("4. Delete an employee" + Environment.NewLine);
                DisplayOutput("5. Get the primary key constraints" + Environment.NewLine);
                DisplayOutput("6. Get all the column names" + Environment.NewLine);
                DisplayOutput("7. Get the total number of tables" + Environment.NewLine);
                DisplayOutput("8. Get the total number of columns" + Environment.NewLine);
                DisplayOutput("9. Quit" + Environment.NewLine);
                DisplayOutput(Environment.NewLine);

                string option = await WaitForInput();

                bool isOptionValid = (option == "1" || option == "2" || option == "3" || option == "4" || option == "5" || option == "6" || option == "7" || option == "8" || option == "9");


                if (isOptionValid)
                {

                    switch (option)
                    {
                        case "1":
                            DisplayOutput("Enter the employee's ID" + Environment.NewLine);
                            string empId = await WaitForInput();
                            DisplayOutput("Enter the employee's first name" + Environment.NewLine);
                            string firstName = await WaitForInput();
                            DisplayOutput("Enter the employee's last name" + Environment.NewLine);
                            string lastName = await WaitForInput();
                            DisplayOutput("Enter the employee's city" + Environment.NewLine);
                            string city = await WaitForInput();
                            DisplayOutput("Enter the employee's phone number" + Environment.NewLine);
                            string phoneNumber = await WaitForInput();
                            DisplayOutput("Enter the employee's job title" + Environment.NewLine);
                            string jobTitle = await WaitForInput();
                            List<MyKeyValuePairCronus> EmployeeData = new List<MyKeyValuePairCronus>
                            {
                                    new MyKeyValuePairCronus("EmpId", empId),
                                    new MyKeyValuePairCronus("FirstName", firstName),
                                    new MyKeyValuePairCronus("LastName", lastName),
                                    new MyKeyValuePairCronus("JobTitle", jobTitle),
                                    new MyKeyValuePairCronus("City", city),
                                    new MyKeyValuePairCronus("PhoneNo",phoneNumber)
                            };
                            
                            if (proxy.GetEmployeeById(empId) != "Employee not found.")
                            {
                                DisplayOutput("Employee already exists" + Environment.NewLine);
                                DisplayOutput(Environment.NewLine);
                                continue;
                            }
                            else
                            {
                                String createResult = proxy.CreateEmployee(EmployeeData.Select(x => (KeyValuePairCronus)x).ToArray());
                                DisplayOutput(Environment.NewLine);
                                DisplayOutput(createResult + Environment.NewLine);
                                DisplayOutput(Environment.NewLine);
                                continue;
                            }

                        case "2":
                            DisplayOutput("Enter the ID of the employee you want to read" + Environment.NewLine);
                            string readEmpId = await WaitForInput();
                            proxy.GetEmployeeById(readEmpId);
                            String readResult = proxy.GetEmployeeById(readEmpId);
                            DisplayOutput(readResult + Environment.NewLine);
                            DisplayOutput(Environment.NewLine);
                            continue;

                        case "3":
                            DisplayOutput("Enter the ID of the employee you want to update" + Environment.NewLine);
                            string updateEmpId = await WaitForInput();
                            DisplayOutput("Enter the (updated) employee first name" + Environment.NewLine);
                            string updateFirstName = await WaitForInput();
                            DisplayOutput("Enter the (updated) employee last name" + Environment.NewLine);
                            string updateLastName = await WaitForInput();
                            DisplayOutput("Enter the (updated) employee city" + Environment.NewLine);
                            string updateCity = await WaitForInput();
                            DisplayOutput("Enter the (updated) employee phone number" + Environment.NewLine);
                            string updatePhoneNumber = await WaitForInput();
                            DisplayOutput("Enter the (updated) employee job title" + Environment.NewLine);
                            string updateJobTitle = await WaitForInput();
                            List<MyKeyValuePairCronus> updateCustomerData = new List<MyKeyValuePairCronus>
                            {
                                    new MyKeyValuePairCronus("EmpId", updateEmpId),
                                    new MyKeyValuePairCronus("FirstName", updateFirstName),
                                    new MyKeyValuePairCronus("LastName", updateLastName),
                                    new MyKeyValuePairCronus("JobTitle", updateJobTitle),
                                    new MyKeyValuePairCronus("City", updateCity),
                                    new MyKeyValuePairCronus("PhoneNo",updatePhoneNumber)
                            };
                            if (proxy.GetEmployeeById(updateEmpId) == "Employee not found.")
                            {
                                DisplayOutput("Employee does not exist" + Environment.NewLine);
                                DisplayOutput(Environment.NewLine);
                                continue;
                            }
                            else
                            {
                                String updateResult = proxy.UpdateEmployee(updateCustomerData.Select(x => (KeyValuePairCronus)x).ToArray());
                                DisplayOutput(Environment.NewLine);
                                DisplayOutput(updateResult + Environment.NewLine);
                                DisplayOutput(Environment.NewLine);
                                continue;
                            }

                        case "4":
                            DisplayOutput("Enter the ID of the employee you want to delete" + Environment.NewLine);
                            string deleteEmpId = await WaitForInput();
                            String deleteResult = proxy.DeleteEmployee(deleteEmpId);
                            DisplayOutput(Environment.NewLine);
                            DisplayOutput(deleteResult + Environment.NewLine);
                            DisplayOutput(Environment.NewLine);
                            continue;
                      
                        case "5":
                            DisplayOutput("Primary key constraints" + Environment.NewLine);
                            string[] primaryKeyConstraints = proxy.GetPrimaryKeyConstraintNames();
                            string primaryKeyResult = "";
                            foreach (string primaryKeyConstraint in primaryKeyConstraints)
                            {
                                primaryKeyResult += primaryKeyConstraint + "\r\n";
                            }
                            if (!string.IsNullOrEmpty(primaryKeyResult))
                            {
                                DisplayOutput(primaryKeyResult + Environment.NewLine);
                            }
                            else {
                                DisplayOutput("No primary key constraints" + Environment.NewLine);
                            }
                            DisplayOutput(Environment.NewLine);
                            DisplayOutput(proxy.GetServerError());
                            continue;
                            
                        case "6":
                            DisplayOutput("All the column names" + Environment.NewLine);
                            string[] tableNames = proxy.GetAllColumnNames();
                            string result = "";
                            foreach (string tableName in tableNames)
                            {
                                result += tableName + "\r\n";
                            }
                            DisplayOutput(result + Environment.NewLine);
                            DisplayOutput(Environment.NewLine);
                            continue;

                        case "7":
                            DisplayOutput("Total number of tables" + Environment.NewLine);
                            String totalTablesResult = proxy.GetTotalTables();
                            DisplayOutput(totalTablesResult + Environment.NewLine);
                            DisplayOutput(Environment.NewLine);
                            continue;

                        case "8":
                            DisplayOutput("Total number of columns" + Environment.NewLine);
                            String totalColumnsResult = proxy.GetTotalColumns();
                            DisplayOutput(totalColumnsResult + Environment.NewLine);
                            DisplayOutput(Environment.NewLine);
                            continue;

                        case "9":                            
                            this.Close();
                            continue;
                    }
                    
                }
                else
                {
                    DisplayOutput("Invalid option, try again" + Environment.NewLine);
                    continue;
                }
            }
        }
    }
}
