﻿using System.Threading.Tasks;
using OrderApi.Views;
using Xamarin.Forms;

namespace OrderApi.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}