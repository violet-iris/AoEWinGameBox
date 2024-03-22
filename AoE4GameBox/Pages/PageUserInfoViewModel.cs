using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AoE4GameBox.Pages
{
    public class PageUserInfoViewModel : INotifyPropertyChanged
    {
        private string _name = "Default"; // 玩家名
        private string _profileId = "Default"; // Profile ID
        private string _steamId = "Default"; // Steam ID
        private string _countryArea = "Default"; // 国家或地区
        private string _siteUrl = "Default"; // Profile site
        private string _avatars = "Default"; // 头像
        private string _steamSite = "Default"; // Steam site

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get => _name;
            set
            {
                if (SetProperty(ref _name, value))
                {
                    // 在此处可添加在属性更改时需要执行的逻辑
                }
            }
        }
        public string ProfileId
        {
            get => _profileId;
            set
            {
                if (SetProperty(ref _profileId, value))
                {
                    // 在此处可添加在属性更改时需要执行的逻辑
                }
            }
        }

        public string SteamId
        {
            get => _steamId;
            set
            {
                if (SetProperty(ref _steamId, value))
                {
                    // 在此处可添加在属性更改时需要执行的逻辑
                }
            }
        }

        public string CountryArea
        {
            get => _countryArea;
            set
            {
                if (SetProperty(ref _countryArea, value))
                {
                    // 在此处可添加在属性更改时需要执行的逻辑
                }
            }
        }

        public string SiteUrl
        {
            get => _siteUrl;
            set
            {
                if (SetProperty(ref _siteUrl, value))
                {
                    // 在此处可添加在属性更改时需要执行的逻辑
                }
            }
        }

        public string Avatars
        {
            get => _avatars;
            set
            {
                if (SetProperty(ref _avatars, value))
                {
                    // 在此处可添加在属性更改时需要执行的逻辑
                }
            }
        }

        public string SteamSite
        {
            get => _steamSite;
            set
            {
                if (SetProperty(ref _steamSite, value))
                {
                    // 在此处可添加在属性更改时需要执行的逻辑
                }
            }
        }

        public PageUserInfoViewModel()
        {
            Name = "玩家昵称";
            ProfileId = "玩家档案编号 (游戏ID) ";
            SteamId = "Steam3 ID (64bit DEC) ";
            CountryArea = "账号国家/地区 (位置可能有误) ";
            SiteUrl = "Profile site";
            SteamSite = "Steam site";
            Avatars = "头像";
        }

        private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, newValue)) return false;
            field = (newValue);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}
