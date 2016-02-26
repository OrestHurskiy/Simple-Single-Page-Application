using System;


namespace CoreValueContacts.Services.Services.HelperClasses
{
    public class OperationResult
    {
        public OperationResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; set; }
    }
}
