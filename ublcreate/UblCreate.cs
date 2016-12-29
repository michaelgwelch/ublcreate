using System;
using System.Collections.Generic;
using System.Linq;
using UblLarsen.Ubl2;
using UblLarsen.Ubl2.Cac;
using UblLarsen.Ubl2.Udt;

namespace Ubl
{
	public static class UblCreate
	{

		public static CatalogueType Catalogue(IdentifierType catalogIdentifier, DateTime issueDate,
			string providerPartyIdentifier, string receiverPartyIdentifier, string sellerSupplierPartyIdentifier,
			IEnumerable<CatalogueLineType> catalogLines)
		{
			var lines = catalogLines.ToArray();
			return new CatalogueType
			{
				ID = catalogIdentifier,
				IssueDate = issueDate,
				IssueTime = issueDate,
				LineCountNumeric = lines.Length,
				ProviderParty = Party(providerPartyIdentifier),
				ReceiverParty = Party(receiverPartyIdentifier),
				SellerSupplierParty = SupplierParty(Party(sellerSupplierPartyIdentifier)),
				CatalogueLine = lines
			};
		}

		public static CatalogueLineType CatalogueLine(string itemIdentifier, string unitOfMeasure,
			CodeType lifeCycleStatusCode)
		{
			return new CatalogueLineType
			{
				Item = Item(ItemIdentification(itemIdentifier)),
				OrderableUnit = unitOfMeasure,
				LifeCycleStatusCode = lifeCycleStatusCode
			};
		}

		public static IdentifierType Identifier(string value = null, string schemeId = null, string schemeAgencyId = null)
		{
			return new IdentifierType
			{
				Value = value,
				schemeID = schemeId,
				schemeAgencyID = schemeAgencyId
			};
		}

		public static SupplierPartyType SupplierParty(PartyType party = null)
		{
			return new SupplierPartyType
			{
				Party = party
			};
		}

		public static PartyType Party(PartyIdentificationType partyIdentification = null)
		{
			return new PartyType
			{
				PartyIdentification = new[] { partyIdentification }
			};
		}

		public static ItemType Item(ItemIdentificationType sellersItemsIdentification = null)
		{
			return new ItemType
			{
				SellersItemIdentification = sellersItemsIdentification
			};
		}

		public static ItemIdentificationType ItemIdentification(IdentifierType id = null)
		{
			return new ItemIdentificationType
			{
				ID = id
			};
		}

		public static CodeType Code(string value = null)
		{
			return new CodeType
			{
				Value = value
			};
		}
	}


}
