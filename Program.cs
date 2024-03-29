﻿//All the library used for this project
using System;
using System.IO; //File Input and Output Libray
using System.Collections.Generic; //List and Dictionary library for data collection and manupulation
using System.Text.RegularExpressions; //Regular Expression library to Check for input validation
using System.Runtime.Serialization.Formatters.Binary; //Serialization Library to serialize and deserialize data 
using System.Linq; //Linq Library for querying data

namespace Staff_Management_System
{

    using System;
    using System.ComponentModel.DataAnnotations; //C# library to validate email address

    [Serializable]

    //Customer Class
    class Customer
    {
        //Defininig fields
        protected string customerFirstName;
        protected string customerLastName;
        protected string customerPhoneNumber;
        private string emailAddress;

        //setter function
        public void setCustomerDetails(string customerFirstName, string customerLastName,
            string phoneNumber, string emailAddress)
        {
            this.customerFirstName = customerFirstName;
            this.customerLastName = customerLastName;
            this.customerPhoneNumber = phoneNumber;
            this.emailAddress = emailAddress;
        }

        //Getter function
        public string getCustomerFirstName()
        {
            return this.customerFirstName;
        }

        public string getCustomerLastName()
        {
            return this.customerLastName;
        }

        public string getCustomerPhoneNumber()
        {
            return this.customerPhoneNumber;
        }

        //displaying all the customer data
        public string displayCustomerDetail()
        {
            string customerDetails = "";

            customerDetails += "First Name: " + this.customerFirstName + "\n";
            customerDetails += "Last Name: " + this.customerLastName + "\n";
            customerDetails += "Phone Number: " + this.customerPhoneNumber + "\n";
            customerDetails += "Email Address: " + this.emailAddress + "\n";

            customerDetails += "\n---------------------------------------------------\n";

            return customerDetails;

        }

        //Searching for Customer class from List and Retrive back the location of class in the customer List
        public (int, bool) getCustomerRecord(List<Customer> customerList, string identifyCustomerFirstName,
            string identifyCustomerLastName, string identifyCustomerPhoneNumber)
        {

            int customerObjectIndexNumber = 0;
            bool foundCustomerObj = false;


            for (int i = 0; i < customerList.Count; i++)
            {
                if (identifyCustomerFirstName == customerList[i].getCustomerFirstName() &&
                    identifyCustomerLastName == customerList[i].getCustomerLastName() &&
                    identifyCustomerPhoneNumber == customerList[i].getCustomerPhoneNumber())
                {
                    customerObjectIndexNumber = i;
                    foundCustomerObj = true;
                }
            }


            return (customerObjectIndexNumber, foundCustomerObj);
        }
    }

    [Serializable]

    //Using Inheretance to inherit Customer fields and Methods to Booking Class
    class Booking : Customer
    {
        //Defining fields
        private DateTime bookingDate;
        private string[] typeOfService;
        private double totalPrice;
        private string serviceCompleted;

        //getter methods
        public DateTime getBookingDate()
        {
            return this.bookingDate = bookingDate;
        }

        //setter method
        public void setSeriveCompleted(string serviceCompleted)
        {
            this.serviceCompleted = serviceCompleted;
        }


        public void setBookingDetail(string customerFirstName, string customerLastName,
            string customerPhoneNumber, DateTime bookingDate, string[] typeOfService,
            double totalPrice, string serviceCompleted)
        {
            this.customerFirstName = customerFirstName;
            this.customerLastName = customerLastName;
            this.customerPhoneNumber = customerPhoneNumber;
            this.bookingDate = bookingDate;
            this.typeOfService = typeOfService;
            this.totalPrice = totalPrice;
            this.serviceCompleted = serviceCompleted;
        }


        //A method to display all booking details along with selected services
        public string displayBookingDetails()
        {
            string displayString = "";

            displayString += "First Name: " + this.customerFirstName + "\n";
            displayString += "Last Name: " + this.customerLastName + "\n";
            displayString += "Phone Number: " + this.customerPhoneNumber + "\n\nSelected Services...\n\n";


            foreach (string service in typeOfService)
            {
                displayString += service + "\n";
            }

            displayString += "Total Price: £ " + this.totalPrice + "\n";


            displayString += "\nBooking Date: " + this.bookingDate.ToShortDateString() + "\n";

            displayString += "\nStatus: " + this.serviceCompleted + "\n\n";

            displayString += "\n---------------------------------------------------\n";


            return displayString;
        }



    }

    [Serializable]

    //Defining Staff Class
    class Staff
    {
        //Defining fields
        protected string staffFirstName;
        protected string staffLastName;
        private string phoneNumber;
        private string emailAddress;
        private string address;
        private string gender;
        protected string dateOfBirth;
        private string NInumber;
        public Staff()
        {

        }


        //setter methods
        public void setFirstName(string staffFirstName)
        {
            this.staffFirstName = staffFirstName;
        }
        public void setLastName(string staffLastName)
        {
            this.staffLastName = staffLastName;
        }
        public void setPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }
        public void setEmailAddress(string emailAddress)
        {
            this.emailAddress = emailAddress;
        }
        public void setAddress(string address)
        {
            this.address = address;
        }
        public void setGender(string gender)
        {
            this.gender = gender;
        }
        public void setDob(string dateOfBirth)
        {
            this.dateOfBirth = dateOfBirth;
        }

        public void setNInumber(string NInumber)
        {
            this.NInumber = NInumber;
        }

        public void setStaffDetails(string firstName, string lastName, string phoneNumber,
        string emailAddress, string address, string gender, string dateOfBirth, string NInumber)
        {
            this.staffFirstName = firstName;
            this.staffLastName = lastName;
            this.phoneNumber = phoneNumber;
            this.emailAddress = emailAddress;
            this.address = address;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.NInumber = NInumber;
        }

        //getter method
        public string getFirstName()
        {
            return this.staffFirstName;
        }
        public string getLastName()
        {
            return this.staffLastName;
        }
        public string getDob()
        {
            return this.dateOfBirth;
        }



        //A method to store the all staff details in a file
        public string displayStaffDetails()
        {
            return this.staffFirstName + "," + this.staffLastName + "," +
                this.phoneNumber + "," + this.emailAddress + "," +
                this.address + "," + this.gender + "," +
                this.dateOfBirth + "," + this.NInumber + "\n";
        }

        //A method to display all the staff details in Console
        public string displayStaffRecords()
        {
            string staffRecord = "";

            staffRecord += "First Name: " + this.staffFirstName + "\n";
            staffRecord += "Last Name: " + this.staffLastName + "\n";
            staffRecord += "Phone Number: " + this.phoneNumber + "\n";
            staffRecord += "Email Address: " + this.emailAddress + "\n";
            staffRecord += "Address: " + this.address + "\n";
            staffRecord += "Gender: " + this.gender + "\n";
            staffRecord += "Date of Birth: " + this.dateOfBirth + "\n";
            staffRecord += "National Insurance Number: " + this.NInumber + "\n";

            staffRecord += "\n---------------------------------------------------\n";


            return staffRecord;
        }

