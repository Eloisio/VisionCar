using System;
using System.Collections.Generic;
using System.Text;

namespace VisionCar.Infrastructure.CloudServices.Interfaces
{
    public interface IFileStorageService
    {
        void UploadFile(byte[] bytes, string fileName);
    }
}
