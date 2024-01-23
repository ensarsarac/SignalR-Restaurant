﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDtoLayer.MessageDto
{
	public class ResultMessageDto
	{
		public int MessageID { get; set; }
		public string NameSurname { get; set; }
		public string Mail { get; set; }
		public string PhoneNumber { get; set; }
		public string Subject { get; set; }
		public string MessageContent { get; set; }
		public DateTime Date { get; set; }
		public bool Status { get; set; }
	}
}
