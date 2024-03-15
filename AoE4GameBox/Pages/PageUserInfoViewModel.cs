using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AoE4GameBox.Pages
{
    public class PageUserInfoViewModel : INotifyPropertyChanged
    {
        private string _playerName;
        private string _playerId;
        private string _playerSteamId;
        public event PropertyChangedEventHandler PropertyChanged;

        public string PlayerName
        {
            get { return _playerName; }
            set
            {
                if (SetProperty(ref _playerName, value))
                {
                    // 在此处可添加在属性更改时需要执行的逻辑
                }
            }
        }
        public string PlayerId
        {
            get { return _playerId; }
            set
            {
                if (SetProperty(ref _playerId, value))
                {
                    // 在此处可添加在属性更改时需要执行的逻辑
                }
            }
        }
        public string PlayerSteamId
        {
            get { return _playerSteamId; }
            set
            {
                if (SetProperty(ref _playerSteamId, value))
                {
                    // 在此处可添加在属性更改时需要执行的逻辑
                }
            }
        }

        public PageUserInfoViewModel()
        {
            PlayerName = "玩家昵称";
            PlayerId = "玩家档案编号 (游戏ID) ";
            PlayerSteamId = "Steam3 ID (64bit DEC) ";
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!(object.Equals(field, newValue)))
            {
                field = (newValue);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }
    }
}