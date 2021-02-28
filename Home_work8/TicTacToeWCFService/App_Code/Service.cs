using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Реструктуризация" можно использовать для одновременного изменения имени класса "Service" в коде, SVC-файле и файле конфигурации.
public class Service : IService
{
	Random rnd = new Random();

	int Id { get; set; }

	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}

	public int GetValue(int i, int j)
    {
		int[,] matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
		return matrix[i, j];
    }

	public TicTacToeType GetMatrix(TicTacToeType stat)
    {		
		return stat;
    }

	public void SetValue(int i)
	{
        Id = i;
	}

	public int GetId()
    {
		Id = rnd.Next(0, 10);
		return Id;
    }
}
