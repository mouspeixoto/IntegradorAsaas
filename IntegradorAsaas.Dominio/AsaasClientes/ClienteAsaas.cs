using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorAsaas.Dominio.AsaasClientes
{
    public class ClienteAsaas
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string? Id { get; set; }

        //[JsonProperty("dateCreated", NullValueHandling = NullValueHandling.Ignore)]
        //public DateTime DateCreated { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string? Email { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string? Phone { get; set; }

        [JsonProperty("mobilePhone", NullValueHandling = NullValueHandling.Ignore)]
        public string? MobilePhone { get; set; }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string? Address { get; set; }

        [JsonProperty("addressNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string? AddressNumber { get; set; }

        [JsonProperty("complement", NullValueHandling = NullValueHandling.Ignore)]
        public string? Complement { get; set; }

        [JsonProperty("province", NullValueHandling = NullValueHandling.Ignore)]
        public string? Province { get; set; }

        [JsonProperty("postalCode", NullValueHandling = NullValueHandling.Ignore)]
        public string? PostalCode { get; set; }

        [JsonProperty("cpfCnpj", NullValueHandling = NullValueHandling.Ignore)]
        public string? CpfCnpj { get; set; }

        [JsonProperty("personType", NullValueHandling = NullValueHandling.Ignore)]
        public string? PersonType { get; set; }

        [JsonProperty("deleted", NullValueHandling = NullValueHandling.Ignore)]
        public bool Deleted { get; set; }

        [JsonProperty("additionalEmails", NullValueHandling = NullValueHandling.Ignore)]
        public string? AdditionalEmails { get; set; }

        [JsonProperty("externalReference", NullValueHandling = NullValueHandling.Ignore)]
        public string? ExternalReference { get; set; }

        [JsonProperty("notificationDisabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool NotificationDisabled { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public int City { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string? State { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string? Country { get; set; }

        [JsonProperty("observations", NullValueHandling = NullValueHandling.Ignore)]
        public string? Observations { get; set; }
    }
}
