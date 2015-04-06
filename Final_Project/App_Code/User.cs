using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project
{
  public class User
  {
    // Fields
    private string firstName;
    private string lastName;
    private string userType;
    private int empID;
    private bool isVietnamese;

    // Constructors
    public User()
    {
      firstName = "First";
      lastName = "Last";
      userType = "regular";
      empID = 1;
      isVietnamese = false;
    }

    public Person(string FirstName, string LastName, string UserType,
                  int EmpID, bool IsVietnamese)
    {
      firstName = FirstName;
      lastName = LastName;
      userType = UserType;
      empID = EmpID;
      isVietnamese = IsVietnamese;
    }

    // Get Methods
    public string getFirstName()
    {
      return firstName;
    }

    public string getLastName()
    {
      return lastName;
    }

    public string getUserType()
    {
      return userType;
    }

    public int getEmpID()
    {
      return empID;
    }

    public bool getIsVietnamese()
    {
      return isVietnamese;
    }

    // Set Methods
    public void setFirstName(string FirstName)
    {
      firstName = FirstName;
    }

    public void setLastName(string LastName)
    {
      lastName = LastName;
    }

    public void setUserType(string UserType)
    {
      userType = UserType;
    }

    public void setEmpID(int EmpID)
    {
      empID = EmpID;
    }

    public void setIsVietnamese(bool IsVietnamese)
    {
      isVietnamese = IsVietnamese;
    }
  }
}
