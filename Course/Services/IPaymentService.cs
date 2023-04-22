
namespace Course.Services
{
    internal interface IPaymentService
    {
        double PaymentFee(double amount);
        double Interest(double amount, int months);
    }
}
