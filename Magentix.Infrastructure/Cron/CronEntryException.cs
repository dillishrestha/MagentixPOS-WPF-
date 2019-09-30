using System;

namespace Magentix.Infrastructure.Cron
{
    [Serializable]
    public class CronEntryException : Exception
	{
		public CronEntryException(string message)
			: base(message)
		{

		}
	}
}