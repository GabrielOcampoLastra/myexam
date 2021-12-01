using System;
using System.Collections.Generic;
using System.Text;

namespace MyExam.Platform
{
    /// <summary>
    /// Interface for url native implementation
    /// </summary>
    public interface IAppUrl
    {
        /// <summary>
        /// Open activityy for call a number
        /// </summary>
        /// <param name="number"></param>
        void OpenCallPhone(string number);
    }
}
