using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDtoLayer.ContactDto
{
    public class CreateContactDto
    {
		public string Location { get; set; }
		public string PhoneNumber { get; set; }
		public string Mail { get; set; }
		public string FooterTitle { get; set; }
		public string FooterDescription { get; set; }
		public string OpenHoursTitle { get; set; }
		public string OpenHoursDescription { get; set; }
		public string OpenHours { get; set; }
		public string CloseHours { get; set; }
	}
}
