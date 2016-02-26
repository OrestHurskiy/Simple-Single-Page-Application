using System;


namespace CoreValueContacts.Services.Services.HelperClasses
{
    public class OperationResult<TEntity> : OperationResult
    {
        public OperationResult(bool isSuccess) : base(isSuccess) { }

        public TEntity Entity { get; set; }
    }
}
