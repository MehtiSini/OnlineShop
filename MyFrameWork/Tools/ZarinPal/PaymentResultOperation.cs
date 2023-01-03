namespace MyFramework.Tools.Authentication
{
    public class PaymentResultOperation
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public string IssueTrackingNo { get; set; }

        public PaymentResultOperation Succeeded(string message, string issueTrackingNo)
        {
            IsSuccessful = true;
            Message = message;
            IssueTrackingNo = issueTrackingNo;
            return this;
        }

        public PaymentResultOperation Failed(string message)
        {
            Message = message;
            IsSuccessful = false;
            return this;
        }
    }
}