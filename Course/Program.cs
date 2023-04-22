using Course.Entities;
using Course.Services;
using System.Globalization;

namespace Aulas
{
    class Aulas
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double totalValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract contract = new Contract(number, date, totalValue);
            ContractService contractService = new ContractService(new PayPalPaymentService());
            contractService.ProcessContract(contract, months);

            Console.WriteLine("Installments:");
            foreach (Installment installment in contract.Installments)
            {
                Console.WriteLine(installment.DueDate.ToString("dd/MM/yyyy") + " - " + installment.Amount.ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}
