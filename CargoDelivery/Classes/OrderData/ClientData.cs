﻿using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CargoDelivery.Classes.OrderData
{
	/// <summary>
	/// Class to represent client data.
	/// </summary>
	[Serializable]
	public class ClientData
	{
		/// <summary>
		/// The first name of a client.
		/// </summary>
		[XmlAttribute]
		public string FirstName { get; set; }
		
		/// <summary>
		/// The second name of a client.
		/// </summary>
		[XmlAttribute]
		public string LastName { get; set; }
		
		/// <summary>
		/// An email of the client.
		/// </summary>
		[XmlAttribute]
		public string Email { get; set; }
		
		/// <summary>
		/// Client's phone number.
		/// </summary>
		[XmlAttribute]
		public string PhoneNumber { get; set; }
		
		/// <summary>
		/// Client's address.
		/// </summary>
		public Address Address { get; set; }
		
		/// <summary>
		/// Default constructor is used for xml serialization/deserialization. 
		/// </summary>
		public ClientData()
		{
			Address = new Address();
		}

		/// <summary>
		/// Constructor to set data from multiple parameters.
		/// </summary>
		/// <param name="firstName">The first name of a client.</param>
		/// <param name="lastName">The second name of a client.</param>
		/// <param name="email">An email of the client.</param>
		/// <param name="phoneNumber">Client's phone number.</param>
		/// <param name="clientAddress">An address of a client.</param>
		public ClientData(
			string firstName,
			string lastName,
			string email,
			string phoneNumber,
			Address clientAddress
		)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			PhoneNumber = phoneNumber;
			Address = clientAddress;
		}

		/// <summary>
		/// Constructor creates its object using XmlNode data.
		/// </summary>
		public ClientData(XmlNode source)
		{
			if (source == null)
			{
				throw new NullReferenceException("can't parse ClientData");
			}
			
			if (source.Attributes == null)
			{
				throw new NullReferenceException("can't parse ClientData attributes");
			}

			FirstName = source.Attributes["FirstName"].Value;
			LastName = source.Attributes["LastName"].Value;
			Email = source.Attributes["Email"].Value;
			PhoneNumber = source.Attributes["PhoneNumber"].Value;
			var addressNode = source.SelectSingleNode("Address");
			if (addressNode == null)
			{
				throw new NullReferenceException("can't parse ClientData.Address");
			}

			Address = new Address(addressNode.Attributes);
		}

		/// <summary>
		/// Transfers the ClientData object to XElement.
		/// </summary>
		public XElement ToXml()
		{
			return new XElement("ClientData",
				new XAttribute("FirstName", FirstName),
				new XAttribute("LastName", LastName),
				new XAttribute("Email", Email),
				new XAttribute("PhoneNumber", PhoneNumber),
				Address.ToXml()
			);
		}
	}
}
