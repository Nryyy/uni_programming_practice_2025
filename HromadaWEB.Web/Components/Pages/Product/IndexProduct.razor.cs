using HromadaWEB.Models.Entities;
using HromadaWEB.Models.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace HromadaWEB.Web.Components.Pages.Product
{
    partial class IndexProduct
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public List<ProductModel> ProductModels { get; set; } = new List<ProductModel>();
        protected override async Task OnInitializedAsync()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("api/Product");
            if (res != null && res.IsSuccess)
            {
                ProductModels = JsonConvert.DeserializeObject<List<ProductModel>>(res.Data.ToString());
            }
            await base.OnInitializedAsync();
        }
    }
}
