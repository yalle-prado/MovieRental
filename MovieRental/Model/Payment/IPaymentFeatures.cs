namespace MovieRental.Payment;

public interface IPaymentFeatures
{
	Payment Save(Payment payment);

	Payment Cancel (Payment payment, int id);
}