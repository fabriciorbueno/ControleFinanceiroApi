using System.Text.Json.Serialization;

namespace ControleFinanceiro.Domain.Dtos.Response.Rest
{
    public class CepRestResponse
    {

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("result")]
        public Result Result { get; set; }
    }
    public class Meta
    {
        [JsonPropertyName("currentPage")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("itemsPerPage")]
        public int ItemsPerPage { get; set; }

        [JsonPropertyName("totalOfItems")]
        public int TotalOfItems { get; set; }

        [JsonPropertyName("totalOfPages")]
        public int TotalOfPages { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("complement")]
        public string Complement { get; set; }

        [JsonPropertyName("district")]
        public string District { get; set; }

        [JsonPropertyName("districtId")]
        public int DistrictId { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("cityId")]
        public int CityId { get; set; }

        [JsonPropertyName("ibgeId")]
        public int IbgeId { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("stateShortname")]
        public string StateShortname { get; set; }

        [JsonPropertyName("zipcode")]
        public string Zipcode { get; set; }
    }



    public class CepRestResponseErro
    {

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("result")]
        public ResultErro Result { get; set; }
    }

    public class ResultErro
    {
        [JsonPropertyName("error")]
        public bool Error { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
