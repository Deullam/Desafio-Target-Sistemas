using Target.Deullam.Challenge.Domain.Features.Distributors;

Console.WriteLine("Cálculo do menor valor, maior valor e média de faturamento!");

List<double> dailyBilling = new List<double>([1000, 2000, 0, 1500, 3000, 500, 0, 0, 4500, 2300, 0, 0, 0, 1300, 1100, 0, 2500, 0, 3200, 1800, 0]);

Distributor distribuitor = new Distributor(dailyBilling);

double minValue = distribuitor.CalculateMinimumBilling();
double maxValue = distribuitor.CalculateMaximumBilling();
double daysAboveAvg = distribuitor.CalculateDaysAboveAverageBilling();

Console.WriteLine($"Menor valor de faturamento: R$ {minValue:F2}");
Console.WriteLine($"Maior valor de faturamento: R$ {maxValue:F2}");
Console.WriteLine($"Número de dias com faturamento acima da média anual: {daysAboveAvg}");
