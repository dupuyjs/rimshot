using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rimshot.Services
{
    public interface IDialogService
    {
        void DisplayStatus(string message, string title, string buttonText);
        void DisplayError(string errorMessage, string title, string buttonText);
        //void ShowError(Exception error, string title, string buttonText);
    }

}