        //a function to find staff class from Staff List Object
        public (int, bool) getStaffRecord(List<Staff> staffListObjects, string identifyStaffFirstName,
            string identifyStaffLastName, string identifyStaffDob)
        {

            int staffObjectIndexNumber = 0;
            bool foundStaffObj = false;


            for (int i = 0; i < staffListObjects.Count; i++)
            {
                if (identifyStaffFirstName == staffListObjects[i].getFirstName() &&
                    identifyStaffLastName == staffListObjects[i].getLastName() &&
                    identifyStaffDob == staffListObjects[i].getDob())
                {
                    staffObjectIndexNumber = i;
                    foundStaffObj = true;
                }
            }

            return (staffObjectIndexNumber, foundStaffObj);
        }

        //A function to read staff details from file and store them in a list
        public void storeStaffRecordInList(List<Staff> staffListObjects)
        {
            if (File.Exists("staffDetails.txt"))
            {
                string[] staffDetailsFromFile = File.ReadAllLines("staffDetails.txt");

                //Console.WriteLine("Total Staff Details stored in File: " + staffDetailsFromFile.Length);

                for (int i = 0; i < staffDetailsFromFile.Length; i++)
                {
                    string staffDetailsSeparator = staffDetailsFromFile[i];
                    string[] individualStaffData = staffDetailsSeparator.Split(',');

                    Staff staffObject = new Staff();

                    staffObject.setStaffDetails(individualStaffData[0], individualStaffData[1],
                        individualStaffData[2], individualStaffData[3], individualStaffData[4],
                        individualStaffData[5], individualStaffData[6], individualStaffData[7]);

                    staffListObjects.Add(staffObject);
                }

            }
        }

    }

    [Serializable]
    //Using Inheretance to inherit Staff fields and Methods to StaffJobRecord Class
    class StaffJobRecord : Staff
    {
        //defining fields
        private string JobDescribtion;
        private DateTime workDate;
        private double hoursWorked;
        private double hourlyPay;
        private double payment;


        //setter method
        public void setJobRecord(string staffFirstName, string staffLastName, string dateOfBirth,
            string JobDescribtion, DateTime workDate, double hoursWorked, double hourlyPay, double payment)
        {
            this.staffFirstName = staffFirstName;
            this.staffLastName = staffLastName;
            this.dateOfBirth = dateOfBirth;
            this.JobDescribtion = JobDescribtion;
            this.workDate = workDate;
            this.hoursWorked = hoursWorked;
            this.hourlyPay = hourlyPay;
            this.payment = payment;
        }

        //getter method
        public double getPayment()
        {
            return this.payment = payment;
        }

        public DateTime getWorkDate()
        {
            return this.workDate;
        }

        //A method to display Staff WeekyJob Records
        public string displayStaffWeekyJobRecords()
        {
            string records = "";

            records += "First Name: " + this.staffFirstName + "\n";
            records += "Last Name: " + this.staffLastName + "\n";
            records += "Date of Birth: " + this.dateOfBirth + "\n";
            records += "Job Describtion: " + this.JobDescribtion + "\n";
            records += "Work Date: " + this.workDate.ToShortDateString() + "\n";
            records += "Hours Worked: " + this.hoursWorked + "\n";
            records += "Horly Pay: " + this.hourlyPay + "\n";
            records += "Payment Made: " + this.payment + "\n";

            records += "\n---------------------------------------------------\n";

            return records;
        }

    }

    //Validation class to validate user input
    class Validator
    {
        //A function to validate Integer value

        /*
         * This function below have be adapted/reused from this book
         * C# Programming Yellow Book (9th edition), Rob Miles.
         */
        public int validateIntegerInput(string userInput)
        {
            Console.Write(userInput);

            do
            {

                try
                {
                    userInput = Console.ReadLine();
                    return int.Parse(userInput);
                }
                catch
                {
                    if (userInput == "")
                        Console.Write("This field cannot be empty: ");
                    else
                        Console.Write("Sorry, only Integer value is accepted, please try again: ");
                }

            } while (true);

        }

        //A function to validate Double value

        public double validateDoubleInput(string userInput)
        {
            Console.Write(userInput);

            do
            {
                try
                {
                    userInput = Console.ReadLine();
                    return double.Parse(userInput);
                }
                catch
                {
                    if (userInput == "")
                        Console.Write("This field cannot be empty: ");
                    else
                        Console.Write("Sorry, float number is accepted, please try again: ");
                }

            } while (true);

        }

        //A function to validate empty string

        public string validateStringInput(string stringInput)
        {
            string storeStringInput;
            do
            {
                Console.Write(stringInput);

                storeStringInput = Console.ReadLine();

                if (storeStringInput == "")
                {
                    Console.WriteLine("This field cannot be empty....");
                }

            } while (storeStringInput == "");

            //Trip empty spaces
            storeStringInput.Trim();

            return storeStringInput;
        }


        //A function to validate date with regex pattern
        public string validateDate(string stringInput)
        {
            string dobPattern = @"^\d{2}?(/)?\d{2}?(/)?\d{4}$";


            Regex dobRegex = new Regex(dobPattern);

            string dobString;

            do
            {
                Console.Write(stringInput);

                dobString = Console.ReadLine();

                if (dobString == "")
                {
                    Console.WriteLine("This field cannot be empty....");
                }
                else if (!dobRegex.IsMatch(dobString))
                {
                    Console.WriteLine("Please enter a valid Date like (01/01/2021)....");
                }

            } while (dobString == "" || !dobRegex.IsMatch(dobString));

            return dobString;

        }

        //A function to validate Email with regex pattern
        public string validateEmailAddress(string stringInput)
        {

            string emailString;

            do
            {
                Console.Write(stringInput);

                emailString = Console.ReadLine();

                if (emailString == "")
                {
                    Console.WriteLine("This field cannot be empty....");
                }

                else if (new EmailAddressAttribute().IsValid(emailString) == false)
                {
                    Console.WriteLine("Please enter a valid Email Address....");
                }

                /* new EmailAddressAttribute().IsValid(emailString) is reused from the website below
                 * https://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address
                 */
            } while (emailString == "" || new EmailAddressAttribute().IsValid(emailString) == false);

            return emailString;

        }

        //A function to validate Phone Number with regex pattern
        public string validatePhoneNumber(string stringInput)
        {
            string regPatternPhoneNumber = @"^((\+44)|(0))?\d{4}?\d{6}$";

            Regex rg = new Regex(regPatternPhoneNumber);

            string phoneNumerString;

            do
            {
                Console.Write(stringInput);

                phoneNumerString = Console.ReadLine();

                if (phoneNumerString == "")
                {
                    Console.WriteLine("This field cannot be empty...");
                }
                else if (!rg.IsMatch(phoneNumerString))
                {
                    Console.WriteLine("Please enter a valid UK phone Number...");
                }

            } while (phoneNumerString == "" || !rg.IsMatch(phoneNumerString));

            return phoneNumerString;
        }

        //A function to validate National Insurance Number with regex pattern
        public string validateNationalInsuranceNumber(string stringInput)
        {
            string regPattern = @"^\s*[A-Z]{2}(?:\s*\d\s*){6}[A-Z]?\s*$";

            Regex rg = new Regex(regPattern);

            string NInumberString;

            do
            {
                Console.Write(stringInput);

                NInumberString = Console.ReadLine();

                if (NInumberString == "")
                {
                    Console.WriteLine("This field cannot be empty...");
                }
                else if (!rg.IsMatch(NInumberString))
                {
                    Console.WriteLine("Please enter a valid National Insurance Number like (BG342342A)...");
                }

            } while (NInumberString == "" || !rg.IsMatch(NInumberString));

            return NInumberString;


        }


    }

    [Serializable]

    class Program
    {

        //Get Maximum Login Attempts from Configuration File
        public static int getMaxLoginAttempts(string getInput)
        {
            string[] split = getInput.Split(':');

            int maxAttempts = int.Parse(split[1]);

            return maxAttempts;

        }

        //Read Login Details from Configuration File
        public static (bool, int) readConfigurationFile(string configurationFileName, string userName, string password)
        {

            StreamReader readConfigurationFileData = new StreamReader(configurationFileName);

            string usernameFromFile = readConfigurationFileData.ReadLine();

            string passwordFromFile = readConfigurationFileData.ReadLine();

            int storeMaxAttempts = getMaxLoginAttempts(readConfigurationFileData.ReadLine());

            readConfigurationFileData.Close();

            if (usernameFromFile == userName && passwordFromFile == password)
            {
                return (true, storeMaxAttempts);
            }

            return (false, storeMaxAttempts);
        }

        //Override Configuration File
        public static void OverrideConfigurationFile(Validator validator, string loginDetailsFileName)
        {
            string updatedUsername = validator.validateStringInput("Enter new username: ");
            string updatedPassword = validator.validateStringInput("Enter new password: ");
            int updatedMaximumLoginAttemps = validator.validateIntegerInput("Enter maximum attempts: ");

            StreamWriter updateConfigurationFileData = new StreamWriter(loginDetailsFileName);

            updateConfigurationFileData.WriteLine(updatedUsername);
            updateConfigurationFileData.WriteLine(updatedPassword);
            updateConfigurationFileData.WriteLine("MaximumLoginAttemps:" + updatedMaximumLoginAttemps);


            updateConfigurationFileData.Close();

            Console.WriteLine("\nNew Login Details has been updated successfully!\n");


        }

        //Display Staff Menu for Admin
        public static void displayStaffManagementMenu()
        {
            Console.WriteLine("\n1. Create New Staff Detail");
            Console.WriteLine("2. View all Staffs Details");
            Console.WriteLine("3. Store Staff Job Details");
            Console.WriteLine("4. View all Staff shifts and payments");
            Console.WriteLine("5. Find Total Payment made to Staff");
            Console.WriteLine("6. Find Staff Records Details by date range");
            Console.WriteLine("7. Update Staff Record");
            Console.WriteLine("8. Delete Staff Record");
            Console.WriteLine("9. Update Configuration File");
            Console.WriteLine("0. Exit Program!");
        }

        //Display Customer and Booking menu for Employees
        public static void displayBookingAppointmentManagementMenu()
        {
            Console.WriteLine("\n1. Create New Customer Detail");
            Console.WriteLine("2. View all Customer Details");
            Console.WriteLine("3. Make a Booking for a Customer");
            Console.WriteLine("4. View all Bookings");
            Console.WriteLine("5. View Bookings with date range");
            Console.WriteLine("6. Complete or Cancel Booking");
            Console.WriteLine("7. Add New Service");
            Console.WriteLine("8. View or Delete service");
            Console.WriteLine("0. Exit Program!");

        }

        public static void displayMainMenu()
        {
            Console.WriteLine("\n1. Store Customer Details and manage booking");
            Console.WriteLine("2. Admin Panel - Staff Management");
            Console.WriteLine("0. Exit Program");
        }

        //Loading and Storing Customer Data with Serialization and Deserialization
        public static List<Customer> loadAndSaveCustomerDataToList(string customerRecordFileName,
            List<Customer> customerList, bool serializeData)
        {
            //Checking if we need Serialize to Deserialize first

            //If serializeData is equals to true then Serialize Customer Data
            if (!serializeData)

            {

                BinaryFormatter bfObject_1 = new BinaryFormatter();

                FileStream file_1 = File.Create(customerRecordFileName);

                bfObject_1.Serialize(file_1, customerList);

                file_1.Close();

            }

            //if serializeData is equals to false then Deserialize Customer Data
            else
            {

                BinaryFormatter bf1 = new BinaryFormatter();

                FileStream fileStream_1 = File.OpenRead(customerRecordFileName);

                customerList = (List<Customer>)bf1.Deserialize(fileStream_1);

                fileStream_1.Close();
            }

            return customerList;


        }

        //Loading and Storing Booking Data with Serialization and Deserialization
        public static List<Booking> loadAndSaveBookingDataToList(string bookingRecordsFileName,
            List<Booking> bookingList, bool serializeData)
        {
            //Checking if we need Serialize to Deserialize first

            //If serializeData is equals to true then Serialize Booking Data
            if (!serializeData)

            {

                BinaryFormatter bfObject_2 = new BinaryFormatter();

                FileStream file_2 = File.Create(bookingRecordsFileName);

                bfObject_2.Serialize(file_2, bookingList);

                file_2.Close();

            }

            //if serializeData is equals to false then Deserialize Booking Data
            else
            {

                BinaryFormatter bf2 = new BinaryFormatter();

                FileStream fileStream_2 = File.OpenRead(bookingRecordsFileName);

                bookingList = (List<Booking>)bf2.Deserialize(fileStream_2);

                fileStream_2.Close();
            }

            return bookingList;

        }

        //Loading and Storing Service Data with Serialization and Deserialization
        public static (Dictionary<string, double>, List<string>) loadAndSaveServiceDataToDictionaryAndList(string serviceFilename,
            Dictionary<string, double> serviceDictionary, List<string> serviceTypeKeysList, bool serializeData)
        {
            //Checking if we need Serialize to Deserialize first

            //If serializeData is equals to true then Serialize Service Data
            if (!serializeData)

            {

                BinaryFormatter bf = new BinaryFormatter();

                FileStream file = File.Create(serviceFilename);

                bf.Serialize(file, serviceDictionary);

                file.Close();

            }

            //if serializeData is equals to false then Deserialize Service Data
            else
            {

                BinaryFormatter bf3 = new BinaryFormatter();

                FileStream fileStream_2 = File.OpenRead(serviceFilename);

                serviceDictionary = (Dictionary<string, double>)bf3.Deserialize(fileStream_2);

                serviceTypeKeysList = new List<string>(serviceDictionary.Keys);

                fileStream_2.Close();
            }

            return (serviceDictionary, serviceTypeKeysList);


        }

        //Loading and Storing Staff Data with Serialization and Deserialization
        public static List<Staff> loadAndSaveStaffDataToList(string staffDetailsFileName,
        List<Staff> staffList, bool serializeData)
        {
            //Checking if we need Serialize to Deserialize first

            //If serializeData is equals to true then Serialize Staff Data
            if (!serializeData)

            {

                BinaryFormatter bfObject = new BinaryFormatter();

                FileStream file = File.Create(staffDetailsFileName);

                bfObject.Serialize(file, staffList);

                file.Close();

            }

            //if serializeData is equals to false then Deserialize Staff Data
            else
            {

                BinaryFormatter bf1 = new BinaryFormatter();

                FileStream file1 = File.OpenRead(staffDetailsFileName);

                staffList = (List<Staff>)bf1.Deserialize(file1);

                file1.Close();
            }

            return staffList;


        }

        //Loading and Storing StaffJobRecord Data with Serialization and Deserialization
        public static List<StaffJobRecord> loadAndSaveStaffJobRecordDataToList(string staffJobRecordsFileName,
            List<StaffJobRecord> staffJobRecordList, bool serializeData)
        {
            //Checking if we need Serialize to Deserialize first

            //If serializeData is equals to true then Serialize StaffJobRecord Data
            if (!serializeData)

            {

                BinaryFormatter bfObject = new BinaryFormatter();

                FileStream file = File.Create(staffJobRecordsFileName);

                bfObject.Serialize(file, staffJobRecordList);

                file.Close();

            }

            //if serializeData is equals to false then Deserialize StaffJobRecord Data
            else
            {

                BinaryFormatter bf1 = new BinaryFormatter();

                FileStream file1 = File.OpenRead(staffJobRecordsFileName);

                staffJobRecordList = (List<StaffJobRecord>)bf1.Deserialize(file1);

                file1.Close();
            }

            return staffJobRecordList;


        }

        static void Main()
        {
            //declaring global variables
            int bookingManagementOption = -1;
            int initialOption = -1;

            //Declaring Validator Object
            Validator validator = new Validator();

            //A variable to store configurationFile
            const string configurationFileName = "configurationFile.txt";


            Console.WriteLine("***** Welcome to Saloon Booking Management System *****");

            do
            {
                Console.WriteLine("\nMain Menu...\n");

                displayMainMenu();

                initialOption = validator.validateIntegerInput("\nEnter your option: ");

                Console.WriteLine();

                if (initialOption == 1)
                {
                    Console.WriteLine("\nChoose any option from the menu...\n");

                    //Declaring List and Dictionary for Customer and Booking class
                    List<Customer> customerList = new List<Customer>();
                    List<Booking> bookingList = new List<Booking>();

                    Dictionary<string, double> serviceDictionary = new Dictionary<string, double>();
                    List<string> serviceTypeKeysList = new List<string>(serviceDictionary.Keys);

                    //Declaring Filenames for the customer and booking data
                    const string bookingRecordsFileName = "bookingRecords.dat";
                    const string customerRecordFileName = "customerDetails.dat";
                    const string serviceFilename = "serviceData.dat";

                    //Declaring boolean variables to check if the file exits
                    bool customerDetailsFileNameExists = false;
                    bool bookingRecordsFileNameExists = false;
                    bool serviceFilenameExists = false;

                    //If Files exits then read the the Customer and Booking Data 
                    //then load the data into list and Dictionary

                    if (File.Exists(customerRecordFileName))
                    {
                        customerList = loadAndSaveCustomerDataToList(customerRecordFileName, customerList, true);

                        customerDetailsFileNameExists = true;

                    }

                    if (File.Exists(bookingRecordsFileName))
                    {
                        bookingList = loadAndSaveBookingDataToList(bookingRecordsFileName, bookingList, true);

                        bookingRecordsFileNameExists = true;

                    }

                    if (File.Exists(serviceFilename))
                    {

                        serviceDictionary = loadAndSaveServiceDataToDictionaryAndList(serviceFilename, serviceDictionary,
                                    serviceTypeKeysList, true).Item1;

                        serviceTypeKeysList = loadAndSaveServiceDataToDictionaryAndList(serviceFilename, serviceDictionary,
                                    serviceTypeKeysList, true).Item2;
                        serviceFilenameExists = true;

                    }

                    do
                    {
                        //Initializing Customer and Booking class
                        Customer customerObject = new Customer();
                        Booking bookingObject = new Booking();

                        //display Booking Appointment management Menu
                        displayBookingAppointmentManagementMenu();

                        bookingManagementOption = validator.validateIntegerInput("\nEnter you option: ");

                        Console.WriteLine();

                        switch (bookingManagementOption)
                        {
                            case 1:
                                //Create new Customer Detail
                                Console.WriteLine("\nEnter customre details....\n");

                                string customerFirstName = validator.validateStringInput("Customer First Name: ");

                                string customerLastName = validator.validateStringInput("Customer Last Name: ");

                                string cutomerPhoneNumber = validator.validatePhoneNumber("Customer Phone Number: ");

                                string customerEmailAddress = validator.validateEmailAddress("Customer Email Address: ");

                                //load the customer details into the Customer class
                                customerObject.setCustomerDetails(customerFirstName, customerLastName,
                                    cutomerPhoneNumber, customerEmailAddress);

                                //Add the Class class to the Customer List
                                customerList.Add(customerObject);

                                //Save the list into the file
                                loadAndSaveCustomerDataToList(customerRecordFileName, customerList, false);


                                Console.WriteLine("\nCustomer Details has been successfully recorded!\n");

                                //If this is first time storing Customer Details in file load Customer data in Customer List
                                if (!customerDetailsFileNameExists)
                                {
                                    customerList = loadAndSaveCustomerDataToList(customerRecordFileName, customerList, true);

                                }

                                break;

                            case 2:
                                //View all Customer Records

                                if (customerList.Count > 0)
                                {
                                    foreach (Customer customer in customerList)
                                    {
                                        Console.WriteLine(customer.displayCustomerDetail());
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nSorry, No cutomer data exits, add Customer data to continue!");
                                }


                                break;

                            case 3:
                                //Create new Customer Booking
                                const string serviceCompleted = "Not Complete";

                                //If customer data exits in file then make a new booking
                                Console.WriteLine("\nEnter Register Customer Details to book an appointment...\n");

                                string identifyCustomerFirstName_1 = validator.validateStringInput("Enter Customer First Name: ");
                                string identifyCustomerLastName_1 = validator.validateStringInput("Enter Customer Last Name: ");
                                string identifyCustomerDob_1 = validator.validatePhoneNumber("Enter Customer Phone Number: ");


                                int CustomerObjectIndexNumber_1 = customerObject.getCustomerRecord(customerList, identifyCustomerFirstName_1,
                                identifyCustomerLastName_1, identifyCustomerDob_1).Item1;


                                bool foundCustomerObj_1 = customerObject.getCustomerRecord(customerList, identifyCustomerFirstName_1,
                                identifyCustomerLastName_1, identifyCustomerDob_1).Item2;

                                if (foundCustomerObj_1)
                                {
                                    Console.WriteLine("\nCustomer Record found, please fill the details below...\n");
                                    //Getting booking data
                                    Console.WriteLine("\nPlease enter Booking Details...\n");

                                    string bookingDate_temp = validator.validateDate("Enter booking Date: ");
                                    DateTime bookingDate = DateTime.Parse(bookingDate_temp);


                                    Console.WriteLine("\nViewing all available service types...");

                                    int serviceNumber = -1;
                                    double totalPrice = 0;
                                    int indexNum = 0;
                                    int itemsSelected = 0;

                                    string[] services = new string[serviceTypeKeysList.Count];


                                    do
                                    {
                                        Console.WriteLine();

                                        //displaying all the available services for the user to choose
                                        for (int i = 0; i < serviceTypeKeysList.Count; i++)
                                        {
                                            Console.WriteLine(i + 1 + ". " + serviceTypeKeysList[i] + ": £ " + serviceDictionary[serviceTypeKeysList[i]]);
                                        }

                                        serviceNumber = validator.validateIntegerInput("\nEnter Service number to add service or Press 0 to exit: ");

                                        while (serviceNumber < 0 || serviceNumber > serviceTypeKeysList.Count)
                                        {
                                            Console.WriteLine("Invalid Input, please try again!");
                                            serviceNumber = validator.validateIntegerInput("\nEnter Service number to add service or Press 0 to exit: ");
                                        }

                                        if (serviceNumber > 0)
                                        {
                                            //Finding Services from Service Dictionary and storing it in Booking List
                                            string storeServiceName = serviceTypeKeysList[serviceNumber - 1];

                                            services[indexNum] = storeServiceName + " --- £ " + serviceDictionary[serviceTypeKeysList[serviceNumber - 1]];

                                            totalPrice += serviceDictionary[serviceTypeKeysList[serviceNumber - 1]];

                                            indexNum++;

                                            itemsSelected++;
                                        }

                                    } while (serviceNumber != 0 && itemsSelected < serviceTypeKeysList.Count);


                                    //Storing Booking details in class
                                    bookingObject.setBookingDetail(identifyCustomerFirstName_1, identifyCustomerLastName_1,
                                        identifyCustomerDob_1, bookingDate, services, totalPrice, serviceCompleted);

                                    //Storing Booking class into Booking List
                                    bookingList.Add(bookingObject);

                                    //Storing the list to the file
                                    loadAndSaveBookingDataToList(bookingRecordsFileName, bookingList, false);

                                    //Reading from the file its first time running the file
                                    if (!bookingRecordsFileNameExists)
                                    {
                                        bookingList = loadAndSaveBookingDataToList(bookingRecordsFileName, bookingList, false);

                                    }

                                    Console.WriteLine("\nA new Booking has been successfully made!\n");

                                }
                                else
                                {
                                    Console.WriteLine("No customer Details found!");
                                }

                                break;

                            case 4:
                                //View All Customer Bookings
                                if (bookingList.Count > 0)
                                {
                                    Console.WriteLine("\nDisplaying the nearest Booking appoinments...\n");

                                    /*
                                     * The below line have been adapted/reused from this website for sorting Booking List value in Asending Order
                                     * https://csharp.net-tutorials.com/linq/sorting-data-the-orderby-thenby-methods/
                                     */
                                    List<Booking> bookings = bookingList.OrderBy(Lastestdate => Lastestdate.getBookingDate()).ToList();

                                    foreach (Booking booking in bookings)
                                    {
                                        Console.Write(booking.displayBookingDetails());
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, No booknig records found, add new booking to continue!");
                                }

                                break;

                            case 5:

                                //View All Customer Bookings with Date Range

                                string tempFirstDate = validator.validateStringInput("Enter First Date range: ");
                                string tempSecondDate = validator.validateStringInput("Enter Second Date range: ");

                                DateTime firstDate = DateTime.Parse(tempFirstDate);
                                DateTime secondDate = DateTime.Parse(tempSecondDate);


                                /* The below line have been adapted/reused from this website for data range of Booking
                                 * https://stackoverflow.com/questions/58377344/searching-objects-from-c-sharp-list-between-date-range-performance-oriented
                                 */
                                List<Booking> findCusomerBookingRecord = bookingList.Where(
                                    find => find.getBookingDate() >= firstDate && find.getBookingDate() <= secondDate).ToList();

                                if (bookingList.Count > 0)
                                {
                                    foreach (Booking cutomerBooking in findCusomerBookingRecord)
                                    {
                                        Console.WriteLine(cutomerBooking.displayBookingDetails());
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No Booking found, in this date range!");
                                }



                                break;

                            case 6:

                                //Complete Booking Or Cancel Booking

                                Console.WriteLine("\nEnter Register Customer Details to Complete or Cancel Booking...\n");

                                string identifyCustomerFirstName_2 = validator.validateStringInput("Enter Customer First Name: ");
                                string identifyCustomerLastName_2 = validator.validateStringInput("Enter Customer Last Name: ");
                                string identifyCustomerDob_2 = validator.validatePhoneNumber("Enter Customer Phone Number: ");


                                int BookingObjectIndexNumber_2 = bookingObject.getCustomerRecord(customerList, identifyCustomerFirstName_2,
                                identifyCustomerLastName_2, identifyCustomerDob_2).Item1;


                                bool foundCustomerObj_3 = bookingObject.getCustomerRecord(customerList, identifyCustomerFirstName_2,
                                identifyCustomerLastName_2, identifyCustomerDob_2).Item2;

                                if (foundCustomerObj_3)
                                {
                                    Console.WriteLine("\nWould you like to Complete Booking or Cancel Booking...\n");
                                    Console.WriteLine("1. Complete Booking");
                                    Console.WriteLine("2. Cancel Booking");

                                    int modifyBookingOption = validator.validateIntegerInput("\nEnter Option: ");

                                    if (modifyBookingOption == 1)
                                    {
                                        bookingList[BookingObjectIndexNumber_2].setSeriveCompleted("Completed");
                                        Console.WriteLine("\nBooking has been Completed!");
                                    }

                                    else if (modifyBookingOption == 2)
                                    {
                                        bookingList.RemoveAt(BookingObjectIndexNumber_2);
                                        Console.WriteLine("\nCustomer Booking has been Cancelled!");
                                    }

                                    else
                                    {
                                        Console.WriteLine("Sorry, wrong input!");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("No customer Details found!");
                                }
                                break;

                            case 7:

                                //Creating a new Service
                                string serviceType = validator.validateStringInput("Enter Service Type: ");
                                double servicePrice = validator.validateDoubleInput("Enter Price: ");

                                serviceDictionary[serviceType] = servicePrice;

                                //Save the dictionary and list value to the file
                                loadAndSaveServiceDataToDictionaryAndList(serviceFilename, serviceDictionary, serviceTypeKeysList, false);

                                //Load the file value to the dictionary and list
                                if (serviceFilenameExists)
                                {
                                    serviceDictionary = loadAndSaveServiceDataToDictionaryAndList(serviceFilename, serviceDictionary,
                                    serviceTypeKeysList, true).Item1;

                                    serviceTypeKeysList = loadAndSaveServiceDataToDictionaryAndList(serviceFilename, serviceDictionary,
                                                serviceTypeKeysList, true).Item2;

                                }

                                Console.WriteLine("New Service has been added successfully!");


                                break;
                            case 8:

                                //View or Delete Serivce

                                if (serviceTypeKeysList.Count > 0)
                                {

                                    Console.WriteLine("\nEnter your Option....\n");

                                    Console.WriteLine("1. View All Services");
                                    Console.WriteLine("2. Delete a Service");

                                    int options = validator.validateIntegerInput("\nEnter option: ");

                                    if (options == 1)
                                    {
                                        Console.WriteLine("\nView all the Serivce Types... \n");
                                        for (int i = 0; i < serviceTypeKeysList.Count; i++)
                                        {
                                            Console.WriteLine(i + 1 + ". " + serviceTypeKeysList[i] + ": £ " + serviceDictionary[serviceTypeKeysList[i]]);
                                        }
                                    }

                                    else if (options == 2)
                                    {
                                        Console.WriteLine("\nViewing all available service types...\n");
                                        for (int i = 0; i < serviceTypeKeysList.Count; i++)
                                        {
                                            Console.WriteLine(i + 1 + ". " + serviceTypeKeysList[i] + ": £ " + serviceDictionary[serviceTypeKeysList[i]]);
                                        }

                                        int serviceNumber = validator.validateIntegerInput("\nEnter Service Number to delete: ");

                                        while (serviceNumber < 0 || serviceNumber > serviceTypeKeysList.Count)
                                        {
                                            Console.WriteLine("Invalid Input, please try again!");
                                            serviceNumber = validator.validateIntegerInput("\nEnter Service Number to delete: ");
                                        }


                                        string storeServiceName = serviceTypeKeysList[serviceNumber - 1];

                                        serviceDictionary.Remove(serviceTypeKeysList[serviceNumber - 1]);


                                        Console.WriteLine("\n" + storeServiceName + " removed successfully!");

                                        //Saving the updated value to the file
                                        loadAndSaveServiceDataToDictionaryAndList(serviceFilename, serviceDictionary, serviceTypeKeysList, false);

                                        //load the updated value from the file to the Dictionary and List
                                        if (serviceFilenameExists)
                                        {
                                            serviceDictionary = loadAndSaveServiceDataToDictionaryAndList(serviceFilename, serviceDictionary,
                                            serviceTypeKeysList, true).Item1;

                                            serviceTypeKeysList = loadAndSaveServiceDataToDictionaryAndList(serviceFilename, serviceDictionary,
                                                        serviceTypeKeysList, true).Item2;
                                        }

                                    }

                                    else
                                    {
                                        Console.WriteLine("Invalid Input, Please try again!");
                                    }

                                }


                                else
                                {
                                    Console.WriteLine("No Serivce found!");
                                }
                                break;

                        }
                    } while (bookingManagementOption != 0);

                    Console.WriteLine("\nTaking you Back to the Main Menu...\n");

                }


                else if (initialOption == 2)
                {
                    //declaring varibales
                    string username;
                    string password;
                    int attempts = 0;
                    int maxAttempts = 0;
                    const string staffDetailsFileName = "staffDetails.dat";
                    bool staffDetailsFileNameExists = false;
                    const string staffJobRecordsFileName = "staffJobRecords.dat";
                    bool staffJobRecordsFileNameExists = false;

                    //Declaring Staff List and Staff Job List to store Staff Class and Staff Job Class
                    List<Staff> staffList = new List<Staff>();

                    List<StaffJobRecord> staffJobRecordList = new List<StaffJobRecord>();

                    // If Files exits then read the the Staff and Staff Job Data
                    //then load the data into lists
                    if (File.Exists(staffDetailsFileName))
                    {
                        staffList = loadAndSaveStaffDataToList(staffDetailsFileName, staffList, true);

                        staffDetailsFileNameExists = true;

                    }


                    if (File.Exists(staffJobRecordsFileName))
                    {
                        staffJobRecordList = loadAndSaveStaffJobRecordDataToList(staffJobRecordsFileName, staffJobRecordList, true);

                        staffJobRecordsFileNameExists = true;
                    }

                    bool exitProgam = true;

                    //If configuration file does not exits then attemp the user to input values
                    if (!File.Exists(configurationFileName))
                    {
                        Console.WriteLine("It looks like Configuration File does not exits!\n" +
                            "\nInput username and password to continue... \n");
                        OverrideConfigurationFile(validator, configurationFileName);

                    }


                    if (File.Exists(configurationFileName))
                    {

                        Console.WriteLine("***** Welcome to Staffing Recruitment *****");

                        do
                        {
                            Console.WriteLine("\nPlease login to continue...\n");

                            //Reading values for user login
                            username = validator.validateStringInput("Enter username: ");

                            password = validator.validateStringInput("Enter Password: ");

                            maxAttempts = readConfigurationFile(configurationFileName, username, password).Item2;


                            //Check configuration file with user credentials
                            if (readConfigurationFile(configurationFileName, username, password).Item1)
                            {
                                Console.WriteLine("\nAccess granted!\n");

                                Console.WriteLine("\nChoose any option from staff option below...\n");

                                int staffManagementOptions = -1;


                                do
                                {
                                    //declaring Staff and StaffJobRecord object
                                    Staff newStaffMember = new Staff();
                                    StaffJobRecord staffJobRecordObject = new StaffJobRecord();

                                    //displaying staff Management Menu
                                    displayStaffManagementMenu();

                                    staffManagementOptions = validator.validateIntegerInput("\nEnter option: ");


                                    switch (staffManagementOptions)
                                    {
                                        //Getting Staff Details from the console
                                        case 1:

                                            string firstName, lastName, phoneNumber,
                                            emailAddress, address, dateOfBirth, gender, NInumber;


                                            Console.WriteLine("\nEnter Staff Details to make new Staff Record...\n");

                                            firstName = validator.validateStringInput("Enter first Name: ");


                                            lastName = validator.validateStringInput("Enter last Name: ");

                                            phoneNumber = validator.validatePhoneNumber("Enter Phone Number: ");


                                            emailAddress = validator.validateEmailAddress("Enter email address: ");


                                            address = validator.validateStringInput("Enter home address: ");

                                            gender = validator.validateStringInput("Enter gender: ");

                                            dateOfBirth = validator.validateDate("Enter Date of Birth: ");

                                            NInumber = validator.validateNationalInsuranceNumber("Enter National Insurance number: ");

                                            //load the Staff details into the Staff class
                                            newStaffMember.setStaffDetails(firstName, lastName, phoneNumber,
                                                emailAddress, address, gender, dateOfBirth, NInumber);

                                            //Add the Class class to the Customer List
                                            staffList.Add(newStaffMember);

                                            //Save the list into the file
                                            loadAndSaveStaffDataToList(staffDetailsFileName, staffList, false);


                                            Console.WriteLine("\nStaff Details has been successfully recorded!\n");

                                            //If this is first time storing Staff Details in file load Staff data in Staff List
                                            if (!staffDetailsFileNameExists)
                                            {
                                                staffList = loadAndSaveStaffDataToList(staffDetailsFileName, staffList, true);

                                            }


                                            break;

                                        case 2:

                                            //Displaying all staff records
                                            if (staffList.Count > 0)
                                            {

                                                Console.WriteLine();

                                                foreach (Staff staff in staffList)
                                                {
                                                    Console.WriteLine(staff.displayStaffRecords());
                                                }

                                            }
                                            else
                                            {
                                                Console.WriteLine("\nNo Staff Record is found, add staff records to continue!");
                                            }
                                            break;

                                        case 3:

                                            //Making a Shift for a Staff using staff Details
                                            Console.WriteLine("\nEnter registered Staff Details to book a Job Shift...\n");


                                            string identifyStaffFirstName_3 = validator.validateStringInput("Enter Staff First Name: ");
                                            string identifyStaffLastName_3 = validator.validateStringInput("Enter Staff Last Name: ");
                                            string identifyStaffDob_3 = validator.validateStringInput("Enter Staff Date of Birth: ");


                                            int staffObjectIndexNumber_3 = newStaffMember.getStaffRecord(staffList, identifyStaffFirstName_3,
                                                identifyStaffLastName_3, identifyStaffDob_3).Item1;

                                            bool foundStaffObj_3 = newStaffMember.getStaffRecord(staffList, identifyStaffFirstName_3,
                                                identifyStaffLastName_3, identifyStaffDob_3).Item2;

                                            if (foundStaffObj_3)
                                            {
                                                Console.WriteLine("\nStaff Record found, please fill the details below...\n");

                                                string jobDescribtion = validator.validateStringInput("Enter Job Describtion: ");

                                                string tempStartDate = validator.validateStringInput("Enter Work Date: ");
                                                DateTime workDate = DateTime.Parse(tempStartDate);

                                                double hoursWorked = validator.validateDoubleInput("Enter Hours worked: ");

                                                double hourlyPay = validator.validateDoubleInput("Enter Hourly Pay: ");


                                                double totalPayment = hoursWorked * hourlyPay;

                                                Console.WriteLine("Total payment made to staff: " + totalPayment);

                                                //Storing Staff Job details in StaffJobRecord class
                                                staffJobRecordObject.setJobRecord(identifyStaffFirstName_3, identifyStaffLastName_3,
                                                    identifyStaffDob_3, jobDescribtion, workDate, hoursWorked, hourlyPay, totalPayment);

                                                //Storing StaffJobRecord class into StaffJobRecord List
                                                staffJobRecordList.Add(staffJobRecordObject);

                                                //Storing the list to the file
                                                loadAndSaveStaffJobRecordDataToList(staffJobRecordsFileName, staffJobRecordList, false);

                                                //If this is first time store Staff Job Records in file then run the below command
                                                //To load the data from the binary file to Staff Job Record List
                                                if (!staffJobRecordsFileNameExists)
                                                {
                                                    staffJobRecordList = loadAndSaveStaffJobRecordDataToList(staffJobRecordsFileName,
                                                        staffJobRecordList, true);
                                                }


                                            }
                                            else
                                            {
                                                Console.WriteLine("\nSorry, Staff Record not found, add staff booking to continue!");
                                            }




                                            break;

                                        case 4:
                                            //Display all staff Job Recods Details

                                            if (staffJobRecordList.Count > 0)
                                            {
                                                Console.WriteLine("\nDisplaying Jobs performed by staffs and payments made to them....\n");

                                                foreach (StaffJobRecord staff in staffJobRecordList)
                                                {
                                                    Console.WriteLine(staff.displayStaffWeekyJobRecords());
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nSorry no Staff Job Record found!\n");
                                            }

                                            break;

                                        case 5:

                                            //Total Payment of Made to Staff
                                            if (staffJobRecordList.Count > 0)
                                            {

                                                double totalPaymentMadeToStaff = 0;
                                                bool foundStaffRecord = false;

                                                string identifyStaffFirstName_5 = validator.validateStringInput("Enter Staff First Name: ");
                                                string identifyStaffLastName_5 = validator.validateStringInput("Enter Staff Last Name: ");
                                                string identifyStaffDob_5 = validator.validateStringInput("Enter Staff Date of Birth: ");

                                                Console.WriteLine();

                                                for (int i = 0; i < staffJobRecordList.Count; i++)
                                                {
                                                    if (identifyStaffFirstName_5 == staffJobRecordList[i].getFirstName() &&
                                                        identifyStaffLastName_5 == staffJobRecordList[i].getLastName() &&
                                                        identifyStaffDob_5 == staffJobRecordList[i].getDob())
                                                    {
                                                        Console.WriteLine(staffJobRecordList[i].displayStaffWeekyJobRecords());
                                                        totalPaymentMadeToStaff += staffJobRecordList[i].getPayment();
                                                        foundStaffRecord = true;
                                                    }

                                                }
                                                if (foundStaffRecord)
                                                {
                                                    Console.WriteLine("\nTotal Payment Made to " + identifyStaffFirstName_5 +
                                                       " " + identifyStaffLastName_5 + " : " + totalPaymentMadeToStaff);

                                                }
                                                else
                                                {
                                                    Console.WriteLine("Sorry, No Staff Record found!");
                                                }

                                            }
                                            else
                                            {
                                                Console.WriteLine("\nSorry no Staff Job Record found!\n");
                                            }
                                            break;

                                        case 6:

                                            //Displaying Staff Job Records using date range
                                            if (staffJobRecordList.Count > 0)
                                            {

                                                string tempFirstDate = validator.validateStringInput("Enter First Date range: ");
                                                string tempSecondDate = validator.validateStringInput("Enter Second Date range: ");

                                                DateTime firstDate = DateTime.Parse(tempFirstDate);
                                                DateTime secondDate = DateTime.Parse(tempSecondDate);

                                                /* The below line have been adapted/reused from this website for data range of Staff work dates
                                                 * https://stackoverflow.com/questions/58377344/searching-objects-from-c-sharp-list-between-date-range-performance-oriented
                                                 */
                                                List<StaffJobRecord> findStaffRecord = staffJobRecordList.Where(
                                                    find => find.getWorkDate() >= firstDate && find.getWorkDate() <= secondDate).ToList();

                                                foreach (StaffJobRecord staff in findStaffRecord)
                                                {
                                                    Console.WriteLine(staff.displayStaffWeekyJobRecords());
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nSorry no Staff Job Record found!\n");
                                            }
                                            break;

                                        case 7:

                                            //Updating Staff Records
                                            Console.WriteLine("\nPlease Enter Staff Details to Update Details...\n");

                                            string identifyStaffFirstName_7 = validator.validateStringInput("Enter Staff First Name: ");
                                            string identifyStaffLastName_7 = validator.validateStringInput("Enter Staff Last Name: ");
                                            string identifyStaffDob_7 = validator.validateStringInput("Enter Staff Date of Birth: ");


                                            int staffObjectIndexNumber_7 = newStaffMember.getStaffRecord(staffList, identifyStaffFirstName_7,
                                                identifyStaffLastName_7, identifyStaffDob_7).Item1;

                                            bool foundStaffObj_7 = newStaffMember.getStaffRecord(staffList, identifyStaffFirstName_7,
                                                identifyStaffLastName_7, identifyStaffDob_7).Item2;


                                            if (foundStaffObj_7)
                                            {
                                                Console.WriteLine("\nStaff Record found, please continue...\n");
                                                string updatedFirstName, updatedLastName, updatedPhoneNumber,
                                                updatedEmailAddress, updatedAddress, updatedDateOfBirth,
                                                updatedGender, updatedNInumber;


                                                Console.WriteLine("\nShowing selected Staff Record details....\n");

                                                Console.WriteLine(staffList[staffObjectIndexNumber_7].displayStaffDetails());

                                                int choice = 0;


                                                Console.WriteLine("\nSelect Any option to update Staff Record...\n");

                                                Console.WriteLine("1. Update First Name");
                                                Console.WriteLine("2. Update Last Name");
                                                Console.WriteLine("3. Update Phone Number");
                                                Console.WriteLine("4. Update Email Address");
                                                Console.WriteLine("5. Update Address");
                                                Console.WriteLine("6. Update Gender");
                                                Console.WriteLine("7. Update Date of Birth");
                                                Console.WriteLine("8. Update National Insurance Number\n");

                                                choice = validator.validateIntegerInput("option: ");

                                                while (choice != 1 && choice != 2 && choice != 3 && choice != 4 &&
                                                    choice != 5 && choice != 6 && choice != 7 && choice != 8)
                                                {
                                                    Console.WriteLine("Invalid Input!, please enter enter your option again!");
                                                    choice = validator.validateIntegerInput("option: ");
                                                }

                                                switch (choice)
                                                {
                                                    case 1:

                                                        updatedFirstName = validator.validateStringInput("Enter updated Staff First Name: ");
                                                        staffList[staffObjectIndexNumber_7].setFirstName(updatedFirstName);

                                                        break;

                                                    case 2:

                                                        updatedLastName = validator.validateStringInput("Enter updated Staff Last Name: ");
                                                        staffList[staffObjectIndexNumber_7].setLastName(updatedLastName);

                                                        break;

                                                    case 3:

                                                        updatedPhoneNumber = validator.validatePhoneNumber("Enter updated Phone Number: ");
                                                        staffList[staffObjectIndexNumber_7].setPhoneNumber(updatedPhoneNumber);

                                                        break;

                                                    case 4:

                                                        updatedEmailAddress = validator.validateStringInput("Enter updated Email Address: ");
                                                        staffList[staffObjectIndexNumber_7].setEmailAddress(updatedEmailAddress);

                                                        break;

                                                    case 5:

                                                        updatedAddress = validator.validateEmailAddress("Enter updated Address: ");

                                                        staffList[staffObjectIndexNumber_7].setAddress(updatedAddress);

                                                        break;

                                                    case 6:

                                                        updatedGender = validator.validateStringInput("Enter updated gender: ");
                                                        staffList[staffObjectIndexNumber_7].setGender(updatedGender);

                                                        break;
                                                    case 7:

                                                        updatedDateOfBirth = validator.validateDate("Enter updated Date of Birth: ");

                                                        staffList[staffObjectIndexNumber_7].setDob(updatedDateOfBirth);

                                                        break;
                                                    case 8:

                                                        updatedNInumber = validator.validateNationalInsuranceNumber("Enter updated National Insurance Number: ");

                                                        staffList[staffObjectIndexNumber_7].setNInumber(updatedNInumber);

                                                        break;

                                                }



                                                Console.WriteLine(staffList[staffObjectIndexNumber_7].displayStaffDetails());

                                                //Storing the updated value to the file
                                                loadAndSaveStaffDataToList(staffDetailsFileName, staffList, false);

                                                Console.WriteLine("\nNew Staff Record has been updated successfully!");

                                                //Reading the updated file data
                                                if (!staffDetailsFileNameExists)
                                                {
                                                    staffList = loadAndSaveStaffDataToList(staffDetailsFileName, staffList, true);

                                                }

                                                Console.WriteLine("\nTaking you back to main menu...\n");


                                            }

                                            else
                                            {
                                                Console.WriteLine("\nSorry, Staff Record Not found! ");
                                            }
                                            break;

                                        case 8:

                                            //Deleting staff Records
                                            Console.WriteLine("\nPlease Enter Staff Details to Delete Records...\n");


                                            string indentifyStaffFirstName_8 = validator.validateStringInput("Enter Staff First Name: ");
                                            string identifyStaffLastName_8 = validator.validateStringInput("Enter Staff Last Name: ");
                                            string identifyStaffDob_8 = validator.validateStringInput("Enter Staff Date of Birth: ");


                                            int staffObjectIndexNum_8 = newStaffMember.getStaffRecord(staffList, indentifyStaffFirstName_8,
                                                identifyStaffLastName_8, identifyStaffDob_8).Item1;

                                            bool foundStaffObj_8 = newStaffMember.getStaffRecord(staffList, indentifyStaffFirstName_8,
                                                identifyStaffLastName_8, identifyStaffDob_8).Item2;


                                            if (foundStaffObj_8)
                                            {

                                                Console.WriteLine("\nShowing selected Staff Record...\n");

                                                Console.WriteLine(staffList[staffObjectIndexNum_8].displayStaffDetails());

                                                string removeStaffRecord = validator.validateStringInput("Are you sure," +
                                                    " you want to delete the selected Staff Record (y/n): ");

                                                if (removeStaffRecord == "y")
                                                {


                                                    staffList.RemoveAt(staffObjectIndexNum_8);

                                                    //Save the lastest Staff List
                                                    loadAndSaveStaffDataToList(staffDetailsFileName, staffList, false);

                                                    Console.WriteLine("\nAbove Staff Record has been deleted successfully! ");

                                                    //Read the lastest Staff Records to Staff List
                                                    if (!staffDetailsFileNameExists)
                                                    {
                                                        staffList = loadAndSaveStaffDataToList(staffDetailsFileName, staffList, true);

                                                    }


                                                }
                                                else if (removeStaffRecord == "n")
                                                {
                                                    Console.WriteLine("\nCancelled Deletion of Staff Record!\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\nWrong Input!\n");
                                                }


                                            }

                                            else
                                            {
                                                Console.WriteLine("Sorry, Staff Record Not found! ");
                                            }

                                            break;

                                        case 9:

                                            //Updating Configuration file

                                            username = validator.validateStringInput("Enter username: ");

                                            password = validator.validateStringInput("Enter Password: ");
                                            //password = Console.ReadLine();


                                            if (readConfigurationFile(configurationFileName, username, password).Item1)
                                            {

                                                OverrideConfigurationFile(validator, configurationFileName);

                                            }
                                            else
                                            {
                                                Console.WriteLine("Sorry, username and password does not match!");
                                            }

                                            break;
                                        case 0:
                                            break;
                                        default:
                                            Console.WriteLine("Invalid Input, Please try again!");
                                            break;


                                    }


                                } while (staffManagementOptions != 0);

                                exitProgam = false;

                                Console.WriteLine("\nTaking you Back to the Main Menu...\n");

                            }
                            else
                            {
                                Console.WriteLine("\nUsername or Password doesn't match, Try again!");
                                attempts++;
                                Console.WriteLine("\nLogin Attempt number: " + attempts);

                                //Check for number to wrong input credentials
                                if (attempts == maxAttempts)
                                {
                                    Console.WriteLine("\nSorry your maximum login attemps is breached!\n");
                                    exitProgam = false;

                                    Console.WriteLine("Closing Program...!");
                                    Console.ReadKey();

                                    System.Environment.Exit(0);


                                }
                            }

                        } while (exitProgam);


                    }

                    else
                    {
                        Console.WriteLine("Cannot Procced Login file doesn't exits!");
                    }

                }

                else if (initialOption != 0)
                {
                    Console.WriteLine("\nSorry, Invalid Input!");
                }

            } while (initialOption != 0);

            Console.WriteLine("\nClosing Program...");

            Console.ReadKey();

        }
    }
}
