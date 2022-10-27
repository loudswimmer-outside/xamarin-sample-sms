using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinSmsSample.Services
{
    public interface ISmsService
    {
        List<string> ReadSms(string p0);
    }
}
