using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project
{
  public class TrainConfirmation
  {
    // Attributes
    private static string trainConfNum = @"";

    private static string BaseMessage = @"";

    // Constructor

    // Behaviors
    private static void createTrainConfirmationMessage(string EmpID)
    {
      BaseMessage = @"";
    }

    // Get Methods
    public string getBaseMessage()
    {
      return BaseMessage;
    }

    // Set Methods
    public void setTrainConfNum(string newConfNum)
    {
      trainConfNum = newConfNum;
    }
  }
}