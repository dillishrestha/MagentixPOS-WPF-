using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magentix.Services.Common;

namespace Magentix.Services
{
    public interface IDeviceService
    {
        IEnumerable<string> GetDeviceNames(DeviceType deviceType);
        IEnumerable<string> GetDeviceNames();
        void InitializeDevice(string deviceName);
        void FinalizeDevices();
        IDevice GetDeviceByName(string deviceName);
    }
}
