using NoviInterviewMiniProject.Models.ViewModels;
using NoviInterviewMiniProject.Repositories;
using System;
using System.Collections.Generic;

namespace NoviInterviewMiniProject.Services
{
    public interface IMemberViewHelper
    {
        List<MemberViewModel> GetViewData(string searchQuery);
    }

    public class MemberViewHelper : IMemberViewHelper
    {
        private readonly IGlobalSettings _globalSettings;
        private readonly INoviApiCaller _noviApiCaller;

        public MemberViewHelper(IGlobalSettings globalSettings, INoviApiCaller noviApiCaller)
        {
            _globalSettings = globalSettings;
            _noviApiCaller = noviApiCaller;
        }

        public List<MemberViewModel> GetViewData(string searchQuery)
        {
            var data = _noviApiCaller.GetData();

            var viewData = data.ConvertAll(m => new MemberViewModel(m));

            return FilterData(viewData, searchQuery);
        }

        private List<MemberViewModel> FilterData(List<MemberViewModel> data, string searchQuery)
        {
            // Filter on given name search query
            if (!string.IsNullOrEmpty(searchQuery))
            {
                foreach (var member in data)
                {
                    if (member.Name.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        member.Visible = true;
                    }
                    else
                    {
                        member.Visible = false;
                    }
                }
            }

            // Always filter out inactive members
            foreach (var member in data)
            {
                if (!member.Active)
                {
                    member.Visible = false;
                }
            }

            return data;
        }
    }
}